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
            string officerRole = "Officer";
            string supervisorRole = "Supervisor";
            string mechanicRole = "Mechanic";


            //insert all the roles into the database (Roles)
            if (!database.Roles.Any()) {
                IdentityRole role = new IdentityRole(adminRole);
                roleManager.CreateAsync(role).Wait();

                role = new IdentityRole(officerRole);
                roleManager.CreateAsync(role).Wait();

                role = new IdentityRole(supervisorRole);
                roleManager.CreateAsync(role).Wait();

                role = new IdentityRole(mechanicRole);
                roleManager.CreateAsync(role).Wait();
            }
            //2 users
            //first user not in any role

            if (!database.Users.Any())
            {


                AppUser appUser = new AppUser("Test1", "NoRole", "304-000-0001", "Test1.NoRole@test.com", "Test1.NoRole");

                userManager.CreateAsync(appUser).Wait();

                //second user is in admin role
                appUser = new AppUser("Test2", "Admin", "304-000-0002", "Test2.Admin@test.com", "Test2.Admin");

                userManager.CreateAsync(appUser).Wait();
                userManager.AddToRoleAsync(appUser, adminRole).Wait();

                Officer officer = new Officer("Test3", "Officer", "304-000-0003", "Test3.Officer@test.com", "Test3.Officer");

                userManager.CreateAsync(officer).Wait();
                userManager.AddToRoleAsync(officer, officerRole).Wait();

                officer = new Officer("Test4", "Officer", "304-000-0004", "Test4.Officer@test.com", "Test4.Officer");

                userManager.CreateAsync(officer).Wait();
                userManager.AddToRoleAsync(officer, officerRole).Wait();

                Supervisor supervisor = new Supervisor("Test5", "Supervisor", "304-000-0005", "Test5.Supervisor@test.com", "Test5.Supervisor");

                userManager.CreateAsync(supervisor).Wait();
                userManager.AddToRoleAsync(supervisor, supervisorRole).Wait();

                supervisor = new Supervisor("Test6", "Supervisor", "304-000-0006", "Test6.Supervisor@test.com", "Test6.Supervisor");

                userManager.CreateAsync(supervisor).Wait();
                userManager.AddToRoleAsync(supervisor, supervisorRole).Wait();


                //O3, S5 1/1/2020, 12/31/2020
                //O3, S6 1/1/2021, null
                //O4, S6 1/1/2023, 12/31/2023
                //O4, S5 1/1/2024, null
            }
        }
    }
}