using InsightHive.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHive.Domain.Entities
{
    public class Review : AuditableEntity
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public float Rate { get; set; }
        public string Image {  get; set; }
        public int BusinessId { get; set; }
        public Business Business { get; set; }
        public int ReviewerId { get; set; }
        public Reviewer Reviewer { get; set; }
        public ICollection<ReviewComment> ReviewComments { get; set; } = new HashSet<ReviewComment>();
        public ICollection<ReviewReaction> ReviewReactions { get; set; } = new HashSet<ReviewReaction>();
    }
}
