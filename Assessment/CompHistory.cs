using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment
{
    public class CompHistory
    {
        public string mostRecentWin;
        public int careerWins;
        public string medals;
        public double personalBest;

        public CompHistory()
        {

        }

        public CompHistory(string mostRecentWin, int careerWins, string medals, double personalBest)
        {
            this.mostRecentWin = mostRecentWin;
            this.careerWins = careerWins;
            this.medals = medals;
            this.personalBest = personalBest;
        }

        public override string ToString()
        {
            return $"{this.mostRecentWin},{this.careerWins},{this.medals},{this.personalBest}";
        }

        public void ToFile()
        {

        }
    }
}
