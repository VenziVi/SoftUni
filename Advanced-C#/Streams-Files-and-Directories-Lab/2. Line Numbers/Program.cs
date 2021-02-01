using System;
using System.IO;

namespace _2._Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var reader = new StreamReader("../../../input.txt");
            using (reader)
            {
                int num = 1;
                string line = reader.ReadLine();

                using (var writer = new StreamWriter("../../../output.txt"))
                {
                    while (line != null)
                    {
                        writer.WriteLine($"{num}. {line}");
                        num++;
                        line = reader.ReadLine();
                    }
                }
            }
            
        }
    }
}
