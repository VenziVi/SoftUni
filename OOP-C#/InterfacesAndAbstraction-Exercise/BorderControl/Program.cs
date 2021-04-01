using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IIdentifiable> identifibles = new List<IIdentifiable>();

            while (true)
            {
                var line = Console.ReadLine();

                if (line == "End")
                {
                    break;
                }

                var parts = line.Split();

                if (parts.Length == 3)
                {
                    var name = parts[0];
                    var age = int.Parse(parts[1]);
                    var id = parts[2];
                    identifibles.Add(new Citizen(name, age, id));
                }
                else
                {
                    var model = parts[0];
                    var id = parts[1];
                    identifibles.Add(new Robot(model, id));
                }
            }

            var digits = Console.ReadLine();

            var realId = identifibles.Where(i => i.Id.EndsWith(digits)).ToList();

            foreach (var id in realId)
            {
                Console.WriteLine(id.Id);
            }
        }
    }
}
