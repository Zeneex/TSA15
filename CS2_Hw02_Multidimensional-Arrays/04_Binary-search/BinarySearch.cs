/*
 * Problem 4. Binary search
 *
 * Write a program, that reads from the console an array of N integers and an integer K,
 * sorts the array and using the method Array.BinSearch() finds the largest number in the array which is ≤ K.
 */
using System;
using System.Collections.Generic;

class BinarySearch
{
    public static void QuickSort(int[] ivVector)
    {
        int lHead;
        int rHead;
        int pivot;
        int rBound = ivVector.Length;                   //init exclusive upper bound

        List<int> ilStack = new List<int>();            //simulate stack struct
        ilStack.Add(-1);                                //init exclusive lower bound

        //algo
        while (rBound > 1)                              //if upper bound <= 1 => array is already sorted
        {
            for (lHead = ilStack[ilStack.Count - 1] + 1, rHead = rBound - 1, pivot = ivVector[lHead] /*now ivVector[lHead] is free*/;
                lHead < rHead; rHead--)
                if (ivVector[rHead] < pivot)
                {
                    ivVector[lHead] = ivVector[rHead];
                    for (lHead++; lHead < rHead; lHead++)
                        if (ivVector[lHead] >= pivot)
                        {
                            ivVector[rHead] = ivVector[lHead];
                            break;
                        }
                }
            ivVector[lHead] = pivot;                    //restore the pivot on the wall position
            ilStack.Add(lHead);                         //push the new wall index into stack simul
            //if diff b/w bound and wall has only 1 or < elements => sub-range is sorted; un-garbage
            while (ilStack.Count != 0 && rBound - ilStack[ilStack.Count - 1] - 1 <= 1)
            {
                rBound = ilStack[ilStack.Count - 1];    //set the new bound from the stack
                ilStack.RemoveAt(ilStack.Count - 1);    //pop the stack
            }
        }
    }
    static void Main()
    {
        //input
        Console.Write("Enter array's length (as integer > 0): ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Enter key value (as integer): ");
        int k = int.Parse(Console.ReadLine());

        //allocate array memory space
        int[] ivVector = new int[n];

        //define array elements
        Console.WriteLine("Enter array's elements (as integers):");
        for (int i = 0; i < ivVector.Length; i++)
        {
            Console.Write("array[{0}] = ", i);
            ivVector[i] = int.Parse(Console.ReadLine());
        }

        #region test block
        /*
        int[] ivVector = { 5, 0, 1, 2, 6, 9, 13, 21, 44 };

        int n = ivVector.Length;
        int k = 45;
        */
        #endregion

        //print
        Console.WriteLine("unsorted array:\n{{ {0} }}", string.Join(", ", ivVector));

        //logic
        QuickSort(ivVector);

        int searchResult = Array.BinarySearch(ivVector, k);

        //print
        Console.WriteLine("sorted array:\n{{ {0} }}", string.Join(", ", ivVector));

        if (searchResult >= 0)
            Console.WriteLine("largest number which is ≤ {2} = array[{1}] = {0}", ivVector[searchResult], searchResult, k);
        else if (~searchResult == 0)
            Console.WriteLine("no number match");
        else
            Console.WriteLine("largest number which is ≤ {2} = array[{1}] = {0}", ivVector[~searchResult - 1], ~searchResult - 1, k);
    }
}