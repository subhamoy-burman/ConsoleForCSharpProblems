using System.Collections.Generic;

namespace ConsoleAppBlind75.Graph
{
    public class GraphCSharp
    {
        private int Source { get; set; }
        private int Neighbour { get; set; }
        private int Weight { get; set; }

        public GraphCSharp(int source, int neighbour, int weight)
        {
            Source = source;
            Neighbour = neighbour;
            Weight = weight;
        }

        public List<List<GraphCSharp>> GetFullGraph()
        {
            var graph = new List<List<GraphCSharp>>();
            
            graph.Insert(0,new List<GraphCSharp>()
            {
                new(0, 1, 10),
                new(0,3,10)
            });
            
            
            graph.Insert(1,new List<GraphCSharp>()
            {
                new(1, 2, 10),
                new(1,0,10)
            });
            
            graph.Insert(2,new List<GraphCSharp>()
            {
                new(2, 3, 10),
                new(2,1,10)
            });
            
            graph.Insert(3,new List<GraphCSharp>()
            {
                new(3, 4, 10),
                new(3,2,10),
                new(3,0,10)
            });
            
            
            graph.Insert(4,new List<GraphCSharp>()
            {
                new(4, 5, 10),
                new(4, 6, 10),
                new (4,3,10)
            });
            
            graph.Insert(5,new List<GraphCSharp>()
            {
                new(5, 6, 10),
                new(5,4,10)
            });
            
            graph.Insert(6,new List<GraphCSharp>()
            {
                new(6, 4, 10),
                new(6,5,10)
            });

            return graph;
        }

        public bool HasPath(List<List<GraphCSharp>> graph, int source, int destination)
        {
            if (source == destination)
            {
                return true;
            }

            foreach (var item in graph[source])
            {
                if (item.Neighbour == source)
                {
                    return true;
                }

                return HasPath(graph, item.Neighbour, destination);
            }

            return false;
        }
    }
}