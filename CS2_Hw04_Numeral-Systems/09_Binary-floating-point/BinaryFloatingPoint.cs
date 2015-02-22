/*
 * Problem 9.* Binary floating-point
 *
 * Write a program that shows the internal binary representation of given 32-bit signed floating-point number
 * in IEEE 754 format (the C# type float).
 *
 *  Example:
 *  number  sign    exponent    mantissa
 *  -27,25  1       10000011    10110100000000000000000
 */
using System;

class BinaryFloatingPoint
{
    static string[] ConvertFloatToBinary(float singleNumber)
    {
        string[] bitPattern = new string[3];                //3-string array: 1 - sign, 2 - exponent, 3 - mantissa

        //determine the sign and set string 0
        if (singleNumber < 0)
        {
            bitPattern[0] = "1";
            singleNumber = -singleNumber;                   //if negative - record the sign and turn it positive
        }
        else
        {
            bitPattern[0] = "0";
        }

        //determine the binary exponent and set string 1
        long exponent = 0;
        const long bias = 127;                              //the 32-bit IEEE real format bias const for the exponent

        if (singleNumber >= 2)                              //if >= 2 : normalize by binary division
        {
            while (singleNumber >= 2)
            {
                singleNumber /= 2;
                exponent++;
            }
        }
        else if (singleNumber < 1)                          //if < 1 : normalize by binary multiplication
        {
            while (singleNumber < 1)
            {
                singleNumber *= 2;
                exponent--;
            }
        }

        exponent += bias;                                   //bias the exponent
        bitPattern[1] = OneSystemToAnyOther.ConvertDecimalToBase(exponent, 2).PadLeft(8, '0');

        //generate the mantissa and set string 2
        singleNumber--;                                     //now 0 <= real number < 1

        for (int i = 1; i <= 23 && singleNumber != 0; i++)
        {
            singleNumber *= 2;
            bitPattern[2] += (int)singleNumber;
            singleNumber = singleNumber % 1;
        }
        bitPattern[2] = bitPattern[2].PadRight(23, '0');    //fill the remaining part of the mantissa (if any)

        //return
        return bitPattern;
    }

    static void Main()
    {
        //input
        /*
        Console.Write("View a float signed real number's binary form: ");
        float inputNumber = float.Parse(Console.ReadLine());
        */

        #region test block
        float inputNumber = -27.25f;        //sign: 1, exponent: 10000011, mantissa: 10110100000000000000000
        //float inputNumber = 173.7f;       //sign: 0, exponent: 10000110, mantissa: 01011011011001100110011 (recurring "0110" sequence)
        //float inputNumber = -0.75f;       //sign: 1, exponent: 01111110, mantissa: 10000000000000000000000
        #endregion

        //logic
        string[] bitPattern = ConvertFloatToBinary(inputNumber);

        //output
        Console.WriteLine("number:   {0}", inputNumber);
        Console.WriteLine("sign:     {0}", bitPattern[0]);
        Console.WriteLine("exponent: {0}", bitPattern[1]);
        Console.WriteLine("mantissa: {0}", bitPattern[2]);

        //inportant notes:
        // - the method implemented here works for normalized real numbers only
        //and doesn't support extremely small (denormal) numbers.
        // - the method doesn't realize any rounding of the mantiss' LSB to minimize the precision error,
        //so it might be that some of the mantiss' LSBs aren't exactly correct
        // - sequence recurring (fraction infinity) is not detected -
        //the reported result is limited by the mantiss' length/precision
    }
}