using InsightHive.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHive.Domain.Entities
{
    public class Badge
    {
        public int Id { get; set; }
        public BadgeName Name { get; set; }
        public string Image { get; set; }
        public ICollection<Reviewer> Reviews { get; set; } = new HashSet<Reviewer>();
    }
}
