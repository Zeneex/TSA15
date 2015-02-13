/*
 * Problem 1. Allocate array
 *
 * Write a program that allocates array of 20 integers and initializes each element by its index multiplied by 5.
 * Print the obtained array on the console.
 */
using System;

class AllocateArray
{
    static void Main()
    {
        for (int[] i = new int[1], intArray = new int[20]; i[0] < intArray.Length; intArray[i[0]] = i[0] * 5, Console.Write(intArray[i[0]] + " "), i[0]++) ;
    }
}