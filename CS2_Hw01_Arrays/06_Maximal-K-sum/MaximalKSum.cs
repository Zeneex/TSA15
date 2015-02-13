/*
 * Problem 6. Maximal K sum
 *
 * Write a program that reads two integer numbers N and K and an array of N elements from the console.
 * Find in the array those K elements that have maximal sum.
 */
using System;

class MaximalKSum
{
    static void Main()
    {
        //user input
        Console.Write("Enter array's length (as integer > 0): ");
        int n = int.Parse(Console.ReadLine());
        if (n <= 0)
        {
            Console.WriteLine("Error: Invalid length.");
            return;
        }
        decimal[] decArray = new decimal[n];                            //create array of real values

        Console.WriteLine("Enter array's elements (as numbers from {0:E3} to {1:E3}):",
            decimal.MinValue, decimal.MaxValue);
        for (int i = 0; i < decArray.Length; i++)
        {
            Console.Write("Array[{0}] = ", i);
            decArray[i] = decimal.Parse(Console.ReadLine());                //define the elements
        }

        Console.Write("How many elements to analize for maximal sum: ");
        int k = int.Parse(Console.ReadLine());
        if (k <= 0)
        {
            Console.WriteLine("Error: Invalid count.");
            return;
        }
        else if (k > n)
        {
            k = n;
        }

        //logic :)
        Array.Sort(decArray);

        //print output
        Console.WriteLine("Array {{ {0} }}", string.Join(", ", decArray));
        Console.Write("Maximal {0} elements {{ ", k);

        for (decimal i = 0m, sum = 0m; i < k; i++)
        {
            sum += decArray[n - 1 - (int)i];
            if (i != k - 1)
                Console.Write(decArray[n - k + (int)i] + ", ");
            else
            {
                Console.WriteLine(decArray[n - k + (int)i] + " }}");
                Console.WriteLine("Maximal sum of {1} elements = {0}", sum, k);
                return;
            }
        }
    }
}