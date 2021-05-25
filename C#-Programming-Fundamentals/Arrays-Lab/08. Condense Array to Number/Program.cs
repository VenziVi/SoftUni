using System;
using System.Linq;

namespace _08._Condense_Array_to_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(" " , StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] condensed;
            if (arr.Length == 1)
            {
                Console.WriteLine(arr[0]);
                
            }
            else
            {
                do

                {
                    condensed = new int[arr.Length - 1];

                    for (int i = 0; i < arr.Length - 1; i++)
                    {
                        condensed[i] = arr[i] + arr[i + 1];

                        arr[i] = condensed[i];

                    }

                    Array.Resize(ref arr, condensed.Length);

                } while (condensed.Length != 1);
                Console.WriteLine(arr[0]);
            }
        }
    }
}
