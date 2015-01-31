/*
 * Problem 9. Matrix of Numbers
 *
 * Write a program that reads from the console a positive integer number n (1 ≤ n ≤ 20)
 * and prints matrix like in the example below. Use two nested loops.
 *  n = 4  matrix
 *  1 2 3 4
 *  2 3 4 5
 *  3 4 5 6
 *  4 5 6 7
 */
using System;

class MatrixOfNumbers
{
    static void Main()
    {
        Console.Write("Enter a positive matrix range, from 1 to 20: ");
        int n = int.Parse(Console.ReadLine());
        if (n < 1 || n > 20)
        {
            Console.WriteLine("Error: Invalid numbers.");
            return;
        }

        for (int row = 1; row <= n; row++)
        {
            for (int col = row; col <= n + row - 1; col++)
            {
                Console.Write(col + " ");
            }
            Console.WriteLine();
        }
    }
}