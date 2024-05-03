namespace InsightHive.Application.Interfaces.Infrastructure
{
    internal interface IEmailService
    {
        Task<bool> SendEmailAsync(string email);
    }
}
