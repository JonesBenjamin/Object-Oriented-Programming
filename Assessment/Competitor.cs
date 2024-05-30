using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Assessment
{
    public class Competitor : IComparable<Competitor>
    {
        public int compNumber;
        public string compName;
        public int compAge;
        public string hometown;
        public Boolean newPB;
        public EventTypes compEvent;
        public Result result;
        public CompHistory history;

        public Competitor()
        {

        }

        public Competitor(int compNumber, string compName, int compAge, string hometown, Boolean newPB,
            int eventNo, int venueID, string venue, string eventDateTime, double record, string eventType, int distance, double winningTime, Boolean newRecord,
            int placed, double raceTime, Boolean qualified,
            string mostRecentWin, int careerWins, string medals, double personalBest)
        {
            this.compNumber = compNumber;
            this.compName = compName;
            this.compAge = compAge;
            this.hometown = hometown;
            this.newPB = newPB;

            this.compEvent = new EventTypes();
            this.compEvent.eventNo = eventNo;
            this.compEvent.venueID = venueID;
            this.compEvent.venue = venue;
            this.compEvent.eventDateTime = eventDateTime;
            this.compEvent.record = record;
            this.compEvent.eventType = eventType;
            this.compEvent.distance = distance;
            this.compEvent.winningTime = winningTime;
            this.compEvent.newRecord = newRecord;

            this.result = new Result();
            this.result.placed = placed;
            this.result.raceTime = raceTime;
            this.result.qualified = qualified;

            this.history = new CompHistory();
            this.history.mostRecentWin = mostRecentWin;
            this.history.careerWins = careerWins;
            this.history.medals = medals;
            this.history.personalBest = personalBest;
        }

        public Competitor(string compNo, string compName, string coAge, string hometown, string pbNew,
            string evNo, string venID, string venue, string eventDateTime, string rec, string eventType, string dist, string winTime, string newRec, 
            string place, string racTim, string qual, 
            string mostRecentWin, string carWins, string medallist, string perBest)
        {
            this.compNumber = Convert.ToInt32(compNo);
            this.compName = compName;
            this.compAge = Convert.ToInt32(coAge);
            this.hometown = hometown;
            this.newPB= Convert.ToBoolean(pbNew);

            this.compEvent = new EventTypes();
            this.compEvent.eventNo = Convert.ToInt32(evNo);
            this.compEvent.venueID = Convert.ToInt32(venID);
            this.compEvent.venue = venue;
            this.compEvent.eventDateTime = eventDateTime;
            this.compEvent.record = Convert.ToDouble(rec);
            this.compEvent.eventType = eventType;
            this.compEvent.distance = Convert.ToInt32(dist);
            this.compEvent.winningTime = Convert.ToDouble(winTime);
            this.compEvent.newRecord = Convert.ToBoolean(newRec);

            this.result = new Result();
            this.result.placed = Convert.ToInt32(place);
            this.result.raceTime = Convert.ToDouble(racTim);
            this.result.qualified = Convert.ToBoolean(qual);

            this.history = new CompHistory();
            this.history.mostRecentWin = mostRecentWin;
            this.history.careerWins = Convert.ToInt32(carWins);
            this.history.medals = medallist;
            this.history.personalBest = Convert.ToDouble(perBest);
        }


        public override string ToString()
        {
            return $"{this.compNumber},{this.compName},{this.compAge},{this.hometown},{this.newPB},{this.compEvent},{this.result.placed},{this.result.raceTime},{this.result.qualified},{this.history.mostRecentWin},{this.history.careerWins},{this.history.medals},{this.history.personalBest}";
        }

        
        public bool IsNewPB(double raceTime, double personalBest)
        {
            this.result.raceTime = raceTime;
            this.history.personalBest = personalBest;
            if (this.result.raceTime < this.history.personalBest)
            {
                this.newPB = true;
            } 
            else
            {
                this.newPB = false;
            }
            return this.newPB;
        }

        public void ToFile()
        {
            
        }

        public int CompareTo(Competitor other)
        {
            return compAge.CompareTo(other.compAge);
        }
    }
}
