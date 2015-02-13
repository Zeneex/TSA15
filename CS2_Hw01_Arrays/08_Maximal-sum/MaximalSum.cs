/*
 * Problem 8. Maximal sum
 *
 * Write a program that finds the sequence of maximal sum in given array.
 * Can you do it with only one loop (with single scan through the elements of the array)?
 */
using System;

class MaximalSum
{
    static void Main()
    {
        //int[] ivVector = { 2, 3, -6, -1, 2, -1, 6, 4, -8, 8 };            //output range: { 2, -1, 6, 4 }
        //int[] ivVector = { 2, 3, -1, -6, 2, -1, 6, 4, -100, 8, 10 };      //output range: { 8, 10 }
        //int[] ivVector = { 2, 3, -1, -6, 2, -1, 6, 4, -2, 8, 10 };        //output range: { 2, -1, 6, 4, -2, 8, 10 }
        //int[] ivVector = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };               //output range: { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }
        //int[] ivVector = { -1, -2, -3, -4, -5, 0, -7, -8, -9, -10 };      //output range: { 0 }
        int[] ivVector = { -1, 0, 5, 3, -5, 0, 20, -21, 0, 30 };            //output range: { 0, 5, 3, -5, 0, 20, -21, 0, 30 }
        //int[] ivVector = { 3, -1, 0, 0, 0, 0, -1, 0, 3 };                 //output range: { 3, -1, 0, 0, 0, 0, -1, 0, 3 }

        long tempSum;
        long tempIndex;
        long tempLength;
        long peakSum;
        long peakIndex;
        long peakLength;

        if (ivVector.Length != 0)       //initialize to first element
        {
            tempSum = ivVector[0];
            tempIndex = 0;
            tempLength = 1;

            peakSum = tempSum;
            peakIndex = tempIndex;
            peakLength = tempLength;
        }
        else                            //break if array empty
        {
            Console.WriteLine("Error: Empty array.");
            return;
        }

        for (int i = 1; i < ivVector.Length; i++)   //begin from the 2nd array element
        {
            if (ivVector[i] >= 0)    //increase or nothing
            {
                if (tempSum >= 0)
                {
                    tempSum += ivVector[i];
                    tempLength++;
                }
                else
                {
                    tempSum = ivVector[i];
                }
                tempIndex = i;
            }
            else                    //decrease
            {
                if (tempSum > peakSum)              //save the temp if it's > the cached peak
                {
                    peakSum = tempSum;
                    peakIndex = tempIndex;
                    peakLength = tempLength;
                }

                if (ivVector[i] + tempSum >= 0)     //keep the temp going only if it's not negative (positive adder)
                {
                    tempSum += ivVector[i];
                    tempIndex = i;
                    tempLength++;
                }
                else                                //flush the temp if its sum is below zero (negative adder)
                {
                    tempSum = ivVector[i];
                    tempIndex = i;
                    tempLength = 1;
                }
            }
        }

        if (tempSum > peakSum)              //save the temp if it's > the cached peak (after full array scan)
        {
            peakSum = tempSum;
            peakIndex = tempIndex;
            peakLength = tempLength;
        }

        //print output
        int[] ivSubVector = new int[peakLength];  //initialize sub-array
        Array.Copy(ivVector, peakIndex - (peakLength - 1), ivSubVector, 0, peakLength);    //copy sub-range into sub-array

        Console.WriteLine("Array {{ {0} }}", string.Join(", ", ivVector));
        Console.WriteLine("Maximal sum sub-array {{ {0} }}", string.Join(", ", ivSubVector));
        Console.WriteLine("Sub-array index = {0}", peakIndex - (peakLength - 1));
        Console.WriteLine("Sub-array length = {0}", peakLength);
        Console.WriteLine("Sub-array sum = {0}", peakSum);

        //it took me 5 hours until I get it to work properly
        //don't hate me for not implementing user input
    }
}
