/*
 * Problem 18.* Trailing Zeroes in N!
 *
 * Write a program that calculates with how many zeroes the factorial of a given number n has at its end.
 * Your program should work well for very big numbers, e.g. n=100000.
 */
using System;

class TrailingZeroesInFactorial
{
    static void Main()
    {
        Console.Write("Enter a number for the factorial base (> 0): ");
        uint n = uint.Parse(Console.ReadLine());

        ulong numberofnulls = 0;

        for (ulong poweroffive = 5; poweroffive <= n; numberofnulls += n / poweroffive, poweroffive *= 5) ;

        Console.WriteLine("trailing_nulls({0}!) = {1}", n, numberofnulls);

        /*Big thank you to Nakov's C# book*/
    }
}