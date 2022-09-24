using Domain.Entities;
using Domain.Entities.Authentication;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography;
using Utilities;

namespace RestAPI.Controllers
{
    [ApiController]
    //[Route("[controller]")]
    [Route("api/[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<UserController> _logger;
        private readonly IUserRepository _userRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserController(IConfiguration configuration, ILogger<UserController> logger, IUserRepository userRepository, IHttpContextAccessor httpContextAccessor)
        {
            _configuration = configuration;
            _logger = logger;
            _userRepository = userRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost]
        [ActionName("Register")]
        public IActionResult Register(User user)
        {
            user.IsActive = true;
            var existingUser = _userRepository.RegisterUser(user.Email).Result;

            if (existingUser == null)
            {
                if (string.IsNullOrEmpty(user.Id))
                    user.CreatedOn = DateTime.UtcNow;
                else
                    user.ModifiedOn = DateTime.UtcNow;

                _userRepository.Save(user);

                return Ok(user);
            }
            else
            {
                return StatusCode(StatusCodes.Status409Conflict, "This email already exist");
            }
        }

        [HttpPost]
        [ActionName("Login")]
        public IActionResult Login(User user)
        {
            if (user != null)
            {
                var existingUser = _userRepository.LoginUser(user.Email, user.Password).Result;

                if (existingUser != null)
                {
                    CreatePasswordHash(user.Password, out byte[] passwordHash, out byte[] passwordSalt);

                    user.PasswordHash = passwordHash;
                    user.PasswordSalt = passwordSalt;

                    if (!VerifyPasswordHash(user.Password, user.PasswordHash, user.PasswordSalt))
                    {
                        return StatusCode(StatusCodes.Status403Forbidden, "Wrong credential.");
                    }
                    else
                    {
                        string token = CreateToken(existingUser);
                        var refreshToken = GenerateRefreshToken();
                        SetRefreshToken(refreshToken, existingUser);
                        return Ok(token);
                    }
                }
                else
                {
                    return StatusCode(StatusCodes.Status404NotFound, "User doesn't exist.");
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [ActionName("RefreshToken")]
        public IActionResult RefreshToken(string userId)
        {
            var refreshToken = Request.Cookies["refreshToken"];
            var user = _userRepository.GetUser(userId).Result;

            if (user != null)
            {
                if (!user.RefreshToken.Equals(refreshToken))
                {
                    return Unauthorized("Invalid Refresh Token.");
                }
                else if (user.TokenExpires < DateTime.UtcNow)
                {
                    return Unauthorized("Token expired.");
                }

                string token = CreateToken(user);
                var newRefreshToken = GenerateRefreshToken();
                SetRefreshToken(newRefreshToken, user);

                return Ok(token);
            }
            else
            {
                return NotFound();
            }        
        }

        private RefreshToken GenerateRefreshToken()
        {
            var refreshToken = new RefreshToken
            {
                Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                Expires = DateTime.UtcNow.AddDays(7),
                Created = DateTime.UtcNow
            };

            return refreshToken;
        }

        private void SetRefreshToken(RefreshToken newRefreshToken, User user)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = newRefreshToken.Expires
            };

            Response.Cookies.Append("refreshToken", newRefreshToken.Token, cookieOptions);

            user.RefreshToken = newRefreshToken.Token;
            user.TokenCreated = newRefreshToken.Created;
            user.TokenExpires = newRefreshToken.Expires;
        }

        private string CreateToken(User user)
        {
            var tokenExpiredOn = DateTime.UtcNow.AddDays(1);

            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Email, user.Email.ToLower()),
                new Claim(ClaimTypes.Role, user.Role.ToLower()),
                new Claim(ClaimTypes.Expiration, tokenExpiredOn.ToString())
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetValue<string>("JWTAuthSecretKey")));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: tokenExpiredOn,
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

        [HttpGet, Authorize]
        [ActionName("GetAllUserToAssign")]
        public IActionResult GetAllUserToAssign()
        {
            var users = _userRepository.GetAllUserToAssign();
            return Ok(users);
        }

        [HttpGet, Authorize]
        [ActionName("GetAllUserCount")]
        //[HttpGet(Name = "GetAllUserCount")]
        public IActionResult GetAllUserCount(string searchQueries)
        {
            List<SearchField> queries = CommonHelperUtility.JsonListDeserialize<SearchField>(searchQueries);
            var users = _userRepository.GetAllUserCount(queries).Result;
            return Ok(users);
        }

        [HttpGet, Authorize]
        [ActionName("GetAllUsers")]
        public IActionResult GetAllUsers(int currentPage, int pageSize, string sortField, string sortDirection, string searchQueries)
        {
            List<SearchField> queries = CommonHelperUtility.JsonListDeserialize<SearchField>(searchQueries);
            var users = _userRepository.GetAllUsers(currentPage, pageSize, sortField, sortDirection, queries).Result;
            return Ok(users);
        }

        [HttpGet, Authorize]
        [ActionName("GetUser")]
        public IActionResult GetUser(string userId)
        {
            var users = _userRepository.GetUser(userId).Result;
            users.Password = "?";
            return Ok(users);
        }

        [HttpPost, Authorize]
        [ActionName("SaveUser")]
        public IActionResult SaveUser(User user)
        {
            var users = _userRepository.Save(user);
            return Ok(users);
        }

        [HttpPut, Authorize]
        [ActionName("UpdateUser")]
        public IActionResult UpdateUser(User user)
        {
            var users = _userRepository.Save(user);
            return Ok(users);
        }

        [HttpDelete, Authorize]
        [ActionName("DeleteUser")]
        public IActionResult DeleteUser(string userId)
        {
            var users = _userRepository.DeleteById(userId);
            return Ok(users);
        }

        [Consumes("multipart/form-data")]
        [HttpPost, Authorize]
        [ActionName("SaveMedia")]
        public async Task<IActionResult> SaveMedia(IFormFile file)
        {
            if (!(!string.IsNullOrEmpty(Request.ContentType)
                   && Request.ContentType.IndexOf("multipart/", StringComparison.OrdinalIgnoreCase) >= 0))
            {
                return StatusCode((int)HttpStatusCode.UnsupportedMediaType);
            }

            string newFileName = string.Empty;
            string path = string.Empty;

            //var httpContext = _httpContextAccessor.HttpContext;

            //if (httpContext.Request.Form.Files.Count > 0)
            //{
                //for (int i = 0; i < httpContext.Request.Form.Files.Count; i++)
                //{
                    //IFormFile httpPostedFile = httpContext.Request.Form.Files[i];
                    IFormFile httpPostedFile = file;

                    if (httpPostedFile != null)
                    {
                        var ms = new MemoryStream();
                        await httpPostedFile.CopyToAsync(ms);
                        var bytes = ms.ToArray();

                        var fileName = httpPostedFile.FileName;
                        newFileName = Guid.NewGuid().ToString() + "-" + fileName.Replace("\"", string.Empty);

                        path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"wwwroot/UploadedFiles"));
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }
                        using (var fileStream = new FileStream(Path.Combine(path, newFileName), FileMode.Create))
                        {
                            await httpPostedFile.CopyToAsync(fileStream);
                        }

                        path = @"https://localhost:7074/UploadedFiles/" + newFileName; //Path.Combine(path, newFileName);
                    }
                //}
            //}

            //return Ok(ApplicationConstants.BaseUrl + relPath + provider.FileName);
            //return Ok(ApplicationConstants.BaseUrl + relPath.Replace("wwwroot/", string.Empty) + newFileName);
            return Ok(path);
        }
    }
}
