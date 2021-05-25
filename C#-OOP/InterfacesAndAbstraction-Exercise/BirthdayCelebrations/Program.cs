using System;
using System.Collections.Generic;
using System.Linq;

namespace BirthdayCelebrations
{
    public class StarttUp
    {
        static void Main(string[] args)
        {
            List<IBirthdate> dates = new List<IBirthdate>();

            while (true)
            {
                var line = Console.ReadLine();

                if (line == "End")
                {
                    break;
                }

                var parts = line.Split();
                var type = parts[0];

                if (type == nameof(Citizen))
                {
                    var name = parts[1];
                    var age = int.Parse(parts[2]);
                    var id = parts[3];
                    var birthDate = parts[4];

                    dates.Add(new Citizen(name, age, id, birthDate));
                }
                else if (type == nameof(Robot))
                {
                    continue;
                }
                else if (type == nameof(Pet))
                {
                    var name = parts[1];
                    var birthDate = parts[2];

                    dates.Add(new Pet(name, birthDate));
                }
            }

            var year = Console.ReadLine();

            var finalDates = dates.Where(y => y.BirthDate.EndsWith(year)).ToList();

            foreach (var date in finalDates)
            {
                Console.WriteLine(date.BirthDate);
            }
        }
    }
}
