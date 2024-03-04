using Microsoft.Extensions.Logging;
using System.Xml.Linq;

namespace Backend.Domain.Models
{
    public class Issue : BaseEntity
    {
        public long? MilestoneId { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public long CreatorId { get; set; }
        public Developer Creator { get; set; }

        public long ProjectId { get; set; }
        public Project Project { get; set; }

        public DateTime CreatedDate { get; set; }

        public ICollection<IssueLabel> IssueLabels { get; set; }

        public ICollection<Developer> Assignees { get; set; }

        public Milestone? Milestone { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Event> Events { get; set; }
        public ICollection<Reaction> Reactions { get; set; }

        public Issue()
        {
        }

        public Issue(long? milestoneId, string title, string description, long creatorId, Developer creator, long projectId, Project project, DateTime createdDate, ICollection<IssueLabel> issueLabels, ICollection<Developer> assignees, Milestone? milestone, ICollection<Comment> comments, ICollection<Event> events, ICollection<Reaction> reactions)
        {
            MilestoneId = milestoneId;
            Title = title;
            Description = description;
            CreatorId = creatorId;
            Creator = creator;
            ProjectId = projectId;
            Project = project;
            CreatedDate = createdDate;
            IssueLabels = issueLabels;
            Assignees = assignees;
            Milestone = milestone;
            Comments = comments;
            Events = events;
            Reactions = reactions;
        }
    }
}
