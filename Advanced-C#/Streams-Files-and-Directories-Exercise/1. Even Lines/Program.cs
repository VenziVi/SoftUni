using System;
using System.IO;
using System.Linq;

namespace _1._Even_Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "../../../text.txt";

            using (StreamReader reader = new StreamReader(filePath))
            {
                string line = reader.ReadLine();
                int counter = 0;

                while (line != null)
                {
                    if (counter++ % 2 == 0)
                    {
                        string[] signs = line.Split(new char[] { '-', ',', '.', '!', '?'});
                        string newLine = string.Join("@", signs);
                        string[] reversed = newLine.Split().Reverse().ToArray();
                        Console.WriteLine(string.Join(" ", reversed));
                    }

                    line = reader.ReadLine();
                }
            }
        }
    }
}
