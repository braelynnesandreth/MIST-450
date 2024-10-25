using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiscussionLibrarySandreth
{
    public class Supervisor : AppUser //parent or base
    {

        //Data (properties)
        

        //Actions (methods)

        public Supervisor() { }

        public Supervisor(string firstName, string lastName, string phoneNumber, string email, string password)
            : base(firstName, lastName, phoneNumber, email, password)
        {

        }
    }
}