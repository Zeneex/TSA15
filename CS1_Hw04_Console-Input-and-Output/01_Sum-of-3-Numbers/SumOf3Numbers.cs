/*
 * Problem 1. Sum of 3 Numbers
 *
 * Write a program that reads 3 real numbers from the console and prints their sum.
 */
using System;
using System.Globalization;
using System.Threading;

class SumOf3Numbers
{
    static void Main()
    {
        double sum = 0;

        //config
        Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-us");      //strict-localize the program

        //user input + logic
        Console.WriteLine("Enter 3 numbers to get their sum (use '.' for decimal sign):");

        try
        {
            for (int i = 0; i < 3; i++)
                sum += double.Parse(Console.ReadLine());
        }
        catch (FormatException ex)
        {
            Console.WriteLine("Error: {0}", ex.Message);
            return;
        }

        //print output (accuracy to 3 decimal places)
        Console.WriteLine("Sum = {0:0.###}", sum);
    }
}