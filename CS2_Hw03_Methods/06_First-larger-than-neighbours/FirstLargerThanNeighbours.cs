/*
 * Problem 6. First larger than neighbours
 *
 * Write a method that returns the index of the first element in array that is larger than its neighbours, or -1, if there’s no such element.
 * Use the method from the previous exercise.
 */
using System;

class FirstLargerThanNeighbours
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

    static int GetFirstLargerElement(int[] ivArray)
    {
        for (int i = 0; i < ivArray.Length; i++ )
        {
            if (CompareAdjacentElements(i, ivArray) == 1)
            {
                return i;
            }
        }
        return -1;
    }

    static void Main()
    {
        //input
        Console.Write("Enter the length of the input array: ");
        int length = int.Parse(Console.ReadLine());
        int[] ivInputVector = GetCyclicInput(length);

        //output
        Console.WriteLine("array: {{ {0} }}", ConsolePrintArray(ivInputVector));
        int result = GetFirstLargerElement(ivInputVector);
        if (result != -1)
        {
            Console.WriteLine("first larger element is array[{0}] = {1}", result, ivInputVector[result]);
        }
        else
        {
            Console.WriteLine("there is not an element that is larger than both its neighbours");
        }
    }
}