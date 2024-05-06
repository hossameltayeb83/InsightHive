namespace InsightHive.Domain.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Category> Categories { get; set;}
        public ICollection<Filter> Filters { get; set;}
    }
}
