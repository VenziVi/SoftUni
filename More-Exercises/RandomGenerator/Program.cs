using System;
using System.Collections.Generic;
using System.IO;

namespace RandomGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> participants = new List<string>();

            using (StreamReader file = new StreamReader("../../../participants.txt"))
            {
                int counter = 0;
                string line;

                while ((line = file.ReadLine()) != null)
                {
                    counter++;
                    participants.Add(line);
                    
                }

            }

            Random rnd = new Random();

            for (int i = 0; i < 2; i++)
            {
                int num = rnd.Next(1, participants.Count);

                Console.WriteLine(participants[num]);

                participants.Remove(participants[num]);
            }
            
        }
    }
}
