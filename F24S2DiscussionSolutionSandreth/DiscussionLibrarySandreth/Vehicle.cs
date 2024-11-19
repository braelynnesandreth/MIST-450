
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace DiscussionLibrarySandreth
{
    public class Vehicle
    {
        public int VehicleId { get; set; }
        public string VIN { get; set; }

        [NotMapped]//do not map to database, dont try to create column
        public List<ServiceRequest> ServiceRequests { get; set; }
        = new List<ServiceRequest>();

        public Vehicle() { }

        public Vehicle(string vin)
        {
            VIN = vin;
        }

        
    }
}