using Domain.Entities;
using Domain.Entities.Authentication;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace RestAPI.Controllers
{
    [Authorize]
    [ApiController]
    //[Route("[controller]")]
    [Route("api/[controller]/[action]")]
    public class IssueController : ControllerBase
    {
        public static Issue Issue = new Issue();
        private readonly IConfiguration _configuration;
        private readonly ILogger<IssueController> _logger;
        private readonly IIssueRepository _IssueRepository;

        public IssueController(IConfiguration configuration, ILogger<IssueController> logger, IIssueRepository IssueRepository)
        {
            _configuration = configuration;
            _logger = logger;
            _IssueRepository = IssueRepository;         
        }

        [HttpPost]
        [ActionName("SaveIssue")]
        public IActionResult SaveIssue(Issue issue)
        {
            if (issue != null)
            {
                if (string.IsNullOrEmpty(issue.Id))
                    issue.CreatedOn = DateTime.UtcNow;
                else
                    issue.ModifiedOn = DateTime.UtcNow;

                var id = _IssueRepository.Save(issue);

                return Ok(issue);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [ActionName("GetAllIssues")]
        public IActionResult GetAllIssues()
        {
            var Issues = _IssueRepository.GetAll().Result;
            return Ok(Issues);
        }
    }
}
