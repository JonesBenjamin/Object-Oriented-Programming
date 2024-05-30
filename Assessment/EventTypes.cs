using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace Assessment
{
    public class EventTypes : Event
    {
        public string eventType;
        public int distance;
        public double winningTime;
        public Boolean newRecord;

        public EventTypes()
        {

        }

        public EventTypes(int eventNo, int venueID, string venue, string eventDateTime, double record, string eventType, int distance, double winningTime, Boolean newRecord)
        {
            this.eventNo = eventNo;
            this.venueID = venueID;
            this.venue = venue;
            this.eventDateTime = eventDateTime;
            this.record = record;
            this.eventType = eventType;
            this.distance = distance;
            this.winningTime = winningTime;
            this.newRecord = newRecord;
        }

        public EventTypes(string evNo, string venID, string venue, string eventDateTime, string rec, string eventType, string dist, string winTime, string newRec)
        {
            this.eventNo = Convert.ToInt32(evNo);
            this.venueID = Convert.ToInt32(venID);
            this.venue = venue;
            this.eventDateTime = eventDateTime;
            this.record = Convert.ToDouble(rec);
            this.eventType = eventType;
            this.distance = Convert.ToInt32(dist);
            this.winningTime = Convert.ToDouble(winTime);
            this.newRecord = Convert.ToBoolean(newRec);
        }

        public override string ToString()
        {
            return $"{this.eventNo},{this.venueID},{this.venue},{this.eventDateTime},{this.record},{this.eventType},{this.distance},{this.winningTime},{this.newRecord}";
        }

        public void ToFile()
        {
            
        }

        public bool IsNewRecord(double winningTime, double record)
        {
            this.winningTime = winningTime;
            this.record = record;
            if (this.winningTime < this.record) {
                this.newRecord = true;
            }
            else
            {
                this.newRecord = false;
            }
            return this.newRecord;
        }
    }
}
