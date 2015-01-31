/*
 * Problem 3. Min, Max, Sum and Average of N Numbers
 *
 * Write a program that reads from the console a sequence of n integer numbers
 * and returns the minimal, the maximal number, the sum and the average of all numbers
 * (displayed with 2 digits after the decimal point).
 * The input starts by the number n (alone in a line) followed by n lines, each holding an integer number.
 */
using System;

class MinMaxSumAndAverageOfNNumbers
{
    static void Main()
    {
        int minimum, maximum, sum, n, i;
        minimum = maximum = sum = 0;

        Console.Write("Enter a positive count: ");
        for (i = 1, n = int.Parse(Console.ReadLine()); i <= n; i++)
        {
            Console.Write("Enter integer number: ");
            int inputNumber = int.Parse(Console.ReadLine());
            if (i != 1) //compare if assigned
            {
                if (inputNumber < minimum)
                    minimum = inputNumber;
                if (inputNumber > maximum)
                    maximum = inputNumber;
            }
            else //assign if first iteration
                minimum = maximum = inputNumber;
            sum += inputNumber;
        }
        Console.WriteLine("min = {0}\nmax = {1}\nsum = {2}\navg = {3:0.00}", minimum, maximum, sum, (double)sum / n);
    }
}
