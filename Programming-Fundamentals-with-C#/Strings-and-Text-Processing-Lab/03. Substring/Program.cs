using System;

namespace _03._Substring
{
    class Program
    {
        static void Main(string[] args)
        {
            string removeWord = Console.ReadLine().ToLower();
            string text = Console.ReadLine().ToLower();

            int index = text.IndexOf(removeWord);

            while (index != -1)
            {
               
               text = text.Remove(index, removeWord.Length);

               index = text.IndexOf(removeWord);
            }

            Console.WriteLine(text);
        }
    }
}
