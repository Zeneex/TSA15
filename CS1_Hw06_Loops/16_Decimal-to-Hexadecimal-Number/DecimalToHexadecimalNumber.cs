/*
 * Problem 16. Decimal to Hexadecimal Number
 *
 * Using loops write a program that converts an integer number to its hexadecimal representation.
 * The input is entered as long. The output should be a variable of type string.
 * Do not use the built-in .NET functionality.
 */
using System;

class DecimalToHexadecimalNumber
{
    static void Main()
    {
        Console.Write("Enter a long integer number, from {0} to {1:N0}: ", ulong.MinValue, ulong.MaxValue);
        ulong dec = ulong.Parse(Console.ReadLine());
        //absolutely no validation - take care when input

        string digits = "";

        if (dec == 0)
        {
            digits += "0";
        }

        while (dec > 0)             //until there is no more to divide
        {
            switch (dec % 16)
            {
                case 10: digits += 'A'; break;
                case 11: digits += 'B'; break;
                case 12: digits += 'C'; break;
                case 13: digits += 'D'; break;
                case 14: digits += 'E'; break;
                case 15: digits += 'F'; break;
                default: digits += (dec % 16); break;
            }
            dec = dec / 16;
        }
        for (int i = digits.Length - 1; i >= 0; i--)
        {
            Console.Write(digits[i]);      //print in reverse order
        }
        Console.WriteLine();
    }
}

