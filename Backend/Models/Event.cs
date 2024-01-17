namespace Backend.Models
{
    public class Event
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public int MilestoneId { get; set; }
        public Milestone Milestone { get; set; }
        public int IssueId { get; set; }
        public Issue Issue { get; set; }
        public int PullRequestId { get; set; }
        public PullRequest PullRequest { get; set; }
        public int ReactionId { get; set; }
        public Reaction Reaction { get; set; }
    }
}
