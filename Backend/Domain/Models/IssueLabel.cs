namespace Backend.Domain.Models
{
    public class IssueLabel
    {

        public long IssueId { get; set; }
        public Issue Issue { get; set; }

        public long LabelId { get; set; }
        public Label Label { get; set; }
    }
}
