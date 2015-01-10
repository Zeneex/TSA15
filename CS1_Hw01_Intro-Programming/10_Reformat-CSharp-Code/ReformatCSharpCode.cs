// Problem 10. Reformat C# Code

// Reformat the following C# code to make it readable according to the C# best practices for code formatting.
// Change the casing of the identifiers in the code (e.g. use PascalCase for the class name).

// unformatted code
/*
using

System;

class hoRRiblEcoDe
{
    static
     void

        Main()
    {
        Console.

    WriteLine("Hi, I am horribly formatted program"
); Console.
      WriteLine("Numbers and squares:")
; for (int i = 0;
i < 10;
i++)
        {
            Console.WriteLine(i +
                " --> " + i
                *
                i);
        }
    }
}
*/

// formatted code
using System;

class HorribleCode
{
    static void Main()
    {
        Console.WriteLine("Hi, I was horribly formatted program");
        Console.WriteLine("Numbers and squares:");
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine(i + " --> " + i * i);
        }
    }
}