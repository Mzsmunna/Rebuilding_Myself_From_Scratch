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

                _IssueRepository.Save(issue);

                return Ok(issue);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [ActionName("GetAllIssue")]
        public IActionResult GetAllIssue()
        {
            var Issues = _IssueRepository.GetAll().Result;
            return Ok(Issues);
        }

        [HttpGet]
        [ActionName("GetAllIssues")]
        public IActionResult GetAllIssues(int currentPage, int pageSize, string sortField, string sortDirection, string searchQueries)
        {
            List<SearchField> queries = null;

            if (!string.IsNullOrEmpty(searchQueries))
            {
                //var config = new JsonSerializerSettings { Error = (se, ev) => { ev.ErrorContext.Handled = true; } };
                //queries = JsonConvert.DeserializeObject<List<SearchField>>(JsonConvert.SerializeObject(searchQueries), config);

                queries = System.Text.Json.JsonSerializer.Deserialize<List<SearchField>>(searchQueries);
            }
                
            var Issues = _IssueRepository.GetAll(currentPage, pageSize, sortField, sortDirection, queries).Result;
            return Ok(Issues);
        }

        [HttpGet]
        [ActionName("GetAllIssuesByAssigner")]
        public IActionResult GetAllIssuesByAssigner(string assignerId)
        {
            var Issues = _IssueRepository.GetAll().Result;
            return Ok(Issues);
        }

        [HttpGet]
        [ActionName("GetAllIssuesByAssigned")]
        public IActionResult GetAllIssuesByAssigned(string assignedId)
        {
            var Issues = _IssueRepository.GetAll().Result;
            return Ok(Issues);
        }
    }
}
