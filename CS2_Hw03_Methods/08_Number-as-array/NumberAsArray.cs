/*
 * Problem 8. Number as array
 *
 * Write a method that adds two positive integer numbers represented as arrays of digits (each array element arr[i] contains a digit; the last digit is kept in arr[0]).
 * Each of the numbers that will be added could have up to 10 000 digits.
 */
using System;
//using System.Numerics;

class NumberAsArray
{
    static byte[] GenerateDigitArray(int upperLimit, Random digitGenerator)
    {

        int length = digitGenerator.Next(1, upperLimit + 1);

        byte[] bvDigitArray = new byte[length];

        for (int i = 0; i < length - 1; i++)
        {
            bvDigitArray[i] = (byte)digitGenerator.Next(0, 10);
        }
        bvDigitArray[bvDigitArray.Length - 1] = (byte)digitGenerator.Next(1, 10);

        return bvDigitArray;
    }

    static byte[] AddBigNumbers(byte[] bvAugendArray, byte[] bvAddendArray)
    {
        byte[] bvLongerArray = bvAugendArray;
        byte[] bvShorterArray = bvAddendArray;

        if (bvAugendArray.Length < bvAddendArray.Length)
        {
            bvLongerArray = bvAddendArray;
            bvShorterArray = bvAugendArray;
        }

        byte[] bvSumArray = new byte[bvLongerArray.Length + 1];

        for (int i = 0; i < bvShorterArray.Length; i++)
        {
            byte digitSum = (byte)(bvAugendArray[i] + bvAddendArray[i] + bvSumArray[i]);
            if (digitSum > 9)
            {
                bvSumArray[i + 1] = 1;
            }
            bvSumArray[i] = (byte)(digitSum % 10);
        }

        for (int i = bvShorterArray.Length;
            i < bvLongerArray.Length; i++)
        {
            byte digitSum = (byte)(bvLongerArray[i] + bvSumArray[i]);
            if (digitSum > 9)
            {
                bvSumArray[i + 1] = 1;
            }
            bvSumArray[i] = (byte)(digitSum % 10);
        }

        return bvSumArray;
    }

    static string ConsolePrintArray(byte[] bvArray)
    {
        return string.Join(", ", bvArray);
    }

    static void Main()
    {
        int upperLimit = 10000;
        Random digitGenerator = new Random();

        byte[] bvAugendArray = GenerateDigitArray(upperLimit, digitGenerator);
        byte[] bvAddendArray = GenerateDigitArray(upperLimit, digitGenerator);

        byte[] bvSumArray = AddBigNumbers(bvAugendArray, bvAddendArray);        //sumArray can have a leading zero in it

        Console.WriteLine(ConsolePrintArray(bvSumArray));
    }
}