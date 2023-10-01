using System;
using System.Collections.Generic;

namespace ConsoleNeetCode.RevisionOne.Graphs;

public static class GraphRevTwo
{

    public static char[,] SurroundedRegion(char[,] inputMatrix)
    {
        int rowLength = inputMatrix.GetLength(0);
        int colLength = inputMatrix.GetLength(1);
        bool[,] visitedMatrix = new bool[rowLength,colLength];
        
        for (int i = 0; i < colLength; i++)
        {
            //Process First Row
            if (inputMatrix[0, i] == 'O' && visitedMatrix[0, i] == false)
            { 
                RegionDfs(0, i, inputMatrix, visitedMatrix);
            }
            
            //Process Last Row
            if (inputMatrix[rowLength - 1, i] == 'O' && visitedMatrix[rowLength - 1, i] == false)
            {
                RegionDfs(rowLength - 1, i, inputMatrix, visitedMatrix);
            }
        }

        for (int j = 0; j < rowLength; j++)
        {
            //Process first column
            if (inputMatrix[j, 0] == 'O' && visitedMatrix[j, 0] == false)
            {
                RegionDfs(j,0,inputMatrix, visitedMatrix);
            }
            
            //Process last column
            if (inputMatrix[j, colLength - 1] == 'O' && visitedMatrix[j, colLength - 1] == false)
            {
                RegionDfs(j, colLength-1, inputMatrix, visitedMatrix);
            }
        }

        return inputMatrix;
    }

    private static void RegionDfs(int rowMove, int colMove, char[,] inputMatrix, bool[,] visitedMatrix)
    {
        visitedMatrix[rowMove, colMove] = true;
        
        int[] dx = new[] {1, 0, -1, 0};
        int[] dy = new[] {0, 1, 0, -1};

        for (int m = 0; m < 4; m++)
        {
            var newRow = rowMove + dx[m];
            var newCol = colMove + dy[m];
            
            if (IsMovementValid(newRow,newCol , inputMatrix.GetLength(0), inputMatrix.GetLength(1))
                &&
                !visitedMatrix[newRow,newCol] 
                &&
                inputMatrix[newRow, newCol] == 'O' )
            {
                RegionDfs(newRow, newCol, inputMatrix, visitedMatrix);
            }
        }
        
    }

    private static bool IsMovementValid(int i, int j, int rows, int cols)
    {
        if (i < 0 || j < 0 || i >= rows || j >= cols) return false;
        return true;
    }

    public class PairIndex
    {
        public int RowIndex { get; set; }
        public int ColIndex { get; set; }
        
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            PairIndex other = (PairIndex)obj;
            return RowIndex == other.RowIndex && ColIndex == other.ColIndex;
        }
    }

    public static int NumberOfDistinctIslands(int[,] inputMatrix)
    {
        int rowLength = inputMatrix.GetLength(0);
        int colLength = inputMatrix.GetLength(1);
        bool[,] visited = new bool[rowLength, colLength];
        HashSet<List<PairIndex>> pairIndices = new HashSet<List<PairIndex>>();

        for (int i = 0; i < rowLength; i++)
        {
            for (int j = 0; j < colLength; j++)
            {
                if (!visited[i, j] && inputMatrix[i, j] == 1)
                {
                    List<PairIndex> listOfNodes = new List<PairIndex>();
                    DistinctIslandDFS(inputMatrix, visited, listOfNodes, i, j, i, j);
                    pairIndices.Add(listOfNodes);
                }
            }
        }

        return pairIndices.Count;
    }

    private static void DistinctIslandDFS(int[,] inputMatrix, bool[,] visited, List<PairIndex> pairIndices, int rowIndex, int colIndex, 
        int baseRowIndex, int baseColIndex)
    {
        int[] dx = new[] {1, 0, -1, 0};
        int[] dy = new[] {0, 1, 0, -1};

        visited[rowIndex, colIndex] = true;
        pairIndices.Add(new PairIndex() {RowIndex = rowIndex - baseRowIndex, ColIndex = colIndex - baseColIndex});
        
        for (int i = 0; i < 4; i++)
        {
            int newRow = rowIndex + dx[i];
            int newCol = colIndex + dy[i];

            if (newRow >= 0 && newCol >= 0 &&
                newRow < inputMatrix.GetLength(0) && newCol < inputMatrix.GetLength(1) 
                && !visited[newRow, newCol] && inputMatrix[newRow,newCol]==1)
            {
                DistinctIslandDFS(inputMatrix, visited, pairIndices, newRow, newCol, rowIndex, colIndex);
            }
        }
    }

    public class Pair
    {
        public int node;
        public int distance;

        public Pair(int distance, int node)
        {
            this.node = node;
            this.distance = distance;
        }
    }

    public static List<int> Dijkstra(int V, List<List<List<int>>> adjList, int source)
    {
        PriorityQueue<Pair, int> pq = new PriorityQueue<Pair, int>();
        List<int> distances = new List<int>();
        
        // Initializing distTo list with a large number to
        // indicate the nodes are unvisited initially.
        // This list contains distance from source to the nodes.
        for (int i = 0; i < V; i++)
        {
            distances.Add((int) (1e9));
        }

        distances[source] = 0;
        pq.Enqueue(new Pair(0,source),0);

        while (pq.Count!=0)
        {
            var currNode = pq.Dequeue();
            int node = currNode.node;
            int distance = currNode.distance;

            for (int i = 0; i < adjList[node].Count; i++)
            {
                int edgeWeight = adjList[node][i][1];
                int adjNode = adjList[node][i][0];

                if ((distance + edgeWeight) < distances[adjNode])
                {
                    distances[adjNode] = distance + edgeWeight;
                    pq.Enqueue(new Pair(distances[adjNode],adjNode),distances[adjNode]);
                }
            }
        }

        return distances;
    }


    //public static bool CheckForCycle
}