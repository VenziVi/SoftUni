using System;

namespace _03._Gaming_Store
{
    class Program
    {
        static void Main(string[] args)
        {
            double balance = double.Parse(Console.ReadLine());
            string game = Console.ReadLine();
            double moneyLeft = balance;

            while (game != "Game Time")
            {
                double gamePrice = 0;

                switch (game)
                {
                    case "OutFall 4":
                        gamePrice = 39.99;
                        break;
                    case "CS: OG":
                        gamePrice = 15.99;
                        break;
                    case "Zplinter Zell":
                        gamePrice = 19.99;
                        break;
                    case "Honored 2":
                        gamePrice = 59.99;
                        break;
                    case "RoverWatch":
                        gamePrice = 29.99;
                        break;
                    case "RoverWatch Origins Edition":
                        gamePrice = 39.99;
                        break;
                    default:
                        Console.WriteLine("Not Found");
                        game = Console.ReadLine();
                        continue;
                }

                if (moneyLeft == 0)
                {
                    Console.WriteLine("Out of money!");
                    break;
                }
                else if (gamePrice <= moneyLeft)
                {
                    moneyLeft -= gamePrice;
                    Console.WriteLine($"Bought {game}");
                }
                else
                {
                    Console.WriteLine("Too Expensive");
                }
                game = Console.ReadLine();
            }

            if (moneyLeft <= 0)
            {
                Console.WriteLine("Out of money!");
            }
            else
            {
                double moneySpend = balance - moneyLeft;
                Console.WriteLine($"Total spent: ${moneySpend:f2}. Remaining: ${moneyLeft:f2}");
            }
        }
    }
}
