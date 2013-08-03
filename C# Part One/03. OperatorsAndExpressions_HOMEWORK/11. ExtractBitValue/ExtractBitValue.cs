// Write an expression that extracts from a given integer i the value 
// of a given bit number b. Example: i=5; b=2 -> value=1.

using System;

class ExtractBitValue
{
    static void Main()
    {
        // Print what the program does:
        Console.WriteLine(
            "This program extracts from a given integer i the value of a given bit number b.");
        Console.WriteLine();

        // Instruct user to enter an integer and bit position:        
        Console.Write("Enter an integer (i): ");
        int i = int.Parse(Console.ReadLine());
        Console.Write("Enter bit position (b): ");
        int b = int.Parse(Console.ReadLine());

        // Declare a mask with value 1 and perform calculations. Then print the result.
        int mask = 1 << b;
        int bit = (i & mask) >> b;
        bool isone = (bit == 1);
        Console.WriteLine(isone ?
            "The {0} bit of number {1} is 1." :
            "The {0} bit of number {1} is 0.", b, i);
    }
}