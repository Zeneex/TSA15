/*
 * Problem 20.* Variations of set
 *
 * Write a program that reads two numbers N and K and generates all the variations of K elements from the set [1..N].
 */
using System;

class VariationsOfSet
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
        Console.Write("Enter variations' length K (as integer > 0 & <= N): ");
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
            ivVector[i] = 1;                                    //init all elements to their minimum
        }

        #region test array block
        //int[] ivVector = { 1, 1, 1, 1, 1, 1, 1 };
        #endregion

        Console.WriteLine(string.Join(" ", ivVector));
        //algo - a simple counter
        for (int rHead = ivVector.Length - 1; rHead >= 0; rHead--)          //set the head at the next element, which is not >= n
        {
            if (ivVector[rHead] < n)                                        //if it's not >= n
            {
                ivVector[rHead]++;                                          //increment it
                rHead = ivVector.Length;                                    //reset the head at right
                //print output
                Console.WriteLine(string.Join(" ", ivVector));              //print the current variation
            }
            else                                                            //if it's >= n
                ivVector[rHead] = 1;                                        //init the element to ist minimum (1), don't reset the head
        }
        //this program is also slow due to the write statement
        //the variations here are generated with the repetitions  =>  V ( k ) = n^k
        //                                                              ( n )
    }
}