using Microsoft.Extensions.Logging;

namespace Backend.Models
{

    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int IssueId { get; set; }
        public Issue Issue { get; set; }
        public int PullRequestId { get; set; }
        public PullRequest PullRequest { get; set; }
        public int DeveloperId { get; set; }
        public Developer Developer { get; set; }
        public int ReactionId { get; set; }
        public Reaction Reaction { get; set; }
    }

}
