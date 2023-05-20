using System;
using System.Collections.Generic;

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
    }
}