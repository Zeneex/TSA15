/*
 * Problem 2. Print Company Information
 *
 * A company has name, address, phone number, fax number, web site and manager.
 * The manager has first name, last name, age and a phone number.
 * Write a program that reads the information about a company and its manager and prints it back on the console.
 */
using System;
using System.Globalization;
using System.Threading;

class PrintCompanyInformation
{
    static void Main()
    {
        string cName,
            cAddress,
            cPhone,
            cFax,
            cSite,
            mFirstName,
            mLastName,
            mPhone,
            cPrompt = "Enter company {0}: ",
            mPrompt = "Enter manager {0}: ",
            error = "Error: Invalid {0}.";
        byte mAge;

        //config
        Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-us");      //strict-localize the program

        //user input
        Console.Write(cPrompt, "name");
        cName = Console.ReadLine();

        Console.Write(cPrompt, "address");
        cAddress = Console.ReadLine();

        Console.Write(cPrompt, "phone number");
        cPhone = Console.ReadLine();

        Console.Write(cPrompt, "fax number");
        cFax = Console.ReadLine();

        Console.Write(cPrompt, "web site");
        cSite = Console.ReadLine();

        Console.Write(mPrompt, "first name");
        mFirstName = Console.ReadLine();

        Console.Write(mPrompt, "last name");
        mLastName = Console.ReadLine();

        Console.Write(mPrompt, "age");
        if (!byte.TryParse(Console.ReadLine(), out mAge))
        {
            Console.WriteLine(error, "age");
            return;
        }
        Console.Write(mPrompt, "phone number");
        mPhone = Console.ReadLine();

        //logic

        //print output
        Console.WriteLine(
            "\n{0}\n" +
            "Address: {1}\n" +
            "Tel.: {2}\n" +
            "Fax: {3}\n" +
            "Web site: {4}\n" +
            "Manager: {5} {6} (age: {8}, tel. {7})",
            cName, cAddress, cPhone, cFax, cSite, mFirstName, mLastName, mPhone, mAge);
    }
}