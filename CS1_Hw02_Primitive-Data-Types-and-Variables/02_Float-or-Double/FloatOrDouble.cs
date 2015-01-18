/*
 * Problem 2. Float or Double?
 *
 * Which of the following values can be assigned to a variable of type float
 * and which to a variable of type double: 34.567839023, 12.345, 8923.1234857, 3456.091?
 * Write a program to assign the numbers in variables and print them to ensure no precision is lost.
 */
using System;

class FloatOrDouble
{
    static void Main()
    {
        float fNumber1 = 12.345f;           // can be set as float/double w/o loss
        double dNumber2 = 34.567839023;     // can be set as double                (float will lose precision)
        float fNumber3 = 3456.091f;         // can be set as float/double w/o loss
        double dNumber4 = 8923.1234857;     // can be set as double                (float will lose precision)

        Console.WriteLine("Number 1 has to be 12.345, it's " + fNumber1 + "; Correct? - " + (fNumber1 == 12.345f) +
            "\nNumber 2 has to be 34.567839023, it's " + dNumber2 + "; Correct? - " + (dNumber2 == 34.567839023) +
            "\nNumber 3 has to be 3456.091, it's " + fNumber3 + "; Correct? - " + (fNumber3 == 3456.091f) +
            "\nNumber 4 has to be 8923.1234857, it's " + dNumber4 + "; Correct? - " + (dNumber4 == 8923.1234857));
    }
}