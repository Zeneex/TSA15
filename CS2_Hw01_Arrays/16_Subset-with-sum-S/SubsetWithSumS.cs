/*
 * Problem 16.* Subset with sum S
 *
 * We are given an array of integers and a number S.
 * Write a program to find if there exists a subset of the elements of the array that has a sum S.
 */
using System;

class SubsetWithSumS
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

        Console.Write("Enter sum to search for (as integer): ");
        int s = int.Parse(Console.ReadLine());

        //logic
        #region test array block
        //int[] ivVector = { 2, 1, 2, 4, 3, 5, 2, 6 };
        #endregion

        //int n = ivVector.Length - 1;
        //int s = 26;

        int sum = 0;
        int[] ivIndexes = new int[ivVector.Length];         //create indexes array with equal length

        for (int i = 0; i < ivIndexes.Length - 1; i++)      //w/o the last one - keep it 0
        {
            ivIndexes[i]--;                                 //init all elements to -1
        }

        Console.WriteLine("Array {{ {0} }}", string.Join(", ", ivVector));
        //algo
        for (int rHead = ivIndexes.Length - 1; rHead >= 0; rHead--)         //set the head at the next element, which is not >= position's maximum
        {
            if (ivIndexes[rHead] < rHead)                                   //if it's not >= position's maximum
            {
                ivIndexes[rHead]++;                                         //increment it
                for (rHead++; rHead < ivIndexes.Length; rHead++)            //init all the positions to the right to the next possible value (if any)
                {
                    ivIndexes[rHead] = ivIndexes[rHead - 1] + 1;
                }
                for (rHead--, sum = 0; rHead > -1 && ivIndexes[rHead] != -1; rHead--)
                {                                                           //build the sum from the index combination
                    sum += ivVector[ivIndexes[rHead]];
                }
                rHead = ivIndexes.Length;                                   //reset the head
                if (sum == s)                                               //have a match
                {
                    Console.Write("Sum = {0} found as: ", s);
                    for (int i = 0; i < ivIndexes.Length; i++)
                    {
                        if (ivIndexes[i] != -1)
	                    {
                            Console.Write("{0} + ", ivVector[ivIndexes[i]]);    //print the sum combination
	                    }
                    }
                    Console.WriteLine("\b\b ");
                    return;
                }
            }
        }
        Console.WriteLine("Sum = {0} not found in array.", s);              //print if no sum match

        //the solution is released with the help of combinations algo - all possible combinations
        //of elements are analized for their sum and compared with the key sum
        //however, it's a slow approach and probably could be optimized
    }
}