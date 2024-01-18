﻿using Microsoft.Extensions.Logging;
using System.Xml.Linq;

namespace Backend.Models
{
    public class PullRequest
    {
        public long Id { get; set; }
        public long SourceBranchId { get; set; }
        public Branch SourceBranch { get; set; }
        public long TargetBranchId { get; set; }
        public Branch TargetBranch { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Event> Events { get; set; }
        public ICollection<Reaction> Reactions { get; set; }
    }
}
