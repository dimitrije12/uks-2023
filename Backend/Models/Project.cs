using Backend.Enums;

namespace Backend.Models
{
    public class Project
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string License { get; set; }
        public Visibility Visibility { get; set; }
        public ICollection<Milestone> Milestones { get; set; }
        public ICollection<Issue> Issues { get; set; }
        public ICollection<PullRequest> PullRequests { get; set; }
        public ICollection<Developer> Developers { get; set; }
    }
}
