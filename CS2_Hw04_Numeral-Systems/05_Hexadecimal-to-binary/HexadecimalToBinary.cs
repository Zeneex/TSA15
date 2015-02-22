/*
 * Problem 5. Hexadecimal to binary
 *
 * Write a program to convert hexadecimal numbers to binary numbers (directly).
 */
using System;

class HexadecimalToBinary
{
    static string ConvertHexadecimalToBinary(string hexNumber)
    {
        string binaryNumber = string.Empty;
        for (int i = hexNumber.Length - 1; i >= 0; i--)
        {
            switch(hexNumber[i])
            {
                case '0': binaryNumber = "0000" + binaryNumber; break;
                case '1': binaryNumber = "0001" + binaryNumber; break;
                case '2': binaryNumber = "0010" + binaryNumber; break;
                case '3': binaryNumber = "0011" + binaryNumber; break;
                case '4': binaryNumber = "0100" + binaryNumber; break;
                case '5': binaryNumber = "0101" + binaryNumber; break;
                case '6': binaryNumber = "0110" + binaryNumber; break;
                case '7': binaryNumber = "0111" + binaryNumber; break;
                case '8': binaryNumber = "1000" + binaryNumber; break;
                case '9': binaryNumber = "1001" + binaryNumber; break;
                case 'A': binaryNumber = "1010" + binaryNumber; break;
                case 'B': binaryNumber = "1011" + binaryNumber; break;
                case 'C': binaryNumber = "1100" + binaryNumber; break;
                case 'D': binaryNumber = "1101" + binaryNumber; break;
                case 'E': binaryNumber = "1110" + binaryNumber; break;
                case 'F': binaryNumber = "1111" + binaryNumber; break;
            }
        }
        return binaryNumber.TrimStart('0');
    }

    static void Main()
    {
        //input
        Console.Write("Convert a hex number to binary number: ");

        //output
        Console.WriteLine(ConvertHexadecimalToBinary(Console.ReadLine()));
    }
}