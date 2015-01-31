/*
 * Problem 1. Numbers from 1 to N
 *
 * Write a program that enters from the console a positive integer n and prints all the numbers from 1 to n,
 * on a single line, separated by a space.
 */
using System;

class NumbersFrom1ToN
{
    static void Main()
    {
        Console.Write("Enter a positive number: ");

        int n = int.Parse(Console.ReadLine());
        int i = 1;
        while (i <= n)
        {
            Console.Write(i + " ");
            i++;
        }
        Console.WriteLine();
    }
}