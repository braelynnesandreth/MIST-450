using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DiscussionLibrarySandreth;

namespace DiscussionMvcSandreth.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        //To migrate a new class to the database, need to add property
        public DbSet<AppUser> AppUser { get; set; }

        public DbSet<Officer> Officer { get; set; }

        public DbSet<Supervisor> Supervisor { get; set; }
        public DbSet<Supervises> Supervises { get; set; }   

        public DbSet<Vehicle> Vehicle { get; set; }
        public DbSet<ServiceRequest> ServiceRequest { get; set; }
        public DbSet<ServiceNote> ServiceNote { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
