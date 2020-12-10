using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._List_Manipulation_Advanced
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string command = Console.ReadLine().ToLower();
            bool isChanged = false;

            while (command != "end")
            {
                string[] function = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                

                switch (function[0].ToLower())
                {
                    case "add":
                        numbers.Add(int.Parse(function[1]));
                        isChanged = true;
                        break;

                    case "remove":
                        numbers.Remove(int.Parse(function[1]));
                        isChanged = true;
                        break;

                    case "removeat":
                        numbers.RemoveAt(int.Parse(function[1]));
                        isChanged = true;
                        break;

                    case "insert":
                        numbers.Insert(int.Parse(function[2]), int.Parse(function[1]));
                        isChanged = true;
                        break;

                    case "contains":
                        bool isNumber = false;
                        for (int i = 0; i < numbers.Count; i++)
                        {

                            if (numbers[i] == int.Parse(function[1]))
                            {
                                isNumber = true;
                                break;
                            }
                            
                        }
                        if (isNumber)
                        {
                            Console.WriteLine("Yes");
                        }
                        else
                        {
                            Console.WriteLine("No such number");
                        }
                        break;

                    case "printeven":
                        Console.WriteLine(string.Join(' ', numbers.Where(n => n % 2 == 0)));
                        break;

                    case "printodd":
                        Console.WriteLine(string.Join(' ', numbers.Where(n => n % 2 == 1)));
                        break;

                    case "getsum":
                        Console.WriteLine(numbers.Sum());
                        break;

                    case "filter":

                        switch (function[1])
                        {
                            case ">":
                                List<int> case1 = new List<int>();
                                for (int i = 0; i < numbers.Count; i++)
                                {
                                    if (numbers[i] > int.Parse(function[2]))
                                    {
                                        case1.Add(numbers[i]);
                                    }
                                }
                                Console.WriteLine(string.Join(' ', case1));
                                break;

                            case "<":
                                List<int> case2 = new List<int>();
                                for (int i = 0; i < numbers.Count; i++)
                                {
                                    if (numbers[i] < int.Parse(function[2]))
                                    {
                                        case2.Add(numbers[i]);
                                    }
                                }
                                Console.WriteLine(string.Join(' ', case2));
                                break;

                            case "<=":
                                List<int> case3 = new List<int>();
                                for (int i = 0; i < numbers.Count; i++)
                                {
                                    if (numbers[i] <= int.Parse(function[2]))
                                    {
                                        case3.Add(numbers[i]);
                                    }
                                }
                                Console.WriteLine(string.Join(' ', case3));
                                break;

                            case ">=":
                                List<int> case4 = new List<int>();
                                for (int i = 0; i < numbers.Count; i++)
                                {
                                    if (numbers[i] >= int.Parse(function[2]))
                                    {
                                        case4.Add(numbers[i]);
                                    }
                                }
                                Console.WriteLine(string.Join(' ', case4));
                                break;

                            default:
                                break;
                        }
                        break;
                }
                
                command = Console.ReadLine();
            }
            if (isChanged)
            {
                Console.WriteLine(string.Join(' ', numbers));
            }
        }
    }
}
