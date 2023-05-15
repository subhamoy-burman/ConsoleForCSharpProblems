using System.Collections.Generic;

namespace ConsoleNeetCode.RevisionOne.Graphs
{
    public class IslandIndex
    {
        public int RowIndex { get; set; }
        public int ColIndex { get; set; }
        
        
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
    }
}