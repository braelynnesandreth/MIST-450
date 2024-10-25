using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiscussionLibrarySandreth
{
    public class Officer : AppUser // parent or base
    { 

        //need separate getters and setters;

        //Property

        //Methods (actions)

        public Officer () { }
        public Officer(string firstname, string lastname,string phoneNumber,string email, string password) 
            : base(firstname, lastname, phoneNumber, email,password)
        {

        }
    }
}