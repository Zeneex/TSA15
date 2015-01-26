/*
 * Problem 11.* Numbers in Interval Dividable by Given Number
 *
 * Write a program that reads two positive integer numbers and prints how many numbers p exist between them
 * such that the reminder of the division by 5 is 0 (i.e. numbers in interval, dividable by 5).
 */
using System;
using System.Globalization;
using System.Threading;

class NumbersInIntervalDividableByGivenNumber
{
    static void Main()
    {
        const double c = 5;                                                             //constant real divisor
        uint a, b;                                                                      //interval bounds
        const string result = "There is {0:N0} number(s) in the range [{1}:{2}], fully dividable by {3}";
                                                                                        //format string output
        //config
        Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-us");      //strict-localize the program

        //user input
        Console.WriteLine("Enter 2 positive numbers from {0} to {1}: ", 0, uint.MaxValue);
        if (!(uint.TryParse(Console.ReadLine(), out a) && uint.TryParse(Console.ReadLine(), out b)))
        {
            Console.WriteLine("Error: Invalid numbers.");
            return;
        }
        //logic
        else if (a > b)                                                                 //sort the values
        {
            a = a + b; b = a - b; a = a - b;                                            //now b > a => diff(a, b) = b - a
        }
        switch (Math.Min(a, b) % 5 == 0)
        {
            case true: Console.WriteLine(result, Math.Ceiling((b - a + 1) / c), a, b, c); break;
            default: Console.WriteLine(result, Math.Ceiling((b - (a + c - a % c) + 1) / c), a, b, c); break;
        }
        /* if a is already dividable by the constant c it's used for the lower bound of the divident interval;
         * if it's not => the lower bound is set to the 1st integer > a and fully dividable by c;
         * then the length of the divident interval given by the upper bound b - lower bound a + 1 is divided
         * by the constant divisor c into n groups of c numbers, statring from the 1st multiple of c in the range;
         * if the result n has a decimal part => the number of groups is (int)n + 1 = ceiling( (real)n );
         * if the result n has not a decimal part => the number of groups is (int)n = ceiling(  (int)n );
         * number of all groups of c numbers in the range, statring from the 1st multiple of c in the range
         * (the closest multiple toward 0) is the number of values, dividable by c in the range;
         * the algorithm is fool-proof for positive ranges;
         */
        //print output (see logic)
    }
}