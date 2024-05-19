namespace InsightHive.Application.Responses
{
    public class AuthenticationResponse
    {
        public bool Succeeded { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
