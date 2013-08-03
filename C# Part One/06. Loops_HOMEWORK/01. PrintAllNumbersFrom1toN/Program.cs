// Write a program that prints all the numbers from 1 to N.

using System;

class Program
{
    static void Main()
    {
        // Print what the program does:
        Console.WriteLine("This program prints all the numbers from 1 to N.");

        // Instruct user to enter an integer:
        Console.Write("Please, enter an integer: ");
        int n = int.Parse(Console.ReadLine());

        // Execute a loop that prints the numbers:
        for (int i = 1; i <= n; i++)
        {
            Console.Write("{0}, ", i);
        }        
    }
}