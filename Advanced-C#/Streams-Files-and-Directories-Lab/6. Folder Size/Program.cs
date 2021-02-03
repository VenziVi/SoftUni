using System;
using System.IO;

namespace _6._Folder_Size
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] files = Directory.GetFiles("../../../TestFolder");
            double sum = 0;

            foreach (var file in files)
            {
                FileInfo info = new FileInfo(file);
                sum += info.Length;
            }

            sum = sum / 1024 / 1024;
            Console.WriteLine(sum);
            File.WriteAllText("../../../output.txt", sum.ToString());
        }
    }
}
