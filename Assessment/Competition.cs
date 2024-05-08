using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment
{
    public class Competition
    {
        new List<Competitor> competitors;

        public void AddCompetitor(Competitor c)
        {
            string curLine = "";
            string csvCompPath = "Competitors.csv";
            int count = 0;
            Console.WriteLine("What is your name?");
            c.compName = Console.ReadLine();
            Console.WriteLine("What is your age?");
            c.compAge = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("What is your hometown?");
            c.hometown = Console.ReadLine();

            using (StreamReader reader = new StreamReader(csvCompPath))
            {
                reader.ReadLine();
                while ((curLine = reader.ReadLine()) != null) // While not End of File
                {
                    count = count + 1;
                }

                c.compNumber = count;
            }
        }

        public void RemoveCompetitor(Competitor c)
        {
            string csvCompPath = "Competitor.csv";
            int remove = Convert.ToInt32(Console.ReadLine());
            remove = remove - 1;
            c.RemoveAt(remove);
            System.IO.File.WriteAllText(csvCompPath, string.Empty);
            using (StreamWriter writer = new StreamWriter(csvCompPath, append: true))
            {
                writer.WriteLine();
                for (int i = 0; i < c.Count; i++)
                {
                    writer.WriteLine($"{c[i].ToString()}");
                }
            }
        }

        public void ClearAll()
        {
            string csvCompetitorPath = "Competitor.csv";
            System.IO.File.WriteAllText(csvCompetitorPath, string.Empty);
            competitors.Clear();
        }

        public void GetAllByEvent(int Event)
        {

        }

        public void LoadFromFile()
        {

        }

        public void SaveToFile()
        {

        }

        public void SortCompetitorsByAge()
        {
            competitors.Sort();
            for (int i = 0; i < competitors.Count; i++)
            {
                Console.WriteLine($"{competitors[i].ToString()}");
            }
        }

        public Dictionary<string, Competitor> CompIndex()
        {

        }

        public void Winners(int target)
        {

        }

        public void GetQualifiers()
        {
            
        }

        public override string ToString()
        {
            
        }

        public string ToFile()
        {

        }
    }
}
