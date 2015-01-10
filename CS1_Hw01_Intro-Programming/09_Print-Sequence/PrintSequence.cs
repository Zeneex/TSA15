// Problem 9. Print a Sequence

// Write a program that prints the first 10 members of the sequence: 2, -3, 4, -5, 6, -7, ...

class PrintSequence
{
    static void Main()
    {
        for (short n = 1; n <= 10; n++)                                         // the n-th sequence member
            System.Console.WriteLine((n + 1) * System.Math.Pow(-1, n + 1));     // the sequence member function u(n) = (n+1)*(-1)^(n+1); for n = [1:10] u(n) = {2,-3,4,-5,6,-7,8,-9,10,-11}
    }
}