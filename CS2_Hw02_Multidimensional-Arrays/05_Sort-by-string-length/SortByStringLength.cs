/*
 * Problem 5. Sort by string length
 *
 * You are given an array of strings.
 * Write a method that sorts the array by the length of its elements (the number of characters composing them).
 */
using System;
using System.Collections.Generic;

class SortByStringLength
{
    public static void QuickSortStrings(string[] svVector)
    {
        int lHead;
        int rHead;
        string pivot;
        int rBound = svVector.Length;                   //init exclusive upper bound

        List<int> ilStack = new List<int>();            //simulate stack struct
        ilStack.Add(-1);                                //init exclusive lower bound

        //algo
        while (rBound > 1)                              //if upper bound <= 1 => array is already sorted
        {
            for (lHead = ilStack[ilStack.Count - 1] + 1, rHead = rBound - 1, pivot = svVector[lHead] /*now ivVector[lHead] is free*/;
                lHead < rHead; rHead--)
                if (svVector[rHead].Length < pivot.Length)
                {
                    svVector[lHead] = svVector[rHead];
                    for (lHead++; lHead < rHead; lHead++)
                        if (svVector[lHead].Length >= pivot.Length)
                        {
                            svVector[rHead] = svVector[lHead];
                            break;
                        }
                }
            svVector[lHead] = pivot;                    //restore the pivot on the wall position
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

        //allocate array memory space
        string[] svVector = new string[n];

        //define array elements
        Console.WriteLine("Enter array's elements:");
        for (int i = 0; i < svVector.Length; i++)
        {
            Console.Write("array[{0}] = ", i);
            svVector[i] = Console.ReadLine();
        }

        #region test block
        /*
        string[] svVector =
            { "O(n*log n)", "pesho", "gosho", "i", "andrei", "hipopotam", "brymbar", "zhirafff", "ko4", "muha", "valentin" };
        */
        #endregion

        //print
        Console.WriteLine("unsorted array:\n{{ {0} }}", string.Join(", ", svVector));

        //logic
        QuickSortStrings(svVector);

        //print
        Console.WriteLine("sorted array:\n{{ {0} }}", string.Join(", ", svVector));
    }
}