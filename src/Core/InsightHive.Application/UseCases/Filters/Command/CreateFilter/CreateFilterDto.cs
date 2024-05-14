namespace InsightHive.Application.UseCases.Filters.Command.CreateFilter
{
    public class CreateFilterDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<CreateOptionDto> Options { get; set; }
    }
}
