/*
 * Problem 6. Strings and Objects
 *
 * Declare two string variables and assign them with Hello and World.
 * Declare an object variable and assign it with the concatenation of the first two variables
 * (mind adding an interval between).
 * Declare a third string variable and initialize it with the value of the object variable (you should perform type casting).
 */
using System;

class StringsAndObjects
{
    static void Main()
    {
        string sHello = "Hello";
        string sWorld = "World";
        object oHelloWorld = sHello + '\u0020' + sWorld;
        string sHelloWorldFromObj = (string) oHelloWorld;

        Console.WriteLine("'sHello' holds: {0} \n" +
                          "'sWorld' holds: {1} \n" +
                          "'oHelloWorld' holds: {2} \n" +
                          "'sHelloWorldFromObj' holds: {3} \n" +
                          "'oHelloWorld' = 'sHelloWorldFromObj' : {4}",
                          sHello, sWorld, oHelloWorld, sHelloWorldFromObj, (oHelloWorld == sHelloWorldFromObj));
    }
}