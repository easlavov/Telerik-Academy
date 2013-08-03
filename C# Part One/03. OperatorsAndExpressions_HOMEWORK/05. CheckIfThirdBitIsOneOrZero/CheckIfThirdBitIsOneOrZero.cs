// Write a boolean expression for finding if the bit 3 (counting from 0)
// of a given integer is 1 or 0.

using System;

class CheckIfThirdBitIsOneOrZero
{
    static void Main()
    {
        // Print what the program does:
        Console.WriteLine(
            "This program checks if the third bit (counting from 0) of a given integer is 1 or 0, then prints the result.");
        Console.WriteLine();

        // Instruct the user to enter an integer:
        Console.Write("Please, enter an integer: ");
        int number = int.Parse(Console.ReadLine());
        Console.WriteLine();

        // Declare integers for the bit position and for a mask, then perform bitwise operations:
        int bitPosition = 3; // Counting from 0.
        int mask = 1 << bitPosition;
        int thirdBit = number & mask;

        // Declare a boolean expression then print result:
        bool check = (thirdBit >> bitPosition) == 1;
        Console.WriteLine((check) ?
            "The third bit of number {0} is 1" :
            "The third bit of number {0} is 0", number);
    }
}
