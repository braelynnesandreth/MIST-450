using System;
using System.Collections.Generic;
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

        
        public Vehicle() { }

        public Vehicle(string vin)
        {
            VIN = vin;
        }
            
    }
}
