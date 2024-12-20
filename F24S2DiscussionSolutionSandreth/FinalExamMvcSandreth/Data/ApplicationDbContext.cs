using FinalExamLibrarySandreth;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FinalExamMvcSandreth.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<AppUser> AppUser { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<CourseOffering> CourseOfferings { get; set; }
        public DbSet<Registers> Registrations { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
