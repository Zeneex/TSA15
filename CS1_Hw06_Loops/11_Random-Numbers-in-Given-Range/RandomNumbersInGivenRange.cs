/*
 * Problem 11. Random Numbers in Given Range
 *
 * Write a program that enters 3 integers n, min and max (min != max)
 * and prints n random numbers in the range [min...max].
 */
using System;
using System.Threading;

class RandomNumbersInGivenRange
{
    static void Main()
    {
        Console.WriteLine("Enter 1 positive integer and 2 other different integer numbers:");
        uint count = uint.Parse(Console.ReadLine());
        int min = int.Parse(Console.ReadLine());
        int max = int.Parse(Console.ReadLine());

        if (min > max)
        {
            min = min + max;
            max = min - max;
            min = min - max;
        }
        else if (min == max)
        {
            Console.WriteLine("Error: Non-different 2nd and 3rd value.");
            return;
        }

        Random random = new Random();

        for (int i = 0; i < count; i++)
        {
            Console.Write("{0} ", random.Next(min, max + 1));
            Thread.Sleep(20);       //help randomize the numbers better
        }
        Console.WriteLine();
    }
}