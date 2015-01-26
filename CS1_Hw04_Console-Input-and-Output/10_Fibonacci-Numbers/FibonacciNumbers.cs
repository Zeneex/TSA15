/*
 * Problem 10. Fibonacci Numbers
 *
 * Write a program that reads a number n and prints on the console the first n members of the Fibonacci sequence
 * (at a single line, separated by comma and space - ,) : 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, ….
 * Note: You may need to learn how to use loops.
 */
using System;
using System.Globalization;
using System.Threading;

class FibonacciNumbers
{
    static void Main()
    {
        uint n;

        //config
        Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-us");      //strict-localize the program

        //user input
        Console.Write("How many Fibonacci members do you want to generate? (from {0} to {1}): ",
            1, uint.MaxValue);
        if (!uint.TryParse(Console.ReadLine(), out n))
        { Console.WriteLine("Error: Invalid count."); return; }

        //logic + output
        for (int i = 0; i < n; i++)
            Console.Write("{0}, ", Math.Round(Math.Pow((1 + Math.Sqrt(5)) / 2, i) / Math.Sqrt(5)));
        Console.WriteLine("\b\b ");

        //print output (see logic)

        /* The formula round(ϕⁿ/√̅5), where n≥0 and ϕ=(1+√̅5)/2 (the golden ratio)
         * is the rounding variant of the closed-form expression for the n-th member
         * of the zero-based Fibonacci sequence. It generates any member F_n of the sequence
         * by rounding the approximation of its value to the nearest integer. The closed-form
         * expression calculates its value based only on the index n, as opposed to the
         * recurrence relation F_n=sum(F_n-1, F_n-2), relying on the two preceding members of F_n.
         * This eliminates the need of seek values (starting points) and recursive calculations -
         * independently can be calculated any value of F given only its member index n in the sequence.
         * However, this calculation implies use of a floating-point arithmetic and
         * is more time-consuming (as it's more complex) than the recursive formula, which
         * can operate just by 2 integer arguments. For more on the topic:
         * http://en.wikipedia.org/wiki/Fibonacci_number#Closed-form_expression
         */
    }
}