using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Assessment
{
    public class Competitor
    {
        public int compNumber;
        public string compName;
        public int compAge;
        public string hometown;
        public BreastStroke compEvent;
        public Result result;
        public CompHistory history;
        public Boolean newPB;

        public Competitor(string compNumber, string compName, string compAge, string hometown, string newPB)
        {
            string compNo = compNumber;
            this.compName = compName;
            string comAge = compAge;
            this.hometown = hometown;
            string pbNew= newPB;
        }


        public override string ToString()
        {
            return $"{this.compNumber},{this.compName},{this.compAge},{this.hometown},{this.compEvent},{this.result},{this.history},{this.newPB}";
        }

        public bool IsNewPB()
        {
            if (result.raceTime < history.personalBest)
            {
                history.personalBest = result.raceTime;
            }
            return history.personalBest;
        }

        public void ToFile()
        {
            string csvCompetitorPath = "Competitor.csv";
            using (StreamWriter writer = new StreamWriter(csvCompetitorPath, append: true))
            {
                writer.WriteLine(this.compNumber + "," + this.compName + "," + this.compAge + "," + this.hometown + "," + this.compEvent + "," + this.result + "," + this.history + "," + this.newPB);
            }
        }

        public int CompareTo(Competitor other)
        {
            return compAge.CompareTo(other.compAge);
        }
    }
}
