using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Assessment
{
    public class Competition
    {
        new List<Competitor> competitors;
        new List<EventTypes> events;

        public Competition()
        {
            this.competitors = new List<Competitor>();
            this.events = new List<EventTypes>();
        }

        public void AddCompetitor(Competitor c)
        {
            int count = 1;
            c.compEvent = new EventTypes();
            for (int i = 0; i < competitors.Count; i++)
            {
                count = count + 1;
            }
            c.compNumber = count;

            count = 1;
            for (int i = 0; i < events.Count; i++)
            {
                count = count + 1;
            }
            c.compEvent.eventNo = count;

            Console.WriteLine("What is your name?");
            c.compName = Console.ReadLine();
            Console.WriteLine("What is your age?");
            c.compAge = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("What is your hometown?");
            c.hometown = Console.ReadLine();

            Console.WriteLine("What is the venue ID?");
            c.compEvent.venueID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("What was the venue?");
            c.compEvent.venue = Console.ReadLine();
            Console.WriteLine("What was the event date and time e.g. 2024-5-14, 10:55?");
            c.compEvent.eventDateTime = Console.ReadLine();
            Console.WriteLine("What is the record time?");
            c.compEvent.record = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("What is the event type? e.g. BreastStroke, FrontCrawl, BackStroke, Butterfly");
            do
            {
                c.compEvent.eventType = Console.ReadLine();
                if (c.compEvent.eventType != "BreastStroke" &&
                    c.compEvent.eventType != "FrontCrawl" &&
                    c.compEvent.eventType != "BackStroke" &&
                    c.compEvent.eventType != "Butterfly")
                {
                    Console.WriteLine("Invalid Type");
                }
            } while (c.compEvent.eventType != "BreastStroke" && 
            c.compEvent.eventType != "FrontCrawl" && 
            c.compEvent.eventType != "BackStroke" &&
            c.compEvent.eventType != "Butterfly");

            Console.WriteLine("What was the event distance in metres?");
            c.compEvent.distance = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("What was the winning time?");
            c.compEvent.winningTime = Convert.ToDouble(Console.ReadLine());
            c.compEvent.newRecord = c.compEvent.IsNewRecord(c.compEvent.winningTime, c.compEvent.record);

            c.result = new Result();
            Console.WriteLine("Where did you place?");
            c.result.placed = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("What was your race time?");
            c.result.raceTime = Convert.ToDouble(Console.ReadLine());
            c.result.qualified = c.result.IsQualified(c.result.placed);

            c.history = new CompHistory();
            Console.WriteLine("Where was your most recent win?");
            c.history.mostRecentWin = Console.ReadLine();
            Console.WriteLine("How many career wins do you have?");
            c.history.careerWins = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("How many medals do you have?");
            c.history.medals = "(";
            int medalAmount = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < medalAmount; i++)
            {
                Console.WriteLine("Which medal did you get?");
                string currentMedal = Console.ReadLine();
                c.history.medals = c.history.medals + currentMedal;
                if (i < (medalAmount - 1))
                {
                    c.history.medals = c.history.medals + ", ";
                }
            }
            c.history.medals = c.history.medals + ")";
            Console.WriteLine("What is your personal best time?");
            c.history.personalBest = Convert.ToDouble(Console.ReadLine());

            c.newPB = c.IsNewPB(c.result.raceTime, c.history.personalBest);
            if (c.newPB == true)
            {
                c.history.personalBest = c.result.raceTime;
            }

            competitors.Add(c);
            events.Add(c.compEvent);
            int compNo = c.compNumber - 1;
            int eventNo = c.compEvent.eventNo - 1;
            Console.WriteLine("New Competitor");
            Console.WriteLine($"{competitors[compNo].ToString()}");
            Console.WriteLine("New Event");
            Console.WriteLine($"{events[eventNo].ToString()}");
        }

        public void RemoveCompetitor()
        {
            for (int i = 0; i < competitors.Count; i++)
            {
                Console.WriteLine($"{competitors[i].ToString()}");
            }
            Console.WriteLine("Which competitor do you want to remove?");
            int remove = Convert.ToInt32(Console.ReadLine());
            remove = remove - 1;
            competitors.RemoveAt(remove);
            for (int i = 0; i < competitors.Count; i++)
            {
                Console.WriteLine($"{competitors[i].ToString()}");
            }
        }

        public void ClearAll()
        {
            string csvCompPath = "Competitors.csv";
            System.IO.File.WriteAllText(csvCompPath, string.Empty);
            competitors.Clear();
            for (int i = 0; i < competitors.Count; i++)
            {
                Console.WriteLine($"{competitors[i].ToString()}");
            }
            string csvEventPath = "Events.csv";
            System.IO.File.WriteAllText(csvEventPath, string.Empty);
            events.Clear();
            for (int i = 0; i < events.Count; i++)
            {
                Console.WriteLine($"{events[i].ToString()}");
            }
        }

        public void GetAllByEvent()
        {
            for (int i = 0; i < events.Count; i++)
            {
                Console.WriteLine($"{events[i].ToString()}");
            }
        }

        public void LoadFromFile()
        {
            string curLine = "";
            string fileDelimiter = ",";
            string csvCompPath = "Competitors.csv";
            string csvEventPath = "Events.csv";
            try
            {
                // Open the file
                using (StreamReader bufferFile = new StreamReader(csvCompPath))
                {
                    bufferFile.ReadLine();
                    while ((curLine = bufferFile.ReadLine()) != null) // While not End of File
                    {
                        string[] item = curLine.Split(fileDelimiter);
                        // Check if enough items are present
                        if (item.Length >= 21)
                        {
                            competitors.Add(new Competitor(item[0], item[1], item[2], item[3], item[4], item[5], item[6], item[7], item[8], item[9], item[10], item[11], item[12], item[13], item[14], item[15], item[16], item[17], item[18], item[19], item[20]));
                        }
                        else
                        {
                            // Handle rows with insufficient data
                            Console.WriteLine($"Warning: Skipped row with insufficient data: {curLine}");
                            // You might want to log this for later analysis
                        }
                    }
                }
                using (StreamReader bufferFile = new StreamReader(csvEventPath))
                {
                    bufferFile.ReadLine();
                    while ((curLine = bufferFile.ReadLine()) != null) // While not End of File
                    {
                        string[] item = curLine.Split(fileDelimiter);
                        // Check if enough items are present
                        if (item.Length >= 9)
                        {
                            events.Add(new EventTypes(item[0], item[1], item[2], item[3], item[4], item[5], item[6], item[7], item[8]));
                        }
                        else
                        {
                            // Handle rows with insufficient data
                            Console.WriteLine($"Warning: Skipped row with insufficient data: {curLine}");
                            // You might want to log this for later analysis
                        }
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found.");
            }
            catch (IOException)
            {
                Console.WriteLine("An error occurred while reading the file.");
            }

            Console.WriteLine("Competitors");
            for (int i = 0; i < competitors.Count; i++)
            {
                Console.WriteLine($"{competitors[i].ToString()}");
            }
            Console.WriteLine(" ");
            Console.WriteLine("Events");
            for (int i = 0; i < events.Count; i++)
            {
                Console.WriteLine($"{events[i].ToString()}");
            }
        }

        public void SaveToFile()
        {
            string csvCompPath = "Competitors.csv";
            string csvEventPath = "Events.csv";
            System.IO.File.WriteAllText(csvCompPath, string.Empty);
            System.IO.File.WriteAllText(csvEventPath, string.Empty);
            using (StreamWriter writer = new StreamWriter(csvCompPath, append: true))
            {
                writer.WriteLine();
                for (int i = 0; i < this.competitors.Count; i++)
                {
                    writer.WriteLine($"{this.competitors[i].ToString()}");
                }
            }
            using (StreamWriter writer = new StreamWriter(csvEventPath, append: true))
            {
                writer.WriteLine();
                for (int i = 0; i < this.events.Count; i++)
                {
                    writer.WriteLine($"{this.events[i].ToString()}");
                }
            }
        }

        public void SortCompetitorsByAge()
        {
            competitors.Sort();
            for (int i = 0; i < competitors.Count; i++)
            {
                Console.WriteLine($"{competitors[i].ToString()}");
            }
        }

        public void Winners()
        {
            Console.WriteLine("What minimum number of career wins do you want to see?");
            int target = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < competitors.Count; i++)
            {
                if (competitors[i].history.careerWins >= target)
                {
                        Console.WriteLine($"{competitors[i].ToString()}");
                }
            }

        }

        public void GetQualifiers()
        {
            for (int i = 0; i < competitors.Count; i++)
            {
                if (competitors[i].result.qualified == true)
                {
                    Console.WriteLine($"{competitors[i].ToString()}");
                }
            }
        }

        public override string ToString()
        {
            return $"{this.competitors}";
        }

        public string ToFile()
        {
            return null;
        }
    }
}
