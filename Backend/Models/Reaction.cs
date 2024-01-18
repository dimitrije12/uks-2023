using Backend.Enums;

namespace Backend.Models
{
    public class Reaction
    {
        public long Id { get; set; }
        public ReactionType Type { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Event> Events { get; set; }
    }
}
