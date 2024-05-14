namespace InsightHive.Application.UseCases.Filters.Command.UpdateFilter
{
    public class UpdateFilterDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<UpdateOptionDto> Options { get; set; }
    }
}
