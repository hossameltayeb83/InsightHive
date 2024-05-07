using InsightHive.Domain.Enums;

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
