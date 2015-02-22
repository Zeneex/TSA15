/*
 * Problem 2. Maximal sum
 *
 * Write a program that reads a rectangular matrix of size N x M
 * and finds in it the square 3 x 3 that has maximal sum of its elements.
 */
using System;

class MaximalSum
{
    public static void ConsolePrintMatrix(int[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write("{0, 4}", matrix[row, col]);
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
    public static void ConsolePrintSubmatrix(int[,] matrix, long startRow, long startCol, long width, long height)
    {
        for (long row = startRow; row < height + startRow; row++)
        {
            for (long col = startCol; col < width + startCol; col++)
            {
                Console.Write("{0, 4}", matrix[row, col]);
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
    static void Main()
    {
        //input
        Console.Write("Enter matrix' width (as integer > 0): ");
        int m = int.Parse(Console.ReadLine());
        Console.Write("Enter matrix' height (as integer > 0): ");
        int n = int.Parse(Console.ReadLine());

        //allocate matrix memory space
        int[,] imMatrix = new int[n, m];

        //define matrix elements
        Console.WriteLine("Enter matrix' elements (as numbers from {0} to {1}):", int.MinValue, int.MaxValue);
        for (int row = 0; row < imMatrix.GetLength(0); row++)
        {
            for (int col = 0; col < imMatrix.GetLength(1); col++)
            {
                Console.Write("matrix[{0}, {1}] = ", row, col);
                imMatrix[row, col] = int.Parse(Console.ReadLine());
            }
        }

        //logic
        #region test block
        /*
        int[,] imMatrix =
        {
            { 5,  6,  7,  2,  3,  9,  8,  1, 10},
            { 4, 20,  5, 64,  2,  9, 87,  3,  5},
            { 9, 65, 21, 45, 35,  7,  6,  4,  1},
            {10, 10, 10, 10, 10, 10, 10, 10, 10},
            { 1,  1, 30,  1,  1, -2,  1,  1, 35},
            { 5,  3,  7,  6,  8,  4,  9,  2,300}
        };
        
        int n = imMatrix.GetLength(0);
        int m = imMatrix.GetLength(1);
        */
        #endregion

        int platformWidth = 3;
        int platformHeight = 3;

        long currentSum = 0;
        long maximalSum = long.MinValue;
        long maximalPlatformStartRow = 0;
        long maximalPlatformStartCol = 0;

        for (int row = 0; row <= n - platformHeight; row++)
        {
            for (int col = 0; col <= m - platformWidth; col++, currentSum = 0)
            {
                for (int platformRow = row; platformRow < platformHeight + row; platformRow++)
                {
                    for (int platformCol = col; platformCol < platformWidth + col; platformCol++)
                    {
                        currentSum += imMatrix[platformRow, platformCol];
                    }
                }
                if (currentSum > maximalSum)
                {
                    maximalSum = currentSum;
                    maximalPlatformStartRow = row;
                    maximalPlatformStartCol = col;
                }
            }
        }

        //print
        Console.WriteLine("matrix:");
        ConsolePrintMatrix(imMatrix);
        Console.WriteLine("maximal platform");
        ConsolePrintSubmatrix(imMatrix, maximalPlatformStartRow, maximalPlatformStartCol, platformWidth, platformHeight);
        Console.WriteLine("maximal platform sum = {0}", maximalSum);
    }
}