using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;

namespace _3._School_Library
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> books = Console.ReadLine().Split("&").ToList();

            string command = Console.ReadLine();

            while (command != "Done")
            {
                string[] cmdArgs = command.Split(" | ");
                string cmd = cmdArgs[0];
                string book = cmdArgs[1];

                if (cmd == "Add Book")
                {
                    if (!books.Contains(book))
                    {
                        books.Insert(0, book);
                    }

                }
                else if (cmd == "Take Book")
                {
                    if (books.Contains(book))
                    {
                        books.Remove(book);
                    }
                }
                else if (cmd == "Swap Books")
                {
                    string book1 = book;
                    string book2 = cmdArgs[2];

                    if (books.Contains(book1) && books.Contains(book2))
                    {
                       int book1Index = books.IndexOf(book1);
                       int book2Index = books.IndexOf(book2);
                       books[book1Index] = book2;
                       books[book2Index] = book1;
                    }

                }
                else if (cmd == "Insert Book")
                {
                    books.Add(book);
                }
                else if (cmd == "Check Book")
                {
                    int index = int.Parse(book);
                    if (index >= 0 && index < books.Count)
                    {
                        Console.WriteLine(books[index]);
                    }
                    else
                    {
                        command = Console.ReadLine();
                        continue;
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", books));
        }
    }
}
