using InsightHive.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHive.Domain.Entities
{
    public class Comment : AuditableEntity
    {
        public int Id { get; set; }
        public string Content { get; set; }

        public ICollection<ReviewComment> ReviewComments { get; set; } = new HashSet<ReviewComment>();

    }
}
