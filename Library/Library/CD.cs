using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class CD : Library
    {
        public int audioLength { get; set; }

        public void displayCD()
        {
            Console.WriteLine("Audio Length: " + audioLength + " seconds");
        }

    }
}
