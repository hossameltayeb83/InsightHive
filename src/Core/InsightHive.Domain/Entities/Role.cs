using InsightHive.Domain.Enums;

namespace InsightHive.Domain.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public RoleTitle Title { get; set; }
        public ICollection<User> Users { get; set; } = new HashSet<User>();
    }
}
