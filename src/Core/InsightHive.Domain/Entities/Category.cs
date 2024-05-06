namespace InsightHive.Domain.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<SubCategory> SubCategories { get; set; } = new HashSet<SubCategory>();
        public ICollection<Filter> Filters { get; set; } = new HashSet<Filter>();
    }
}
