using System.Collections.Generic;
using ConsoleAppBlind75.Graph;
using NUnit.Framework;

namespace Blind75.Test.GraphTests
{
    [TestFixture]
    public class GraphTests
    {
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
        
        public List<List<GraphCSharp>> GetFullGraph2()
        {
            var graph = new List<List<GraphCSharp>>();
            
            graph.Insert(0,new List<GraphCSharp>()
            {
                new(0, 1, 10),
                
            });
            
            
            graph.Insert(1,new List<GraphCSharp>()
            {
                new(1,0,10)
            });
            
            graph.Insert(2,new List<GraphCSharp>()
            {
                new(2, 3, 10),
            });
            
            graph.Insert(3,new List<GraphCSharp>()
            {
                new(3,2,10),
            });
            
            
            graph.Insert(4,new List<GraphCSharp>()
            {
                new(4, 5, 10),
                new(4, 6, 10),
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

        public int[,] CreateFullIsland()
        {
            int[,] fullIsland = new[,]
            {
                {0, 0, 1, 1, 1, 1, 1, 1},
                {0, 0, 1, 1, 1, 1, 1, 1},
                {1, 1, 1, 1, 1, 1, 1, 0},
                {1, 1, 0, 0, 0, 1, 1, 0},
                {1, 1, 1, 1, 0, 1, 1, 0},
                {1, 1, 1, 1, 0, 1, 1, 0},
                {1, 1, 1, 1, 1, 1, 1, 0},
                {1, 1, 1, 1, 1, 1, 1, 0}
            };

            return fullIsland;
        }
        
        [Test]
        public void TestHasPath()
        {
            bool hasPath = GraphPrograms.HasPath(GetFullGraph(), 1, 6);
        }
        
        [Test]
        public void TestPrintAllPath()
        {
             GraphPrograms.PrintAllPaths(GetFullGraph(), "0",  0, 6, new bool[7]);
        }

        [Test]
        public void TestOneString()
        {
            GraphPrograms.TestStringProperty();
        }

        [Test]
        public void TestGetConnectedComponents()
        {
            GraphPrograms.GetConnectedComponents(GetFullGraph2(),0,new bool[7],string.Empty);
        }

        [Test]
        public void GetNumberOfIslands()
        {
            GraphPrograms.GetNumberOfIslands(CreateFullIsland());
        }
    }
}