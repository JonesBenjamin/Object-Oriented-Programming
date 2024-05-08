using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace Assessment
{
    public class BreastStroke : Event
    {
        public string eventType;
        public int distance;
        public double winningTime;
        public Boolean newRecord;

        public BreastStroke(int eventNo, int venueID, string venue, string eventDateTime, double record, string eventType, int distance, double winningTime, Boolean newRecord)
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

        public override string ToString()
        {
            return $"{this.eventType},{this.distance},{this.winningTime},{this.newRecord}";
        }

        public void ToFile()
        {
            string csvEventPath = "Event.csv";
            using (StreamWriter writer = new StreamWriter(csvEventPath, append: true))
            {
                writer.WriteLine(this.eventType + "," + this.distance + "," + this.winningTime + "," + this.newRecord);
            }
        }

        public bool IsNewRecord()
        {
            if (winningTime > record) {
                return newRecord = true;
            }
            else
            {
                return newRecord = false;
            }
        }
    }
}
