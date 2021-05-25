using System;

namespace Threeuple
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] text = Console.ReadLine().Split();
            string firstName = $"{text[0]} {text[1]}";
            string address = text[2];
            string town = TownDef(text);

            Tuple1<string, string, string> tuple = new Tuple1<string, string, string>(firstName, address, town);
            Console.WriteLine(tuple.ToString());

            string[] text1 = Console.ReadLine().Split();
            string name = text1[0];
            int liters = int.Parse(text1[1]);
            bool isDrunk = text1[2] == "drunk";

            Tuple1<string, int, bool> tuple1 = new Tuple1<string, int, bool>(name, liters, isDrunk);
            Console.WriteLine(tuple1.ToString());

            string[] text2 = Console.ReadLine().Split();
            string fName = text2[0];
            double balance = double.Parse(text2[1]);
            string bankName = text2[2];

            Tuple1<string, double, string> tuple2 = new Tuple1<string, double, string>(fName, balance, bankName);
            Console.WriteLine(tuple2.ToString());
        }

        private static string TownDef(string[] text)
        {
            string town = string.Empty;
            if (text.Length == 4)
            {
                town = text[3];
            }
            else if (text.Length == 5)
            {
                town = $"{text[3]} {text[4]}";
            }

            return town;
        }
    }
}
