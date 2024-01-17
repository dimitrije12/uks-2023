using Backend.Enums;

namespace Backend.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string License { get; set; }
        public Visibility Visibility { get; set; }
        public List<Milestone> Milestones { get; set; }
        public List<Issue> Issues { get; set; }
        public List<PullRequest> PullRequests { get; set; }
        public List<Developer> Developers { get; set; }
    }
}
