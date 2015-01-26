/*
 * Problem 7. Sum of 5 Numbers
 *
 * Write a program that enters 5 numbers (given in a single line, separated by a space), calculates and prints their sum.
 */
using System;
using System.Globalization;
using System.Threading;

class SumOf5Numbers
{
    static void Main()
    {
        double sum = 0;
        string[] nums = null;

        //config
        Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-us");      //strict-localize the program

        //user input + logic
        Console.Write("Enter 5 numbers from {1:E2} to {0:E2} in a row;\nUse '.' for decimal sign and ' ' for separator: ",
            double.MaxValue, double.MinValue);
        try
        {
            nums = Console.ReadLine().Split(new char[] { ' ' }, 5 + 1, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < 5; i++)         /*it could use the array.length for comparing to eliminate the OutOfRange exception*/
                sum += double.Parse(nums[i]);
        }
        catch (FormatException ex)
        {
            Console.WriteLine("Error: {0}", ex.Message);
            return;
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine("Error: Not enaugh numbers.");
            return;
        }
        //print output (accuracy to 3 decimal places)
        Console.WriteLine("Sum = {0:0.###}", sum);
    }
}