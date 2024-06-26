﻿using InsightHive.Domain.Common;

namespace InsightHive.Domain.Entities
{
    public class Review : AuditableEntity
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public float Rate { get; set; }
        public string Image { get; set; }
        public int BusinessId { get; set; }
        public Business Business { get; set; }
        public int? ReviewerId { get; set; }
        public Reviewer? Reviewer { get; set; }
        public ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();
        public ICollection<ReviewReaction> ReviewReactions { get; set; } = new HashSet<ReviewReaction>();
    }
}
