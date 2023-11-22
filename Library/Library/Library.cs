using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Library
    {
        public string name { get; set; }
        public string genre { get; set; }
        public double price { get; set; }
        public string author { get; set; }

        public void displayLibrary()
        {
            Console.WriteLine("Name: " + name);
            Console.WriteLine("Genre: " + genre);
            Console.WriteLine("Price: £" + price);
            Console.WriteLine("Author: " + author);
        }
    }
}
