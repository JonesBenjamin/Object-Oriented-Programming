using System;
using System.IO;

namespace CSVTutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            // Declare the location of the CSV file
            string csvFilePath = "data.csv";
            string csvNewPath = "newdata.csv";
            if (File.Exists(csvFilePath))
            {
                try
                {
                    using (StreamWriter writer = new StreamWriter(csvNewPath))
                    {
                        writer.WriteLine(" ");
                    }
                    // The file exists, open it
                    using (StreamReader reader = new StreamReader(csvFilePath))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            string[] tokens = line.Split(',');
                            foreach (var token in tokens)
                            {
                                Console.Write(token + "\n");
                                using (StreamWriter writer = new StreamWriter(csvNewPath, append: true))
                                {
                                    writer.WriteLine(token);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // File not found or not openable
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }
            else
            {
                Console.WriteLine("File does not exist.");
            }
        }
    }
}