using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace DiscussionLibrarySandreth
{
    //Security: Authentication (Who are you?) ,
    //Authorization (What are you allowed to access? - Role-based authorization)
    public class AppUser : IdentityUser
    {
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
