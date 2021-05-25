using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _5._Directory_Traversal
{
    class Program
    {
        static void Main(string[] args)
        {
            string directoryPath = Directory.GetCurrentDirectory();
            string[] filesNames = Directory.GetFiles(directoryPath);
            Dictionary<string, Dictionary<string, double>> filesData =
                new Dictionary<string, Dictionary<string, double>>();

            foreach (var fileName in filesNames)
            {
                FileInfo fileInfo = new FileInfo(fileName);
                string extension = fileInfo.Extension;
                string nameOfFile = fileInfo.Name;
                long size = fileInfo.Length;
                double kbSize = size / 1024.0;

                if (!filesData.ContainsKey(extension))
                {
                    filesData.Add(extension, new Dictionary<string, double>());
                }

                filesData[extension].Add(nameOfFile, kbSize);
            }

            Dictionary<string, Dictionary<string, double>> sorted = filesData
                .OrderByDescending(v => v.Value.Count)
                .ThenBy(v => v.Key)
                .ToDictionary(k => k.Key, v => v.Value);

            List<string> res = new List<string>();

            foreach (var item in sorted)
            {
                res.Add(item.Key);

                foreach (var fileData in item.Value.OrderBy(v => v.Value))
                {
                    res.Add($"--{fileData.Key} - {fileData.Value:f3}kb");
                }
            }

            string filePath = Path.Combine(Environment.GetFolderPath
                (Environment.SpecialFolder.Desktop), "output.txt");
            File.WriteAllLines(filePath, res);
        }
    }
}
