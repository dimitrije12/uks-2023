using Microsoft.Extensions.Logging;
using System.Xml.Linq;

namespace Backend.Models
{
    public class Issue
    {
        public int Id { get; set; }
        public int MilestoneId { get; set; }
        public Milestone Milestone { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Event> Events { get; set; }
        public List<Reaction> Reactions { get; set; }
    }
}
