using Backend.Domain.Models;
using Backend.Dto;

namespace Backend.Interfaces
{
    public interface IIssueService
    {

        Task<List<IssueDTO>> GetIssues(long repositoryId);

        Task<Issue> GetIssue(long id);

    }
}
