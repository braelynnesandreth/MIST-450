using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiscussionLibrarySandreth
{
    public class Officer : AppUser // parent or base
    {

        //Property

        public List<Supervises> SupervisorsOfOfficer { get; set; }

        //Methods (actions)

        public Officer () 
        { 
            this.SupervisorsOfOfficer = new List<Supervises> ();
        }
        public Officer(string firstname, string lastname,string phoneNumber,string email, string password) 
            : base(firstname, lastname, phoneNumber, email,password)
        {
            this.SupervisorsOfOfficer = new List<Supervises>();

        }
    }
}