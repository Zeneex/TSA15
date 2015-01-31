/*
 * Problem 14. Decimal to Binary Number
 *
 * Using loops write a program that converts an integer number to its binary representation.
 * The input is entered as long. The output should be a variable of type string.
 * Do not use the built-in .NET functionality.
 */
using System;

class DecimalToBinaryNumber
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
            digits += (dec % 2);    //1 or 0 to "1" or "0"
            dec = dec / 2;
        }
        for (int i = digits.Length - 1; i >= 0; i--)
		{
			 Console.Write(digits[i]);      //print in reverse order
		}
        Console.WriteLine();
    }
}