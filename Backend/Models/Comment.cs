using Microsoft.Extensions.Logging;

namespace Backend.Models
{

    public class Comment
    {
        public long Id { get; set; }
        public string Content { get; set; }
        public long IssueId { get; set; }
        public Issue Issue { get; set; }
        public long PullRequestId { get; set; }
        public PullRequest PullRequest { get; set; }
        public long DeveloperId { get; set; }
        public Developer Developer { get; set; }
        public long ReactionId { get; set; }
        public Reaction Reaction { get; set; }
    }

}
