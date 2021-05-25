using System;

namespace _07._Max_Sequence_of_Equal_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr = Console.ReadLine()
                                  .Split(" ");
            int bestIndex = 0;
            int bestCounter = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                string currentNum = arr[i];
                int currentCounter = 1;

                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (currentNum == arr[j])
                    {
                        currentCounter++;
                    }
                    else
                    {
                        break;
                    }
                }
                if (currentCounter > bestCounter)
                {
                    bestCounter = currentCounter;
                    bestIndex = i;
                }
            }
            for (int i = 0; i < bestCounter; i++)
            {
                Console.Write(arr[bestIndex] + " ");
            }
        }
    }
}
