using System;
using System.Collections.Generic;
using System.Text;

namespace _02.VillainNames
{
    public static class Query
    {
        public static string query = @"SELECT v.Name AS Name,COUNT(*) AS [Count]
                                	FROM MinionsVillains as mv
                                	JOIN Villains AS v ON v.Id = mv.VillainId
                                	JOIN Minions AS m ON m.Id = mv.MinionId
                                GROUP BY v.Name
                                HAVING COUNT(*) >= 3
                                ORDER BY COUNT(*) DESC";
    }
}
