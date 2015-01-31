/*
 * Problem 6. Calculate N! / K!
 *
 * Write a program that calculates n! / k! for given n and k (1 < k < n < 100).
 * Use only one loop.
 */
using System;

class CalculateFactorialsQuotient
{
    static void Main()
    {
        Console.WriteLine("Enter 2 positive numbers for N and K, from 1 to 99: ");
        int n = int.Parse(Console.ReadLine());
        int k = int.Parse(Console.ReadLine());
        if (n <= 1 || n >= 100 || k <= 1 || k >= 100)
        {
            Console.WriteLine("Error: Invalid numbers.");
            return;
        }
        if (n < k)
        {   //swap if n is the smaller one
            k = k + n;
            n = k - n;
            k = k - n;
        }   //now n is the bigger one
        decimal quotient = 1;
        for (k++; k <= n; k++)
        {
            quotient *= k;
        }
        Console.WriteLine("n! / k! = {0}", quotient);
    }
}
