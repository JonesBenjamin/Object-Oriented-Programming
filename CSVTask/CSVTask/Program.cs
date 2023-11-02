using System;
using System.Collections.Generic;
using System.IO;
namespace CSVTask
{
    class Program
    {
        static void Main(string[] args)
        {
            // Local Variables
            string curLine = "";
            string fileDelimiter = ",";
            string csvFilePath = "data.csv";
            string csvNewPath = "newdata.csv";
            // Create a List (A type of array) for all our people!
            List<Person> people = new List<Person>();
            try
            {
                using (StreamWriter writer = new StreamWriter(csvNewPath))
                {
                    writer.WriteLine(" ");
                }
                // Open the file
                using (StreamReader bufferFile = new StreamReader(csvFilePath))
                {
                    // Skip the first line
                    bufferFile.ReadLine();
                    while ((curLine = bufferFile.ReadLine()) != null) // While not End of File
                    {
                        string[] individual = curLine.Split(fileDelimiter);
                        people.Add(new Person(individual[1], individual[2], individual[3], individual[4], individual[5]));
                    }
                }
            }
            catch (FileNotFoundException)
            {
                // No File found
                Console.WriteLine("File not found.");
            }
            catch (IOException)
            {
                // Can't read file
                Console.WriteLine("An error occurred while reading the file.");
            }
            // Sort the list of people
            people.Sort();
            // Print the sorted list of people
            for (int i = 0; i < people.Count; i++)
            {
                Console.WriteLine($"{i + 1},{people[i].ToString()}");
                using (StreamWriter writer = new StreamWriter(csvNewPath, append: true))
                {
                    writer.WriteLine($"{i + 1},{people[i].ToString()}");
                }
            }
        }
    }
}