using System;
using System.IO;

namespace _4._Merge_Files
{
    class Program
    {
        static void Main(string[] args)
        {


            using (var reader = new StreamReader("../../../input1.txt"))
            {
                var num1 = reader.ReadLine();

                var secondReader = new StreamReader("../../../input2.txt");

                var num2 = secondReader.ReadLine();

                using (var writer = new StreamWriter("../../../output.txt"))
                {
                    while (num1 != null)
                    {
                        writer.WriteLine($"{num1}");
                        writer.WriteLine($"{num2}");
                        num1 = reader.ReadLine();
                        num2 = secondReader.ReadLine();
                    }
                }
            }
        }
    }
}
