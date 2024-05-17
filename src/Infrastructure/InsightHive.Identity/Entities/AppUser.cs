using Microsoft.AspNetCore.Identity;

namespace InsightHive.Identity.Models
{
    public class AppUser : IdentityUser<int>
    {
        public int RoleId { get; set; }
        public string Name { get; set; }

    }
}
