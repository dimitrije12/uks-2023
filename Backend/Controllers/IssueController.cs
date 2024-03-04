using Backend.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssueController : ControllerBase
    {
        private readonly IIssueService _issueService;
        public IssueController(IIssueService issueService)
        {
            _issueService = issueService;
        }

        [HttpGet("issues/{repositoryId}")]
        public async Task<IActionResult> GetIssues(long repositoryId)
        {
            return Ok(await _issueService.GetIssues(repositoryId));
        }


        [HttpGet("issue/{issueId}")]
        public async Task<IActionResult> getIssue(long issueId)
        {
            return Ok(await _issueService.GetIssue(issueId));
        }
    }
}
