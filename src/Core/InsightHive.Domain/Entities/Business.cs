namespace InsightHive.Domain.Entities
{
    public class Business
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Logo { get; set; }
        public int SubCategoryId { get; set; }
        public SubCategory SubCategory { get; set; }
        public int OwnerId { get; set; }
        public Owner Owner { get; set; }
        public ICollection<Attachment> Attachments { get; set; } = new HashSet<Attachment>();
        public ICollection<Review> Reviews { get; set; } = new HashSet<Review>();
        public ICollection<Option> Options { get; set; } = new HashSet<Option>();

    }
}
