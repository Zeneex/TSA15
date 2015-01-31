//n! calculator for big factorial tests

using System;
using System.Numerics;

class Factorial
{
    static void Main()
    {
        while (true)
        {
            Console.Write("N = ");
            uint n = uint.Parse(Console.ReadLine());

            BigInteger factorial = 1;

            for (int i = 0; i <= n; i++)
                if (i != 0)
                    factorial *= i;

            Console.WriteLine(factorial);
        }
    }
}