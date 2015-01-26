/*
 * Problem 8. Numbers from 1 to n
 *
 * Write a program that reads an integer number n from the console and prints all the numbers in the interval [1..n],
 * each on a single line.
 * Note: You may need to use a for-loop.
 */
using System;
using System.Globalization;
using System.Threading;

class NumbersFrom1ToN
{
    static void Main()
    {
        uint n;
        //config
        Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-us");      //strict-localize the program

        //user input
        Console.Write("Enter 1 positive integer number from {0} to {1}: ", 1, uint.MaxValue);
        if (! (uint.TryParse(Console.ReadLine(), out n ) && n > 0 ) )
            Console.WriteLine("Error: Invalid number.");
        
        //logic
        for (int i = 1; i <= n; Console.WriteLine(i++)) ;

        //print output (see logic)
    }
}