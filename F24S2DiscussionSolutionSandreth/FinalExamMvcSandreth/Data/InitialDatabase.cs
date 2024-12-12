using FinalExamLibrarySandreth;
using Microsoft.AspNetCore.Identity;

namespace FinalExamMvcSandreth.Data
{
    public class InitialDatabase
    {
        public static void SeedDatabase(IServiceProvider services)
        {
            //1. Database service
            ApplicationDbContext database = services.GetRequiredService<ApplicationDbContext>();

            //2. AppUser service
            UserManager<AppUser> userManager = services.GetRequiredService<UserManager<AppUser>>();

            //3. Role service
            RoleManager<IdentityRole> roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

        }
    }
}

