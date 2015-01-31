/*
 * Problem 13. Binary to Decimal Number
 *
 * Using loops write a program that converts a binary integer number to its decimal form.
 * The input is entered as string. The output should be a variable of type long.
 * Do not use the built-in .NET functionality.
 */
using System;
using System.Numerics;

class BinaryToDecimalNumber
{
    static void Main()
    {
        Console.Write("Enter a binary number with no more than 64 digits: ");
        BigInteger bin =  BigInteger.Parse(Console.ReadLine()); //BigInteger.Parse(Convert.ToString(2435351918, 2));
        //absolutely no validation - take care when input

        ulong dec = 0;
        int index = 0;
        ulong power = 1;
        do
        {
            int lastDigit = (int)(bin % 10);

            if (lastDigit == 1)
            {
                for (int i = 0; i <= index; i++)
                {
                    if (i != 0)
                    {
                        power *= 2;
                    }
                }
                dec += power;
                power = 1;
            }
            index++;
        } while ((bin /= 10) != 0);
        
        Console.WriteLine(dec);
    }
}