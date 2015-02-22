/*
 * Problem 6. Binary to hexadecimal
 *
 * Write a program to convert binary numbers to hexadecimal numbers (directly).
 */
using System;

class BinaryToHexadecimal
{
    static string ConvertBinaryToHexadecimal(string binaryNumber)
    {
        string hexNumber = string.Empty;
        if (binaryNumber.Length % 4 != 0)
        {
            binaryNumber = binaryNumber.PadLeft(4 - (binaryNumber.Length % 4) + binaryNumber.Length, '0');
        }

        for (int i = 0; i < binaryNumber.Length; i += 4)
        {
            switch (binaryNumber.Substring(i, 4))
            {
                case "0000": hexNumber += '0'; break;
                case "0001": hexNumber += '1'; break;
                case "0010": hexNumber += '2'; break;
                case "0011": hexNumber += '3'; break;
                case "0100": hexNumber += '4'; break;
                case "0101": hexNumber += '5'; break;
                case "0110": hexNumber += '6'; break;
                case "0111": hexNumber += '7'; break;
                case "1000": hexNumber += '8'; break;
                case "1001": hexNumber += '9'; break;
                case "1010": hexNumber += 'A'; break;
                case "1011": hexNumber += 'B'; break;
                case "1100": hexNumber += 'C'; break;
                case "1101": hexNumber += 'D'; break;
                case "1110": hexNumber += 'E'; break;
                case "1111": hexNumber += 'F'; break;
            }
        }
        return hexNumber.TrimStart('0') == string.Empty ? "0" : hexNumber.TrimStart('0');
    }

    static void Main()
    {
        //input
        Console.Write("Convert a binary number to hex number: ");

        //output
        Console.WriteLine(ConvertBinaryToHexadecimal(Console.ReadLine()));
    }
}