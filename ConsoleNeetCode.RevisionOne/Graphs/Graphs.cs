using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleNeetCode.RevisionOne.DynamicProgramming;
using ConsoleNeetCode.RevisionOne.Trees;
// ReSharper disable PossibleNullReferenceException

namespace ConsoleNeetCode.RevisionOne.Graphs
{
    public class IslandIndex
    {
        public int RowIndex { get; set; }
        public int ColIndex { get; set; }
    }

    public class GridIndex : IslandIndex
    {
        
    }

    public class WordListPair
    {
        public int Index { get; set; }
        public string Word { get; set; }
    }
    
    public class GraphNode {
        public int NodeVal;
        public List<GraphNode> Neighbors;
    }
    public static class Graphs
    {
        public static int NumberOfIslandBfs(int[,] landMatrix)
        {
            int islandCount = 0;
            int rowNums = landMatrix.GetLength(0);
            int colNums = landMatrix.GetLength(1);

            bool[,] visitedMatrix = new bool[rowNums, colNums];

            Queue<IslandIndex> islandQueue = new Queue<IslandIndex>();

            for (int i = 0; i < landMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < landMatrix.GetLength(1); j++)
                {
                    if (!visitedMatrix[i, j] && landMatrix[i,j] == 1)
                    {
                        islandQueue.Enqueue(new IslandIndex(){RowIndex = i, ColIndex = j});
                        visitedMatrix[i, j] = true;
                        islandCount++;
                        PerformBfsForIsland(landMatrix,visitedMatrix,islandQueue);
                    }
                }
            }
            
            return islandCount;
        }

        private static void PerformBfsForIsland(int[,] landMatrix, bool[,] visitedMatrix, Queue<IslandIndex> queue)
        {
            while (queue.Count>0)
            {
                IslandIndex currentIndex = queue.Peek();
                queue.Dequeue();
                
                //Traverse in 8 direction from the current index
                for (int deltaRow = -1; deltaRow <= 1; deltaRow++)
                {
                    for (int deltaCol = -1; deltaCol <= 1; deltaCol++)
                    {
                        int destinationRow = currentIndex.RowIndex + deltaRow;
                        int destinationCol = currentIndex.ColIndex + deltaCol;

                        if (destinationRow >= 0 && destinationRow < landMatrix.GetLength(0)
                                                &&
                                                destinationCol >= 0 && destinationCol < landMatrix.GetLength(1)
                                                &&
                                                visitedMatrix[destinationRow, destinationCol]==false
                                                && 
                                                landMatrix[destinationRow, destinationCol] == 1)
                        {
                            queue.Enqueue(new IslandIndex(){RowIndex = destinationRow, ColIndex = destinationCol});
                            visitedMatrix[destinationRow, destinationCol] = true;
                        }
                    }
                }
            }
        }

        public static int NumberOfIslandDfs(int[,] landMatrix)
        {
            int islandCount = 0;
            int rowSize = landMatrix.GetLength(0);
            int colSize = landMatrix.GetLength(1);

            bool[,] visitedMatrix = new bool[rowSize, colSize];

            for (int i = 0; i < landMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < landMatrix.GetLength(1); j++)
                {
                    if (landMatrix[i, j] == 1 && !visitedMatrix[i, j])
                    {
                        islandCount++;
                        visitedMatrix[i, j] = true;
                        PerformDFSOnIsland(landMatrix, visitedMatrix, i, j);
                    }
                }
            }

