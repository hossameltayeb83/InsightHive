using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHive.Domain.Entities
{
    public class Attachment
    {
        public string Image { get; set; }
        public int BusinessId { get; set; }
        public Business Business { get; set; }

    }
}
