/*
 * Problem 3. Decimal to hexadecimal
 *
 * Write a program to convert decimal numbers to their hexadecimal representation.
 */
using System;

class DecimalToHexadecimal
{
    static string ConvertDecimalToHexadecimal(long decimalNumber)
    {
        string hexNumber = string.Empty;
        while (decimalNumber > 0)
        {
            long hexRemainder = decimalNumber % 16;
            if (hexRemainder >= 0 && hexRemainder <= 9)
            {
                hexNumber = hexRemainder + hexNumber;
            }
            else if (hexRemainder >= 10 && hexRemainder <= 15)
            {
                hexNumber = (char)(hexRemainder - 10 + 'A') + hexNumber;
            }
            decimalNumber /= 16;
        }
        return hexNumber;
    }

    static void Main()
    {
        //input
        Console.Write("Convert a decimal number to hex number: ");
        long decimalNumber = long.Parse(Console.ReadLine());

        //output
        Console.WriteLine(ConvertDecimalToHexadecimal(decimalNumber));
    }
}