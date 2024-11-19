using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscussionLibrarySandreth
{
    public class ServiceRequest
    {
        public int ServiceRequestId {get; set;}
        public DateTime DateRequestMade { get; set;}

        public Officer Officer {get; set;}
        public Vehicle Vehicle {get; set;}
        public Supervisor Supervisor {get; set;}
        public string ServiceRequestDescription {get; set;}
        public DateTime DateAssignedToMechanic { get; set; }
        public DateTime? DaterequestedCompleted { get; set; }
        public string DecisionStatus { get; set; }
        public string RepairNote { get; set; }
        public DateTime? RepairNoteDate { get; set; }


        public ServiceRequest () { }
        public ServiceRequest
            (//int serviceRequestId, 
            //DateTime dateRequestMade,
            Officer officer,
            Vehicle vehicle,
            Supervisor supervisor,
            string serviceRequestDescription)
        {
            //ServiceRequestId = serviceRequestId;
            DateRequestMade = DateTime.Now;
            Officer = officer;
            Vehicle = vehicle;
            Supervisor = supervisor;
            ServiceRequestDescription = serviceRequestDescription;
        }
    }
}
