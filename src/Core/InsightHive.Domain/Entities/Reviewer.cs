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
        public string Name { get; set; }
        public int Age { get; set; }
        public string Image {  get; set; }
        public Gender Gender { get; set; }
        public ICollection<Badge> Badges { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<ReviewComment> ReviewComments { get; set; }
        public ICollection<ReviewReaction> ReviewReactions { get; set; }

    }
}
