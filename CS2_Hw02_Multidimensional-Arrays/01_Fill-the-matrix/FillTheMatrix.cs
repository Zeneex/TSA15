/*
 * Problem 1. Fill the matrix
 *
 * Write a program that fills and prints a matrix of size (n, n) as shown below:
 * 
 * Example for n=4:
 * 
 * a)               |  b)               |  c)               |  d)*
 * 1 	5 	9 	13  |  1 	8 	9 	16  |  7 	11 	14 	16  |  1    12 	11 	10
 * 2 	6 	10 	14  |  2 	7 	10 	15  |  4 	8 	12 	15  |  2 	13 	16 	9
 * 3 	7 	11 	15  |  3 	6 	11 	14  |  2 	5 	9 	13  |  3 	14 	15 	8
 * 4 	8 	12 	16  |  4 	5 	12 	13  |  1 	3 	6 	10  |  4 	5 	6 	7
 */
using System;

class FillTheMatrix
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
    static void Main()
    {
        //input
        Console.Write("Enter square matrix size: ");
        int n = int.Parse(Console.ReadLine());

        //allocate matrix memory space
        int[,] imMatrix = new int[n, n];

        //logic - case a
        for (int col = 0; col < n; col++)
        {
            for (int row = 0; row < n; row++)
            {
                imMatrix[row, col] = row + 1 + col * n;
            }
        }

        //print - case a
        ConsolePrintMatrix(imMatrix);

        //logic - case b
        for (int col = 0; col < n; col++)
        {
            if (col % 2 == 0)
            {
                for (int row = 0; row < n; row++)
                {
                    imMatrix[row, col] = row + 1 + col * n;
                }
            }
            else
            {
                for (int row = n - 1; row >= 0; row--)
                {
                    imMatrix[row, col] = n - row + col * n;
                }
            }
        }

        //print - case b
        ConsolePrintMatrix(imMatrix);

        //logic - case c
        int number = 0;
        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col <= row; col++, number++)
            {
                imMatrix[n - 1 - row + col, col] = number + 1;
            }
        }
        for (int col = 1; col < n; col++)
        {
            for (int row = 0; row <= n - 1 - col; row++, number++)
            {
                imMatrix[row, col + row] = number + 1;
            }
        }

        //print - case c
        ConsolePrintMatrix(imMatrix);

        //logic - case d
        number = 1;
        int c = -1;     //the matrix current column
        int r = -1;     //the matrix current row
        int m;          //number of steps in one direction
        while (n > 0)
        {
            //direction = down, col = left, steps = 0 to n, increment = row
            for (m = 0, r++, c++; m < n; m++, r++, number++)
            {
                imMatrix[r, c] = number;
            }
            //direction = right, row = bottom, n - 1, steps = 0 to n, increment = column
            for (m = 0, r--, c++, n--; m < n; m++, c++, number++)
            {
                imMatrix[r, c] = number;
            }
            //direction = up, col = right, steps = 0 to n, decrement = row
            for (m = 0, c--, r--; m < n; m++, r--, number++)
            {
                imMatrix[r, c] = number;
            }
            //direction = left, row = top, n - 1, steps = 0 to n, decrement = column
            for (m = 0, r++, c--, n--; m < n; m++, c--, number++)
            {
                imMatrix[r, c] = number;
            }
        }

        //print - case d
        ConsolePrintMatrix(imMatrix);
    }
}