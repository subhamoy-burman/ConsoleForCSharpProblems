using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ConsoleAppBlind75.Graph
{
    public class GraphCSharp
    {
        public int Source { get; set; }
        public int Neighbour { get; set; }
        public int Weight { get; set; }

        public GraphCSharp(int source, int neighbour, int weight)
        {
            Source = source;
            Neighbour = neighbour;
            Weight = weight;
        }

        public List<List<GraphCSharp>> GetFullGraph()
        {
            var graph = new List<List<GraphCSharp>>();

            graph.Insert(0, new List<GraphCSharp>()
            {
                new(0, 1, 10),
                new(0, 3, 10)
            });


            graph.Insert(1, new List<GraphCSharp>()
            {
                new(1, 2, 10),
                new(1, 0, 10)
            });

            graph.Insert(2, new List<GraphCSharp>()
            {
                new(2, 3, 10),
                new(2, 1, 10)
            });

            graph.Insert(3, new List<GraphCSharp>()
            {
                new(3, 4, 10),
                new(3, 2, 10),
                new(3, 0, 10)
            });


            graph.Insert(4, new List<GraphCSharp>()
            {
                new(4, 5, 10),
                new(4, 6, 10),
                new(4, 3, 10)
            });

            graph.Insert(5, new List<GraphCSharp>()
            {
                new(5, 6, 10),
                new(5, 4, 10)
            });

            graph.Insert(6, new List<GraphCSharp>()
            {
                new(6, 4, 10),
                new(6, 5, 10)
            });

            return graph;
        }
    }

    public static class GraphPrograms
    {
        public static bool HasPath(List<List<GraphCSharp>> graph, int source, int destination)
        {
            if (source == destination)
            {
                return true;
            }

            foreach (var item in graph[source])
            {
                return HasPath(graph, item.Neighbour, destination);
            }

            return false;
        }

        public static void PrintAllPaths(List<List<GraphCSharp>> graph, string pathSoFar, int source, int destination,
            bool[] visitedList)
        {
            if (source == destination)
            {
                Debug.WriteLine(pathSoFar);
                return;
            }

            visitedList[source] = true;
            foreach (var item in graph[source])
            {
                if (!visitedList[item.Neighbour])
                {
                    PrintAllPaths(graph, pathSoFar + item.Neighbour, item.Neighbour, destination, visitedList);
                }
            }
        }

        public static void GetConnectedComponents(List<List<GraphCSharp>> graph, int source, bool[] visited,
            string pathSofar)
        {
            if (visited[source])
            {
                Debug.WriteLine(pathSofar.Append('|'));
                return;
            }

            foreach (var item in graph)
            {
                foreach (var edge in item)
                {
                    if (!visited[edge.Source])
                    {
                        visited[edge.Source] = true;
                        GetConnectedComponents(graph, edge.Neighbour, visited, pathSofar + edge.Source);
                        pathSofar = string.Empty;
                    }
                }
            }
        }

        public static void GetConnectedComponents2(List<List<GraphCSharp>> graph, int source)
        {
            bool[] visited = new bool[7];

            List<List<int>> totalComponents = new List<List<int>>();
            for (int vertices = 0; vertices < 7; vertices++)
            {
                if (visited[vertices] == false)
                {
                    List<int> individualComponent = new List<int>();
                    GenerateComponents(graph, vertices, source, individualComponent, visited);
                    totalComponents.Add(individualComponent);
                }
            }
        }

        private static void GenerateComponents(List<List<GraphCSharp>> graph, int vertices, int source,
            List<int> individualComponent, bool[] visited)
        {
            visited[source] = true;
            individualComponent.Add(source);

            foreach (var edge in graph[source])
            {
                if (visited[edge.Neighbour] == false)
                {
                    GenerateComponents(graph, vertices, edge.Neighbour, individualComponent, visited);
                }
            }
        }

        public static int GetNumberOfIslands(int[,] islands)
        {
            int islandCount = 0;
            bool[,] visited = new bool[islands.GetLength(0), islands.GetLength(1)];

            for (int i = 0; i < islands.GetLength(0); i++)
            {
                for (int j = 0; j < islands.GetLength(1); j++)
                {
                    if (islands[i, j] == 0 && !visited[i, j])
                    {
                        DrawTreeAndGetIsland(islands, i, j, visited);
                        islandCount++;
                    }
                }
            }

            return islandCount;
        }

        private static void DrawTreeAndGetIsland(int[,] islands, int i, int j, bool[,] visited)
        {
            if (i < 0 || j < 0 || i >= islands.GetLength(0) || j >= islands.GetLength(1)
                || visited[i, j] || islands[i, j] == 1)
            {
                return;
            }

            visited[i, j] = true;
            
            DrawTreeAndGetIsland(islands, i-1, j, visited);
            DrawTreeAndGetIsland(islands, i+1, j, visited);
            DrawTreeAndGetIsland(islands, i, j-1, visited);
            DrawTreeAndGetIsland(islands, i, j+1, visited);

        }

        public static void TestStringProperty()
        {
            List<string> zText = new List<string>();
            FillString(zText);
            Debug.Print(zText.ToString());
        }

        private static void FillString(List<string> zText)
        {
            zText.Add("foo");
        }
    }
}