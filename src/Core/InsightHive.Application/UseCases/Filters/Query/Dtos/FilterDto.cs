namespace InsightHive.Application.UseCases.Filters.Query.Dtos
{
    public class FilterDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<OptionDto> Options { get; set; }
    }
}
