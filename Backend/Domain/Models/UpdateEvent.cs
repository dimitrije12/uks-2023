namespace Backend.Domain.Models
{
    public class UpdateEvent : Event
    {
        public string FieldName { get; set; }
        public string OldContent { get; set; }
        public string NewContent { get; set; }
    }
}
