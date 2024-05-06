using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHive.Domain.Entities
{
    public class Reaction
    {
        public int Id { get; set; }
        public ICollection<ReviewReaction> ReviewReactions { get; set; }
    }
}
