/*
 * Problem 12. Index of letters
 *
 * Write a program that creates an array containing all letters from the alphabet (A-Z).
 * Read a word from the console and print the index of each of its letters in the array.
 */
using System;

class IndexOfLetters
{
    static void Main()
    {
        //user input
        Console.WriteLine("Enter a word: ");
        string sWord = Console.ReadLine();

        //pre-process
        for (int i = 0; i < sWord.Length; i++)
            if (!char.IsLetter(sWord[i]))
            {
                sWord = sWord.Remove(i, 1);
                i--;
            }
        sWord = sWord.ToUpper();

        //logic
        char[] cvAlphabet = new char['Z' - 'A' + 1];
        for (char symbol = 'A'; symbol <= 'Z'; cvAlphabet[symbol - 'A'] = symbol, symbol++) ;

        //binary search block
        for (int i = 0; i < sWord.Length; i++)
        {
            int midIndex = -1;                       //non-negative index for found key or -1 for not found
            int minBound = -1;                       //set the bounds as exclusive
            int maxBound = cvAlphabet.Length;        //set the bounds as exclusive
            while (maxBound - minBound != 1 /*if == 1 -> empty set*/)
            {
                midIndex = (maxBound + minBound) / 2;

                if (cvAlphabet[midIndex] > sWord[i])                          //must devide left half
                    maxBound = midIndex;                                    //adjust the max bound
                else if (cvAlphabet[midIndex] < sWord[i])                     //must devide right half
                    minBound = midIndex;                                    //adjust the min bound
                else
                    break;                                                  //key found - keep the index intact

                midIndex = -1;                                              //key not found - default the index
            }
            //print ouput
            Console.WriteLine("'{0}' = Alphabet[{1}]", sWord[i], midIndex);
        }
    }
}