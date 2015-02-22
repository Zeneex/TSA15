/*
 * Problem 8. Binary short
 *
 * Write a program that shows the binary representation of given 16-bit signed integer number (the C# type short).
 */
using System;

class BinaryShort
{

    static void Main()
    {
        //input
        Console.Write("View a short signed integer number's binary form: ");
        short inputNumber = short.Parse(Console.ReadLine());
        
        //output
        Console.WriteLine("{0}(10) = {1}(2)",
            inputNumber, OneSystemToAnyOther.ConvertDecimalToBase((long)(ushort)inputNumber, 2).PadLeft(16, '0'));

        //instead of doing the ushort complement calculation when number is negative, i.e. 65536 + inputNumber
        //[for inputNumber < 0], it's the same as (ushort)inputNumber, so
        //65536 + inputNumber = 65535 + 1 - |inputNumber| = ushort.MaxVal + 1 - |inputNumber| = (ushort)inputNumber
        //and we just use our already tested methods for representing numbers in binary form...
    }
}