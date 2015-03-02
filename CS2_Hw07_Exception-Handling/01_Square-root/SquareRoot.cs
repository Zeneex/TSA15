/*
 * Problem 1. Square root
 *
 * Write a program that reads an integer number and calculates and prints its square root.
 *     If the number is invalid or negative, print Invalid number.
 *     In all cases finally print Good bye.
 * Use try-catch-finally block.
 */
using System;

class SquareRoot
{
    static void Main()
    {
        Console.Write("Calculate the suqare root of an integer number: ");
        try
        {
            Console.WriteLine("Square root = {0}", Math.Sqrt(int.Parse(Console.ReadLine())));
        }
        catch (Exception)
        {
            Console.WriteLine("Invalid number");
        }
        finally
        {
            Console.WriteLine("Good bye");
        }
    }
}