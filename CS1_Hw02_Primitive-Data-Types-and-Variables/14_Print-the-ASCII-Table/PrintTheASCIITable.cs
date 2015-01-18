/*
 * Problem 14.* Print the ASCII Table
 *
 * Find online more information about ASCII (American Standard Code for Information Interchange)
 * and write a program that prints the entire ASCII table of characters on the console (characters from 0 to 255).
 * 
 * Note: Some characters have a special purpose and will not be displayed as expected.
 * You may skip them or display them differently.
 */
using System;
using System.Text;

class PrintTheASCIITable
{
    static void Main()
    {
        string sPrint;
        byte bLimit;
        Console.OutputEncoding = Encoding.GetEncoding(1252);
        if (((3 + 5 + 1) * 16) + 1 <= Console.LargestWindowWidth)
        {
            Console.BufferWidth = ((3 + 5 + 1) * 16) + 1;
            Console.WindowWidth = Console.BufferWidth;
            bLimit = 16;
        }
        else
            bLimit = 8;
        for (ushort usCharCode = 0; usCharCode <= 255; usCharCode++)
        {
            switch (usCharCode)
            {
                case 0: Console.Write("ASCII [0:127]"); break;
                case 128: Console.Write("\nHIGH ASCII [128:255]"); break;
            }
            if (usCharCode % bLimit == 0)
                Console.WriteLine();
            switch (usCharCode)
            {
                case 7: sPrint = usCharCode.ToString().PadLeft(3) + " <BEL>"; break;
                case 8: sPrint = usCharCode.ToString().PadLeft(3) + " <BS> "; break;
                case 9: sPrint = usCharCode.ToString().PadLeft(3) + " <TAB>"; break;
                case 10: sPrint = usCharCode.ToString().PadLeft(3) + " <LF> "; break;
                case 13: sPrint = usCharCode.ToString().PadLeft(3) + " <CR> "; break;

                default: sPrint = usCharCode.ToString().PadLeft(3) + " " + ((char)usCharCode).ToString().PadRight(5); break;
            }
            Console.Write(sPrint);
            
        }
        Console.WriteLine();
    }
}