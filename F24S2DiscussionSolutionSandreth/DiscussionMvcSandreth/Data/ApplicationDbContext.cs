using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DiscussionLibrarySandreth;

namespace DiscussionMvcSandreth.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<AppUser> AppUser { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
