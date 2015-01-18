/*
 * Problem 8. Isosceles Triangle
 *
 * Write a program that prints an isosceles triangle of 9 copyright symbols ©.
 * Note: The © symbol may be displayed incorrectly at the console
 * so you may need to change the console character encoding to UTF-8
 * and assign a Unicode-friendly font in the console.
 * Note: Under old versions of Windows the © symbol may still be displayed incorrectly,
 * regardless of how much effort you put to fix it.
 */
using System;
using System.Text;

class IsoscelesTriangle
{
    static void Main()
    {
        // Initial declarations //
        string sWellcome = "Isosceles Triangle\nCopyright (c) 2015 Zenix.\n\n" +
                           "Change the console font to TrueType font (for example 'Lucida Console') via\n" +
                           "right click -> properties -> font tab -> font box.\n";
        string sSetPrompt = "Set triangle's {0} as integer value in the range {1} to {2}: ";
        string sErrorPrompt = "Invalid {0}. Try again: ";
        string sEvenMessage = "For the triangle to have unambiguous top, the {0} should be odd value.\n" +
                              "Your {0} was trimmed down to {1}.";
        char cSymbol = '\u00A9';                            // copyright character
        ushort usBase;                                      // for the triangle's base length
        ushort usHeight;                                    // for the triangle's height
        byte bBaseMin = 3;                                  // minimum, allowed for the base length
        byte bHeightMin = 4;                                // minimum, allowed for the height

        // Wellcome & prompt with default encoding //
        Console.WriteLine(sWellcome);
        Console.Write(sSetPrompt, "base length", bBaseMin, Console.LargestWindowWidth);     // prompt: base
        while (!(ushort.TryParse(Console.ReadLine(), out usBase)
            && usBase >= bBaseMin
            && usBase <= Console.LargestWindowWidth))                   // parsing: base; entering infinite loop if input is out of range
            Console.Write(sErrorPrompt, "base length");                 // error prompt: base; loop
        // Check the base value: if even, make it odd
        if (usBase % 2 == 0)                                            // even
        {
            usBase--;                                                   // decrement to the highest odd value
            Console.WriteLine(sEvenMessage, "base length", usBase);     // decrement message
        }
        Console.Write(sSetPrompt, "height", bHeightMin, Console.LargestWindowHeight);       // prompt: height
        while (!(ushort.TryParse(Console.ReadLine(), out usHeight)
            && usHeight >= bHeightMin
            && usHeight <= Console.LargestWindowHeight))                // parsing: height; entering infinite loop if input is out of range
            Console.Write(sErrorPrompt, "height");                      // error prompt: height; loop

        // Input successful. Proceed to console config //
        Console.Clear();                                                // flush the console
        Console.BackgroundColor = ConsoleColor.DarkBlue;                // set bg color: maroon
        Console.ForegroundColor = ConsoleColor.White;                   // set fg color: white
        Console.OutputEncoding = Encoding.UTF8;                         // set encoding: UTF-8
        if (usBase > Console.WindowWidth)
        {                                                               // enlarge console horisontally if too narrow
            Console.BufferWidth = usBase;
            Console.WindowWidth = Console.BufferWidth;
        }
        if (usHeight > Console.WindowHeight)
        {                                                               // enlarge console vertically if too short
            Console.BufferHeight = usHeight + 2;                        // + 2 rows: "Any key" prompt + 1 empty row
            Console.WindowHeight = Console.BufferHeight;
        }

        // Draw logic //
        for (int x = 1; x <= usHeight; x++)                             // iterator: rows; x=[1:height]
        {
            // Calculate the coords for triangle's legs at any row
            double y_hi = (double)usBase / 2d * (1d + (x - 1d) / ((double)usHeight - 1d));      // right leg
            double y_lo = usBase - y_hi;                                                        // left leg
            y_hi = Math.Floor(y_hi);                                    // round right value lower
            y_lo = Math.Floor(y_lo);                                    // round left value lower
            int length = (int)(y_hi - y_lo + 1);                        // determine the length between the legs (inclusive)
            // Generate the output string for the row
            string s;
            if (length == 1)                                            // one char rows
                s = new String(cSymbol, x);
            else if (x == usHeight)                                     // last row; row length = base length
                s = new String(cSymbol, usBase);
            else                                                        // any other row: © + spaces + ©
                s = cSymbol + new String(' ', length - 2) + cSymbol;
            // Position the cursor and draw
            Console.CursorLeft = (int)y_lo;
            Console.WriteLine(s);
        }

        // End draw. Reset colors //
        Console.ResetColor();
        /*
         * I decide to make the console change its font automatically to eliminate the need of manual user setting.
         * I spent day 1 in understanding the right way of loading and calling kernel library functions.
         * I spent day 2 in trying & trying & TRYING to make some functions work.
         *                                                      I made them work. Nothing changed! Quit the task.
         * I spent day 3 until I get the program right. It still have issues in certain cases...
         * Result: 3 days lost for a 10 minute exercise.
         *
         * Zenix
         */
    }
}
