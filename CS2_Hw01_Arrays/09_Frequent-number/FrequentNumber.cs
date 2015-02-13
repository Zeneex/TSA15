/*
 * Problem 9. Frequent number
 *
 * Write a program that finds the most frequent number in an array.
 * 
 * 4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3 	4 (5 times)
 */
using System;
using System.Collections.Generic;

class FrequentNumber
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
        int[] ivVector = new int[n];                           //create integer array

        Console.WriteLine("Enter array's elements (as integers):");
        for (int i = 0; i < ivVector.Length; i++)
        {
            Console.Write("Array[{0}] = ", i);
            ivVector[i] = int.Parse(Console.ReadLine());       //define the elements
        }
        //int[] ivVector = { 30, 8, 2, 50, 2, 5, 40, 20, 1, 6, 4, 9, 3 };

        //logic
        List<int> ilScannedNums = new List<int>();
        int iMostFrequentNum = ivVector[0];
        int iFrequency, iCurrentFrequency, k;

        for (k = iFrequency = iCurrentFrequency = 0; k < ivVector.Length; k++, iCurrentFrequency = 0)
            if (!ilScannedNums.Contains(ivVector[k]))
            {
                ilScannedNums.Add(ivVector[k]);
                for (int j = k; j < ivVector.Length; j++)
                    if (ivVector[j] == ivVector[k])
                        iCurrentFrequency++;
                if (iCurrentFrequency > iFrequency)
                {
                    iFrequency = iCurrentFrequency;
                    iMostFrequentNum = ivVector[k];
                }
            }

        //print output
        Console.WriteLine("Array {{ {0} }}", string.Join(", ", ivVector));
        Console.WriteLine("Most frequent number = {0} ({1} times)", iMostFrequentNum, iFrequency);
    }
}