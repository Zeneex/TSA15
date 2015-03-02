/*
 * Problem 2. Enter numbers
 *
 * Write a method ReadNumber(int start, int end) that enters an integer number in a given range [start…end].
 *     If an invalid number or non-number text is entered, the method should throw an exception.
 * Using this method write a program that enters 10 numbers: a1, a2, … a10, such that 1 < a1 < … < a10 < 100
 */
using System;

class EnterNumbers
{
    static int ReadNumber(int start, int end)
    {
        Console.Write("Enter an integer number in the range [{0}:{1}]: ", start, end);
        string input = Console.ReadLine();
        int number;
        try
        {
            number = int.Parse(input);
        }
        catch (ArgumentNullException)
        {
            throw new ArgumentException("Null argument not permitted");
        }
        catch (FormatException)
        {
            throw new ArgumentException(string.Format("{0}: Bad Format", input));
        }
        catch (OverflowException)
        {
            throw new ArgumentOutOfRangeException(string.Format("{0}: Out of range", input));
        }
        if (number < start || number > end)
        {
            throw new ArgumentOutOfRangeException(string.Format("{0}: Out of range", input));
        }
        return number;
    }
    static int[] ReadNumbers(int count, int start, int end)
    {
        int[] numbers = new int[count];

        for (int i = 0; i < count; i++, start++)
        {
            numbers[i] = start = ReadNumber(start, end);
        }
        return numbers;
    }
    static void Main()
    {
        int start = 0;
        int end = 100;
        int numbersCount = 10;
        //int number = ReadNumber(start, end);
        int[] numbers = ReadNumbers(numbersCount, start, end);
        Console.WriteLine(string.Join(", ", numbers));
    }
}