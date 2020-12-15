using System;
using System.Linq;

namespace _01._Valid_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < input.Length; i++)
            {
                var username = input[i];

                if (IsValid(username))
                {
                    Console.WriteLine(username);
                }
            }
        }

        public static bool IsValid(string user)
        {
            return user.Length >= 3 && user.Length <= 16 &&
                user.All(c => char.IsLetterOrDigit(c)) ||
                user.Contains("-") || user.Contains("_");
        }
    }
}
