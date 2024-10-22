using DiscussionLibrarySandreth;
using Microsoft.AspNetCore.Identity;

namespace DiscussionMvcSandreth.Data
{
    public class InitialDatabase
    {
        //2 types of methods
        //object or instance method
        //class / static method
        public static void SeedDatabase(IServiceProvider services)
        {
            //1. Database service
            ApplicationDbContext database = services.GetRequiredService<ApplicationDbContext>();

            //2. AppUser service
            UserManager<AppUser> userManager = services.GetRequiredService<UserManager<AppUser>>();

            //3. Role service
            RoleManager<IdentityRole> roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();


            IdentityRole role = new IdentityRole("Admin");
            roleManager.CreateAsync(role).Wait();
        }
    }
}