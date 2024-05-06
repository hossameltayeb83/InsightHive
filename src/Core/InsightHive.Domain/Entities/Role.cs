using InsightHive.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHive.Domain.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public RoleTitle Title { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