            return islandCount;
        }

        private static void PerformDFSOnIsland(int[,] landMatrix, bool[,] visitedMatrix, int rowIndex, int colIndex)
        {
            for (int deltaRow = -1; deltaRow <= 1; deltaRow++)
            {
                for (int deltaCol = -1; deltaCol <= 1; deltaCol++)
                {
                    int destinationRow = rowIndex + deltaRow;
                    int destinationCol = colIndex + deltaCol;

                    if (destinationRow >= 0 && destinationRow < landMatrix.GetLength(0)
                                            &&
                                            destinationCol >= 0 && destinationCol < landMatrix.GetLength(1)
                                            &&
                                            visitedMatrix[destinationRow, destinationCol] == false
                                            &&
                                            landMatrix[destinationRow, destinationCol] == 1)
                    {

                        if (landMatrix[destinationRow, destinationCol] == 1 && !visitedMatrix[destinationRow, destinationCol])
                        {
                            visitedMatrix[destinationRow, destinationCol] = true;
                            PerformDFSOnIsland(landMatrix, visitedMatrix, destinationRow, destinationCol);
                        }
                    }
                }
            }
        }

        public static GraphNode CloneGraph(GraphNode node)
        {
            if (node == null)
            {
                return null;
            }   

            Dictionary<GraphNode, GraphNode> dictNodes = new Dictionary<GraphNode, GraphNode>();

            if (!dictNodes.ContainsKey(node))
            {
                dictNodes[node] = new GraphNode(){NodeVal = node.NodeVal};
                foreach(var neighbor in node.Neighbors)
                {
                    dictNodes[node].Neighbors.Add(CloneGraph(neighbor));
                }
            }

            return dictNodes[node];
        }

        public static int MaxAreaOfIsland(int[,] grid)
        {
            bool[,] visited = new bool[grid.GetLength(0),grid.GetLength(1)];
            int max = Int32.MinValue;

            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    if (grid[i, j] == 1 && !visited[i, j])
                    {
                        max = Math.Max(max, MaxAreaOfIslandDfs(grid, i, j, visited));
                    }
                }
            }

            return max;
        }

        private static int MaxAreaOfIslandDfs(int[,] grid, int rowIndex, int colIndex, bool[,] visited)
        {
            if (rowIndex >= 0 && rowIndex < grid.GetLength(0)
                              && colIndex >= 0 && colIndex < grid.GetLength(1) 
                              && grid[rowIndex,colIndex] == 1 && !visited[rowIndex, colIndex])
            {
                visited[rowIndex, colIndex] = true;
                return 1 + MaxAreaOfIslandDfs(grid, rowIndex + 1, colIndex + 1, visited) 
                         + MaxAreaOfIslandDfs(grid, rowIndex+1, colIndex, visited)
                         + MaxAreaOfIslandDfs(grid, rowIndex-1, colIndex-1, visited)
                         + MaxAreaOfIslandDfs(grid, rowIndex-1, colIndex, visited);
            }

            return 0;
        }

        public class Region
        {
            public int XMark { get; set; }
            public int YMark { get; set; }
            
        }
        public static char[,] SurroundedRegion(char[,] graph)
        {
            bool[,] visited = new bool[graph.GetLength(0), graph.GetLength(1)];

            int[] dx = {0, -1, 0, 1};
            int[] dy = {1, 0, 1, 0};
            int rowEndIndex = graph.GetLength(0) - 1;
            int colEndIndex = graph.GetLength(1) - 1;
            for (int i = 0; i <= colEndIndex; i++)
            {
                if (graph[0, i] == '0' && !visited[0, i])
                {
                    visited[0, i] = true;
                    for (int j = 0; j < 4; j++)
                    {
                        DfsSurroundedRegions(graph, 0+dx[j], i+dy[j], visited);
                    }
                }

                if (graph[rowEndIndex, i] == '0' 
                    && !visited[rowEndIndex, i])
                {
                    visited[rowEndIndex, i] = true;
                    for (int j = 0; j < 4; j++)
                    {
                        DfsSurroundedRegions(graph, rowEndIndex+dx[j], i+dy[j], visited);
                    }
                }
            }

            for (int i = 0; i <= rowEndIndex; i++)
            {
                if (graph[i, 0] == '0' && !visited[i, 0])
                {
                    visited[i, 0] = true;
                    for (int j = 0; j < 4; j++)
                    {
                        DfsSurroundedRegions(graph, i+dx[j], 0+dy[j], visited);
                    }
                }
                if (graph[i, colEndIndex] == '0' 
                    && !visited[i, colEndIndex])
                {
                    visited[i, colEndIndex] = true;
                    for (int j = 0; j < 4; j++)
                    {
                        DfsSurroundedRegions(graph, i+dx[j], colEndIndex+dy[j], visited);
                    }
                }
            }
            
            return graph;
        }

        private static void DfsSurroundedRegions(char[,] graph,int rowIndex, int colIndex,bool[,] visited)
        {   
            if (rowIndex >= 0 && rowIndex < graph.GetLength(0)
                              && colIndex >= 0 && colIndex < graph.GetLength(1) 
                              && !visited[rowIndex, colIndex] && graph[rowIndex, colIndex] == 1)
            {
                visited[rowIndex, colIndex] = true;
            }
        }

        public static int RottenOranges(int[,] grid)
        {
            return SolveRottenOranges(grid);
        }

        private static int SolveRottenOranges(int[,] grid)
        {
            //This implementation has a issue we need to Find the Max TS on each queue operation
            int rowNum = grid.GetLength(0);
            int colNum = grid.GetLength(1);
            int timeToRotOrange = 0;
            Queue<GridIndex> rottenQueue = new Queue<GridIndex>();
            bool[,] visited = new bool[rowNum, colNum];
            for (int i = 0; i < rowNum; i++)
            {
                for (int j = 0; j < colNum; j++)
                {
                    if (grid[i, j] == 2)
                    {
                        visited[i, j] = true;
                        rottenQueue.Enqueue(new GridIndex(){ RowIndex = i, ColIndex = j});
                    }
                }
            }

            int[] dx = new[] {0, 1, 0, -1};
            int[] dy = new[] {1, 0, -1, 0};

            while (rottenQueue.Count != 0)
            {
                int toBeProcessed = rottenQueue.Count;
                timeToRotOrange++;
                for (int i = 0; i < toBeProcessed; i++)
                {
                    var processed = rottenQueue.Dequeue();
                    
                    for (int j = 0; j < 4; j++)
                    {
                        if (processed.RowIndex + dx[j] < rowNum
                            &&
                            processed.ColIndex + dy[j] < colNum
                            &&
                            processed.RowIndex + dx[j] >= 0
                            &&
                            processed.ColIndex + dy[j] >= 0
                            && 
                            grid[processed.RowIndex + dx[j], processed.ColIndex + dy[j]] == 2
                            &&
                            !visited[processed.RowIndex + dx[j], processed.ColIndex + dy[j]] 
                            )
                        {
                            rottenQueue.Enqueue(new GridIndex(){ RowIndex = processed.RowIndex + dx[j], ColIndex = processed.ColIndex + dy[j]});
                            visited[processed.RowIndex + dx[j], processed.ColIndex + dy[j]] = true;
                        }
                    }
                }
            }

            //if visited count == rotten count then return timeToRotOrange else return -1
            return  timeToRotOrange;
        }

        public static string AlienDictionary(List<string> listOfStrings, int noOfAlphabets)
        {
            List<List<int>> adjList = new List<List<int>>();

            for (int i = 0; i < noOfAlphabets; i++)
            {
                adjList.Add(new List<int>());
            }
            
            for (int i = 0; i < listOfStrings.Count-1; i++)
            {
                string firstString = listOfStrings[i];
                string secondString = listOfStrings[i + 1];
                int iterationLength = Math.Min(firstString.Length, secondString.Length);
                for (int j = 0; j < iterationLength; j++)
                {
                    if (firstString[j] == secondString[j]) continue;
                    adjList[firstString[j]-'a'].Add(secondString[j]-'a');
                    break;
                }
            }

            List<int> listOfChars = SolveAlienDictionary(adjList,noOfAlphabets, new List<int>());
            string ans = "";
            foreach (int it in listOfChars)
            {
                ans = ans + (char)(it);
            }

            return ans;
        }

        private static List<int> SolveAlienDictionary(List<List<int>> adjList, int vertices, List<int> topoList)
        {
            int[] degreeArray = new int[vertices];

            for (int i = 0; i < vertices; i++)
            {
                foreach (var item in adjList[i])
                {
                    degreeArray[item]++;
                }
            }

            Queue<int> queue = new Queue<int>();

            for(int i=0; i<degreeArray.Length;i++)
            {
                if (degreeArray[i] == 0)
                {
                    queue.Enqueue(i);
                }
            }

            while (queue.Count != 0)
            {
                var elementToProcess = queue.Dequeue();
                topoList.Add(elementToProcess + 'a');
                foreach (var item in adjList[elementToProcess])
                {
                    degreeArray[item]--;
                    if(degreeArray[item] == 0)
                        queue.Enqueue(item);
                }
            }

            return topoList;
        }

        public static int WordLadder(List<string> wordList, string startWord, string targetWord)
        {
            Queue<WordListPair> pairs = new Queue<WordListPair>();
            pairs.Enqueue(new WordListPair(){ Index = 1, Word = startWord});

            while (pairs.Count>0)
            {
                var pair = pairs.Dequeue();

                if (pair.Word.Equals(targetWord)) return pair.Index;
                for (int i = 0; i < pair.Word.Length; i++)
                {
                    for (char ch = 'a'; ch <= 'z'; ch++)
                    {
                        char[] replacedCharArray = pair.Word.ToCharArray();
                        replacedCharArray[i] = ch;

                        string replacedWord = replacedCharArray.ToString();

                        if (wordList.Contains(replacedWord))
                        {
                            wordList.Remove(replacedWord);
                            pairs.Enqueue(new WordListPair(){ Index = pair.Index +1, Word = replacedWord});
                        }
                    }
                }
            }

            return 0;
        }

        public static List<string> FindItinerary(List<List<string>> listOfTickets)
        {
            Dictionary<string, SortedSet<string>> adjDictList = new Dictionary<string, SortedSet<string>>();
            List<string> ans = new List<string>();

            foreach (var item in listOfTickets)
            {
                if(adjDictList.ContainsKey(item[0]))
                {
                    adjDictList[item[0]].Add(item[1]);
                }
                else
                {
                    adjDictList[item[0]] = new SortedSet<string>() {item[1]};
                }
            }

            Stack<string> journeyStack = new Stack<string>();
            
            journeyStack.Push("JFK");

            while (journeyStack.Count>0)
            {
                var element = journeyStack.Peek();
                if (adjDictList.ContainsKey(element) && adjDictList[element].Count > 0)
                {
                    var nextDestination = adjDictList[element].FirstOrDefault();
                    if (nextDestination != null) adjDictList[element].Remove(nextDestination);
                    journeyStack.Push(nextDestination);
                }
                else
                {
                    ans.Add(journeyStack.Pop());
                }
            }

            ans.Reverse();
            return ans;
        }

        public class NodeDistancePair
        {
            public int Value { get; set; }
            public int Distance { get; set; }
        }
        
        public class GraphZeroIndexNode
        {
            public int DestinationNode { get; set; }
            public int Weight { get; set; }
        }
        
        public class DistanceComparer : IComparer<NodeDistancePair>
        {
            public int Compare(NodeDistancePair x, NodeDistancePair y)
            {
                // Compare based on the Distance property
                return x.Distance.CompareTo(y.Distance);
            }
        }
        public static int[] Dijkstra(int numOfVertices, List<List<GraphZeroIndexNode>> adjList, int source)
        {
            var pq = new PriorityQueue<NodeDistancePair, NodeDistancePair>(new DistanceComparer());

            int[] dist = new int[numOfVertices];
            for (int i = 0; i < numOfVertices; i++)
            {
                dist[i] = Int32.MaxValue;
            }

            NodeDistancePair sourceNodeDistancePair = new NodeDistancePair() {Value = source, Distance = 0};
            pq.Enqueue(sourceNodeDistancePair, sourceNodeDistancePair);

            while (pq.Count > 0)
            {
                var element = pq.Dequeue();

                for (int i = 0; i < adjList[element.Value].Count; i++)
                {
                    int edgeWeight = adjList[element.Value][i].Weight;
                    int adjNode = adjList[element.Value][i].DestinationNode;

                    if (element.Distance + edgeWeight < dist[adjNode])
                    {
                        dist[adjNode] = element.Distance + edgeWeight;
                        var nodeDistancePair = new NodeDistancePair() {Distance = dist[adjNode], Value = adjNode};
                        pq.Enqueue(nodeDistancePair, nodeDistancePair);
                        
                    }
                }
            }

            return dist;

        }
        
        public class GraphRowColDistance
        {
            public int Row { get; set; }
            public int Col { get; set; }
            public int Distance { get; set; }
        }
        
        public class EffortComparer : IComparer<GraphRowColDistance>
        {
            public int Compare(GraphRowColDistance x, GraphRowColDistance y)
            {
                // Compare based on the Distance property
                return x.Distance.CompareTo(y.Distance);
            }
        }

        public static int MinimumEffort(int[,] grid)
        {
            var pq = new PriorityQueue<GraphRowColDistance, GraphRowColDistance>(new EffortComparer());

            int row = grid.GetLength(0);
            int col = grid.GetLength(1);

            int[,] distanceArray = new int[row, col];

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    distanceArray[i,j] = Int32.MaxValue;
                }
            }

            distanceArray[0, 0] = 0;
            var initialNode = new GraphRowColDistance() {Row = 0, Col = 0, Distance = 0};
            pq.Enqueue(initialNode, initialNode);

            int[] deltaRow = new[] {-1, 0, 1, 0};
            int[] deltaCol = new[] {0, 1, 0, -1};
            
            if (pq.Count > 0)
            {
                var element = pq.Dequeue();
                int diff = element.Distance;
                int rowVal = element.Row;
                int colVal = element.Col;

                if (rowVal == row - 1 && colVal == col - 1)
                {
                    return diff;
                }

                for (int i = 0; i < 4; i++)
                {
                    int newRow = rowVal + deltaRow[i];
                    int newCol = colVal + deltaCol[i];

                    if (newRow >= 0 && newRow < row && newCol >= 0 && newCol < col)
                    {
                        int newEffort = Math.Max(Math.Abs(grid[newRow, newCol]) - Math.Abs(grid[rowVal, colVal]), diff);
                        if (newEffort < distanceArray[newRow, newCol])
                        {
                            distanceArray[newRow, newCol] = newEffort;
                        }
                    }
                }
            }

            return 0;

        }

        public static int[] BellmanFord(int vertices, List<GraphZeroIndexNode> edges, int startPoint)
        {
            int[] distanceArray = new int[vertices];

            for (int i = 0; i < distanceArray.Length; i++)
            {
                distanceArray[i] = Int32.MaxValue;
            }
            distanceArray[startPoint] = 0;

            for (int i = 0; i < vertices - 1; i++)
            {
                int index = 0;
                foreach (var item in edges)
                {
                    int start = index;
                    int destination = item.DestinationNode;
                    int weight = item.Weight;

                    if (distanceArray[start] != Int32.MaxValue &&
                        distanceArray[start] + weight < distanceArray[destination])
                    {
                        distanceArray[destination] = distanceArray[start] + weight;
                    }
                }
            }

            return distanceArray;

        }


        public class WeightNodePair
        {
            public int Weight { get; set; }
            public int Node { get; set; }
        }
        
        public class WeightComparer : IComparer<WeightNodePair>
        {
            public int Compare(WeightNodePair x, WeightNodePair y)
            {
                // Compare based on the Distance property
                return x.Weight.CompareTo(y.Weight);
            }
        }

        public static int MinCostToConnectAllPoints(List<GridIndex> points)
        {
            int N = points.Count;
            Dictionary<int, List<int[]>> adjacencyList = new Dictionary<int, List<int[]>>();

            for (int i = 0; i < N; i++)
            {
                GridIndex point = points[i];
                int xCoordinate = point.RowIndex;
                int yCoordinate = point.ColIndex;

                adjacencyList[i] = new List<int[]>();

                for (int j = i + 1; j < N; j++)
                {
                    GridIndex pointToConnect = points[j];
                    int dist = Math.Abs(xCoordinate - pointToConnect.RowIndex) +
                               Math.Abs(yCoordinate - pointToConnect.ColIndex);
                    
                    adjacencyList[i].Add(new int[]{ dist, j});
                    adjacencyList[j].Add(new []{ dist, i});
                }
            }

            int sum = 0;

            PriorityQueue<WeightNodePair, WeightNodePair> pq = new PriorityQueue<WeightNodePair, WeightNodePair>( new WeightComparer());
            WeightNodePair weightNodePair = new WeightNodePair() {Node = 0, Weight = 0};
            pq.Enqueue(weightNodePair,weightNodePair);

            int[] visited = new int[N];

            while (pq.Count>0)
            {
                var minElement = pq.Dequeue();

                if (visited[minElement.Node] != 1)
                {
                    sum += minElement.Weight;
                    visited[minElement.Node] = 1;
                    foreach (var item in adjacencyList[minElement.Node])
                    {
                        if (visited[item[1]] != 1)
                        {
                            var weightPairNode = new WeightNodePair() {Weight = item[0], Node = item[1]};
                            pq.Enqueue(weightPairNode, weightPairNode);
                        }
                    }
                }

            }

            return sum;
        }

        public class Node
        {
            public int NodeIndex { get; set; }
            public int DestinationNodeIndex { get; set; }
            public int Weight { get; set; }

            public Node(int u, int v, int w)
            {
                NodeIndex = u;
                DestinationNodeIndex = v;
                Weight = w;
            }
        }

        public class SortComparer : IComparer<Node>
        {
            public int Compare(Node x, Node y)
            {
                if (x.Weight < y.Weight)
                {
                    return -1;
                }

                if (x.Weight > y.Weight)
                {
                    return 1;
                }

                return 0;
            }
        }
        
        private static int FindPar(int u, int[] parent)
        {
            if (u == parent[u]) return u;
            return parent[u] = FindPar(parent[u], parent);
        }

        private static void Union(int u, int v, int[] parent, int[] rank)
        {
            u = FindPar(u, parent);
            v = FindPar(v, parent);
            if (rank[u] < rank[v])
            {
                parent[u] = v;
            }
            else if (rank[v] < rank[u])
            {
                parent[v] = u;
            }
            else
            {
                parent[v] = u;
                rank[u]++;
            }
        }

        public static List<Node> Kruskal(List<Node> adjMatrix, int N)
        {
            adjMatrix.Sort(new SortComparer());

            int[] parent = new int[N];
            int[] rank = new int[N];

            for (int i = 0; i < N; i++)
            {
                parent[i] = i;
                rank[i] = 0;
            }

            int costMst = 0;
            List<Node> mst = new List<Node>();

            foreach (var item in adjMatrix)
            {
                if (FindPar(item.NodeIndex, parent) != FindPar(item.DestinationNodeIndex, parent))
                {
                    costMst = costMst + item.Weight;
                    mst.Add(item);
                    Union(item.NodeIndex, item.DestinationNodeIndex, parent, rank);
                }
            }
            
            Console.WriteLine(costMst);

            foreach (var item in mst)
            {
                Console.WriteLine(item.NodeIndex + " - " + item.DestinationNodeIndex);
            }

            return mst;
        }

        public static int NumberOfConnectedComponents(List<Tuple<int,int>> listOfInput, int N)
        {    
            int[] parent = new int[N];
            int[] rank = new int[N];

            for (int i = 0; i < N; i++)
            {
                parent[i] = i;
                rank[i] = 0;
            }

            foreach (var item in listOfInput)
            {
                Union(item.Item1,item.Item2, parent, rank);
            }
            
            Console.WriteLine();
            return -1;
        }

    }
}