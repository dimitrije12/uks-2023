namespace Backend.Models
{
    public class Event
    {
        public long Id { get; set; }
        public DateTime Time { get; set; }
        public long MilestoneId { get; set; }
        public Milestone Milestone { get; set; }
        public long IssueId { get; set; }
        public Issue Issue { get; set; }
        public long PullRequestId { get; set; }
        public PullRequest PullRequest { get; set; }
        public long ReactionId { get; set; }
        public Reaction Reaction { get; set; }
    }
}
