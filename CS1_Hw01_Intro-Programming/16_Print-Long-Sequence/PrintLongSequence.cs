// Problem 16.* Print Long Sequence

// Write a program that prints the first 1000 members of the sequence: 2, -3, 4, -5, 6, -7, …
// You might need to learn how to use loops in C# (search in Internet).

class PrintLongSequence
{
    static void Main()
    {
        System.Console.BufferHeight = 1001;                                     // extend the output buffer so it can hold all output + "Press any key" debug message
        for (short n = 1; n <= 1000; n++)                                       // the n-th sequence member
            System.Console.WriteLine((n + 1) * System.Math.Pow(-1, n + 1));     // the sequence member function u(n) = (n+1)*(-1)^(n+1); for n = [1:1000] u(n) = [2:-1001]
    }
}