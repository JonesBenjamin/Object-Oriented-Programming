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
        private string mostRecentWin;
        private int careerWins;
        private ArrayList medals;
        private double personalBest;

        public CompHistory(string mostRecentWin, int careerWins, ArrayList medals, double personalBest)
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
            string csvHistoryPath = "CompHistory.csv";
            using (StreamWriter writer = new StreamWriter(csvHistoryPath, append: true))
            {
                writer.WriteLine(this.mostRecentWin + "," + this.careerWins + "," + this.medals + "," + this.personalBest);
            }
        }
    }
}
