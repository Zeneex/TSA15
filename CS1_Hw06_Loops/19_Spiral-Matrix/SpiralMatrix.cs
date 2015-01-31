/*
 * Problem 19.** Spiral Matrix
 *
 * Write a program that reads from the console a positive integer number n (1 ≤ n ≤ 20) and prints a matrix
 * holding the numbers from 1 to n*n in the form of square spiral like in the example below.
 *
 *  n = 4   matrix
 *          1  2  3  4
 *          12 13 14 5
 *          11 16 15 6
 *          10 9  8  7
 */
using System;

class SpiralMatrix
{
    static void Main()
    {
        Console.Write("Set the size of a square spiral matrix (from 1 to 20): ");
        int n = int.Parse(Console.ReadLine());
        if (n < 1 || n > 20)
        {
            Console.WriteLine("Error: Invalid size.");
            return;
        }
        int[,] matrix = new int[n,n];
        int a = 1;
        int c = -1;
        int r = -1;
        int l = n;
        int m;
        while (l > 0)                                   //the brute-force way; there must be more intelligent one
        {
            for (m = 0, r++, c++; m < l; m++, c++, a++)
            {
                matrix[r, c] = a;
            }
            for (m = 0, r++, c--, l--; m < l; m++, r++, a++)
            {
                matrix[r, c] = a;
            }
            for (m = 0, r--, c--; m < l; m++, c--, a++)
            {
                matrix[r, c] = a;
            }
            for (m = 0, c++, r--, l--; m < l; m++, r--, a++)
            {
                matrix[r, c] = a;
            }
        }
        string formatstring = "{0, -" + ((n*n).ToString().Length + 1) + "}";
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(formatstring, matrix[i, j]);
            }
            Console.WriteLine();
        }
    }
}