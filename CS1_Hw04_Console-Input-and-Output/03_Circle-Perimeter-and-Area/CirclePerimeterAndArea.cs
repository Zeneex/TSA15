/*
 * Problem 3. Circle Perimeter and Area
 *
 * Write a program that reads the radius r of a circle and prints its perimeter and area
 * formatted with 2 digits after the decimal point.
 */
using System;
using System.Globalization;
using System.Threading;

class CirclePerimeterAndArea
{
    static void Main()
    {
        double radius;
        double perimeter;
        double area;

        //config
        Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-us");      //strict-localize the program

        //user input
        Console.Write("Enter the radius for a circle as positive number from 0 to {0:E2}\n(use '.' for decimal sign): ",
            double.MaxValue);
        if ( !( double.TryParse(Console.ReadLine(), out radius) && radius >= 0 ) )
        {
            Console.WriteLine("Error: Invalid radius.");
            return;
        }
        //logic
        perimeter = 2 * Math.PI * radius;
        area = Math.PI * radius * radius;

        //print output
        Console.WriteLine("perimeter: {0:N2}\narea: {1:N2}", perimeter, area);
    }
}