/*
 * Problem 10. Employee Data
 *
 * A marketing company wants to keep record of its employees.
 * Each record would have the following characteristics:
 *  First name
 *  Last name
 *  Age (0...100)
 *  Gender (m or f)
 *  Personal ID number (e.g. 8306112507)
 *  Unique employee number (27560000…27569999)
 * Declare the variables needed to keep the information for a single employee using appropriate primitive data types.
 * Use descriptive names. Print the data at the console.
 */
using System;
using System.Text.RegularExpressions;

class EmployeeData
{
    static void Main()
    {
        // Initial declarations //
        string sFirstName = null;
        string sLastName = null;
        byte   bAge;
        char   cGender;
        ulong  ulPersonalId;
        uint   uiEmployeeId;

        string sInputPrompt = "Set employee's {0}.\nPossible values - {1}: ";
        string sErrorPrompt = "Invalid {0}. Try again: ";
        string sInputBuffer;
        string sPattern = "^[a-z]+$";
        byte   bCounter;

        // Set names //
        for (bCounter = 1; bCounter <= 2; bCounter++)
        {
            Console.Write(sInputPrompt, (bCounter == 1 ? "first name" : "last name"), "English letters only");      // prompt: names
            sInputBuffer = Console.ReadLine();
            while (!Regex.IsMatch(sInputBuffer, sPattern, RegexOptions.IgnoreCase))                                 // validate: names; loop if invalid
            {
                Console.Write(sErrorPrompt, (bCounter == 1 ? "first name" : "last name"));                          // error prompt: names; loop
                sInputBuffer = Console.ReadLine();
            }
            if (bCounter == 1)                                                                                      // set: names
                sFirstName = sInputBuffer;
            else
                sLastName = sInputBuffer;
        }

        // Set age //
        Console.Write(sInputPrompt, "age", "0 to 100");
        while (!(byte.TryParse(Console.ReadLine(), out bAge) && bAge <= 100))
            Console.Write(sErrorPrompt, "age");

        // Set gender //
        Console.Write(sInputPrompt, "gender", "'m' or 'f'");
        sInputBuffer = Console.ReadLine();
        sPattern = "^[mf]$";
        while (!Regex.IsMatch(sInputBuffer, sPattern))
        {
            Console.Write(sErrorPrompt, "gender");
            sInputBuffer = Console.ReadLine();
        }
        cGender = sInputBuffer[0];

        // Set personal ID number //
        Console.Write(sInputPrompt, "personal ID number", "10-digit numbers only");
        sInputBuffer = Console.ReadLine();
        while (!(ulong.TryParse(sInputBuffer, out ulPersonalId)
                && sInputBuffer.Length == 10
                && ulPersonalId >= 1010100                  // valid range is 00.01.01.01.00 to 99.52.31.99.99
                && ulPersonalId <= 9952319999))
        {
            Console.Write(sErrorPrompt, "personal ID number");
            sInputBuffer = Console.ReadLine();
        }

        // Set employee number //
        Console.Write(sInputPrompt, "unique number", "27560000 to 27569999");
        while (!(uint.TryParse(Console.ReadLine(), out uiEmployeeId)
                && uiEmployeeId >= 27560000
                && uiEmployeeId <= 27569999))
            Console.Write(sErrorPrompt, "unique number");

        // Print employee's info//
        Console.WriteLine("Employee info: {0} {1}, {2}, {3}, ID {4}, # {5}",
                      sFirstName, sLastName, bAge, cGender, ulPersonalId, uiEmployeeId);
        /*
         * The name validation is not strong enough to validate to real-world names.
         * The personal ID validation is not adequate. It has to be split into sub-strings and parsed.
         */
    }
}