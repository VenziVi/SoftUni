using System;
using System.Text.RegularExpressions;

namespace _02._Fancy_Barcodes
{
    class Program
    {
        static void Main(string[] args)
        {
            string patternBarcode = @"\#+[A-Z][A-Za-z0-9]{4,}[A-Z]@\#+";
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                Match match = Regex.Match(input, patternBarcode);

                if (match.Success)
                {
                    string compare = match.Value;
                    string pattern = @"\d+";
                    string groupNum = string.Empty;

                    MatchCollection matches = Regex.Matches(compare, pattern);

                    if (matches.Count > 0)
                    {
                        foreach (var item in matches)
                        {
                            groupNum += item;
                        }

                        Console.WriteLine($"Product group: {groupNum}");
                    }
                    else
                    {
                        Console.WriteLine("Product group: 00");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                }
            }
        }
    }
}
