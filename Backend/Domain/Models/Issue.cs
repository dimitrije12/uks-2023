using Microsoft.Extensions.Logging;
using System.Xml.Linq;

namespace Backend.Domain.Models
{
    public class Issue : BaseEntity
    {
        public long MilestoneId { get; set; }
        public Milestone Milestone { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Event> Events { get; set; }
        public ICollection<Reaction> Reactions { get; set; }
    }
}
