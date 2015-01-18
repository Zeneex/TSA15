/*
 * Problem 5. Boolean Variable
 *
 * Declare a Boolean variable called isFemale and assign an appropriate value corresponding to your gender.
 * Print it on the console.
 */
using System;
using System.Text.RegularExpressions;                               // swith-on the regex class

class BooleanVariable
{
    static void Main()
    {
        string sPatternFemale = "^f(e(m(a(le?)?)?)?|m(l|ale)?)?$";  // crafted regex search pattern for female
        string sPatternMale = "^m(a(le?)?|l)?$";                    // crafted regex search pattern for male
        bool isFemale = false;                                      // our boolean variable

        Console.Write("Please, enter your gender: ");               // gender prompt

        while (!isFemale)                                           // genger check; enter infinite loop if invalid
        { 
            string sInput = Console.ReadLine();                     // user intup
            
            // What follows is input check against the female regex pattern.
            // If pattern matches, IsMatch() method returns true to the bool variable.
            isFemale = Regex.IsMatch(sInput, sPatternFemale, RegexOptions.IgnoreCase);
            if (isFemale)                                                                   // valid; true (exit loop)
                Console.WriteLine("'isFemale' returns " + isFemale + ". Hello, lady.");

            // You're not a female. Are you male?
            else if (Regex.IsMatch(sInput, sPatternMale, RegexOptions.IgnoreCase))          // valid; false
            {
                Console.WriteLine("'isFemale' returns " + isFemale + ". What's up, dude.");
                return;                                                                     // exit loop anyway
            }
            // You're neither male, nor a female. You got to be either one!
            else
                Console.Write("Invalid gender. Please, try again: ");                       // invalid; loop
        }
    }
}