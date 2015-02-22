/*
 * Problem 5. Larger than neighbours
 *
 * Write a method that checks if the element at given position in given array of integers is larger than its two neighbours (when such exist).
 */
using System;

class LargerThanNeighbours
{
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

    static string ConsolePrintArray(int[] dvArray)
    {
        return string.Join(", ", dvArray);
    }

    static int CompareAdjacentElements(int index, int[] ivArray)
    {
        if (index > 0 && index < ivArray.Length - 1)                                                //if element is not on the bounds, but inside the array
        {
            if (ivArray[index] > ivArray[index - 1] && ivArray[index] > ivArray[index + 1])         //if element is > than its 2 neighbours
            {
                return 1;
            }
            else if (ivArray[index] < ivArray[index - 1] && ivArray[index] < ivArray[index + 1])    //if element is < than its 2 neighbours
            {
                return -1;
            }
            else                                                                                    //if none of the above (not determined)
            {
                return 0;
            }
        }
        else if (index < 0)                                                                         //if element is below lower bound
        {
            return -2;
        }
        else if (index > ivArray.Length)                                                            //if element is above upper bound
        {
            return 2;
        }
        else                                                                                        //if element is on some of the bounds
        {
            return int.MinValue;
        }
    }

    static void Main()
    {
        //input
        Console.Write("Enter the length of the input array: ");
        int length = int.Parse(Console.ReadLine());
        int[] ivInputVector = GetCyclicInput(length);

        Console.Write("Enter element index to check if it's greater than its neighbours: ");
        int index = int.Parse(Console.ReadLine());

        //output
        Console.WriteLine("array: {{ {0} }}", ConsolePrintArray(ivInputVector));
        Console.WriteLine("index: {0}", index);
        
        switch(CompareAdjacentElements(index, ivInputVector))
        {
            case 1:             Console.WriteLine("index {0} is greater than its neighbours: {1} and {2}",
                index, ivInputVector[index - 1], ivInputVector[index + 1]); break;
            case -1:            Console.WriteLine("index {0} is less than its neighbours: {1} and {2}",
                index, ivInputVector[index - 1], ivInputVector[index + 1]); break;
            case 0:             Console.WriteLine("index {0} is undetermined compared to its neighbours: {1} and {2}",
                index, ivInputVector[index - 1], ivInputVector[index + 1]); break;
            case -2:            Console.WriteLine("index {0} is below the lower array bound", index); break;
            case 2:             Console.WriteLine("index {0} is above the upper array bound", index); break;
            case int.MinValue:  Console.WriteLine("index {0} is on some of the bounds", index); break;
        }
    }
}