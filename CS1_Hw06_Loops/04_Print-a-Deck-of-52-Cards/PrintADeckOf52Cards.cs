/*
 * Problem 4. Print a Deck of 52 Cards
 *
 * Write a program that generates and prints all possible cards from a standard deck of 52 cards (without the jokers).
 * The cards should be printed using the classical notation (like 5 of spades, A of hearts, 9 of clubs; and K of diamonds).
 *     The card faces should start from 2 to A.
 *     Print each card face in its four possible suits: clubs, diamonds, hearts and spades.
 *     Use 2 nested for-loops and a switch-case statement.
 */
        //2 of spades, 2 of clubs, 2 of hearts, 2 of diamonds
        //3 of spades, 3 of clubs, 3 of hearts, 3 of diamonds
        //…  
        //K of spades, K of clubs, K of hearts, K of diamonds
        //A of spades, A of clubs, A of hearts, A of diamonds
using System;

class PrintADeckOf52Cards
{
    static void Main()
    {
        string suit;
        for (int faceIndex = 2; faceIndex <= 14; faceIndex++)
        {
            for (int suitIndex = 1; suitIndex <= 4; suitIndex++)
            {
                switch (suitIndex)
                {
                    case 1: suit = "spades"; break;
                    case 2: suit = "clubs"; break;
                    case 3: suit = "diamonds"; break;
                    default: suit = "hearts"; break;
                }
                //switch (faceIndex)
                //{
                //    case 11:  face = 'J'; break;
                //    case 12: face = 'Q'; break;
                //    case 13: face = 'K'; break;
                //    case 14: face = 'A'; break;
                //    default: face = (char)(faceIndex + '0'); break;
                //}
                Console.Write("{0} of {1}, ",
                    faceIndex == 11
                    ? "J"
                    : faceIndex == 12
                        ? "Q"
                        : faceIndex == 13
                            ? "K"
                            : faceIndex == 14
                                ? "A"
                                : faceIndex.ToString(), suit);
            }
            Console.WriteLine();
        }
    }
}
