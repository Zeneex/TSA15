/*
 * Problem 4. Appearance count
 *
 * Write a method that counts how many times given number appears in given array.
 * Write a test program to check if the method is workings correctly.
 */
using System;

class AppearanceCount
{
    static double[] GetCyclicInput(int cycles)
    {
        double[] ivInputs = new double[cycles];
        Console.WriteLine("Enter {0} values (as real values):", cycles);
        for (int i = 0; i < cycles; i++)
        {
            Console.Write("value " + i + ": ");
            ivInputs[i] = double.Parse(Console.ReadLine());
        }
        return ivInputs;
    }

    static int CountValueAppearance(double keyValue, double[] dvArray)
    {
        int appearanceCount = 0;
        foreach (var value in dvArray)
        {
            if (value == keyValue)
            {
                appearanceCount++;
            }
        }
        return appearanceCount;
    }

    static string ConsolePrintArray(double[] dvArray)   //print array isn't appropriate name here, as the method just returns the string representation
    {
        return string.Join(", ", dvArray);
    }

    static void Main()
    {
        //input
        /*
        Console.Write("Enter the length of the input array: ");
        int length = int.Parse(Console.ReadLine());
        double[] dvInputVector = GetCyclicInput(length);
        */
        double[] dvInputVector = { 2.3, 4.36, 2.1, 3.3, 3.3, 3.3, 45.6, 1.2, 3.3 };
        /*
        Console.Write("Enter a value to get its frequency: ");
        double keyValue = double.Parse(Console.ReadLine());
        */
        double keyValue = 3.3;

        //output
        Console.WriteLine("array: {{ {0} }}", ConsolePrintArray(dvInputVector));
        Console.WriteLine("key value: {0}", keyValue);
        Console.WriteLine("key value appearance count: {0}", CountValueAppearance(keyValue, dvInputVector));
    }
}