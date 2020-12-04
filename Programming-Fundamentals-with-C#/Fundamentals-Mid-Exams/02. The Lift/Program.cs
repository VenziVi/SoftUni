using System;
using System.ComponentModel.Design;
using System.Linq;

namespace _2._The_Lift
{
    class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            int[] seats = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int peopleLeft = 0;


            for (int i = 0; i < seats.Length; i++)
            {
                if (people == 0)
                {
                    break;
                }
                while (seats[i] < 4)
                {
                    seats[i] += 1;
                    people--;
                    
                    if (people <= 0)
                    {
                        peopleLeft = people;
                        break;
                    }
                    else
                    {
                        peopleLeft = people;
                    }
   
                }
            }

            bool isLiftFool = true;

            for (int i = 0; i < seats.Length; i++)
            {
                if (seats[i] < 4)
                {
                    isLiftFool = false;
                }
            }

            if (isLiftFool && peopleLeft > 0)
            {
                Console.WriteLine($"There isn't enough space! {peopleLeft} people in a queue!");
                Console.WriteLine(string.Join(" ", seats));

            }

            if (!isLiftFool && peopleLeft == 0)
            {
                Console.WriteLine("The lift has empty spots!");
                Console.WriteLine(string.Join(" ", seats));

            }

            if (isLiftFool && peopleLeft == 0)
            {
                Console.WriteLine(string.Join(" ", seats));

            }
        }
    }
}