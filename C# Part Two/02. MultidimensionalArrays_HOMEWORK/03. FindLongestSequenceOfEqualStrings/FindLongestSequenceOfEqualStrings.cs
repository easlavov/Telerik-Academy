// We are given a matrix of strings of size N x M. Sequences in the matrix we define
// as sets of several neighbor elements located on the same line, column or diagonal. 
// Write a program that finds the longest sequence of equal strings in the matrix.

using System;

class FindLongestSequenceOfEqualStrings
{
    static int longestSequence = 0;
    static string longestString = "";
    static int currentSequence = 1;

    static void Main()
    {
        // Print what the program does
        Console.WriteLine("This program finds the longest sequence of equal strings in the matrix.");
        Console.WriteLine();

        // Declare and print a test matrix
        // TEST BY EDITING THE CODE, PLEASE! :)
        string[,] matrix =
        {
            {"me", "you", "me", "co"},
            {"you", "me", "he", "co"},
            {"you", "he", "me", "co"},
            {"no", "you", "he", "co"}
        };
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int p = 0; p < matrix.GetLength(1); p++)
            {
                Console.Write("{0} ", matrix[i,p]);
            }
            Console.WriteLine();
        }
        Console.WriteLine();

        // Every element serves as a starting direction for a 'scan'.
        // This loop cycles through all the elements in the matrix
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int p = 0; p < matrix.GetLength(1); p++)
            {
                Scan(matrix, i, p);
                currentSequence = 1;
            }
        }

        // Print the result
        Console.Write("The longest sequence is: ");
        for (int i = 0; i < longestSequence; i++)
        {
            if (i < longestSequence - 1)
            {
                Console.Write("{0}, ", longestString);
            }
            else
            {
                Console.Write("{0}", longestString);
            }
        }
        Console.WriteLine();
    }

    static void Scan(string[,] matrix, int row, int column)
    {
        // This method checks if the next element is equal to the previuos.
        // It scans in three directions - right, down and diagonally.
        // If an equal element is found, the method is called recursively.

        // Check bottom cell
        if (row + 1 < matrix.GetLength(0) && column < matrix.GetLength(1)) // Prevents 'out of range' exception
        {
            if (matrix[row, column] == matrix[row + 1, column])
            {
                currentSequence++;
                if (currentSequence > longestSequence)
                {
                    longestSequence = currentSequence;
                    longestString = matrix[row, column];
                }
                Scan(matrix, row + 1, column);
            }
        }
        else
        {
            currentSequence--;
            return;
        }

        // Check right cell
        if (row < matrix.GetLength(0) && column + 1 < matrix.GetLength(1)) // Prevents 'out of range' exception
        {
            if (matrix[row, column] == matrix[row, column + 1])
            {
                currentSequence++;
                if (currentSequence > longestSequence)
                {
                    longestSequence = currentSequence;
                    longestString = matrix[row, column];
                }
                Scan(matrix, row, column + 1);
            }
        }
        else
        {
            currentSequence--;
            return;
        }

        // Check diagonally
        if (row + 1 < matrix.GetLength(0) && column + 1 < matrix.GetLength(1)) // Prevents 'out of range' exception
        {
            if (matrix[row, column] == matrix[row + 1, column + 1])
            {
                currentSequence++;
                if (currentSequence > longestSequence)
                {
                    longestSequence = currentSequence;
                    longestString = matrix[row, column];
                }
                Scan(matrix, row + 1, column + 1);
            }
        }
        else
        {
            currentSequence--;
            return;
        }

    }
}