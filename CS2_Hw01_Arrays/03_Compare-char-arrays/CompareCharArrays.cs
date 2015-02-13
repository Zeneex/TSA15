/*
 * Problem 3. Compare char arrays
 *
 * Write a program that compares two char arrays lexicographically (letter by letter).
 */
using System;

class CompareCharArrays
{
    static void Main()
    {
        //Note: A string is actually a char array
        Console.Write("Enter first array's elements (as letters): ");
        string charArray1 = Console.ReadLine();
        if (charArray1 == "")
        {
            Console.WriteLine("Error: Nothing to compare.");
            return;
        }
        
        Console.Write("Enter second array's elements (as letters): ");
        string charArray2 = Console.ReadLine();
        if (charArray2 == "")
        {
            Console.WriteLine("Error: Nothing to compare.");
            return;
        }

        //compare and print results
        Console.WriteLine("Results:");
        for (int i = 0; i < Math.Max(charArray1.Length, charArray2.Length); i++)
        {
            try
            {
                Console.WriteLine("charArray1[{0}] = '{1}' {3} charArray2[{0}] = '{2}'",
                    i, charArray1[i], charArray2[i],
                    charArray1[i] > charArray2[i] ? ">" : charArray1[i] < charArray2[i] ? "<" : "=");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Error: Nothing to compare - [{0}] doesn't exist.", i);
            }
        }
    }
}