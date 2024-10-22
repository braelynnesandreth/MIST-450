using DiscussionLibrarySandreth;
using Microsoft.AspNetCore.Identity;

namespace DiscussionMvcSandreth.Data
{
    //Why Object-orientation?
    //Inheritance: Re-use existing logic / behaviors
    //Componentization - Seperation of responsibilities
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

            string adminRole = "Admin";
            IdentityRole role = new IdentityRole(adminRole);
            roleManager.CreateAsync(role).Wait();

            //2 users
            //first user not in any role
            AppUser appUser = new AppUser("Test1", "NoRole", "304-000-0001", "Test1.NoRole@test.com", "Test1.NoRole");

           userManager.CreateAsync(appUser).Wait();

            //second user is in admin role
            appUser = new AppUser("Test2", "Admin", "304-000-0002", "Test2.Admin@test.com", "Test2.Admin");

            userManager.CreateAsync(appUser).Wait();
            userManager.AddToRoleAsync(appUser, adminRole).Wait();

        }
    }
}