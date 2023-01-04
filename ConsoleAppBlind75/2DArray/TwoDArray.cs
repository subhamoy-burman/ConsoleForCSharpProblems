using System.Collections.Generic;

namespace ConsoleAppBlind75._2DArray
{
    public static class TwoDArray
    {
        public static int[,] MatrixMultiplication(int[,] array1, int[,] array2)
        {
            if (array2.GetLength(0) == array1.GetLength(1))
            {
                int[,] resultArray = new int[array1.GetLength(0), array2.GetLength(1)];

                for (int i = 0; i < resultArray.GetLength(0); i++)
                {
                    for (int j = 0; j < resultArray.GetLength(1); j++)
                    {
                        for (int k = 0; k < array1.GetLength(1); k++)
                        {
                            resultArray[i, j] += array1[i, k] * array2[k, j];
                        }
                    }
                }

                return resultArray;
            }
            return new int[,] {};
        }

        public static int[,] RotateBy90Degree(int[,] inputArray)
        {
            int rowCount = inputArray.GetLength(0);
            int columnCount = inputArray.GetLength(1);
            for (int i = 0; i < rowCount; i++)
            {
                for (int j = i; j < columnCount; j++)
                {
                    // ReSharper disable once SwapViaDeconstruction
                    int temp = inputArray[i, j];
                    inputArray[i, j] = inputArray[j, i];
                    inputArray[j, i] = temp;

                }
            }

            int auxColCount = columnCount;
            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < columnCount; j++)
                {
                    // ReSharper disable once SwapViaDeconstruction
                    int temp = inputArray[i, j];
                    inputArray[i, j] = inputArray[j, columnCount-1];
                    inputArray[j, columnCount-1] = temp;
                    
                }

                columnCount--;
            }

            return inputArray;
        }
        
        public static IList<int> SpiralOrder(int[,] matrix) {
        
            List<int> spiralPath = new List<int>();
        
            int minRow = 0;
            int minColumn = 0;
            int maxRow = matrix.GetLength(0);
            int maxColumn = matrix.GetLength(1);
            int printedCount = 0;
            int totalElements = matrix.GetLength(0) * matrix.GetLength(1);

            while(printedCount<totalElements)
            {
                //top wall
                for(int j= minColumn; j< maxColumn; j++ )
                {
                    int i = minRow;
                    spiralPath.Add(matrix[i,j]);
                    printedCount++;
                }

                minRow++;

                //right wall
                for( int i= minRow; i< maxRow; i++ )
                {
                    int j= maxColumn-1;
                    spiralPath.Add(matrix[i,j]);
                    printedCount++;
                }

                maxColumn--;

                //bottom wall
                for(int j= maxColumn-1; j >= minColumn; j--)
                {
                    int i= maxRow-1;
                    spiralPath.Add(matrix[i,j]);
                    printedCount++;
                }

                maxRow--;

                //left wall
                for(int i= maxRow-1; i>= minRow; i-- )
                {
                    int j = minColumn;
                    spiralPath.Add(matrix[i,j]);
                    printedCount++;
                }

                minColumn++;

            }

            return spiralPath;

        }
    }
}