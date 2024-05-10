using InsightHive.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHive.Domain.Entities
{
    public class ReviewerBadge : AuditableEntity
    {
       public int ReviewerId { get; set; }
        public int BadgeId { get; set; }
        public Reviewer Reviewer { get; set; }
        public Badge Badge { get; set; }
    }
}
