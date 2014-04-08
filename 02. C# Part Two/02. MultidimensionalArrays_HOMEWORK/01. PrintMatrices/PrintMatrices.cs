// Write a program that fills and prints a matrix of size (n, n) as shown.

using System;

class PrintMatrices
{
    static void Main()
    {
        // Print what the program does
        Console.WriteLine("This program fills and prints a matrix of size n in four different ways.");
        Console.WriteLine();
        // Read n
        Console.Write("Please, enter n: ");
        int n = int.Parse(Console.ReadLine());
        // Declare the matrix
        int[,] matrix = new int[n, n];

        // Print Matrix a)
        int row = 0;
        int column = 0;
        for (int i = 1; i <= n * n; i++)
        {
            matrix[row, column] = i;
            row++;
            // Restart at next column and first row if the end of the column is reached.
            if (row == matrix.GetLength(0))
            {
                column++;
                row = 0;
            }
        }
        Console.WriteLine("Matrix a):");
        Print(matrix);
        Console.WriteLine();

        // Print Matrix b)
        row = 0; column = 0;
        int direction = 0; // 0 means rows will increase. 1 - decrease
        for (int i = 1; i <= n * n; i++)
        {
            matrix[row, column] = i;
            if (direction == 0)
            {
                row++;
            }
            else
            {
                row--;
            }
            if (row == matrix.GetLength(0))
            {
                row--;
                column++;
                direction = 1;
            }
            if (row == -1)
            {
                row = 0;
                column++;
                direction = 0;
            }
        }
        Console.WriteLine("Matrix b):");
        Print(matrix);
        Console.WriteLine();

        // Print Matrix c)
        row = matrix.GetLength(0) - 1;
        column = 0;
        int digits = 1;
        int start = 1;
        for (int i = 0; i < n * 2 - 1; i++)
        {
            // Method fills the cells diagonally from a starting cell
            matrix = FillDiagonally(matrix, row, column, digits, start);
            if (row > 0)
            {
                row -= 1;
                start += digits;
                digits++;
                continue;
            }
            // When half the matrix is filled, the the rules change
            if (row == 0)
            {
                column++;
                start += digits;
                digits--;
            }
        }
        Console.WriteLine("Matrix c):");
        Print(matrix);
        Console.WriteLine();

        // Print Matrix d)
        // Fill the matrix with zeroes
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int p = 0; p < matrix.GetLength(1); p++)
            {
                matrix[i, p] = 0;
            }
        }

        direction = 0; // 0 - down, 1 - right, 2 - up, 3 - left
        row = 0; column = 0;
        for (int i = 1; i <= n * n; i++)
        {
            matrix[row, column] = i;
            if (direction == 0)
            {
                row++;
                if (row == matrix.GetLength(0) || matrix[row, column] != 0)
                {
                    row--;
                    column++;
                    direction = 1;
                    continue;
                }
            }
            if (direction == 1)
            {
                column++;
                if (column == matrix.GetLength(1) || matrix[row, column] != 0)
                {
                    row--;
                    column--;
                    direction = 2;
                    continue;
                }
            }
            if (direction == 2)
            {
                row--;
                if (row < 0 || matrix[row, column] != 0)
                {
                    row++;
                    column--;
                    direction = 3;
                    continue;
                }
            }
            if (direction == 3)
            {
                column--;
                if (matrix[row, column] != 0)
                {
                    row++;
                    column++;
                    direction = 0;
                    continue;
                }
            }
        }
        Console.WriteLine("Matrix d):");
        Print(matrix);
    }

    static void Print(int[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int column = 0; column < matrix.GetLength(1); column++)
            {
                if (matrix[row, column] < 10)
                {
                    Console.Write("{0}   ", matrix[row, column]);
                }
                else if (matrix[row, column] < 100)
                {
                    Console.Write("{0}  ", matrix[row, column]);
                }
                else if (matrix[row, column] < 1000)
                {
                    Console.Write("{0} ", matrix[row, column]);
                }

            }
            Console.WriteLine();
        }
    }

    static int[,] FillDiagonally(int[,] matrix, int row, int column, int digits, int start)
    {
        for (int i = 0; i < digits; i++)
        {
            matrix[row + i, column + i] = start + i;
        }
        return matrix;
    }
}