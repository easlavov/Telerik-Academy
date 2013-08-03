// We are given integer number n, value v (v=0 or 1) and a position p. 
// Write a sequence of operators that modifies n to hold the value v at 
// the position p from the binary representation of n.
// Example: n = 5 (00000101), p=3, v=1 -> 13 (00001101)
// n = 5 (00000101), p=2, v=0 -> 1 (00000001)

using System;

class ChangeSpecificBitValueToOneOrZero
{
    static void Main()
    {
        // Print what the program does:
        Console.WriteLine(
            "This program changes the bit in specific position to 0 or 1");
        Console.WriteLine();

        // Instruct the user to enter variables n, v and p.
        Console.Write("Enter an integer: ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Enter bit value (0 or 1): ");
        int v = int.Parse(Console.ReadLine());
        Console.Write("Enter bit position: ");
        int p = int.Parse(Console.ReadLine());

        // Create a mask and perform calculations according to a conditional statement and print the new number:
        int mask = 1 << p;

        if (v == 0)
        {
            n = n & (~mask);
            Console.WriteLine("The new number is {0}.", n);
        }
        else
        {
            n = n | (mask);
            Console.WriteLine("The new number is {0}.", n);
        }
    }
}