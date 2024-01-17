using Microsoft.Extensions.Logging;

namespace Backend.Models
{
    public class Milestone
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public List<Issue> Issues { get; set; }
        public List<Event> Events { get; set; }
    }
}
