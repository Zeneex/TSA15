/*
 * Problem 2. Binary to decimal
 *
 * Write a program to convert binary numbers to their decimal representation.
 */
using System;

class BinaryToDecimal
{
    static long CovertBinaryToDecimal(string binaryNumber)
    {
        long decimalNumber = new long();
        for (int i = binaryNumber.Length - 1; i >= 0; i--)
        {
            decimalNumber += (binaryNumber[i] - '0') * (long)Math.Pow(2, binaryNumber.Length - 1 - i);
        }
        return decimalNumber;
    }

    static void Main()
    {
        //input
        Console.Write("Convert a binary number to decimal number: ");

        //output
        Console.WriteLine(CovertBinaryToDecimal(Console.ReadLine()));
    }
}