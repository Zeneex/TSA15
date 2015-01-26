/*
 * Problem 5. Formatting Numbers
 *
 * Write a program that reads 3 numbers:
 *     integer a (0 <= a <= 500)
 *     floating-point b
 *     floating-point c
 * The program then prints them in 4 virtual columns on the console. Each column should have a width of 10 characters.
 *     The number a should be printed in hexadecimal, left aligned
 *     Then the number a should be printed in binary form, padded with zeroes
 *     The number b should be printed with 2 digits after the decimal point, right aligned
 *     The number c should be printed with 3 digits after the decimal point, left aligned.
 */
using System;
using System.Globalization;
using System.Threading;

class FormattingNumbers
{
    static void Main()
    {
        uint a;
        double b, c;

        //config
        Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-us");      //strict-localize the program

        //user input
        Console.Write("Enter 1 number from 0 to 500 (use '.' for decimal sign): ");
        if (!(uint.TryParse(Console.ReadLine(), out a) && a <= 500))
        {
            Console.WriteLine("Error: Invalid number.");
            return;
        }
        Console.WriteLine("Enter 2 numbers from {0:E2} to {1:E2} (use '.' for decimal sign): ",
            double.MinValue, double.MaxValue);
        if (!(double.TryParse(Console.ReadLine(), out b) &&
            double.TryParse(Console.ReadLine(), out c) ) )
        {
            Console.WriteLine("Error: Invalid number.");
            return;
        }

        //logic

        //print output
        Console.WriteLine("|{0,-10:X}|{1}|{2,10:F2}|{3,-10:F3}|", a, Convert.ToString(a, 2).PadLeft(10,'0'), b, c);
    }
}