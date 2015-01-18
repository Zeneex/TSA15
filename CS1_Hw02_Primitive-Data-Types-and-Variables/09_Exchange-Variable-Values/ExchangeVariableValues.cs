/*
 * Problem 9. Exchange Variable Values
 *
 * Declare two integer variables a and b and assign them with 5 and 10 and after that
 * exchange their values by using some programming logic.
 * Print the variable values before and after the exchange.
 */
using System;

class ExchangeVariableValues
{
    static void Main()
    {
        // The problem has two types of solutions: w/ additional variable and w/o additional variable
        // We'll demonstrate both of them
        int a = 5;
        int b = 10;
        Console.WriteLine("a = {0}; b = {1}", a, b);

        // w/o 3rd variable     // Initial values;          a=5,  b=10
        a = a + b;              // Sum of the two into a;   a=15, b=10
        b = a - b;              // Diff of the two into b;  a=15, b=5
        a = a - b;              // Diff of the two into a;  a=10, b=5
        Console.WriteLine("a = {0}; b = {1}", a, b);

        // w/ 3rd variable
        int c;                  // Swapped values;              a=10, b=5,  c=null
        c = a;                  // Push a into c; a is free;    a=10, b=5,  c=10
        a = b;                  // Push b into a; b is free;    a=5,  b=5,  c=10
        b = c;                  // Push c into b; c is free;    a=5,  b=10, c=10
        Console.WriteLine("a = {0}; b = {1}", a, b);
    }
}