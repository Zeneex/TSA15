// Problem 15.* Age after 10 Years

// Write a program to read your birthday from the console
// and print how old you are now and how old you will be after 10 years.


using System;

class AgeAfter10Years
{
    static void Main()
    {
        byte day;
        byte month;
        ushort year;

        Console.Write("Enter your day of birth: ");                                             // prompt - day
        for (; !byte.TryParse(Console.ReadLine(), out day) | day > 31 ; )                       // parsing - day; entering infinite loop if input is invalid
            Console.Write("Invalid day of birth. Try again: ");                                 // error prompt; loop
        Console.Write("Enter your month of birth: ");                                           // prompt - month
        for (; !byte.TryParse(Console.ReadLine(), out month) | month > 12; )                    // parsing - month; entering infinite loop if input is invalid
            Console.Write("Invalid month of birth. Try again: ");                               // error prompt; loop
        Console.Write("Enter your year of birth: ");                                            // prompt - year
        for (; !ushort.TryParse(Console.ReadLine(), out year) | year > DateTime.Now.Year; )     // parsing - year; entering infinite loop if input is invalid
            Console.Write("Invalid year of birth. Try again: ");                                // error prompt; loop
        
        // CAN NOT OVERCOME THE GODDAMN PARSING BLOAT! >:{

        ushort currentAge = (ushort)((DateTime.Now - new DateTime(year, month, day)).Days / 365.25);    // the actual age in years

        Console.WriteLine("You are {0} y.o. now and you'll be {1} y.o. in 10 years.", currentAge, currentAge + 10);     // final output
    }
}