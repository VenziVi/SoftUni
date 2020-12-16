using System;
using System.Collections.Generic;

namespace _04._Songs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Song> songs = new List<Song>(n);

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine()
                    .Split('_', StringSplitOptions.RemoveEmptyEntries);

                string type = data[0];
                string name = data[1];
                string time = data[2];

                Song song = new Song();

                song.TypeList = type;
                song.Name = name;
                song.Time = time;

                songs.Add(song);
            }

            string typelist = Console.ReadLine();

            if (typelist == "all")
            {
                foreach (var song in songs)
                {
                    Console.WriteLine(song.Name);
                }
            }
            else
            {
                foreach (var song in songs)
                {
                    if (song.TypeList == typelist)
                    {
                        Console.WriteLine(song.Name);
                    }
                }
            }
        }
    }

    class Song
    {
        public string TypeList { get; set; }

        public string Name { get; set; }

        public string Time { get; set; }

    }
}
