using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace DiscussionLibrarySandreth
{
    public class Officer : AppUser // parent or base
    {

        //Property

        public List<Supervises> SupervisorsOfOfficer { get; set; }

        [NotMapped]//do not map to database, dont try to create column
        public List<ServiceRequest> ServiceRequests { get; set; }
        = new List<ServiceRequest>();



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