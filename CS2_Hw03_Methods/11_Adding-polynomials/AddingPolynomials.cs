/*
 * Problem 11. Adding polynomials
 *
 * Write a method that adds two polynomials.
 * Represent them as arrays of their coefficients.
 *
 * Example:
 * x2 + 5 = 1x2 + 0x + 5 => {5, 0, 1}
 */
using System;
using System.Collections.Generic;
using System.Text;

public class AddingPolynomials
{
    public static List<int> GetPolynom(string representation)
    {
        List<int> coefficients = new List<int>();
        string[] monom = new string[2];
        string[] monoms = representation.Split('+');
        for (int i = 0; i < monoms.Length; i++)
        {
            monoms[i] = monoms[i].Trim();

            if (monoms[i].StartsWith("x") || monoms[i].StartsWith("X"))
            {
                monoms[i] = "1" + monoms[i];
            }

            if (monoms[i].EndsWith("x") || monoms[i].EndsWith("X"))
            {
                monoms[i] += "^1";
            }

            if (!monoms[i].Contains("x") && !monoms[i].Contains("X"))
            {
                monoms[i] += "x^0";
            }

            monom = monoms[i].Split(new char[] { 'x', 'X', '^' }, StringSplitOptions.RemoveEmptyEntries);
            int coefficient = int.Parse(monom[0].Trim());
            int power = int.Parse(monom[1].Trim());

            if (power > coefficients.Count - 1)
            {
                coefficients.AddRange(new int[power - (coefficients.Count - 1)]);
            }

            coefficients[power] += coefficient;
        }

        return coefficients;
    }

    static List<int> AddPolynoms(List<List<int>> polynoms)
    {
        List<int> polynomSum = new List<int>();
        foreach (List<int> polynom in polynoms)
        {
            for (int i = 0; i < polynom.Count; i++)
            {
                if (i > polynomSum.Count - 1)
                {
                    polynomSum.Add(new int());
                }

                polynomSum[i] += polynom[i];
            }
        }

        return polynomSum;
    }

    public static string GetPolynomString(List<int> polynom)
    {
        StringBuilder polynomSumString = new StringBuilder(string.Empty);

        for (int i = polynom.Count - 1; i >= 0; i--)
        {
            if (polynom[i] != 0)
            {
                polynomSumString.Append(polynom[i]);

                if (i == 1)
                {
                    polynomSumString.Append("x");
                }
                else if (i != 0 && i != 1)
                {
                    polynomSumString.Append("x^");
                    polynomSumString.Append(i);
                }
                //if i == 0 append nothing
            }
            if (i != 0)
            {
                polynomSumString.Append(" + ");
            }
        }

        string tempResult = polynomSumString.ToString().Trim('+', ' ');
        polynomSumString.Clear();
        polynomSumString.Append(tempResult);

        return polynomSumString.ToString();
    }

    static void Main()
    {
        int n = 4;
        string[] representations = new string[n];
        representations[0] = "1x^2 + x^2 + 0x^1 + x^1 + x + 2x + 5 + 10x^3 + 12x^5 + -2x^2";
        representations[1] = "3x^2 + 4x^2 + 10x^1 + 0x^1 + 0x + 2x^0 + 5 + 10x^3 + 12x^5 + -25x^2";
        representations[2] = "-1x^2 + -1x^2 + -0x^1 + x^1 + x + 2x + -5 + -10x^3 + -12x^5 + 2x^2";
        representations[3] = "3 + -1x^6 + -3x^5 + -12x^2 + -1x + 2x + 15x^4 + 11x^3 + -14x^7";
        //the parser is not good enough to pass it "-x" w/o coefficient b/w the sign & the "x" - it will fail

        List<List<int>> polynoms = new List<List<int>>();
        for (int i = 0; i < representations.Length; i++)
        {
            polynoms.Add( GetPolynom(representations[i]) );
        }

        List<int> polynomSum = new List<int>();
        polynomSum = AddPolynoms(polynoms);

        Console.WriteLine("polynom sum = " + GetPolynomString(polynomSum));
    }
}