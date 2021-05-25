using System;
using System.ComponentModel.Design;
using System.Linq;

namespace _3._Angry_Pet
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] items = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int entryPoint = int.Parse(Console.ReadLine());
            string typeOfItems = Console.ReadLine();
            string priceRating = Console.ReadLine();
            int rightDamage = 0;
            int leftDamage = 0;

            int entryVallue = items[entryPoint];

            if (typeOfItems == "cheap")
            {
                if (priceRating == "positive")
                {
                    for (int i = 0; i < entryPoint; i++)
                    {
                        if (items[i] < entryVallue && items[i] > 0)
                        {
                            leftDamage += items[i];
                        }
                    }

                    for (int j = entryPoint + 1; j < items.Length; j++)
                    {
                        if (items[j] < entryVallue && items[j] > 0)
                        {
                            rightDamage += items[j];
                        }
                    }
                }
                else if (priceRating == "negative")
                {
                    for (int i = 0; i < entryPoint; i++)
                    {
                        if (items[i] < entryVallue && items[i] < 0)
                        {
                            leftDamage += items[i];
                        }
                    }

                    for (int j = entryPoint + 1; j < items.Length; j++)
                    {
                        if (items[j] < entryVallue && items[j] < 0)
                        {
                            rightDamage += items[j];
                        }
                    }
                }
                else if (priceRating == "all")
                {
                    for (int i = 0; i < entryPoint; i++)
                    {
                        if (items[i] < entryVallue)
                        {
                            leftDamage += items[i];
                        }
                    }

                    for (int j = entryPoint + 1; j < items.Length; j++)
                    {
                        if (items[j] < entryVallue)
                        {
                            rightDamage += items[j];
                        }
                    }
                }
            }
            else if (typeOfItems == "expensive")
            {
                if (priceRating == "positive")
                {
                    for (int i = 0; i < entryPoint; i++)
                    {
                        if (items[i] >= entryVallue && items[i] > 0)
                        {
                            leftDamage += items[i];
                        }
                    }

                    for (int j = entryPoint + 1; j < items.Length; j++)
                    {
                        if (items[j] >= entryVallue && items[j] > 0)
                        {
                            rightDamage += items[j];
                        }
                    }
                }
                else if (priceRating == "negative")
                {
                    for (int i = 0; i < entryPoint; i++)
                    {
                        if (items[i] >= entryVallue && items[i] < 0)
                        {
                            leftDamage += items[i];
                        }
                    }

                    for (int j = entryPoint + 1; j < items.Length; j++)
                    {
                        if (items[j] >= entryVallue && items[j] < 0)
                        {
                            rightDamage += items[j];
                        }
                    }
                }
                else if (priceRating == "all")
                {
                    for (int i = 0; i < entryPoint; i++)
                    {
                        if (items[i] >= entryVallue)
                        {
                            leftDamage += items[i];
                        }
                    }

                    for (int j = entryPoint + 1; j < items.Length; j++)
                    {
                        if (items[j] >= entryVallue)
                        {
                            rightDamage += items[j];
                        }
                    }
                }
            }

            if (rightDamage > leftDamage)
            {
                Console.WriteLine($"Right - {rightDamage}");
            }
            else
            {
                Console.WriteLine($"Left - {leftDamage}");
            }
        }
    }
}

