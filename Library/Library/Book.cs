using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Book : Library
    {
        public int wordCount { get; set; }

        public void displayBook()
        {
            Console.WriteLine("Word Count: " + wordCount);
        }
    }
}
