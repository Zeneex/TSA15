/*
 * Problem 13.* Comparing Floats
 *
 * Write a program that safely compares floating-point numbers (double) with precision 'eps' = 0.000001.
 * Note: Two floating-point numbers 'a' and 'b' cannot be compared directly by "a == b"
 * because of the nature of the floating-point arithmetic. Therefore, we assume two numbers are equal
 * if they are more closely to each other than a fixed constant 'eps'.
 */
using System;

class ComparingFloats
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
        double a;
        double b;
        double eps = 0.000001;
        a = 5.3;
        b = 6.01;
        Console.WriteLine("a = {0}; b = {1}; precision = {2}; a = b: {3}", a, b, eps, EqualFloats(a, b, eps));
        a = 5.00000001;
        b = 5.00000003;
        Console.WriteLine("a = {0}; b = {1}; precision = {2}; a = b: {3}", a, b, eps, EqualFloats(a, b, eps));
        a = 5.00000005;
        b = 5.00000001;
        Console.WriteLine("a = {0}; b = {1}; precision = {2}; a = b: {3}", a, b, eps, EqualFloats(a, b, eps));
        a = -0.0000007;
        b =  0.00000007;
        Console.WriteLine("a = {0}; b = {1}; precision = {2}; a = b: {3}", a, b, eps, EqualFloats(a, b, eps));
        a = -4.999999;
        b = -4.999998;
        Console.WriteLine("a = {0}; b = {1}; precision = {2}; a = b: {3}", a, b, eps, EqualFloats(a, b, eps));
        a = 4.999999;
        b = 4.999998;
        Console.WriteLine("a = {0}; b = {1}; precision = {2}; a = b: {3}", a, b, eps, EqualFloats(a, b, eps));
    }
}