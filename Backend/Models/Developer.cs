using System.Xml.Linq;

namespace Backend.Models
{
    public class Developer
    {
        public int Id { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Project> StarredProjects { get; set; }
        public List<Issue> AssignedIssues { get; set; }
        public List<Reaction> Reactions { get; set; }
    }
}
