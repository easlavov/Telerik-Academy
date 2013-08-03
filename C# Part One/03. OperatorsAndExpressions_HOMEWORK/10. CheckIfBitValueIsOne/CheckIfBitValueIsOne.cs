// Write a boolean expression that returns if the bit at position p 
// (counting from 0) in a given integer number v has value of 1. Example: v=5; p=1 -> false.

using System;

class CheckIfBitValueIsOne
{
    static void Main()
    {
        // Print what the program does:
        Console.WriteLine(
            "This program checks if the bit at position p (counting from 0) in a given integer number v has value of 1. Example: v=5; p=1 -> false.");
        Console.WriteLine();

        // Instruct user to enter an integer and bit position:        
        Console.Write("Enter an integer: ");
        int v = int.Parse(Console.ReadLine());
        Console.Write("Enter bit position: ");
        int p = int.Parse(Console.ReadLine());

        // Declare a mask with value 1 and perform calculations. Then print the result.
        int mask = 1 << p;
        int bit = (v & mask) >> p;
        bool isone = (bit == 1);
        Console.WriteLine(isone ?
            "The {0} bit of number {1} is 1." :
            "The {0} bit of number {1} is not 1.", p, v);
    }
}