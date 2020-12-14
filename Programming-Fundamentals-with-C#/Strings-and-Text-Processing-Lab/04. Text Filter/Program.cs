using System;

namespace _4._Text_Filter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] banList = Console.ReadLine().Split(", ");
            string text = Console.ReadLine();

            for (int i = 0; i < banList.Length; i++)
            {
                string banWord = banList[i];
                string replaceChar = new string('*', banWord.Length);

                text = text.Replace(banWord, replaceChar);
            }

            Console.WriteLine(text);
        }
    }
}
