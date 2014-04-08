// * Write a program that finds the largest area of equal neighbor elements in a rectangular matrix and prints its size.

using System;

class FindLargestAreaOfEqualNeighbourElementsInAMatrix
{
    static int longestSequence = 0;
    static int largestAreaElement = 0;
    static int currentSequence = 1;

    static void Main()
    {
        // Print what the program does
        Console.WriteLine("This program finds the largest area of equal neighbor elements in a rectangular matrix and prints its size.");
        Console.WriteLine();

        // Declare and print a test matrix
        // TEST BY EDITING THE CODE, PLEASE! :)
        int[,] matrix =
        {
            {1, 3, 5, 7, 8},
            {3, 3, 3, 3, 8},
            {4, 3, 0, 6, 8},
            {9, 2, 8, 2, 8}
        };

        // This boolean matrix helps avoid double counting of elements and infinite recursion (see method)
        bool[,] visited = new bool[matrix.GetLength(0), matrix.GetLength(1)];

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int p = 0; p < matrix.GetLength(1); p++)
            {
                Console.Write("{0} ", matrix[i, p]);
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
                visited[i, p] = true;
                // We call the method:
                Scan(matrix, visited, i, p);
                currentSequence = 1;
                // Every scan from a new starting element begins with the boolean matrix reset!
                Array.Clear(visited, 0, visited.GetLength(0) * visited.GetLength(1));
            }
        }

        // Print the size of the largest area of equal neighbor elements
        Console.WriteLine("The size of the largest are of equal neighbour elements is {0}. ", longestSequence);
        Console.WriteLine("It consists of {0}'s.", largestAreaElement);
    }

    static void Scan(int[,] matrix, bool[,] visited, int row, int column)
    {
        // This method checks if the next element is equal to the previuos.
        // It scans in four directions - left, up, right and down.
        // If an equal element is found, the method is called recursively.

        // Check left cell
        if (row < matrix.GetLength(0) && column - 1 >= 0) // Prevents 'out of range' exception
        {
            if (matrix[row, column] == matrix[row, column - 1] && visited[row, column - 1] == false)
            {
                currentSequence++;
                // Marking the element as 'visited' prevents infinite recursion and incorrect counting
                visited[row, column - 1] = true;
                if (currentSequence > longestSequence)
                {
                    longestSequence = currentSequence;
                    largestAreaElement = matrix[row, column];
                }
                Scan(matrix, visited, row, column - 1);
            }
        }

        // Check upper cell
        if (row - 1 >= 0 && column < matrix.GetLength(1)) // Prevents 'out of range' exception
        {
            if (matrix[row, column] == matrix[row - 1, column] && visited[row - 1, column] == false)
            {
                currentSequence++;
                visited[row - 1, column] = true;
                if (currentSequence > longestSequence)
                {
                    longestSequence = currentSequence;
                    largestAreaElement = matrix[row, column];
                }
                Scan(matrix, visited, row - 1, column);
            }
        }

        // Check right cell
        if (row < matrix.GetLength(0) && column + 1 < matrix.GetLength(1)) // Prevents 'out of range' exception
        {
            if (matrix[row, column] == matrix[row, column + 1] && visited[row, column + 1] == false)
            {
                currentSequence++;
                visited[row, column + 1] = true;
                if (currentSequence > longestSequence)
                {
                    longestSequence = currentSequence;
                    largestAreaElement = matrix[row, column];
                }
                Scan(matrix, visited, row, column + 1);
            }
        }

        // Check lower cell
        if (row + 1 < matrix.GetLength(0) && column < matrix.GetLength(1)) // Prevents 'out of range' exception
        {
            if (matrix[row, column] == matrix[row + 1, column] && visited[row + 1, column] == false)
            {
                currentSequence++;
                visited[row + 1, column] = true;
                if (currentSequence > longestSequence)
                {
                    longestSequence = currentSequence;
                    largestAreaElement = matrix[row, column];
                }
                Scan(matrix, visited, row + 1, column);
            }
        }

        // This method returns only when all nearby elements have been checked
        return;
    }
}