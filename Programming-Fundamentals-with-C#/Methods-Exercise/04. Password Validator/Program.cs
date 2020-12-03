using System;

namespace _04._Password_Validator
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            bool isTrue = PasswordLength(password) &&
                          LettersAndDigits(password) &&
                          AtLeastTwoDigits(password);

            if (isTrue)
            {
                Console.WriteLine("Password is valid");
            }
            else
            {
                if (!PasswordLength(password))
                {
                    Console.WriteLine("Password must be between 6 and 10 characters");
                }
                if (!LettersAndDigits(password))
                {
                    Console.WriteLine("Password must consist only of letters and digits");
                }
                if (!AtLeastTwoDigits(password))
                {
                    Console.WriteLine("Password must have at least 2 digits");
                }
            }
        }

        private static bool AtLeastTwoDigits(string password)
        {
            int numberOfDigits = 0;

            foreach (char c in password)
            {
                if (char.IsDigit(c))
                {
                    numberOfDigits++;
                }
            }
            if (numberOfDigits < 2)
            {
                return false;
            }

            return true;
        }

        private static bool LettersAndDigits(string password)
        {
            foreach (char c in password)
            {

                if (!char.IsLetterOrDigit(c))
                {
                    return false;
                }
            }
            return true;
        }

        private static bool PasswordLength(string password)
        {
            
            if (password.Length >= 6 && password.Length <= 10)
            {
                return true;
            }

            return false;
        }
    }
}
