/*
 * Problem 15. Prime numbers
 *
 * Write a program that finds all prime numbers in the range [1...10 000 000]. Use the Sieve of Eratosthenes algorithm.
 */
using System;

class PrimeNumbers
{
    static void Main()
    {
        int n = 10000000;                       //number of values to sieve
        bool[] bvVector = new bool[n + 1];      //bool = 1 byte, bool[] = 10 MB

        for (int i = 2; i < n + 1; i++)
        {
            bvVector[i] = true;                 //init all indexes as primes (except index 0 and 1)
        }

        int nRoot = (int)Math.Sqrt(n);          //store the root(n) - no repeated calculation

        for (int i = 2; i <= nRoot; i++)        //main loop - 2 to root(n)
        {
            if (bvVector[i])
            {
                for (int j = i * i; j < n + 1; j += i)
                {                               //sieve out (false) all indexes, multiples of i
                    bvVector[j] = false;
                }
            }
        }
        //primes array is ready; begin print

        //print output (print is a slow process)
        Console.WriteLine("Primes:");
        for (int i = 2; i < n + 1; i++)
        {
            if (bvVector[i])
            {
                Console.Write("{0} ", i);
            }
        }

        //the idea of the algo isn't mine - it's the Wikipedia's optimized implementation (runs fast for large arrays)
        //http://en.wikipedia.org/wiki/Sieve_of_Eratosthenes#Implementation
        //the Wikipedia's article cites even more optimized algos for prime sieves...
    }
}