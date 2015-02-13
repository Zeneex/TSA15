/*
 * Problem 19.* Permutations of set
 *
 * Write a program that reads a number N and generates and prints all the permutations of the numbers [1 … N].
 */
using System;

class PermutationsOfSet
{
    static void Main()
    {
        //user input
        Console.Write("Enter array's length (as integer > 0 & < 11): ");
        int n = int.Parse(Console.ReadLine());
        if (n <= 0)
        {
            Console.WriteLine("Error: Invalid length.");
            return;
        }
        if (n > 10)
        {
            Console.WriteLine("The input length is > 10 - it will slow down the program!");
            Console.WriteLine("Would you like to proceed?");
            Console.ReadKey();
        }

        //logic
        int[] ivVector = new int[n];                           //create integer array

        for (int i = 0; i < ivVector.Length; i++)
        {
            ivVector[i] = i + 1;                               //define the elements
        }

        #region test array block
        //int[] ivVector = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
        //int[] ivVector = { 1, 4, 3, 2 };
        #endregion

        int length = ivVector.Length;
        int rHead = length;
        int lHead = 0;
        int pHolder = 0;

        while (true)
        {
            //print output
            Console.WriteLine(string.Join(" ", ivVector));
            for (rHead = length - 1; rHead >= 0; rHead--)
            {
                if (ivVector[rHead] != 0)
                {
                    ivVector[rHead]++;
                    for (lHead = 0; lHead < rHead; lHead++)
                    {
                        if (ivVector[lHead] == ivVector[rHead])
                        {
                            ivVector[rHead]++;
                            lHead = -1;
                        }
                    }
                    if (ivVector[rHead] > length)
                    {
                        ivVector[rHead] = 0;
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            if (rHead < 0)
            {
                return;
            }

            for (lHead = 0, pHolder = 0; lHead < length; lHead++)
            {
                if (ivVector[lHead] == 0)
                {
                    ivVector[lHead]++;
                    pHolder = lHead;
                    for (lHead = 0; lHead < pHolder; lHead++)
                    {
                        if (ivVector[lHead] == ivVector[pHolder])
                        {
                            ivVector[pHolder]++;
                            lHead = -1;
                        }
                    }
                    lHead = pHolder;
                }
            }
        }
    }
    //on a 1GHz CPU array of size 11 take about 1min:20sec to complete
    //it's EXTREMELY SLOW implementation thanks to my high programming skills
}