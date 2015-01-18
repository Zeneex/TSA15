/*
 * Problem 4. Unicode Character
 *
 * Declare a character variable and assign it with the symbol that has Unicode code 42 (decimal)
 * using the \u00XX syntax, and then print it.
 * The output should be *.
 */
using System;

class UnicodeCharacter
{
    static void Main()
    {
        // 42 = 32 + 10 = 20(16) + A(16) = 2A(16)
        char cChar = '\u002A';
        Console.WriteLine("The value has to be '*' char, it's '" + cChar + "' char; Correct? - " + (cChar == '*'));
    }
}