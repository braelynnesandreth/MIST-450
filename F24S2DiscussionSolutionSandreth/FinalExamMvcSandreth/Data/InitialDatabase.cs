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

            if (!roleManager.Roles.Any())
            {
                roleManager.CreateAsync(new IdentityRole("Admin")).Wait();
                roleManager.CreateAsync(new IdentityRole("Student")).Wait();
            }

            if (!userManager.Users.Any(u => u.Email == "admin@university.edu"))
            {
                var adminUser = new AppUser("System", "Admin", "555-0123", "admin@university.edu", "Admin123!");
                userManager.CreateAsync(adminUser).Wait();
                userManager.AddToRoleAsync(adminUser, "Admin").Wait();
            }

            if (!database.Courses.Any())
            {
                var courses = new List<Course>
            {
                new Course("CS101", "Introduction to Programming", 3, 30),
                new Course("CS201", "Data Structures", 3, 25),
                new Course("CS301", "Database Systems", 3, 25),
                new Course("CS401", "Software Engineering", 3, 20)
            };

                database.Courses.AddRange(courses);
                database.SaveChanges();

                var cs101 = database.Courses.Single(c => c.CourseNumber == "CS101");
                var cs201 = database.Courses.Single(c => c.CourseNumber == "CS201");
                var cs301 = database.Courses.Single(c => c.CourseNumber == "CS301");
                var cs401 = database.Courses.Single(c => c.CourseNumber == "CS401");

                cs201.RequiredCourses.Add(cs101);
                cs301.RequiredCourses.Add(cs201);
                cs401.RequiredCourses.Add(cs301);

                database.SaveChanges();
            }



            if (!database.Students.Any())
            {
                var students = new List<Student>
            {
                new Student("John", "Doe", "555-0001", "john.doe@university.edu", "Student123!"),
                new Student("Jane", "Smith", "555-0002", "jane.smith@university.edu", "Student123!")
            };

                foreach (var student in students)
                {
                    if (!userManager.Users.Any(u => u.Email == student.Email))
                    {
                        userManager.CreateAsync(student).Wait();
                        userManager.AddToRoleAsync(student, "Student").Wait();
                    }
                }
            }

           
            var currentSemester = "Fall2024";

            if (!database.CourseOfferings.Any())
            {
                var courses = database.Courses.ToList();

                foreach (var course in courses)
                {
                    var offering = new CourseOffering(course, currentSemester, 1, "MWF 10:00-10:50");
                    database.CourseOfferings.Add(offering);
                }

                database.SaveChanges();
            }

            var studentCourses = database.CourseOfferings.ToList();

            foreach (var student in database.Students)
            {
                foreach (var offering in studentCourses)
                {
                    
                    if (!student.Registrations.Any(r => r.CourseOffering.Id == offering.Id && r.Semester == currentSemester))
                    {
                        var register = new Registers(student, offering, currentSemester)
                        {
                            Grade = Registers.LetterGrade.A
                        };

                        student.Registrations.Add(register);
                        offering.Registrations.Add(register);
                    }
                }
            }

            
            database.SaveChanges();
        }
    }
}
