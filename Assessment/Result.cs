using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment
{
    public class Result
    {
        public int placed;
        public double raceTime;
        public Boolean qualified;

        public Result()
        {

        }

        public Result(int placed, double raceTime, Boolean qualified)
        {
            this.placed = placed;
            this.raceTime = raceTime;
            this.qualified = qualified;
        }

        public override string ToString()
        {
            return $"{this.placed},{this.raceTime},{this.qualified}";
        }

        public void ToFile()
        {

        }

        public bool IsQualified(int placed)
        {
            this.placed = placed;
            if (this.placed <= 3) {
                this.qualified = true;
            }
            else
            { 
                this.qualified = false;
            }
            return this.qualified;
        }
    }
}
