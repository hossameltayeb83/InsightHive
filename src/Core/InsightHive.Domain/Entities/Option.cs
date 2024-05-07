namespace InsightHive.Domain.Entities
{
    public class Option
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public ICollection<Filter> Filters { get; set; } = new HashSet<Filter>();
    }
}
