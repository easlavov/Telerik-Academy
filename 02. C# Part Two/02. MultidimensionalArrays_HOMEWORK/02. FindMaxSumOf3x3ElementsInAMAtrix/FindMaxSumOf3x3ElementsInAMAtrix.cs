// Write a program that reads a rectangular matrix of size N x M 
// and finds in it the square 3 x 3 that has maximal sum of its elements.

using System;

class FindMaxSumOf3x3ElementsInAMAtrix
{
    static void Main()
    {
        // Print what the program does
        Console.WriteLine("This program reads a rectangular matrix of size N x M and finds in it the square 3 x 3 that has maximal sum of its elements.");
        Console.WriteLine();

        // Input matrix
        Console.WriteLine("Please, enter matrix dimensions.");
        Console.Write("Enter number of rows (>=3): ");
        int r = int.Parse(Console.ReadLine());
        Console.Write("Enter number of columns (>=3): ");
        int c = int.Parse(Console.ReadLine());
        int[,] matrix = new int[r, c];
        // Fill matrix
        Console.WriteLine("");
        for (int i = 0; i < r; i++)
        {
            for (int p = 0; p < c; p++)
            {
                Console.Write("Enter element [{0}, {1}]: ", i, p);
                matrix[i, p] = int.Parse(Console.ReadLine());
            }
        }

        //// UNCOMMENT TO TEST EASILY
        //int[,] matrix = 
        //{ 
        //  { 3, 4, 0, 6, 1 },
        //  { 2, 8, 0, 0, 0 },
        //  { 5, 1, 0, 7, 0 },
        //  { 100, 0, 3, 2, 4 }
        //};

        int row = 0;
        int column = 0;
        int maxSum = int.MinValue;
        int leadingBlockRowIndex = 0;
        int leadingBlockColumnIndex = 0;
        while (true)
        {
            int blockSum = CheckBlocksSum(matrix, row, column);
            if (blockSum > maxSum)
            {
                maxSum = blockSum;
                leadingBlockRowIndex = row;
                leadingBlockColumnIndex = column;
            }
            column++;
            if (column > matrix.GetLength(1) - 3)
            {
                row++;
                column = 0;
            }
            if (row > matrix.GetLength(0) - 3)
            {
                break;
            }
        }

        // Print block
        Console.WriteLine();
        Console.WriteLine("This block has the biggest sum of its elements - {0}:", maxSum);
        for (int i = 0; i < 3; i++)
        {
            for (int p = 0; p < 3; p++)
            {
                Console.Write("{0} ", matrix[leadingBlockRowIndex + i, leadingBlockColumnIndex + p]);
            }
            Console.WriteLine();
        }
    }

    private static int CheckBlocksSum(int[,] matrix, int row, int column)
    {
        int sum = 0;
        sum += matrix[row, column];
        sum += matrix[row + 1, column];
        sum += matrix[row + 2, column];
        sum += matrix[row, column + 1];
        sum += matrix[row, column + 2];
        sum += matrix[row + 1, column + 1];
        sum += matrix[row + 2, column + 1];
        sum += matrix[row + 1, column + 2];
        sum += matrix[row + 2, column + 2];
        return sum;
    }
}