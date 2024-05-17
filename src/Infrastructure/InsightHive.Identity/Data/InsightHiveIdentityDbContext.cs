using InsightHive.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InsightHive.Identity.Data
{
    public class InsightHiveIdentityDbContext : IdentityDbContext<AppUser, IdentityRole<int>, int>
    {
        public InsightHiveIdentityDbContext(DbContextOptions<InsightHiveIdentityDbContext> options) : base(options) { }
        protected InsightHiveIdentityDbContext(DbContextOptions options) : base(options) { }
    }
}
