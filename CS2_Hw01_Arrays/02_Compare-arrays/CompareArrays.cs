/*
 * Problem 2. Compare arrays
 *
 * Write a program that reads two integer arrays from the console and compares them element by element.
 */
using System;

class CompareArrays
{
    static void Main()
    {
        Console.Write("Enter first array's length (as integer > 0): ");
        int n = int.Parse(Console.ReadLine());
        if (n <= 0)
        {
            Console.WriteLine("Error: Nothing to compare.");
            return;
        }
        int[] intArray1 = new int[n];                           //create first array

        Console.WriteLine("Enter first array's elements (as integers):");
        for (int i = 0; i < intArray1.Length; i++)
        {
            Console.Write("Array 1, Element {0} = ", i);
            intArray1[i] = int.Parse(Console.ReadLine());       //define the elements
        }

        Console.Write("Enter second array's length (as integer > 0): ");
        int m = int.Parse(Console.ReadLine());
        if (m <= 0)
        {
            Console.WriteLine("Error: Nothing to compare.");
            return;
        }
        int[] intArray2 = new int[m];                           //create second array

        Console.WriteLine("Enter second array's elements (as integers):");
        for (int i = 0; i < intArray2.Length; i++)
        {
            Console.Write("Array 2, Element {0} = ", i);
            intArray2[i] = int.Parse(Console.ReadLine());       //define the elements
        }
        //compare and print results
        Console.WriteLine("Results:");
        for (int i = 0; i < Math.Max(intArray1.Length, intArray2.Length); i++)
        {
            try
            {
                Console.WriteLine("intArray1[{0}] = {1} {3} intArray2[{0}] = {2}",
                    i, intArray1[i], intArray2[i],
                    intArray1[i] > intArray2[i] ? ">" : intArray1[i] < intArray2[i] ? "<" : "=");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Error: Nothing to compare - [{0}] doesn't exist.", i);
            }
        }
    }
}