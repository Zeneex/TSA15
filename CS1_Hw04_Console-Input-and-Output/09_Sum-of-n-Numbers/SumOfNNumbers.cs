/*
 * Problem 9. Sum of n Numbers
 *
 * Write a program that enters a number n and after that enters more n numbers and calculates and prints their sum.
 * Note: You may need to use a for-loop.
 */
using System;
using System.Globalization;
using System.Threading;

class SumOfNNumbers
{
    static void Main()
    {
        uint n = 0;
        double sum = 0;

        //config
        Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-us");      //strict-localize the program

        //user input + logic
        Console.Write("How many numbers you want to sum (form {0} to {1}): ", 1, uint.MaxValue);
        if (!(uint.TryParse(Console.ReadLine(), out n) && n > 0))
            Console.WriteLine("Error: Invalid count.");
        else
        {
            Console.WriteLine("Enter {0} numbers to get their sum (use '.' for decimal sign): ", n);
            try {
                for (; n > 0; n--, sum += double.Parse(Console.ReadLine())) ; }
            catch (FormatException ex) {
                Console.WriteLine("Error: {0}", ex.Message); }

            //logic

            //print output (accuracy to 3 decimal places)
            Console.WriteLine("Sum = {0:0.###}", sum);
        }
    }
}