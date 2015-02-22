/*
 * Problem 2. Get largest number
 *
 * Write a method GetMax() with two parameters that returns the larger of two integers.
 * Write a program that reads 3 integers from the console and prints the largest of them using the method GetMax().
 */
using System;

public static class GetLargestNumber
{
    static int GetMax(int firstNumber, int secondNumber)
    {
        int maxValue = firstNumber;
        if (secondNumber > firstNumber)
        {
            maxValue = secondNumber;
        }
        return maxValue;
    }

    static int[] GetCyclicInput(int cycles)
    {
        int[] ivInputs = new int[cycles];
        Console.WriteLine("Enter {0} values (as integers):", cycles);
        for (int i = 0; i < cycles; i++)
        {
            Console.Write("value " + i + ": ");
            ivInputs[i] = int.Parse(Console.ReadLine());
        }
        return ivInputs;
    }

    static void Main()
    {
        int[] ivInputs = GetCyclicInput(3);
        int maxValue = GetMax(ivInputs[0], ivInputs[1]);
        maxValue = GetMax(maxValue, ivInputs[2]);
        Console.WriteLine("max value = {0}", maxValue);
    }
}