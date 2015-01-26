/*
 * Problem 6. Quadratic Equation
 *
 * Write a program that reads the coefficients a, b and c of a quadratic equation ax2 + bx + c = 0
 * and solves it (prints its real roots).
 */
using System;
using System.Globalization;
using System.Threading;

class QuadraticEquation
{
    static public bool EqualFloats(double a, double b, double eps)
    {
        if (Math.Abs(a - b) < eps)
            return true;
        else
            return false;
    }
    static void Main()
    {
        //def
        double a, b, c;

        //config
        Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-us");      //strict-localize the program

        //user input
        Console.WriteLine("Enter quadratic equation coefficients, from {0:E2} to {1:E2} (use '.' for decimal sign): ",
            double.MinValue, double.MaxValue);
        if ( 
            !( double.TryParse(Console.ReadLine(), out a) &&
               double.TryParse(Console.ReadLine(), out b) &&
               double.TryParse(Console.ReadLine(), out c) )
           )
            Console.WriteLine("Error: Invalid number.");

        //logic
        else if (a == 0)                                                    /*no quadratic coefficient*/
            Console.WriteLine("Error: Linear equation.");
        else if (EqualFloats(Math.Sqrt(b*b - 4*a*c), 0, 0.000001))          /*no discriminant*/
            Console.WriteLine("x1 = x2 = {0:0.###}", -b / 2 / a);
        else if (b * b - 4 * a * c < 0)                                     /*no real roots*/
            Console.WriteLine("no real roots");
        else                                                                /*general case*/
            Console.WriteLine("x1 = {0:0.###}; x2 = {1:0.###}", (Math.Sqrt(b * b - 4 * a * c) - b) / 2 / a, (-Math.Sqrt(b * b - 4 * a * c) - b) / 2 / a);

        //print output (see logic)

        /*logic can be much pretier...*/
    }
}