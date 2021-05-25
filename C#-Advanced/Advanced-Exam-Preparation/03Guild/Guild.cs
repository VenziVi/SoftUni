using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        List<Player> roster;

        public Guild(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            roster = new List<Player>();
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count { get { return roster.Count; } }

        public void AddPlayer(Player player)
        {
            if (Capacity > roster.Count)
            {
                roster.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            Player player = roster.FirstOrDefault(p => p.Name == name);

            if (player == null)
            {
                return false;
            }

            roster.Remove(player);
            return true;
        }

        public void PromotePlayer(string name)
        {
            Player player = roster.FirstOrDefault(p => p.Name == name && p.Rank != "Member");

            if (player != null)
            {
                player.Rank = "Member";
            }
        }

        public void DemotePlayer(string name)
        {
            Player player = roster.FirstOrDefault(p => p.Name == name && p.Rank != "Trial");

            if (player != null)
            {
                player.Rank = "Trial";
            }
        }


        public Player[] KickPlayersByClass(string classy)
        {

            List<Player> myListTemp = new List<Player>();
            foreach (var player in this.roster)
            {
                if (player.Class == classy)
                {
                    myListTemp.Add(player);
                }
            }
            Player[] myArrayToReturn = myListTemp.ToArray();

            this.roster = this.roster.Where(x => x.Class != classy).ToList();

            return myArrayToReturn;
        }

        public string Report()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine($"Players in the guild: {Name}");

            foreach (var player in roster)
            {
                output.AppendLine(player.ToString());
            }

            return output.ToString().TrimEnd();
        }
    }
}
