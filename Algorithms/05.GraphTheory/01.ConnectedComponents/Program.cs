using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.ConnectedComponents
{
    internal class Program
    {
        private static bool[] visited;
        private static List<int>[] graph;
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            graph = new List<int>[n];
            visited = new bool[n];

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine();

                if (string.IsNullOrEmpty(line))
                {
                    graph[i] = new List<int>();
                }
                else
                {
                    graph[i] = line
                        .Split()
                        .Select(int.Parse)
                        .ToList();
                }
            }

            for (int startNode = 0; startNode < graph.Length; startNode++)
            {
                if (!visited[startNode])
                {
                    Console.Write("Connected component:");
                    DFS(startNode);
                    Console.WriteLine();
                }
                
            }
        }

        private static void DFS(int node)
        {
            if (visited[node])
            {
                return;
            }

            visited[node] = true;
            foreach (var child in graph[node])
            {
                DFS(child);
            }
            Console.Write($" {node}");
        }
    }
}
