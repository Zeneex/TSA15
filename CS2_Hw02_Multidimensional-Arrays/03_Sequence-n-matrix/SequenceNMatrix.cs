/*
 * Problem 3. Sequence n matrix
 *
 * We are given a matrix of strings of size N x M. Sequences in the matrix we define as
 * sets of several neighbour elements located on the same line, column or diagonal.
 * Write a program that finds the longest sequence of equal strings in the matrix.
 * 
 * Examples:
 * 
 *  matrix               result      matrix    result
 *  --------------------+-----------+---------+------
 *  ha   fifi ho   hi   |ha, ha, ha |s  qq s  |s, s, s
 *  fo   ha   hi   xx   |           |pp pp s  |
 *  xxx  ho   ha   xx   |           |pp qq s  |
 */
using System;
using System.Collections.Generic;

class SequenceNMatrix
{
    public static void ConsolePrintMatrix(string[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write("{0} ", matrix[row, col]);
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
        string[,] imMatrix = new string[n, m];

        //define matrix elements
        Console.WriteLine("Enter matrix' elements (as strings):");
        for (int row = 0; row < imMatrix.GetLength(0); row++)
        {
            for (int col = 0; col < imMatrix.GetLength(1); col++)
            {
                Console.Write("matrix[{0}, {1}] = ", row, col);
                imMatrix[row, col] = Console.ReadLine();
            }
        }

        //logic
        #region test block
        /*
        int[,] imMatrix =
        {
            { 5,  0,  1,  0,  1,  0,  1,  0,  1},
            { 1,  5,  0,  0, 10,  0,  1,  0,  1},
            { 1,  0,  2, 10,  1,  0,  1,  0,  2},
            {10, 10, 10,  5, 10, 10, 10, 10,  1},
            { 1, 10, 30,  0,  5,  0,  1,  0,  1},
            {10,  0,  1,  0,  1,  5,  1,  0,  2}
        };
        
        int n = imMatrix.GetLength(0);
        int m = imMatrix.GetLength(1);
        */
        #endregion

        List<string> currentSequence = new List<string>();
        List<string> maximalSequence = new List<string>();

        //crawl the main matrix
        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < m; col++)
            {
                //peek rightward and see if the next element is equal, starting at the current element
                int sequenceRow = row;
                int sequenceCol = col;
                currentSequence.Clear();
                currentSequence.Add(imMatrix[sequenceRow, sequenceCol]);
                while (sequenceCol + 1 < m && imMatrix[sequenceRow, sequenceCol + 1] == imMatrix[sequenceRow, sequenceCol])
                {
                    currentSequence.Add(imMatrix[sequenceRow, sequenceCol + 1]);
                    sequenceCol++;
                }
                if (currentSequence.Count > maximalSequence.Count)
                {
                    maximalSequence.Clear();
                    foreach (var element in currentSequence)
                    {
                        maximalSequence.Add(element);
                    }
                }
                //peek downward and see if the next element is equal, starting at the current element
                sequenceRow = row;
                sequenceCol = col;
                currentSequence.Clear();
                currentSequence.Add(imMatrix[sequenceRow, sequenceCol]);
                while (sequenceRow + 1 < n && imMatrix[sequenceRow + 1, sequenceCol] == imMatrix[sequenceRow, sequenceCol])
                {
                    currentSequence.Add(imMatrix[sequenceRow + 1, sequenceCol]);
                    sequenceRow++;
                }
                if (currentSequence.Count > maximalSequence.Count)
                {
                    maximalSequence.Clear();
                    foreach (var element in currentSequence)
                    {
                        maximalSequence.Add(element);
                    }
                }
                //peek matrix diagonal (135°) and see if the next element is equal, starting at the current element
                sequenceRow = row;
                sequenceCol = col;
                currentSequence.Clear();
                currentSequence.Add(imMatrix[sequenceRow, sequenceCol]);
                while (sequenceRow + 1 < n && sequenceCol + 1 < m && imMatrix[sequenceRow + 1, sequenceCol + 1] == imMatrix[sequenceRow, sequenceCol])
                {
                    currentSequence.Add(imMatrix[sequenceRow + 1, sequenceCol + 1]);
                    sequenceRow++;
                    sequenceCol++;
                }
                if (currentSequence.Count > maximalSequence.Count)
                {
                    maximalSequence.Clear();
                    foreach (var element in currentSequence)
                    {
                        maximalSequence.Add(element);
                    }
                }
                //peek matrix diagonal (45°) and see if the next element is equal, starting at the current element
                sequenceRow = row;
                sequenceCol = col;
                currentSequence.Clear();
                currentSequence.Add(imMatrix[sequenceRow, sequenceCol]);
                while (sequenceRow + 1 < n && sequenceCol - 1 >= 0 && imMatrix[sequenceRow + 1, sequenceCol - 1] == imMatrix[sequenceRow, sequenceCol])
                {
                    currentSequence.Add(imMatrix[sequenceRow + 1, sequenceCol - 1]);
                    sequenceRow++;
                    sequenceCol--;
                }
                if (currentSequence.Count > maximalSequence.Count)
                {
                    maximalSequence.Clear();
                    foreach (var element in currentSequence)
                    {
                        maximalSequence.Add(element);
                    }
                }
            }
        }

        //print
        Console.WriteLine("matrix:");
        ConsolePrintMatrix(imMatrix);
        Console.WriteLine("longest sequence: {0}", string.Join(", ", maximalSequence));
    }
}