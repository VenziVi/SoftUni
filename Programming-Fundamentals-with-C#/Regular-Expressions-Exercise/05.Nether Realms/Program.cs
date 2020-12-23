using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _05.Nether_Realms
{
    class Program
    {
        static void Main(string[] args)
        {
            var demonsHealth = new Dictionary<string, int>();
            var demonsDamage = new Dictionary<string, double>();

            string[] demons = Console.ReadLine().Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var demon in demons)
            {
                string pattern = @"[A-Za-z]";
                Regex helthReg = new Regex(pattern);
                MatchCollection matches = helthReg.Matches(demon);
                int health = 0;

                foreach (Match match in matches)
                {
                    char letter = char.Parse(match.ToString());
                    health += letter;
                }
                demonsHealth.Add(demon, health);

                string patternNums = @"[+-]?[0-9]+\.?[0-9]*";
                Regex damageReg = new Regex(patternNums);
                MatchCollection numsMatches = damageReg.Matches(demon);
                double damage = 0;

                foreach (Match nums in numsMatches)
                {
                    double currentNum = double.Parse(nums.ToString());
                    damage += currentNum;
                }

                string patternSym = @"[\*\/]";
                Regex symbols = new Regex(patternSym);
                MatchCollection matchedSymbols = symbols.Matches(demon);

                foreach (Match symbol in matchedSymbols)
                {
                    if (symbol.ToString() == "*")
                    {
                        damage *= 2;
                    }
                    else if (symbol.ToString() == "/")
                    {
                        damage /= 2;
                    }
                }

                demonsDamage.Add(demon, damage);
            }

            foreach (var item in demonsHealth.OrderBy(x => x.Key))
            {
                string name = item.Key;
                Console.WriteLine($"{item.Key} - {item.Value} health, {demonsDamage[name]:f2} damage");
            }

        }
    }
}
