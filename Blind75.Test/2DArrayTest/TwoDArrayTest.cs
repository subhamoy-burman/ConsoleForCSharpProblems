using ConsoleAppBlind75._2DArray;
using NUnit.Framework;

namespace Blind75.Test._2DArrayTest
{
    [TestFixture]
    public class TwoDArrayTest
    {
        [Test]
        public void MatrixMultiplicationTester()
        {
            int[,] array1 = new int[,]
            {
                {10, 0, 0},
                {0, 1, 20}
            };

            int[,] array2 = new int[,]
            {
                {10,1,1,1},
                {20,1,1,1},
                {3,2,0,30}

            };
            var resultMatrix = TwoDArray.MatrixMultiplication(array1, array2);
        }

        [Test]
        public void TestRotateArray()
        {
            int[,] inputArray = new int[,]
            {
                {1, 2, 3, 4},
                {5, 6, 7, 8},
                {9, 10, 11, 12},
                {13, 14, 15, 16}
            };

            var result = TwoDArray.RotateBy90Degree(inputArray);
        }

        [Test]
        public void TestSpiralMatrix()
        {
            int[,] inputArray = new int[,]
            {
                {1, 2, 3},
                {4, 5, 6},
                {7, 8, 9}
            };
            
            var result = TwoDArray.SpiralOrder(inputArray);
        }
    }
}