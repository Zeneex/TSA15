// Problem 6. Print Numbers

// Write a program to print the numbers 1, 101 and 1001, each at a separate line.
// Name the program correctly.

class PrintNumbers
{
    static void Main()
    {
        for (byte n = 1; n <= 3; n++)                                                   //the logic - iterator
            System.Console.WriteLine(System.Convert.ToString(1 + (n - 1) * 4, 2));      //the logic - u(n)=1+(n-1)*4; for n=[1:3] u(n)={1,4,9}(dec)={1,101,1001}(bin);
    }
}