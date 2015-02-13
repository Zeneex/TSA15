/*
 * Problem 5. Maximal increasing sequence
 *
 * Write a program that finds the maximal increasing sequence in an array.
 */
using System;

class MaximalIncreasingSequence
{
    public struct maxSequence
    {
        public int lastIndex;
        public int maxLength;
        public int currentLength;
        public dynamic subArray;        //it will change its type
    }

    static void Main()
    {
        //four different types of data arrays; unable to join them in a single, multi-type... something, sorry
        int[] testArray1 = { 2, 1, 1, 2, 3, 10, 3, 2, 2, 2, 1 };
        char[] testArray2 = { '~', '@', '%', '2', '3', '6', '9', 'Z', 'a', '0', '0', '0', '0', '0', '!' };
        bool[] testArray3 = { true, false, true, true, false, true, true, false, false, false, false, true, false };
        double[] testArray4 = { 1.1, 2.1, 3.1, 5.8, 5.8, 5.8, 4.1, 5.1, 1.999999999999999999999999999, 2.000, 2.0000000000000000000000009, 2.000000000000000035, 2.000000000000000056 };
        decimal[] testArray5 = { 1.1m, 2.1m, 3.1m, 5.8m, 5.8m, 5.8m, 4.1m, 5.1m, 1.999999999999999999999999999m, 2.000m, 2.0000000000000000000000009m, 2.000000000000000035m, 2.000000000000000056m };   //same values as in double array

        maxSequence stats = new maxSequence();          //create stats container

        stats.lastIndex = 0;                            //initialize stats container
        stats.maxLength = 1;
        stats.currentLength = 1;

        #region test first array
        for (int i = 1; i < testArray1.Length; i++)     //skip the first element, test to the last element
        {
            if (testArray1[i] > testArray1[i - 1])     //look behind
            {
                stats.currentLength++;
                if (stats.currentLength > stats.maxLength)
                {
                    stats.maxLength = stats.currentLength;
                    stats.lastIndex = i;
                }
            }
            else
            {
                stats.currentLength = 1;
            }
        }

        stats.subArray = new int[stats.maxLength];  //initialize sub-array
        Array.Copy(testArray1, stats.lastIndex - (stats.maxLength - 1), stats.subArray, 0, stats.maxLength);    //copy sub-range into sub-array
        Console.WriteLine("Array {{ {0} }}", string.Join(", ", testArray1));
        Console.WriteLine("Maximal increasing sub-array {{ {0} }}", string.Join(", ", stats.subArray));
        Console.WriteLine("Sub-array start = {0}", stats.lastIndex - (stats.maxLength - 1));
        Console.WriteLine("Sub-array length = {0}", stats.maxLength);
        #endregion

        stats.lastIndex = 0;                            //initialize stats container
        stats.maxLength = 1;
        stats.currentLength = 1;

        #region test second array
        for (int i = 1; i < testArray2.Length; i++)     //skip the first element, test to the last element
        {
            if (testArray2[i] > testArray2[i - 1])     //look behind
            {
                stats.currentLength++;
                if (stats.currentLength > stats.maxLength)
                {
                    stats.maxLength = stats.currentLength;
                    stats.lastIndex = i;
                }
            }
            else
            {
                stats.currentLength = 1;
            }
        }

        stats.subArray = new char[stats.maxLength];
        Array.Copy(testArray2, stats.lastIndex - (stats.maxLength - 1), stats.subArray, 0, stats.maxLength);
        Console.WriteLine("Array {{ {0} }}", string.Join(", ", testArray2));
        Console.WriteLine("Maximal increasing sub-array {{ {0} }}", string.Join(", ", stats.subArray));
        Console.WriteLine("Sub-array start = {0}", stats.lastIndex - (stats.maxLength - 1));
        Console.WriteLine("Sub-array length = {0}", stats.maxLength);
        #endregion

        stats.lastIndex = 0;                            //initialize stats container
        stats.maxLength = 1;
        stats.currentLength = 1;

        #region test third array
        for (int i = 1; i < testArray3.Length; i++)     //skip the first element, test to the last element
        {
            if (Convert.ToInt32(testArray3[i]) > Convert.ToInt32(testArray3[i - 1]))     //can not directly compare boolean values with arithmetic operators
            {
                stats.currentLength++;
                if (stats.currentLength > stats.maxLength)
                {
                    stats.maxLength = stats.currentLength;
                    stats.lastIndex = i;
                }
            }
            else
            {
                stats.currentLength = 1;
            }
        }

        stats.subArray = new bool[stats.maxLength];
        Array.Copy(testArray3, stats.lastIndex - (stats.maxLength - 1), stats.subArray, 0, stats.maxLength);
        Console.WriteLine("Array {{ {0} }}", string.Join(", ", testArray3));
        Console.WriteLine("Maximal increasing sub-array {{ {0} }}", string.Join(", ", stats.subArray));
        Console.WriteLine("Sub-array start = {0}", stats.lastIndex - (stats.maxLength - 1));
        Console.WriteLine("Sub-array length = {0}", stats.maxLength);
        #endregion

        stats.lastIndex = 0;                            //initialize stats container
        stats.maxLength = 1;
        stats.currentLength = 1;

        #region test fourth array
        for (int i = 1; i < testArray4.Length; i++)     //skip the first element, test to the last element
        {
            if (testArray4[i] > testArray4[i - 1])     //look behind
            {
                stats.currentLength++;
                if (stats.currentLength > stats.maxLength)
                {
                    stats.maxLength = stats.currentLength;
                    stats.lastIndex = i;
                }
            }
            else
            {
                stats.currentLength = 1;
            }
        }

        stats.subArray = new double[stats.maxLength];
        Array.Copy(testArray4, stats.lastIndex - (stats.maxLength - 1), stats.subArray, 0, stats.maxLength);
        Console.WriteLine("Array {{ {0} }}", string.Join(", ", testArray4));
        Console.WriteLine("Maximal increasing sub-array {{ {0} }}", string.Join(", ", stats.subArray));
        Console.WriteLine("Sub-array start = {0}", stats.lastIndex - (stats.maxLength - 1));
        Console.WriteLine("Sub-array length = {0}", stats.maxLength);

        //results in incorrect sequence due to double's lossy nature
        #endregion

        stats.lastIndex = 0;                            //initialize stats container
        stats.maxLength = 1;
        stats.currentLength = 1;

        #region test fifth array
        for (int i = 1; i < testArray5.Length; i++)     //skip the first element, test to the last element
        {
            if (testArray5[i] > testArray5[i - 1])     //look behind
            {
                stats.currentLength++;
                if (stats.currentLength > stats.maxLength)
                {
                    stats.maxLength = stats.currentLength;
                    stats.lastIndex = i;
                }
            }
            else
            {
                stats.currentLength = 1;
            }
        }

        stats.subArray = new decimal[stats.maxLength];
        Array.Copy(testArray5, stats.lastIndex - (stats.maxLength - 1), stats.subArray, 0, stats.maxLength);
        Console.WriteLine("Array {{ {0} }}", string.Join(", ", testArray5));
        Console.WriteLine("Maximal increasing sub-array {{ {0} }}", string.Join(", ", stats.subArray));
        Console.WriteLine("Sub-array start = {0}", stats.lastIndex - (stats.maxLength - 1));
        Console.WriteLine("Sub-array length = {0}", stats.maxLength);

        //the correct sequence...
        //you get the idea
        #endregion
    }
}
