namespace InsightHive.Domain.Entities
{
    public class SubCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<Business> Businesses { get; set; } = new HashSet<Business>();
    }
}
