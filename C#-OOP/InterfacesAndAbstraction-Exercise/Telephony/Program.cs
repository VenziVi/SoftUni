using System;
using System.Linq;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var inputNumber = Console.ReadLine().Split();
            var inputURL = Console.ReadLine().Split();

            foreach (var number in inputNumber)
            {
                char[] numberChar = number.ToCharArray();

                if (numberChar.Any(char.IsLetter))
                {
                    Console.WriteLine("Invalid number!");
                    continue;
                }

                if (number.Length == 10)
                {
                    Smartphone smartphone = new Smartphone();
                    smartphone.Calling(number);
                }

                if (number.Length == 7)
                {
                    StationaryPhone stationaryPhone = new StationaryPhone();
                    stationaryPhone.Dialing(number);
                }
            }

            foreach (var url in inputURL)
            {
                char[] urlChar = url.ToCharArray();

                if (urlChar.Any(char.IsDigit))
                {
                    Console.WriteLine("Invalid URL!");
                    continue;
                }

                Smartphone smartphone = new Smartphone();
                smartphone.Browsing(url);
            }
        }
    }
}
