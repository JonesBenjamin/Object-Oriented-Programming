using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment
{
    public class Result
    {
        private int placed;
        private double raceTime;
        private Boolean qualified;

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
            string csvResultPath = "Result.csv";
            using (StreamWriter writer = new StreamWriter(csvResultPath, append: true))
            {
                writer.WriteLine(this.placed + "," + this.raceTime + "," + this.qualified);
            }
        }

        public string IsQualified()
        {
            if (this.placed <= 3) {
                qualified = true;
            }
            else
            {
                qualified = false;
            }
            return qualified;
        }
    }
}
