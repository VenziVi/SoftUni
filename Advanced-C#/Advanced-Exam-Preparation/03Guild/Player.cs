using System;
using System.Collections.Generic;
using System.Text;

namespace Guild
{
    public class Player
    {
        public Player(string name, string Class)
        {
            Name = name;
            this.Class = Class;
            Rank = "Trial";
            Description = "n/a";
        }

        public string Name { get; set; }

        public string Class { get; set; }

        public string Rank { get; set; }

        public string Description { get; set; }

        public override string ToString()
        {
            string output = $"Player {Name}: {Class}" + Environment.NewLine;
            output += $"Rank: {Rank}" + Environment.NewLine;
            output += $"Description: {Description}";
            return output;
        }
    }
}
