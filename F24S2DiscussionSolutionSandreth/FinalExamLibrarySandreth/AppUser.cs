using Microsoft.AspNetCore.Identity;

namespace FinalExamLibrarySandreth
{
        public class AppUser : IdentityUser
        {
            //All the subclasses of IdentityUser
            //use Id as its Identifier (as PK in database)
            //string (GUID)
            public string Firstname { get; set; }
            public string Lastname { get; set; }

            //MVC needs an empty constructor: 00 -> Relational (Entity Framework - O R Mapper)
            public AppUser() { }

            public AppUser(string firstname, string lastname, string phoneNumber, string email, string password)
            {
                //this refers to object being constructed
                this.Firstname = firstname;//logical v build errors
                this.Lastname = lastname;
                this.PhoneNumber = phoneNumber;
                this.Email = email;
                this.UserName = email;

                //Hashed password
                //Hashing (password) v Encrypting: Forgot password: Retrieve hashed?
                PasswordHasher<AppUser> passwordHasher = new PasswordHasher<AppUser>();
                this.PasswordHash = passwordHasher.HashPassword(this, password);


            }
        }

    }


