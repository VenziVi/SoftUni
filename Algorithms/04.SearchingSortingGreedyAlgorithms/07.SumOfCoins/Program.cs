using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _07.SumOfCoins
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var coins = new Queue<int>(Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .OrderByDescending(c => c));

            var sum = int.Parse(Console.ReadLine());

            var coinsType = new Dictionary<int, int>();
            int totalCount = 0;

            while (sum > 0 && coins.Count > 0)
            {
                var currCoin = coins.Dequeue();
                var coinsCount = sum / currCoin;

                if (coinsCount == 0)
                {
                    continue;
                }

                coinsType[currCoin] = coinsCount;
                totalCount += coinsCount;

                sum %= currCoin;
            }

            if (sum == 0)
            {
                Console.WriteLine($"Number of coins to take: {totalCount}");

                foreach (var coin in coinsType.OrderByDescending(c => c.Key))
                {
                    Console.WriteLine($"{coin.Value} coin(s) with value {coin.Key}");
                }
            }
            else
            {
                Console.WriteLine("Error");    
            }
        }
    }
}
