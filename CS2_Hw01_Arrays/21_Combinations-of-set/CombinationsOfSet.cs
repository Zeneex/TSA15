/*
 * Problem 21.* Combinations of set
 *
 * Write a program that reads two numbers N and K and generates
 * all the combinations of K distinct elements from the set [1..N].
 */
using System;

class CombinationsOfSet
{
    static void Main()
    {
        //user input
        Console.Write("Enter set's length N (as integer > 0): ");
        int n = int.Parse(Console.ReadLine());
        if (n <= 0)
        {
            Console.WriteLine("Error: Invalid length N.");
            return;
        }
        Console.Write("Enter combinations' length K (as integer > 0 & <= N): ");
        int k = int.Parse(Console.ReadLine());
        if (k <= 0 || k > n)
        {
            Console.WriteLine("Error: Invalid length K.");
            return;
        }

        //logic
        int[] ivVector = new int[k];                            //create integer array with k positions

        for (int i = 0; i < ivVector.Length; i++)
        {
            ivVector[i] = i + 1;                                //init all elements to their minimum
        }

        #region test array block
        //int[] ivVector = { 1, 2, 3, 4 };
        #endregion

        Console.WriteLine(string.Join(" ", ivVector));
        //algo
        for (int rHead = ivVector.Length - 1; rHead >= 0; rHead--)          //set the head at the next element, which is not >= position's maximum
        {
            if (ivVector[rHead] < n - (k - 1 - rHead))                      //if it's not >= position's maximum
            {
                ivVector[rHead]++;                                          //increment it
                for ( rHead++; rHead < ivVector.Length; rHead++)            //init all the positions to the right to the next possible value (if any)
                {
                    ivVector[rHead] = ivVector[rHead - 1] + 1;
                }
                Console.WriteLine(string.Join(" ", ivVector));              //print the current combination
            }
        }
    }
}