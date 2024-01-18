using Microsoft.Extensions.Logging;

namespace Backend.Models
{
    public class Milestone
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public long ProjectId { get; set; }
        public Project Project { get; set; }
        public ICollection<Issue> Issues { get; set; }
        public ICollection<Event> Events { get; set; }
    }
}
