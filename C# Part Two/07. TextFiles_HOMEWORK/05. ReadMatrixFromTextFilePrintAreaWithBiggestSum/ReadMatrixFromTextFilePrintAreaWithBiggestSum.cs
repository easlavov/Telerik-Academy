// Write a program that reads a text file containing a square matrix of numbers and finds 
// in the matrix an area of size 2 x 2 with a maximal sum of its elements. The first line in
// the input file contains the size of matrix N. Each of the next N lines contain N numbers 
// separated by space. The output should be a single number in a separate text file.

using System;
using System.IO;
using System.Text;

class ReadMatrixFromTextFilePrintAreaWithBiggestSum
{
    static void Main(string[] args)
    {
        Console.WriteLine(
            "This program reads a text file containing a square matrix of numbers and finds" +
            "in the matrix an area of size 2 x 2 with a maximal sum of its elements.");
        Console.WriteLine();

        // The paths are hard-coded to allow easier testing
        Console.WriteLine("Reading file 'secret.txt': ");
        var filePath = "..\\..\\matrix.txt";
        Console.WriteLine("Please, enter path to a txt file to write the result to.");
        var output = Console.ReadLine();
        // Initialize a StreamWriter instance for the output file
        StreamWriter writer = new StreamWriter(output);
        // Initialize a StreamReader instance for the source file
        StreamReader reader = new StreamReader(filePath, Encoding.GetEncoding("windows-1251"));

        using (reader)
        {
            using (writer)
            {
                // Read matrix dimensions
                int dimension = int.Parse(reader.ReadLine());
                // Declare a matrix
                int[,] matrix = new int[dimension, dimension];
                // Initialize the matrix
                for (int row = 0; row < dimension; row++)
                {
                    string line = reader.ReadLine();
                    for (int column = 0, character = 0; character < dimension * 2; column++, character += 2)
                    {
                        matrix[row, column] = int.Parse(line[character].ToString());
                    }
                }
                // Find 2x2 square with maximum sum
                int maxSum = FindMaxSum(matrix);
                // Write result to txt file
                writer.WriteLine(maxSum);
            }
        }
    }

    private static int FindMaxSum(int[,] matrix)
    {
        int row = 0;
        int column = 0;
        int maxSum = int.MinValue;
        while (true)
        {
            int blockSum = CheckBlocksSum(matrix, row, column);
            if (blockSum > maxSum)
            {
                maxSum = blockSum;
            }
            column++;
            if (column > matrix.GetLength(1) - 2)
            {
                row++;
                column = 0;
            }
            if (row > matrix.GetLength(0) - 2)
            {
                break;
            }
        }
        return maxSum;
    }

    private static int CheckBlocksSum(int[,] matrix, int row, int column)
    {
        int sum = 0;
        sum += matrix[row, column];
        sum += matrix[row + 1, column];
        sum += matrix[row, column + 1];
        sum += matrix[row + 1, column + 1];
        return sum;
    }

}