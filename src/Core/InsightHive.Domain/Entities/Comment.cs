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

        public int ReviewId { get; set; }
        public Review Review { get; set; }
        public int? ReviewerId { get; set; }
        public Reviewer? Reviewer { get; set; }

    }
}
