using System;

namespace _03._Extract_File
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int index = input.LastIndexOf('.');

            string file = string.Empty;
            string fileExe = string.Empty;

            for (int i = index +1; i < input.Length; i++)
            {
                fileExe += input[i];
            }
            char[] text = input.ToCharArray();

            for (int i = index - 1; i >= 0; i--)
            {
                int ascii = text[i];
                
                if (ascii != 92)
                {
                    file = input[i] + file;
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine($"File name: {file}");
            Console.WriteLine($"File extension: {fileExe}");
        }
    }
}
