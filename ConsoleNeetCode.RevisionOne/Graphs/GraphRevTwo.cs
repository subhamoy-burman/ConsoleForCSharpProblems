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
}