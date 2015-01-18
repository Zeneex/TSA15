/*
 * Problem 3. Variable in Hexadecimal Format
 * 
 * Declare an integer variable and assign it with the value 254 in hexadecimal format (0x##).
 * Use Windows Calculator to find its hexadecimal representation.
 * Print the variable and ensure that the result is 254.
 */
using System;

class VariableInHexadecimalFormat
{
    static void Main()
    {
        // 254 = 255-1 = FF(16)-1 = FE(16)
        int iHexToDec = 0xFE;
        Console.WriteLine("The value has to be 254, it's " + iHexToDec + "; Correct? - " + (iHexToDec == 254));
    }
}
