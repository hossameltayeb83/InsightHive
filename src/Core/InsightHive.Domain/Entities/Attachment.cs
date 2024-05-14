namespace InsightHive.Domain.Entities
{
    public class Attachment
    {
        public string Image { get; set; }
        public int BusinessId { get; set; }
        public Business Business { get; set; }

    }
}
