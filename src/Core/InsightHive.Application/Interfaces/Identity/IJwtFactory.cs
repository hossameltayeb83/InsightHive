using InsightHive.Domain.Entities;

namespace InsightHive.Application.Interfaces.Identity
{
    public interface IJwtFactory
    {
        public string GenerateJwt(User user);
    }
}
