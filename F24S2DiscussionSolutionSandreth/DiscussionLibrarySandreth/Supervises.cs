using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiscussionLibrarySandreth
{
    public class Supervises
    {
        //MVC requirement of an ID property (on database, PK)
        //auto-generated
        public int SupervisesId {  get; set; }
        public Officer Officer { get; set; }
        public Supervisor Supervisor { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        
        //DateTime, int, double, bool

        //PK? (OId, SId, StartDateTime) 01, S1, 1/1/2020-12/1/2020
        //01, S2 1/1/2021-12/1/2021
        //01, S1 1/1/2024 - 

        //FK? (OId) (SId)
        //Constructors (MVC) 
        public Supervises()
        {

        }
        public Supervises(Officer officer, Supervisor supervisor, DateTime startDate)
        {
            Officer= officer;
            Supervisor= supervisor;
            StartDate = startDate;
            this.EndDate = null;

        }



    }
}