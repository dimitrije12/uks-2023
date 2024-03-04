using Backend.Domain.Models;

namespace Backend.Dto
{
    public class IssueDTO
    {

        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public string CreatorUsername { get; set; }

        public DateTime CreatedDate { get; set; }

        public List<string> labelNames { get; set; }
        public IssueDTO() { }


        public IssueDTO(Issue issue, List<IssueLabel> issueLabels)
        {
            this.labelNames = new List<string>();
            this.Id = issue.Id;
            this.Title = issue.Title;
            this.Description = issue.Description;
            this.CreatorUsername = issue.Creator.Username;
            this.CreatedDate = issue.CreatedDate;

            foreach (IssueLabel label in issueLabels)
            {
                labelNames.Add(label.Label.Name);
            }
        }
    }
}
