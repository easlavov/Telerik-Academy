// Write a program that reads from the console a positive integer number N (N < 20) and outputs a matrix.

using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("This program reads from the console a positive integer number N (N < 20) and outputs a matrix.");
        Console.WriteLine();

        Console.Write("Enter N (N <0): ");
        byte n = byte.Parse(Console.ReadLine());
        int row = 1;

        while (row <= n) // Number of rows equal N. This 'while' loop moves the cursor to the next row.
        {
            for (int i = row; i < n + row; i++)
            {
                if (i < 10) // Used to avoid distortion when the numbers are printed.
                {
                    Console.Write("  {0}", i); // Two space before each digit.
                }
                else
                {
                    Console.Write(" {0}", i); // One space before each double-digit number.
                }                
            }
            row++; // Used to set a new starting number for the next row.
            Console.WriteLine();
        }        
        Console.WriteLine();
    }
}