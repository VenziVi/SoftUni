using System;
using Microsoft.EntityFrameworkCore;
using P03_FootballBetting.Data;

namespace P03_FootballBetting
{
    class StartUp
    {
        static void Main(string[] args)
        {
            FootballBettingContext footballDb = new FootballBettingContext();

            footballDb.Database.Migrate();

            Console.WriteLine("Database created successfully");
        }
    }
}
