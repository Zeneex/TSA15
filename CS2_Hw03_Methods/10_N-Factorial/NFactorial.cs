/*
 * Problem 10. N Factorial
 *
 * Write a program to calculate n! for each n in the range [1..100].
 * Hint: Implement first a method that multiplies a number represented as array of digits by given integer number.
 */
using System;
using System.Text;

class NFactorial
{
    static void Main()
    {
        for (int i = 1; i <= 100; i++)
        {
            Console.WriteLine("{0}! = {1}", i, Factorial(i));
        }
    }

    static string Multiply(string multiplicand, int multiplier)     //the multiplicand have to be positive integer
    {
        multiplicand = multiplicand.TrimStart('0');                 //trim unneeded leading zeros

        if (multiplicand == string.Empty || multiplier == 0)        //if some of the factors is 0, return 0
        {
            return new int().ToString();
        }

        long carryOut = 0;                                          //else, calculate the proper product
        StringBuilder product = new StringBuilder(string.Empty);
        for (int i = multiplicand.Length - 1; i >= 0; i--)
        {
            long tempProduct = (long)(multiplicand[i] - '0') * multiplier + carryOut;
            product = product.Insert(0, tempProduct % 10);
            carryOut = tempProduct / 10;
        }
        if (carryOut != 0)
        {
            product = product.Insert(0, carryOut.ToString());
        }

        return product.ToString();
    }

    static string Factorial(int n)
    {
        if (n < 0)                  //return error if n is negative
        {
            return "Invalid value";
        }
        else if (n <= 1)            //return 1 if n equals 0 or 1; 0! = 1
        {
            return 1.ToString();
        }

        StringBuilder factorial = new StringBuilder("1");
        while (n > 1)
        {
            string tempFactorial = Multiply(factorial.ToString(), n);
            factorial = factorial.Clear();
            factorial.Append(tempFactorial);
            n--;
        }

        return factorial.ToString();
    }
}