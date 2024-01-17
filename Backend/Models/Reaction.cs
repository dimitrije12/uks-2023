using Backend.Enums;

namespace Backend.Models
{
    public class Reaction
    {
        public int Id { get; set; }
        public ReactionType Type { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Event> Events { get; set; }
    }
}
