using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscussionLibrarySandreth
{
    public class ServiceRequest
    {
        public int ServiceRequestId { get; set; }
        public DateTime DateRequestMade { get; set; }

        public Officer Officer { get; set; }
        public Vehicle Vehicle { get; set; }
        public Supervisor Supervisor { get; set; }
        public string ServiceRequestDescription { get; set; }
        public ServiceRequestStatusOptions ServiceRequestStatus { get; set; } //Pending, Approved, Denied, Completed

        [NotMapped]
        public List<ServiceNote> ServiceNotesForServiceRequest { get; set; }
        public ServiceRequest() { }
        public ServiceRequest(
            //int serviceRequestId,
            //DateTime dateRequestMade,
            Officer officer,
            Vehicle vehicle,
            Supervisor supervisor,
            string serviceRequestDescription
            )
        {
            //ServiceRequestId = serviceRequestId;
            DateRequestMade = DateTime.Now;
            Officer = officer;
            Vehicle = vehicle;
            Supervisor = supervisor;
            ServiceRequestDescription = serviceRequestDescription;
            ServiceRequestStatus = ServiceRequestStatusOptions.Pending;

        }//end constructor
        public ServiceRequest(
            //int serviceRequestId,
            //DateTime dateRequestMade,
            Officer officer,
            Vehicle vehicle,
            //Supervisor supervisor,
            string serviceRequestDescription
            )
        {
            //ServiceRequestId = serviceRequestId;
            DateRequestMade = DateTime.Now;
            Officer = officer;
            Vehicle = vehicle;
            Supervisor = officer.FindCurrentSupervisorOfOfficer();
            ServiceRequestDescription = serviceRequestDescription;
            ServiceRequestStatus = ServiceRequestStatusOptions.Pending;

        }//end constructor

        //belongs to the object or the class itself 
        public static List<ServiceRequest> SearchServiceRequests
            (List<ServiceRequest>
            inputServiceRequests,
           ServiceRequestStatusOptions? inputServiceRequestStatus,
          DateTime? inputStartDateRequestMade,
          DateTime? inputEndDateRequestMade,
          string? inputOfficerEmail)


        {
            List<ServiceRequest> searchResult = inputServiceRequests;

            //Filter based on input search criteria 
            if(inputServiceRequestStatus != null)
            {
                searchResult =
                searchResult.Where(sr => sr.ServiceRequestStatus == inputServiceRequestStatus).ToList();
            }

            if(inputStartDateRequestMade != null)
            {
                searchResult = searchResult.Where(sr => sr.DateRequestMade >= inputStartDateRequestMade).ToList();
            }
            if (inputEndDateRequestMade != null)
            {
                searchResult = searchResult.Where(sr => sr.DateRequestMade <= inputStartDateRequestMade.Value).ToList();
            }
            if (inputOfficerEmail != null)
            {
                searchResult = searchResult.Where(sr => sr.Officer.Email == inputOfficerEmail).ToList();
            }


            return searchResult;

        }
    }//end class

    public enum ServiceRequestStatusOptions
    {
        Pending, Approved, Denied, Completed
    }

}//end namespace

           

