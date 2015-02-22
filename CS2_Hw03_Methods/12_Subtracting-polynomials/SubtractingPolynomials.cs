/*
 * Problem 12. Subtracting polynomials
 *
 * Extend the previous program to support also subtraction and multiplication of polynomials.
 */
using System;
using System.Collections.Generic;

class SubtractingPolynomials
{
    static List<int> SubtractPolynoms(List<int> minuendPolynom, List<int> subtrahendPolynom)
    {
        List<int> polynomDiff = new List<int>();

        List<int> shorterList = minuendPolynom;
        List<int> longerList = subtrahendPolynom;

        if (minuendPolynom.Count > subtrahendPolynom.Count)
        {
            shorterList = subtrahendPolynom;
            longerList = minuendPolynom;
        }

        for (int i = 0; i < longerList.Count; i++)
        {
            if (i > polynomDiff.Count - 1)
            {
                polynomDiff.Add(new int());
            }

            if (i <= shorterList.Count)
            {
                polynomDiff[i] = minuendPolynom[i] - subtrahendPolynom[i];
            }
            else
            {
                polynomDiff[i] += -longerList[i];
                
            }
        }

        return polynomDiff;
    }

    static void Main()
    {
        int n = 2;
        string[] representations = new string[n];
        representations[0] = "1x^2 + x^2 + 0x^1 + x^1 + x + 2x + 5 + 10x^3 + 12x^5 + -2x^2";
        representations[1] = "3x^2 + 4x^2 + 10x^1 + 0x^1 + 0x + 2x^0 + 5 + 10x^3 + 12x^5 + -25x^2";
        //representations[2] = -1x^2 + -1x^2 + -0x^1 + x^1 "+ x + 2x + -5 + -10x^3 + -12x^5 + 2x^2";
        //representations[3] = "3 + -1x^6 + -3x^5 + -12x^2 + -1x + 2x + 15x^4 + 11x^3 + -14x^7";
        //the parser is not good enough to pass it "-x" w/o coefficient b/w the sign & the "x" - it will fail

        List<int> Polynom1 = new List<int>();
        Polynom1 = AddingPolynomials.GetPolynom(representations[0]);

        List<int> Polynom2 = new List<int>();
        Polynom2 = AddingPolynomials.GetPolynom(representations[1]);
        
        List<int> polynomDiff = new List<int>();
        polynomDiff = SubtractPolynoms(Polynom1, Polynom2);

        Console.WriteLine("polynom diff = " + AddingPolynomials.GetPolynomString(polynomDiff));
    }
}