// Write a program that prints all the numbers from 1 to N, that are not divisible by 3 and 7 at the same time.

using System;

class Program
{
    static void Main()
    {
        // Print what the program does:
        Console.WriteLine("This program prints all the numbers from 1 to N that are not divisible by 3 and 7 at the same time.");

        // Instruct user to enter an integer:
        Console.Write("Please, enter an integer: ");
        int n = int.Parse(Console.ReadLine());

        // Execute a loop that prints the numbers:
        for (int i = 1; i <= n; i++)
        {
            bool divideBy3and7 = (i % 3 == 0) && (i % 7 == 0);
            if (divideBy3and7 == false)
            {
                Console.Write("{0}, ", i);
            }            
        }        
    }
}