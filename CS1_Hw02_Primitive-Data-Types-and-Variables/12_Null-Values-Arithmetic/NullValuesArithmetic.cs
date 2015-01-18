/*
 * Problem 12. Null Values Arithmetic
 *
 * Create a program that assigns null values to an integer and to a double variable.
 * Try to print these variables at the console.
 * Try to add some number or the null literal to these variables and print the result.
 *
 */

using System;

class NullValuesArithmetic
{
    static void Main()
    {
        int?    inInt = null;
        double? dnDbl = null;
        Console.WriteLine("inInt = {0}; dnDbl = {1}", inInt, dnDbl);
        Console.WriteLine("inInt = dnDbl: {0}", (inInt == dnDbl));
        inInt += 5;
        dnDbl += 10;
        Console.WriteLine("inInt + 5 = {0}; dnDbl + 10 = {1}", inInt, dnDbl);
        Console.WriteLine("inInt = dnDbl: {0}", (inInt == dnDbl));
        inInt += null;
        dnDbl += null;
        Console.WriteLine("inInt + null = {0}; dnDbl + null = {1}", inInt, dnDbl);
        Console.WriteLine("inInt = dnDbl: {0}", (inInt == dnDbl));
        inInt = 5;
        dnDbl = 5.5;
        Console.WriteLine("inInt = {0}; dnDbl = {1}", inInt, dnDbl);
        Console.WriteLine("inInt = dnDbl: {0}", (inInt == dnDbl));
        inInt += null;
        dnDbl += null;
        Console.WriteLine("inInt + null = {0}; dnDbl + null = {1}", inInt, dnDbl);
        Console.WriteLine("inInt = dnDbl: {0}", (inInt == dnDbl));
    }
}