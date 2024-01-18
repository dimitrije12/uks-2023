using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace Backend.Models
{
    public class Developer
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Project> StarredProjects { get; set; }
        public ICollection<Issue> AssignedIssues { get; set; }
        public ICollection<Reaction> Reactions { get; set; }
    }
}
