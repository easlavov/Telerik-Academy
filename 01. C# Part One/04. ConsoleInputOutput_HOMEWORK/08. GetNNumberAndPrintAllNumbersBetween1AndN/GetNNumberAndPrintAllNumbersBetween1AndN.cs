// Write a program that reads an integer number n from the console 
// and prints all the numbers in the interval [1..n], each on a single line.

using System;

class GetNNumberAndPrintAllNumbersBetween1AndN
{
    static void Main()
    {
        // Print what the program does:
        Console.WriteLine("This program reads an integer number n from the console and prints all the numbers in the interval [1..n], each on a single line.");

        // We instruct the user to enter the n number:
        Console.Write("Please, enter a number: ");
        int numberN = int.Parse(Console.ReadLine());

        // We use a 'while' loop to count and print the numbers from 1 to the user-input integer.
        int container = 1;
        while (container <= numberN)
        {
            Console.WriteLine(container);
            container += 1;
        }
    }
}