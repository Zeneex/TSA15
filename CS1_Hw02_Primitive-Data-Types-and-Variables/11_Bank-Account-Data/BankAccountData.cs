/*
 * Problem 11. Bank Account Data
 *
 * A bank account has a holder name (first name, middle name and last name),
 * available amount of money (balance), bank name, IBAN,
 * 3 credit card numbers associated with the account.
 * Declare the variables needed to keep the information for a single bank account
 * using the appropriate data types and descriptive names.
 */
using System;

class BankAccountData
{
    static void Main()
    {
        ulong   ulAccount = 0ul;
        // holder
            string  sFirstName = null;
            string  sMiddleName = null;
            string  sLastName = null;
        decimal dBallance = 0.0m;
        string  sBankName = null;
        // iban                                 // It has to be some type of structure, not a string dummy...
            // string sIbanPrefix = null;
            // ulong ulIbanValue = 0ul;
            string  sIban = null;
        ulong   ulCardNumber1 = 0ul;
        ulong   ulCardNumber2 = 0ul;
        ulong   ulCardNumber3 = 0ul;
        /*
        Console.WriteLine("Bank: {0}", sBankName);
        Console.WriteLine("Account: {0}", ulAccount);
        Console.WriteLine("IBAN: {0}", sIban);
        Console.WriteLine("Holder: {1} {2}, {0}", sFirstName, sMiddleName, sLastName);
        Console.WriteLine("Money: {0}", dBallance);
        Console.WriteLine("Card #1: {0}", ulCardNumber1);
        Console.WriteLine("Card #2: {0}", ulCardNumber2);
        Console.WriteLine("Card #3: {0}", ulCardNumber3);
        */
    }
}