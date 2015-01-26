/*
 * Problem 4. Number Comparer
 *
 * Write a program that gets two numbers from the console and prints the greater of them.
 * Try to implement this without if statements.
 */
using System;
using System.Globalization;
using System.Threading;

class NumberComparer
{
    static void Main()
    {
        double a, b;

        //config
        Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-us");      //strict-localize the program

        //user input
        Console.WriteLine("Enter 2 numbers from {1:E2} to {0:E2} (use '.' for decimal sign): ",
            double.MaxValue, double.MinValue);
        if ( !( double.TryParse(Console.ReadLine(), out a) && double.TryParse(Console.ReadLine(), out b) ) )
        {
            Console.WriteLine("Error: Invalid number.");
            return;
        } /* the 'if' here is for validation purpose only, not for logic */

        //logic (see output)

        //print output
        Console.WriteLine("maximum = {0}", ( a + b + Math.Abs(a - b) ) / 2);
        /*
         * because the sum(a, b) is 2 times max(a, b) - diff(a, b)      =>
         * sum(a, b) + diff(a, b) all divided by 2 is the max(a, b)
         */
    }
}