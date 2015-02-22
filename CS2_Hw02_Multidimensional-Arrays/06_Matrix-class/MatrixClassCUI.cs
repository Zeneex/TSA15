/*
 * Problem 6.* Matrix class
 *
 * Write a class Matrix, to hold a matrix of integers.
 * Overload the operators for adding, subtracting and multiplying of matrices,
 * indexer for accessing the matrix content and ToString().
 */
using System;

class Matrix
{
    //the main matrix field
    private int[,] myMatrix;

    //the constructor
    public Matrix(int rows, int cols)
    {
        myMatrix = new int[rows, cols];
    }

    //the indexer
    public int this[int row, int col]
    {
        get
        {
            return myMatrix[row, col];
        }
        set
        {
            myMatrix[row, col] = value;
        }
    }

    //get the last index of the specified dimension; helper method - could be used for:
    // - get last row index
    // - get last col index
    // - get number of rows (last row index + 1)
    // - get number of cols (last col index + 1)
    public int LastIndex(int dimension)
    {
        return myMatrix.GetUpperBound(dimension);
    }

    //the ToString() method overload
    public override string ToString()
    {
        string sReturn = null;
        for (int row = 0; row < myMatrix.GetLength(0); row++)
        {
            for (int col = 0; col < myMatrix.GetLength(1); col++)
            {
                sReturn += myMatrix[row, col] + " ";
            }
            sReturn = sReturn.TrimEnd();
            sReturn += "\n";
        }
        sReturn = sReturn.TrimEnd();
        return sReturn;
    }

    //the + operator
    public static Matrix operator +(Matrix augend, Matrix addent)
    {
        //check if two matrices are compatible
        if (augend.LastIndex(0) != addent.LastIndex(0) || augend.LastIndex(1) != addent.LastIndex(1))
        {
            return null;
        }
        else
        {
            //allocate the summation matrix
            Matrix sum = new Matrix(addent.LastIndex(0) + 1, addent.LastIndex(1) + 1);
            //calculate the sum entrywise
            for (int row = 0; row <= addent.LastIndex(0); row++)
            {
                for (int col = 0; col <= addent.LastIndex(1); col++)
                {
                    sum[row, col] = augend[row, col] + addent[row, col];
                }
            }
            //return the summation matrix
            return sum;
        }
    }

    //the - operator; the order of the matrices is important - second members are subtracted from first ones
    public static Matrix operator -(Matrix minuend, Matrix subtrahend)
    {
        //check if two matrices are compatible
        if (minuend.LastIndex(0) != subtrahend.LastIndex(0) || minuend.LastIndex(1) != subtrahend.LastIndex(1))
        {
            return null;
        }
        else
        {
            //allocate the difference matrix
            Matrix diff = new Matrix(subtrahend.LastIndex(0) + 1, subtrahend.LastIndex(1) + 1);
            //calculate the difference entrywise
            for (int row = 0; row <= subtrahend.LastIndex(0); row++)
            {
                for (int col = 0; col <= subtrahend.LastIndex(1); col++)
                {
                    diff[row, col] = minuend[row, col] - subtrahend[row, col];
                }
            }
            //return the difference matrix
            return diff;
        }
    }

    //the * operator; the order of the matrices is important;
    //multiplication is done by the standard matrix multiplication method, the so-called "dot product"
    //Hadamard matrix product (entrywise) or Kronecker matrix product (combinatory) are not implemented
    public static Matrix operator *(Matrix multiplicand, Matrix multiplier)
    {
        //check if two matrices are compatible
        if (multiplicand.LastIndex(1) != multiplier.LastIndex(0))
        {
            return null;
        }
        else
        {
            //allocate the product matrix
            Matrix product = new Matrix(multiplicand.LastIndex(0) + 1, multiplier.LastIndex(1) + 1);
            //calculate the product matrix
            for (int row1 = 0; row1 <= multiplicand.LastIndex(0); row1++)
            {
                for (int col1 = 0; col1 <= multiplicand.LastIndex(1); col1++)   //col1 = row2
                {
                    for (int col2 = 0; col2 <= multiplier.LastIndex(1); col2++)
                    {
                        product[row1, col2] += multiplicand[row1, col1] * multiplier[col1, col2];
                    }
                }
            }
            //return the product matrix
            return product;
        }
    }
}

class MatrixClassCUI
{
    static void Main()
    {
        #region test for base functionality
        Matrix oMatrix = new Matrix(3, 2);

        oMatrix[0, 0] = -1;
        oMatrix[oMatrix.LastIndex(0), oMatrix.LastIndex(1)] = -1;

        Console.WriteLine("matrix[0, 0] = {0}", oMatrix[0, 0]);
        Console.WriteLine("matrix[{0}, {1}] = {2}",
            oMatrix.LastIndex(0),
            oMatrix.LastIndex(1),
            oMatrix[oMatrix.LastIndex(0), oMatrix.LastIndex(1)]);

        Console.WriteLine("matrix:\n{0}", oMatrix.ToString());
        #endregion

        #region test for operator functionality
        //allocate two new matrices of the same size
        Matrix oMatrix1 = new Matrix(4, 4);
        Matrix oMatrix2 = new Matrix(4, 4);

        //initialize the two new matrices complementary
        for (int row = 0; row <= oMatrix1.LastIndex(0); row++)
        {
            for (int col = 0; col <= oMatrix1.LastIndex(1); col++)
            {
                oMatrix1[row, col] = col + row * (oMatrix1.LastIndex(1) + 1);
                oMatrix2[oMatrix2.LastIndex(0) - row, oMatrix2.LastIndex(1) - col] =
                    col + row * (oMatrix2.LastIndex(1) + 1);
            }
        }

        //print the two matrices
        Console.WriteLine("matrix1:\n{0}", oMatrix1.ToString());
        Console.WriteLine("matrix2:\n{0}", oMatrix2.ToString());

        //sum and print the two matrices
        Matrix oSumMatrix = oMatrix1 + oMatrix2;
        Console.WriteLine("matrix1 + matrix2:\n{0}", oSumMatrix.ToString());

        //subtract and print the two matrices
        Matrix oDiffMatrix = oMatrix1 - oMatrix2;
        Console.WriteLine("matrix1 - matrix2:\n{0}", oDiffMatrix.ToString());

        //multiply and print the two matrices
        Matrix oProductMatrix = oMatrix1 * oMatrix2;
        Console.WriteLine("matrix1 * matrix2:\n{0}", oProductMatrix.ToString());
        #endregion
    }
}