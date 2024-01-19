using Backend.Domain.Enums;

namespace Backend.Domain.Models
{
    public class Reaction : BaseEntity
    {
        public ReactionType Type { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Event> Events { get; set; }
    }
}
