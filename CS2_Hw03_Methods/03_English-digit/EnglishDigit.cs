/*
 * Problem 3. English digit
 *
 * Write a method that returns the last digit of given integer as an English word.
 *
 * Examples:
 *  input 	output
 *  512 	two
 *  1024 	four
 *  12309 	nine
 */
using System;

class EnglishDigit
{
    static string GetLastDigitAsWord(int number)
    {
        int lastDigit = number % 10;
        switch(lastDigit)
        {
            case 1: return "one";
            case 2: return "two";
            case 3: return "three";
            case 4: return "four";
            case 5: return "five";
            case 6: return "six";
            case 7: return "seven";
            case 8: return "eight";
            case 9: return "nine";
            case 0: return "zero";
            default: return "Invalid number";
        }
    }

    static void Main()
    {
        Console.Write("Enter a number to get last digit from: ");
        int input = int.Parse(Console.ReadLine());
        Console.WriteLine(GetLastDigitAsWord(input));
    }
}