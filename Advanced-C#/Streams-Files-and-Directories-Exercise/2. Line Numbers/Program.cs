using System;
using System.IO;

namespace _2._Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("../../../text.txt");
            using (StreamWriter writer = new StreamWriter("../../../output.txt"))
            {
                for (int i = 0; i < lines.Length; i++)
                {
                    int lettersCount = 0;
                    int punctuationCount = 0;
                    string line = lines[i];
                    char[] letters = line.ToCharArray();

                    for (int j = 0; j < letters.Length; j++)
                    {
                        if (char.IsLetter(letters[j]))
                        {
                            lettersCount++;
                        }
                        else if (char.IsPunctuation(letters[j]))
                        {
                            punctuationCount++;
                        }
                    }
                    string output = ($"Line {i + 1}: {line} ({lettersCount})({punctuationCount})").ToString();
                    Console.WriteLine(output);
                    writer.WriteLine(output);
                }
            }
        }
    }
}
