using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHive.Domain.Entities
{
    public class Option
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int FilterId { get; set; }
        public Filter Filter { get; set; }
        public ICollection<Business> Businesses { get; set; }
    }
}
