/*
 * Problem 10. Odd and Even Product
 *
 * You are given n integers (given in a single line, separated by a space).
 * Write a program that checks whether the product of the odd elements is equal to the product of the even elements.
 * Elements are counted from 1 to n, so the first element is odd, the second is even, etc.
 */
using System;

class OddAndEvenProduct
{
    static void Main()
    {
        Console.WriteLine("Enter integer values (use ' ' for separator):");
        string[] numbers = Console.ReadLine().Split(' ');
        decimal evenProduct = 1;
        decimal oddProduct = 1;

        for (int i = 1; i <= numbers.Length; i++)
        {
            if (i % 2 == 0)                     //even
            {
                evenProduct *= decimal.Parse(numbers[i - 1]);
            }
            else
            {
                oddProduct *= decimal.Parse(numbers[i - 1]);
            }
        }
        Console.WriteLine("Is {0} = {1}? {2}",evenProduct, oddProduct, evenProduct == oddProduct ? "yes" : "no");
    }
}