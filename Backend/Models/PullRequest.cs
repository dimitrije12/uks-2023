using Microsoft.Extensions.Logging;
using System.Xml.Linq;

namespace Backend.Models
{
    public class PullRequest
    {
        public int Id { get; set; }
        public int SourceBranchId { get; set; }
        public Branch SourceBranch { get; set; }
        public int TargetBranchId { get; set; }
        public Branch TargetBranch { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Event> Events { get; set; }
        public List<Reaction> Reactions { get; set; }
    }
}
