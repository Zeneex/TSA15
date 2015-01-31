/*
 * Problem 15. Hexadecimal to Decimal Number
 *
 * Using loops write a program that converts a hexadecimal integer number to its decimal form.
 * The input is entered as string. The output should be a variable of type long.
 * Do not use the built-in .NET functionality.
 */
using System;

class HexadecimalToDecimalNumber
{
    static void Main()
    {
        Console.Write("Enter a hexadecimal number with no more than 16 digits: ");
        string hex = Console.ReadLine();
        //absolutely no validation - take care when input

        ulong dec = 0;
        int index = 0;
        ulong power = 1;
        uint currentDigit;

        for (index = hex.Length - 1; index >= 0; index--, power = 1)
        {
            switch (hex[index])
            {
                case 'A': currentDigit = 10; break;
                case 'B': currentDigit = 11; break;
                case 'C': currentDigit = 12; break;
                case 'D': currentDigit = 13; break;
                case 'E': currentDigit = 14; break;
                case 'F': currentDigit = 15; break;
                default: currentDigit = uint.Parse(hex[index].ToString()); break;
            }
            for (int i = 0; i <= hex.Length - 1 - index; i++)
            {
                if (i != 0)
                {
                    power *= 16;
                }
            }
            dec += power * currentDigit;
        }
        Console.WriteLine(dec);
    }
}