/*
 * This class is used to store some helper methods that ease the task solutions even more (at least for me)
 */

using System;

class HelperMethods
{
    public static int[] GetCyclicInput(int cycles)
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
}