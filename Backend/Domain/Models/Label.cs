using System.Security.Cryptography.X509Certificates;

namespace Backend.Domain.Models
{
    public class Label : BaseEntity
    {

        public string Name { get; set; }
        public string Description { get; set; }

        public string Color { get; set; }

        public ICollection<IssueLabel> IssueLabels { get; set; }


        public Label()
        {

        }

        public Label(string name, string description, string color)
        {
            Name = name;
            Description = description;
            Color = color;
        }
    }
}
