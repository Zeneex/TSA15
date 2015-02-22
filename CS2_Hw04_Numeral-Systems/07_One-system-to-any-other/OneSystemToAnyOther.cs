/*
 * Problem 7. One system to any other
 *
 * Write a program to convert from any numeral system of given base s to any other numeral system of base d (2 ≤ s, d ≤ 16).
 */
using System;

public class OneSystemToAnyOther
{
    public static string ConvertDecimalToBase(long decimalNumber, int targetBase)
    {
        string targetBaseNumber = string.Empty;
        while (decimalNumber > 0)
        {
            long remainder = decimalNumber % targetBase;
            if (remainder >= 0 && remainder <= 9)
            {
                targetBaseNumber = remainder + targetBaseNumber;
            }
            else
            {
                targetBaseNumber = (char)(remainder - 10 + 'A') + targetBaseNumber;
            }
            decimalNumber /= targetBase;
        }
        return targetBaseNumber;
    }

    static long ConvertBaseToDecimal(string sourceNumber, int sourceBase)
    {
        long decimalNumber = new long();
        for (int i = sourceNumber.Length - 1; i >= 0; i--)
        {
            if (sourceNumber[i] >= '0' && sourceNumber[i] <= '9')
            {
                decimalNumber += (sourceNumber[i] - '0') * (long)Math.Pow(sourceBase, sourceNumber.Length - 1 - i);
            }
            else
            {
                decimalNumber += (sourceNumber[i] - 'A' + 10) * (long)Math.Pow(sourceBase, sourceNumber.Length - 1 - i);
            }
        }
        return decimalNumber;
    }

    static string ConvertBaseToBase(string inputNumber, int sourceBase, int targetBase)
    {
        if (sourceBase == targetBase)
        {
            return inputNumber;
        }
        else if (sourceBase == 10)
        {
            return ConvertDecimalToBase(long.Parse(inputNumber), targetBase);
        }
        else if (targetBase == 10)
        {
            return ConvertBaseToDecimal(inputNumber, sourceBase).ToString();
        }
        else
        {
            string tempConvert = ConvertBaseToDecimal(inputNumber, sourceBase).ToString();
            return ConvertDecimalToBase(long.Parse(tempConvert), targetBase);
        }
    }

    static void Main()
    {
        //input
        Console.Write("Convert a number in one numeral system to a number in another numeral system." +
            "\nNumber have to be non-negative: ");
        string inputNumber = Console.ReadLine();
        Console.Write("Source numeral system base (2 to 16): ");
        int sourceBase = int.Parse(Console.ReadLine());
        Console.Write("Target numeral system base (2 to 16): ");
        int targetBase = int.Parse(Console.ReadLine());

        //output
        Console.WriteLine("{0}(10) = {1}({2})",
            inputNumber, ConvertDecimalToBase(long.Parse(inputNumber), targetBase), targetBase);
        Console.WriteLine("{0}({1}) = {2}(10)",
            inputNumber, sourceBase, ConvertBaseToDecimal(inputNumber, sourceBase));
        Console.WriteLine("{0}({1}) = {2}({3})",
            inputNumber, sourceBase, ConvertBaseToBase(inputNumber, sourceBase, targetBase), targetBase);
    }
}