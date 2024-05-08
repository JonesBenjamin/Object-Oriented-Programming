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

        public override string ToString()
        {
            return $"{this.eventNo},{this.venueID},{this.venue},{this.eventDateTime},{this.record}";
        }

        public void ToFile()
        {
            string csvEventPath = "Event.csv";
            using (StreamWriter writer = new StreamWriter(csvEventPath, append: true))
            {
                writer.WriteLine(this.eventNo + "," + this.venueID + "," + this.venue + "," + this.eventDateTime + "," + this.record);
            }
        }
    }
}
