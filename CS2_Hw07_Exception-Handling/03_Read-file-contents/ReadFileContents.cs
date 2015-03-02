/*
 * Problem 3. Read file contents
 *
 * Write a program that enters file name along with its full file path (e.g. C:\WINDOWS\win.ini),
 * reads its contents and prints it on the console.
 * Find in MSDN how to use System.IO.File.ReadAllText(…).
 * Be sure to catch all possible exceptions and print user-friendly error messages.
 */
using System;
using System.IO;
using System.Security;

class ReadFileContents
{
    static void Main()
    {
        //input
        //Console.Write("Enter a file's fullpath in the FS to read: ");
        //string fullPath = Console.ReadLine();

        #region //test block
        //string fullPath = "qwertyA01zxcBZW--113#";                    //raise FileNotFoundException (until you have such meaningless file)
        //string fullPath = null;                                       //raise ArgumentNullException
        //string fullPath = "\n";                                       //raise ArgumentException
        //string fullPath = @"C:\Windows\whatfile?:whatextension?";     //raise ArgumentException
        //string fullPath = string.Empty;                               //raise ArgumentException
        //string fullPath = new string('c', 270);                       //raise PathTooLongException
        //string fullPath = @"C:\Root\Win32\text.txt";                  //raise DirectoryNotFoundException (until you have such dir)
        //string fullPath = @"C:\Windows\system32\config";              //raise UnauthorizedAccessException
            //DON'T GO THERE UNTIL YOU KNOW EXACTLY WHAT YOU ARE DOING !!!
            //IF YOU GO - DON'T POKE ANYTHING OR YOUR ENTIRE SYSTEM MAY RENDER UNUSABLE !!!
        string fullPath = @"C:\\\\\Windows\\\\\win.ini";                //strangely, it succeeds...
                                                                        //unable to raise IOException
                                                                        //unable to raise NotSupportedException
                                                                        //unable to raise SecurityException
        #endregion

        //logic
        string readText = "File empty";
        try
        {
            readText = File.ReadAllText(fullPath);

            //output
            Console.WriteLine(readText);
        }

        //handlers
        catch (ArgumentNullException)
        {
            Console.WriteLine("Null argument not permitted");
        }
        catch (ArgumentException)
        {
            Console.WriteLine("Path is a zero-length string, contains only white space, or contains one or more invalid path characters");
        }
        catch (PathTooLongException)
        {
            Console.WriteLine("The specified path, file name, or both exceed the system-defined maximum length. Paths must be less than 248 characters, and file names must be less than 260 characters");
        }
        catch (DirectoryNotFoundException)
        {
            Console.WriteLine("The specified path is invalid");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("The file specified was not found");
        }
        catch (IOException)
        {
            Console.WriteLine("An I/O error occurred while opening the file");
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("Path evaluates to a directory instead to a file OR You do not have the required permission");
        }
        catch (NotSupportedException)
        {
            Console.WriteLine("File path is in an invalid format");
        }
        catch (SecurityException)
        {
            Console.WriteLine("You do not have the required permission");
        }
    }
}