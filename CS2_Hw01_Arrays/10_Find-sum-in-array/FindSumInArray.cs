/*
 * Problem 10. Find sum in array
 *
 * Write a program that finds in given array of integers a sequence of given sum S (if present).
 */
using System;

class FindSumInArray
{
    static void Main()
    {
        //user input
        /*
        Console.Write("Enter array's length (as integer > 0): ");
        int n = int.Parse(Console.ReadLine());
        if (n <= 0)
        {
            Console.WriteLine("Error: Invalid length.");
            return;
        }
        int[] ivVector = new int[n];                           //create integer array

        Console.WriteLine("Enter array's elements (as integers):");
        for (int i = 0; i < ivVector.Length; i++)
        {
            Console.Write("Array[{0}] = ", i);
            ivVector[i] = int.Parse(Console.ReadLine());       //define the elements
        }

        Console.Write("Enter some sum to search for: ");
        int Sum = int.Parse(Console.ReadLine());
         */
        //int[] ivVector = { 30, 8, 2, 50, 2, 5, 10, 20, 1, 6, 4, 9, 10 };
        //int[] ivVector = { 30, 8, 2, 43, 2, 5, 10, 20, 1, 6, 4, 9, 10 };
        //int[] ivVector = { 30, 8, 2, 43, 2, 4, 10, 20, 1, 6, 4, 9, 10 };
        //int[] ivVector = { 30, 8, 2, 43, 2, 4, 9, 20, 1, 6, 4, 9, 10 };
        //int[] ivVector = { -30, +80, 2, 43, 2, 4, 9, 20, 1, 6, 4, 9, 10 };
        //int[] ivVector = { 0, 0, 0, 43, 2, 5, 9, 20, 1, 6, 4, 9, 10 };
        int[] ivVector = { 30, 8, 2, 47, 2, 70, 9, 0, 1, 6, 4, 9, -27 };

        const long constSum = 50;
        long sumIndex = 0;
        long sumLength = 0;
        long tempSum = 0;
        bool isFound = false;

        //logic
        for (int i = 0, j = 0; i < ivVector.Length; i++, j = i, tempSum = 0, sumLength = 0)
        {
            while (j < ivVector.Length && (tempSum += ivVector[j]) <= constSum)
            {
                sumLength++;
                sumIndex = j;
                if (tempSum == constSum)
                {
                    isFound = true;
                    break;
                }
                j++;
            }
            if (isFound)
                break;
        }

        //print output
        if (isFound)
        {
            //initialize sub-array
            int[] ivSubVector = new int[sumLength];
            //copy sub-range into sub-array
            Array.Copy(ivVector, sumIndex - (sumLength - 1), ivSubVector, 0, sumLength);

            Console.WriteLine("Array {{ {0} }}", string.Join(", ", ivVector));
            Console.WriteLine("Seek sum = {0}", constSum);
            Console.WriteLine("Sum sub-array {{ {0} }}", string.Join(", ", ivSubVector));
            Console.WriteLine("Sub-array index = {0}", sumIndex - (sumLength - 1));
            Console.WriteLine("Sub-array length = {0}", sumLength);
        }
        else
        {
            Console.WriteLine("Sub-array with sum {0} not found in the array {{ {1} }}",
                constSum, string.Join(", ", ivVector));
            Console.ForegroundColor = ConsoleColor.
        }
    }
}