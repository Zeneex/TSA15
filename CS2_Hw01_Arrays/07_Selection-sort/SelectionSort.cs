/*
 * Problem 7. Selection sort
 *
 * Sorting an array means to arrange its elements in increasing order. Write a program to sort an array.
 * Use the Selection sort algorithm: Find the smallest element, move it at the first position,
 * find the smallest from the rest, move it at the second position, etc.
 */
using System;
using System.Collections.Generic;

class SelectionSort
{
    static void Main()
    {
        //user input
        Console.Write("Enter array's length (as integer > 0): ");
        int n = int.Parse(Console.ReadLine());                                  //list's length
        if (n <= 0)
        {
            Console.WriteLine("Error: Invalid length.");
            return;
        }
        List<decimal> mlVector = new List<decimal>();                           //create list of real values

        Console.WriteLine("Enter array's elements (as numbers from {0:E2} to {1:E2}):",
            decimal.MinValue, decimal.MaxValue);
        for (int i = 0; i < n; i++)
        {
            Console.Write("Array[{0}] = ", i);
            mlVector.Add(decimal.Parse(Console.ReadLine()));                    //define the elements
        }

        //logic
        for (int i = n - 1; i >= 0; i--)
        {
            int currentMinimumIndex = new int();
            for (int j = 0; j <= i; j++)
                if (mlVector[j] < mlVector[currentMinimumIndex])
                    currentMinimumIndex = j;
            decimal swapValue = mlVector[currentMinimumIndex];
            mlVector.RemoveAt(currentMinimumIndex);
            mlVector.Add(swapValue);
        }

        //print oputput
        Console.WriteLine("Sorted array {{ {0} }}", string.Join(", ", mlVector));

        //instead of using array I decide to play with a list, cause it has already defined functions
        //for adding and removing elements
        //instead of swapping current minimal element in the list with the first element in the list
        //I remove the current minimal element from the list and add it again at the end
        //the list automatically resize and re-index itself
        //the algo is pretty much the same
    }
}