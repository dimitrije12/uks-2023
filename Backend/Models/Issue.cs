using Microsoft.Extensions.Logging;
using System.Xml.Linq;

namespace Backend.Models
{
    public class Issue
    {
        public long Id { get; set; }
        public long MilestoneId { get; set; }
        public Milestone Milestone { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Event> Events { get; set; }
        public ICollection<Reaction> Reactions { get; set; }
    }
}
