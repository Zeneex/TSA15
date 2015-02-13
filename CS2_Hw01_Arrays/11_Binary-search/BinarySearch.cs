/*
 * Problem 11. Binary search
 *
 * Write a program that finds the index of given element in a sorted array of integers
 * by using the Binary search algorithm.
 */
using System;

class BinarySearch
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

        Console.Write("Enter key value to search for (as integer): ");
        */
        int keyValue = 124;// int.Parse(Console.ReadLine());          //determine the key value to search for

        //logic
        #region test array block
        //int[] ivVector = { -30, +80, 2, 43, 2, 4, 9, 20, 1, 6, 4, 9, 10 };
        //int[] ivVector = { 0, 0, 0, 43, 2, 5, 9, 20, 1, 6, 4, 9, 10 };
        //int[] ivVector = { 30, 8, 2, 47, 2, 70, 9, 0, 1, 6, 4, 9, -27 };
        int[] ivVector = { 2, -5, -3, -56, 123, 45, 67, 10, -40, -100, };
        #endregion

        #region sort array block (selection sort)
        //single expression variant of the value swap algo: a += b - ( b += ( a - b ) ); author: me;
        //so a value-swapping loop can be compressed into an extremal, one-liner (empty) form:
        //for ( int i = 0; i < limit; i++, a += b - ( b += ( a - b ) ) );

        for (int i = 0, j, minIndex;                                    //array sorting loop, using value swap
            i < ivVector.Length;
            ivVector[i] += ivVector[minIndex] - (ivVector[minIndex] += (ivVector[i] - ivVector[minIndex])), i++)

			for (j = i, minIndex = i; j < ivVector.Length; j++)         //minimum search loop
			    if (ivVector[j] < ivVector[minIndex])
		            minIndex = j;
        #endregion

        #region binary search block
        int midIndex = -1;  //non-negative index for found key or -1 for not found; default = not found
        int minBound = -1;                       //set the bounds as exclusive
        int maxBound = ivVector.Length;          //set the bounds as exclusive

        while (maxBound - minBound != 1 /*if == 1 -> empty set*/)
        {
            midIndex = (maxBound + minBound) / 2;

            if (ivVector[midIndex] > keyValue)                          //must devide left half
                maxBound = midIndex;                                    //adjust the max bound
            else if (ivVector[midIndex] < keyValue)                     //must devide right half
                minBound = midIndex;                                    //adjust the min bound
            else
                break;                                                  //key found - keep the index intact

            midIndex = -1;                                              //key not found - default the index
        }
        #endregion

        //print output
        if (midIndex != -1)
        {
            Console.WriteLine("Array {{ {0} }}", string.Join(", ", ivVector));
            Console.WriteLine("Key value = {0}", keyValue);
            Console.WriteLine("Key index = {0}", midIndex);
        }
        else
        {
            Console.WriteLine("Key {0} not found in the array {{ {1} }}",
                keyValue, string.Join(", ", ivVector));
        }
        // This is implementation of exclusive bounds (both), iterative, two-branch (first match), binary search algorithm.
    }
}