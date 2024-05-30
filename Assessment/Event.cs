using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment
{
    public abstract class Event
    {
        public int eventNo { get; set; }
        public int venueID { get; set; }
        public string venue { get; set; }
        public string eventDateTime { get; set; }
        public double record { get; set; }

        public Event()
        {

        }

        public Event(int eventNo, int venueID, string venue, string eventDateTime, double record)
        {
            this.eventNo = eventNo;
            this.venueID = venueID;
            this.venue = venue;
            this.eventDateTime = eventDateTime;
            this.record = record;
        }

        public override string ToString()
        {
            return $"{this.eventNo},{this.venueID},{this.venue},{this.eventDateTime},{this.record}";
        }

        public void ToFile()
        {
            
        }
    }
}
