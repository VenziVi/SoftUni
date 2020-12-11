using System;

namespace _09._Greater_of_Two_Values
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            string n1 = Console.ReadLine();
            string n2 = Console.ReadLine();

            string result = "";

            switch (type)
            {
                case "int":
                   int integer = GetMax(int.Parse(n1), int.Parse(n2));
                    result = integer.ToString();
                    break;
                case "char":
                    char letter = GetMax(char.Parse(n1), char.Parse(n2));
                    result = letter.ToString();
                    break;
                case "string":
                    string text = GetMax(n1, n2);
                    result = text;
                    break;
            }
            Console.WriteLine(result);
        }

        private static string GetMax(string n1, string n2)
        {
            string result = string.Empty;
            int first = 0;
            int second = 0;

            for (int i = 0; i < n1.Length; i++)
            {
                first += n1[i]; ; 
            }

            for (int i = 0; i < n2.Length; i++)
            {
                second += n2[i];
            }

            if (first > second)
            {
                result = n1;
            }
            else
            {
                result = n2;
            }
         
            return result;
        }

        private static char GetMax(char n1, char n2)
        {

            char result = ' ';

            if (n1 > n2)
            {
                result = n1;
            }
            else
            {
                result = n2;
            }

            return result;
        }

        private static int GetMax(int n1, int n2)
        {

            int result = 0;

            if (n1 > n2)
            {
                result = n1;
            }
            else
            {
                result = n2;
            }
            return result;
        }
    }
}
