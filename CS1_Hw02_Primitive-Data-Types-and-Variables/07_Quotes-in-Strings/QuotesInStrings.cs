/*
 * Problem 7. Quotes in Strings
 *
 * Declare two string variables and assign them with following value: The "use" of quotations causes difficulties.
 * Do the above in two different ways - with and without using quoted strings.
 * Print the variables to ensure that their value was correctly defined.
 */
using System;

class QuotesInStrings
{
    static void Main()
    {
        string sUnquoted = "The \"use\" of quotations causes difficulties.";    // without using quoted string;
        string sQuoted = @"The ""use"" of quotations causes difficulties.";     // via quoted string;
        Console.WriteLine("Is the unquoted string: \n" +
                          "'" + sUnquoted + "' \n" +
                          "equal to the queted one: \n" +
                          "'" + sQuoted + "'? \n" +
                          (sUnquoted == sQuoted));
    }
}