/*
 * Problem 17.* Calculate GCD
 *
 * Write a program that calculates the greatest common divisor (GCD) of given two integers a and b.
 * Use the Euclidean algorithm (find it in Internet).
 */
using System;

class CalculateGCDViaEA
{
    static void Main()
    {
        Console.WriteLine("Enter 2 integers (other than 0) to calculate their GCD using the EA:");
        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());
        string result = "GCD(" + a + ", " + b + ")";        //cache the values
        if (a == 0 || b == 0)                               //basic validation
        {
            Console.WriteLine("Error: Can not be 0.");
            return;
        }
        if (a < 0)                                          //make a positive
        {
            a = -a;
        }
        if (b < 0)                                          //make b positive
        {
            b = -b;
        }
        if (b > a)                                          //sort
        {
            a = a + b;
            b = a - b;
            a = a - b;
        }
        for (int r = a % b; r != 0; a = b, b = r, r = a % b) ;        //the Euclidean algo

        Console.WriteLine("{0} = {1}", result, b);          //print the GCD
    }
}