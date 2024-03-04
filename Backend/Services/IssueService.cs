using System.Collections.ObjectModel;
using Backend.Domain.Models;
using Backend.Dto;
using Backend.Infrastructure;
using Backend.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services
{
    public class IssueService : IIssueService
    {

        private readonly DatabaseContext _databaseContext;

        public IssueService(DatabaseContext databaseContext)
        {

            _databaseContext = databaseContext;
        }

        public async Task<Issue> GetIssue(long id)
        {
            Issue? issue = await _databaseContext.Issues.FirstOrDefaultAsync(x => x.Id == id);

            return issue;
        }

        public async Task<List<IssueDTO>> GetIssues(long repositoryId)


        {
            List<Issue> issues = _databaseContext.Issues.Where(x => x.ProjectId == repositoryId).Include(i => i.Creator).ToList();
            List<IssueDTO> issuesDTO = new List<IssueDTO>();

            foreach (Issue issue in issues)
            {
                List<IssueLabel> issueLabel = _databaseContext.IssueLabels.Where(x => x.IssueId == issue.Id).Include(i => i.Label).ToList();

                issuesDTO.Add(new IssueDTO(issue, issueLabel));
            }

            return issuesDTO;




        }
    }
}
