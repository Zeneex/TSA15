/*
 * Problem 1. Decimal to binary
 *
 * Write a program to convert decimal numbers to their binary representation.
 */
using System;

class DecimalToBinary
{
    static string ConvertDecimalToBinary(long decimalNumber)
    {
        string binaryNumber = string.Empty;
        while (decimalNumber > 0)
        {
            long binaryRemainder = decimalNumber % 2;
            binaryNumber = binaryRemainder + binaryNumber;
            decimalNumber /= 2;
        }
        return binaryNumber.PadLeft(64, '0');
    }

    static void Main()
    {
        //input
        Console.Write("Convert a decimal number to binary number: ");
        long decimalNumber = long.Parse(Console.ReadLine());

        //output
        Console.WriteLine(ConvertDecimalToBinary(decimalNumber));
    }
}
