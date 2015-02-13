/*
 * Problem 14. Quick sort
 *
 * Write a program that sorts an array of strings(??) using the Quick sort algorithm.
 */
using System;
using System.Collections.Generic;

class QuickSort
{
    static void Main()
    {
        //logic
        #region test array block
        int[] ivVector = { 6, 1, 5, 13, 3, 6, 100, 10, 2, 30, -1, -5, -20, 4, 9, 7, 4, 9, 7, 4, 9, 7 };
        #endregion

        Console.WriteLine("Initial array {{ {0} }}", string.Join(", ", ivVector));

        int lHead;
        int rHead;
        int pivot;
        int rBound = ivVector.Length;               //init exclusive upper bound

        List<int> ilStack = new List<int>();        //simulate stack struct
        ilStack.Add(-1);                            //init exclusive lower bound

        //algo
        while (rBound > 1)                          //if upper bound <= 1 => array is already sorted
        {
            for (lHead = ilStack[ilStack.Count - 1] + 1, rHead = rBound - 1, pivot = ivVector[lHead] /*now ivVector[lHead] is free*/;
                lHead < rHead; rHead--)
                if (ivVector[rHead] < pivot)
                {
                    ivVector[lHead] = ivVector[rHead];
                    for (lHead++; lHead < rHead; lHead++)
                        if (ivVector[lHead] >= pivot)   //we'll try this way
                        {
                            ivVector[rHead] = ivVector[lHead];
                            break;
                        }
                }
            ivVector[lHead] = pivot;                    //restore the pivot on the wall position
            ilStack.Add(lHead);                         //push the new wall index into stack simul
            while (ilStack.Count != 0 && rBound - ilStack[ilStack.Count - 1] - 1 <= 1)      //if diff b/w bound and wall has only 1 or < elements => sub-range is sorted; un-garbage
            {
                rBound = ilStack[ilStack.Count - 1];    //set the new bound from the stack
                ilStack.RemoveAt(ilStack.Count - 1);    //pop the stack
            }
        }

        //print output
        Console.WriteLine("Sorted array {{ {0} }}", string.Join(", ", ivVector));
    }
}