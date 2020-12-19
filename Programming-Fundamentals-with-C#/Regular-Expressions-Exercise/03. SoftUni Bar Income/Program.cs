using System;
using System.Text.RegularExpressions;

namespace _03._SoftUni_Bar_Income
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"%([A-Z][a-z]+)%[^|$%.]*<(\w+)>[^|$%.]*\|(\d+)\|[^|$%.]*?(\d+.?\d*)\$";
            Regex regex = new Regex(pattern);
            double totalPrice = 0;
            string input = Console.ReadLine();

            while (input != "end of shift")
            {
                Match match = regex.Match(input);

                if (match.Success)
                {
                    //customer, product, count and a price
                    string costumer = match.Groups[1].Value;
                    string product = match.Groups[2].Value;
                    int count = int.Parse(match.Groups[3].Value);
                    double price = double.Parse(match.Groups[4].Value);

                    double sum = count * price;
                    totalPrice += sum;

                    Console.WriteLine($"{costumer}: {product} - {sum:f2}");

                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Total income: {totalPrice:f2}");
        }
    }
}
