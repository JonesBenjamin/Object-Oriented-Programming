using System;
using System.IO;

try
{
    using (StreamWriter fileWrite = new StreamWriter("numbers.txt"))
    {
        int count = 1;
        while (count <= 10)
        {
            fileWrite.WriteLine(count);
            count = count + 1;
        }
    }
}
catch (Exception error)
{
    Console.WriteLine(error.Message);
}
