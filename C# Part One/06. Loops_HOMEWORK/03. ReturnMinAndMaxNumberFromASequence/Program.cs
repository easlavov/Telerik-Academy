// Write a program that reads from the console a sequence of N integer
// numbers and returns the minimal and maximal of them.

using System;
using System.Collections.Generic; // Required for using Lists
using System.Linq; // Required for using advanced List methods

class Program
{
    static void Main()
    {
        // Print what the program does:
        Console.WriteLine("This program reads from the console a sequence of N integer numbers and returns the minimal and maximal of them.");
        Console.WriteLine();

        // Instruct user to enter an integer:
        Console.Write("Please, enter how many numbers you'd like to add to the sequence: ");
        int n = int.Parse(Console.ReadLine());
        
        // Declare a list:
        List<double> intList = new List<double>();

        // Initialize the list:
        for (int i = 0; i < n; i++)
        {
            Console.Write("Please, enter number {0}: ", i + 1);
            intList.Add(double.Parse(Console.ReadLine()));
        }

        // Declare variables and set their values by using Min, Max methods.
        double minimal = intList.Min();
        double maximal = intList.Max();
        Console.WriteLine("The smallest number in the sequence is {0}", minimal);
        Console.WriteLine("The biggest number in the sequence is {0}", maximal);
    }
}