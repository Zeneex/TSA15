/*
 * Problem 12.* Randomize the Numbers 1…N
 *
 * Write a program that enters in integer n and prints the numbers 1, 2, …, n in random order.
 * 
 * Example:
 *  n 	randomized numbers 1…n
 *  10 	3 4 8 2 6 7 9 1 10 5
 *  
 * You might need to use arrays.
 */
using System;

class RandomizeNNumbers
{
    static void Main()
    {
        Console.Write("Enter numbers count (greater than 0): ");
        int count = int.Parse(Console.ReadLine());                //get the num count
        if (count <= 0)
        {
            Console.WriteLine("Error: Invalid count.");
            return;
        }
        int[] numbers = new int[count];                             //create the nums array
        for (int i = 0; i < numbers.Length; i++)                    //fill the nums - 1 to N
        {
            numbers[i] = i + 1;
        }
        Random random = new Random();                               //create the randomizer
        for (int i = 0, temp, index; i < numbers.Length; i++)       //shuffle the nums - once each num (can be method)
        {
            index = random.Next(0, numbers.Length - i);             //get random index I
            temp = numbers[index];                                  //get random num M by the index
            for (int j = index + 1; j < numbers.Length; j++)        //shift left all nums from I to the end with 1 position
            {
                numbers[j - 1] = numbers[j];
            }
            numbers[numbers.Length - 1] = temp;                     //set the num M to the last position
        }

        Console.WriteLine(string.Join(" ", numbers));
        /*
         * Note: this method uses 1 array only in contrast to the MSDN way, which recommends using 2 differemnt arrays
         * - 1 for the nums and other for a random indexes, filled with random real numbers. The second array is then
         * used to sort the first depending on its random values (indexes) with Array.Sort() method, i.e random sorting =
         * shuffling.
         * Note: "Intro to programming" book recommends method, which uses
         * 1 array only and shuffles the nums in random pairs multiple number of times. In such scenario there is a chance
         * of shuffling the same num more than once, which leads to repetitive shuffle of one value, thus increasing the
         * overhead of the program. Although the method used here is a bit different, it's based on the one given
         * in the book.
         * Nevertheless, the method I'm using can be optimized further...
         */
    }
}