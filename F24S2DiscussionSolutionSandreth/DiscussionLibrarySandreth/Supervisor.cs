using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace DiscussionLibrarySandreth
{
    public class Supervisor : AppUser //parent or base
    {
        public List<Supervises> OfficersSupervised {  get; set; }

        [NotMapped]//do not map to database, dont try to create column
        public List<ServiceRequest> ServiceRequests { get; set; }
        = new List<ServiceRequest>();


        //Constructors
        public Supervisor(string firstName, string lastName, string phoneNumber, string email, string password)
            : base(firstName, lastName, phoneNumber, email, password)
        {
            OfficersSupervised = new List<Supervises>();
        }
        //Buld/compile erros, Runtime errors
        //00 -> Relational DB
        //O R Mapper : Entity Framework

        public Supervisor () 
        {
           OfficersSupervised = new List<Supervises>();
        }
    }
}