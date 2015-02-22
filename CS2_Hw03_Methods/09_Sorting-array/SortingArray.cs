/*
 * Problem 9. Sorting array
 *
 * Write a method that return the maximal element in a portion of array of integers starting at given index.
 * Using it write another method that sorts an array in ascending / descending order.
 */
using System;

class SortingArray
{
    static int GetLocalMaximum(int[] ivInputArray, int startIndex, int endIndex)
    {
        int localMaximum = ivInputArray[startIndex];
        for (int i = startIndex + 1; i <= endIndex; i++)
            if (ivInputArray[i] > localMaximum)
                localMaximum = ivInputArray[i];
        return localMaximum;
    }

    static void SortArray(int[] ivInputArray, bool sortAscending = true)
    {
        if (sortAscending)
        {
            for (int i = ivInputArray.Length - 1; i >= 0; i--)
            {
                int localMaximum = GetLocalMaximum(ivInputArray, 0, i);
                int maximumIndex = Array.IndexOf(ivInputArray, localMaximum);
                ivInputArray[maximumIndex] = ivInputArray[i];
                ivInputArray[i] = localMaximum;
            }
        }
        else
        {
            for (int i = 0; i < ivInputArray.Length; i++)
            {
                int localMaximum = GetLocalMaximum(ivInputArray, i, ivInputArray.Length - 1);
                int maximumIndex = Array.IndexOf(ivInputArray, localMaximum);
                ivInputArray[maximumIndex] = ivInputArray[i];
                ivInputArray[i] = localMaximum;
            }
        }
    }

    static void Main()
    {
        //input
        /*
        Console.Write("Enter the length of the input array: ");
        int length = int.Parse(Console.ReadLine());
        int[] ivInputVector = GetCyclicInput(length);
        */
        int[] ivInputVector = { 2, 3, 4, 36, 2, 1, 3, 3, 10, 8, 40000, 3, 45, 6, 1, -1, 3, 0 };

        Console.WriteLine("initial array: {{ {0} }}", string.Join(", ", ivInputVector));

        SortArray(ivInputVector);
        Console.WriteLine("sorted array (ascending): {{ {0} }}", string.Join(", ", ivInputVector));

        SortArray(ivInputVector, false);
        Console.WriteLine("sorted array (descending): {{ {0} }}", string.Join(", ", ivInputVector));

    }

    static int[] GetCyclicInput(int cycles)
    {
        int[] ivInputs = new int[cycles];
        Console.WriteLine("Enter {0} values (as integers):", cycles);
        for (int i = 0; i < cycles; i++)
        {
            Console.Write("value " + i + ": ");
            ivInputs[i] = int.Parse(Console.ReadLine());
        }
        return ivInputs;
    }
}