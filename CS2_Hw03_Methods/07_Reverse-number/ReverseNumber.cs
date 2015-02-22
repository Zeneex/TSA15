/*
 * Problem 7. Reverse number
 *
 * Write a method that reverses the digits of given decimal number.
 * 
 * Example:
 *  input 	output
 *  256 	652
 *  123.45 	54.321
 */
using System;

class ReverseNumber
{
    static decimal ReverseDigits(decimal dInputNumber)
    {
        string numberToString = Convert.ToString(dInputNumber);
        string reversedNumber = null;
        for (int i = numberToString.Length - 1; i >=0 ; i--)
        {
            reversedNumber += numberToString[i];
        }
        return decimal.Parse(reversedNumber);
    }

    static void Main()
    {
        Console.Write("Enter real number to reverse: ");
        decimal dInputNumber = decimal.Parse(Console.ReadLine());

        decimal dReversedNumber = ReverseDigits(dInputNumber);
        Console.WriteLine(dReversedNumber);
    }
}