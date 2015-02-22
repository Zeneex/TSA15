/*
 * Problem 4. Hexadecimal to decimal
 *
 * Write a program to convert hexadecimal numbers to their decimal representation.
 */
using System;

class HexadecimalToDecimal
{
    static long ConvertHexadecimalToDecimal(string hexNumber)
    {
        long decimalNumber = new long();
        for (int i = hexNumber.Length - 1; i >= 0; i--)
        {
            if (hexNumber[i] >= '0' && hexNumber[i] <= '9')
            {
                decimalNumber += (hexNumber[i] - '0') * (long)Math.Pow(16, hexNumber.Length - 1 - i);
            }
            else if (hexNumber[i] >= 'A' && hexNumber[i] <= 'F')
            {
                decimalNumber += (hexNumber[i] - 'A' + 10) * (long)Math.Pow(16, hexNumber.Length - 1 - i);
            }
        }
        return decimalNumber;
    }

    static void Main()
    {
        //input
        Console.Write("Convert a hex number to decimal number: ");

        //output
        Console.WriteLine(ConvertHexadecimalToDecimal(Console.ReadLine()));
    }
}