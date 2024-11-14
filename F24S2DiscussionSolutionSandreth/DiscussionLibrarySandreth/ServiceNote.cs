using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace DiscussionLibrarySandreth
{
    public class ServiceNote
    {
        public int ServiceNoteId    { get; set; }
        public string ServiceNoteDescription {  get; set; }
        public DateTime ServiceNoteDate { get; set; }
        public ServiceRequest ServiceRequest { get; set; }
        public ServiceNote? ServiceNoteRespondedTo { get; set; }

        [NotMapped]
        public List<ServiceNote> ServiceNoteListOfResponses { get; set; }

        public ServiceNote (int serviceNoteId, string serviceNoteDescription, DateTime serviceNoteDate, ServiceRequest serviceRequest, ServiceNote serviceNoteRespondedTo, List<ServiceNote> serviceNoteListOfResponses)
        {
            ServiceNoteId = serviceNoteId;
            ServiceNoteDescription = serviceNoteDescription;
            ServiceNoteDate = serviceNoteDate;
            ServiceRequest = serviceRequest;
            ServiceNoteRespondedTo = serviceNoteRespondedTo;
            ServiceNoteListOfResponses = serviceNoteListOfResponses;
        }
    }
}