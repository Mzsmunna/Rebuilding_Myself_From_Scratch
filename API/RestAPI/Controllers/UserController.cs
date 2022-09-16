using Domain.Entities;
using Domain.Entities.Authentication;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
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

        public UserController(IConfiguration configuration, ILogger<UserController> logger, IUserRepository userRepository)
        {
            _configuration = configuration;
            _logger = logger;
            _userRepository = userRepository;         
        }

        [HttpPost]
        [ActionName("Register")]
        public IActionResult Register(User user)
        {
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
                        string token = CreateToken(user);
                        var refreshToken = GenerateRefreshToken();
                        SetRefreshToken(refreshToken, user);
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
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email.ToLower()),
                new Claim(ClaimTypes.Role, user.Role.ToLower())
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetValue<string>("JWTAuthSecretKey")));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddDays(1),
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
        //[HttpGet(Name = "GetAllUsers")]
        public IActionResult GetAllUsers(int currentPage, int pageSize, string sortField, string sortDirection, string searchQueries)
        {
            List<SearchField> queries = CommonHelperUtility.JsonListDeserialize<SearchField>(searchQueries);
            var users = _userRepository.GetAllUsers(currentPage, pageSize, sortField, sortDirection, queries).Result;
            return Ok(users);
        }
    }
}
