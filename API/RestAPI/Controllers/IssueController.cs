using Domain.Entities;
using Domain.Entities.Authentication;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text.Json;
using Utilities;

namespace RestAPI.Controllers
{
    [Authorize]
    [ApiController]
    //[Route("[controller]")]
    [Route("api/[controller]/[action]")]
    public class IssueController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<IssueController> _logger;
        private readonly IIssueRepository _IssueRepository;
        private readonly IUserRepository _userRepository;

        public IssueController(IConfiguration configuration, ILogger<IssueController> logger, IIssueRepository IssueRepository, IUserRepository userRepository)
        {
            _configuration = configuration;
            _logger = logger;
            _IssueRepository = IssueRepository;
            _userRepository = userRepository;
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

                if (!string.IsNullOrEmpty(issue.AssignedId))
                {
                    var user = _userRepository.GetUser(issue.AssignedId).Result;
                    issue.AssignedName = user.FirstName + " " + user.LastName;
                }
                
                _IssueRepository.Save(issue);

                return Ok(issue);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [ActionName("GetAllIssueCount")]
        public IActionResult GetAllIssueCount(string searchQueries)
        {
            List<SearchField> queries = CommonHelperUtility.JsonListDeserialize<SearchField>(searchQueries);
            var Issues = _IssueRepository.GetAllIssueCount(queries).Result;
            return Ok(Issues);
        }

        [HttpGet]
        [ActionName("GetAllIssues")]
        public IActionResult GetAllIssues(int currentPage, int pageSize, string sortField, string sortDirection, string searchQueries)
        {
            List<SearchField> queries = CommonHelperUtility.JsonListDeserialize<SearchField>(searchQueries);
            var Issues = _IssueRepository.GetAllIssues(currentPage, pageSize, sortField, sortDirection, queries).Result;
            return Ok(Issues);
        }

        [HttpGet]
        [ActionName("GetAllIssuesByAssignerCount")]
        public IActionResult GetAllIssuesByAssignerCount(string searchQueries)
        {
            List<SearchField> queries = CommonHelperUtility.JsonListDeserialize<SearchField>(searchQueries);

            if (queries != null && queries.Count > 0 && queries.Any(x => !string.IsNullOrEmpty(x.Key) && x.Key.ToLower().Equals("assignerid")))
            {
                var issueCount = _IssueRepository.GetAllIssueCount(queries);
                return Ok(issueCount);
            }
            else
            {
                return Ok(0);
            }
        }

        [HttpGet]
        [ActionName("GetAllIssuesByAssigner")]
        public IActionResult GetAllIssuesByAssigner(int currentPage, int pageSize, string sortField, string sortDirection, string searchQueries)
        {
            List<SearchField> queries = CommonHelperUtility.JsonListDeserialize<SearchField>(searchQueries);

            if (queries != null && queries.Count > 0 && queries.Any(x => !string.IsNullOrEmpty(x.Key) && x.Key.ToLower().Equals("assignerid")))
            {
                var Issues = _IssueRepository.GetAllIssues(currentPage, pageSize, sortField, sortDirection, queries);
                return Ok(Issues);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [ActionName("GetAllIssuesByAssignedCount")]
        public IActionResult GetAllIssuesByAssignedCount(string searchQueries)
        {
            List<SearchField> queries = CommonHelperUtility.JsonListDeserialize<SearchField>(searchQueries);

            if (queries != null && queries.Count > 0 && queries.Any(x => !string.IsNullOrEmpty(x.Key) && x.Key.ToLower().Equals("assignerid")))
            {
                var issueCount = _IssueRepository.GetAllIssueCount(queries);
                return Ok(issueCount);
            }
            else
            {
                return Ok(0);
            }
        }

        [HttpGet]
        [ActionName("GetAllIssuesByAssigned")]
        public IActionResult GetAllIssuesByAssigned(int currentPage, int pageSize, string sortField, string sortDirection, string searchQueries)
        {
            List<SearchField> queries = CommonHelperUtility.JsonListDeserialize<SearchField>(searchQueries);

            if (queries != null && queries.Count > 0 && queries.Any(x => !string.IsNullOrEmpty(x.Key) && x.Key.ToLower().Equals("assignerid")))
            {
                var Issues = _IssueRepository.GetAllIssues(currentPage, pageSize, sortField, sortDirection, queries);
                return Ok(Issues);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
