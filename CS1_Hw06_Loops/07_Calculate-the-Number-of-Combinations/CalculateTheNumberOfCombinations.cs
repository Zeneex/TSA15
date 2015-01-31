/*
 * Problem 7. Calculate N! / (K! * (N-K)!)
 *
 * In combinatorics, the number of ways to choose k different members out of a group of n different elements
 * (also known as the number of combinations) is calculated by the following formula: N! / (K! * (N-K)!)
 * For example, there are 2598960 ways to withdraw 5 cards out of a standard deck of 52 cards.
 * Your task is to write a program that calculates n! / (k! * (n-k)!) for given n and k (1 < k < n < 100).
 * Try to use only two loops.
 */
using System;
using System.Numerics;

class CalculateTheNumberOfCombinations
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

        int difference = n - k;
        BigInteger differenceFactorial = 1;    //represents (n - k)!, got to be bigint - difference can be as high as 98
        BigInteger factorialQuotient = 1;      //represents n! / k!, got to be bigint (same reasons)

        for (k++; k <= n; k++)
        {
            factorialQuotient *= k;
        }
        for (int i = 1; i <= difference; i++)
        {
            differenceFactorial *= i;
        }
        Console.WriteLine("n! / (k! * (n - k)! ) = {0}", factorialQuotient / differenceFactorial);
    }
}