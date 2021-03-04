using System;
using System.Collections.Generic;
using System.Linq;

namespace _01ListyIterator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<string> inputs = new List<string>();
            ListyIterator<string> list = new ListyIterator<string>(inputs);

            string command = Console.ReadLine();

            while (command != "END")
            {
                string[] splited = command.Split();
                string cmdArgs = splited[0];

                switch (cmdArgs)
                {
                    case "Create":
                        string[] input = command.Split().Skip(1).ToArray();
                        for (int i = 0; i < input.Length; i++)
                        {
                            inputs.Add(input[i]);
                        }
                        break;

                    case "Move":
                        Console.WriteLine(list.Move());
                        break;

                    case "Print":
                        try
                        {
                            list.Print();
                        }
                        catch (IndexOutOfRangeException e)
                        {

                            Console.WriteLine(e.Message); ;
                        }
                        break;

                    case "HasNext":
                        Console.WriteLine(list.HasNext());
                        break;

                    case "PrintAll":
                        try
                        {
                            list.PrintAll();
                        }
                        catch (IndexOutOfRangeException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;

                    default:
                        break;
                }

                command = Console.ReadLine();
            }
        }
    }
}