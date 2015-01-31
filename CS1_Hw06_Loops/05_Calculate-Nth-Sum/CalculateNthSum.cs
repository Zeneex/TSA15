/*
 * Problem 5. Calculate 1 + 1!/X + 2!/X^2 + … + N!/X^N
 *
 * Write a program that, for a given two integer numbers n and x, calculates the sum S = 1 + 1!/x + 2!/x2 + … + n!/x^n.
 * Use only one loop. Print the result with 5 digits after the decimal point.
 */
using System;

class CalculateNthSum
{
    static void Main()
    {
        Console.Write("Enter 1 positive number for N, than 1 integer number for X (other than 0): ");

        for (decimal                                //total work-around :)
            n = decimal.Parse(Console.ReadLine()),
            x = decimal.Parse(Console.ReadLine()),
            sum = 0,
            factorial = 1,
            power = 1,
            i = 0;
            i <= n && x != 0;
            i++,
            Console.Write("{0:F5}\r", sum += factorial/power)       //slows down the proccessing a lot
            )
            if(i != 0)
            {
		        factorial *= i;
                power *= x;
            }
        Console.WriteLine();
    }
}