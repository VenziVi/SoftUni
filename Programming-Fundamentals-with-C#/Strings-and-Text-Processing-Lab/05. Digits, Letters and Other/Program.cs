using System;
using System.Linq;
using System.Text;

namespace _5._Digits__Letters_and_Other
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string digits = string.Empty;
            string letters = string.Empty;

            for (int i = 0; i < text.Length; i++)
            {
                if (char.IsDigit(text[i]))
                {
                    digits += text[i];
                    text = text.Remove(i, 1);
                    i--;
                }
                else if (char.IsLetter(text[i]))
                {
                    letters += text[i];
                    text = text.Remove(i, 1);
                    i--;
                }
            }
            Console.WriteLine(digits);
            Console.WriteLine(letters);
            Console.WriteLine(text);
        }
    }
}
