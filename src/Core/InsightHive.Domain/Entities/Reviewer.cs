using InsightHive.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHive.Domain.Entities
{
    public class Reviewer
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public string Image {  get; set; }
        public Gender Gender { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }  
        public ICollection<Badge> Badges { get; set; } = new HashSet<Badge>();
        public ICollection<Review> Reviews { get; set; } = new HashSet<Review>();
        public ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();  
        public ICollection<ReviewReaction> ReviewReactions { get; set; } = new HashSet<ReviewReaction>();

    }
}
