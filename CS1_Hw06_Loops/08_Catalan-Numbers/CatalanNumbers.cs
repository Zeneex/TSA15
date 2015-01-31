/*
 * Problem 8. Catalan Numbers
 *
 * In combinatorics, the Catalan numbers are calculated by the following formula:
 *     C_n = (1 / (n + 1)) * combin(2n over n)
 *         = (2n)! / ((n + 1)! * n!)
 *         = (1 / (n + 1)) * ∏(n + i) / n! (for i = 1 to n)
 *         = ∏((n + i) / i) (for i = 2 to n)
 *         = ∏(n + i) / (n + 1)! (for i = 1 to n)
 * Write a program to calculate the nth Catalan number (C_n) by given n (0 ≤ n ≤ 100).
 */
using System;
using System.Numerics;

class CatalanNumbers
{
    static void Main()
    {
        Console.WriteLine("Enter the Nth Catalan index, from 0 to 100: ");
        int n = int.Parse(Console.ReadLine());
        if (n < 0 || n > 100)
        {
            Console.WriteLine("Error: Invalid numbers.");
            return;
        }

        BigInteger factorialDivisor = 1;
        BigInteger productDivident = 1;
        BigInteger catalanNumber = 1;

        for (int i = 1; i <= n; i++)
        {
            productDivident *= (n + i);
            factorialDivisor *= i;
        }
        factorialDivisor *= (n + 1);
        catalanNumber = productDivident / factorialDivisor;

        Console.WriteLine("C_{0} = {1}", n, catalanNumber);
        /*
         * It's important for this task that ∏(n + i) / (n + 1)! variant is used for calculation of the Catalan's
         * number. Other formula variants can not accurately represent a big Catalan's numbers due to the fact they
         * must go through a real division fase, resulting in values with decimal (non-integral) part that need to be
         * preserved for the subsequent arithmetic. The only suitable value type for the task is the decimal type,
         * but it can not hold really big real numbers, for ex. ∏((n + i) / i) when n = 100 and i is from 2 to 100.
         * => the real arithmetic here can not be done for all possible values for n (type overflow occurs).
         * This issue can be overcome by doing intgral-only arithmetic for which the form
         * ∏(n + i) / (n + 1)! (for i = 1 to n) is more appropriate, e.g.:
         *  - first calculating the product (results in integral number)
         *  - then calculating the factorial divisor (results in integral number)
         *  - at the end divide the two (results in integral number, which is the nth Catalan number)
         */
    }
}
