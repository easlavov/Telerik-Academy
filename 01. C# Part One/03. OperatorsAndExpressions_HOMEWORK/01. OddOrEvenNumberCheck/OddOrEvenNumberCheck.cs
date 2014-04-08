// Write an expression that checks if given integer is odd or even.

using System;

class OddOrEven
{
    static void Main()
    {
        // Print what the program does:
        Console.WriteLine("This program checks if a given integer is odd or even and then prints the result.");
        Console.WriteLine();

        // Instruct the user to enter an integer:
        Console.Write("Please, enter an integer: ");
        int integerA = int.Parse(Console.ReadLine());

        // Declare a mask with value 1:
        int mask = 1;

        // Use the bitwise operator & on the user-input integer and the mask. The operator will return 1
        // if the integer is odd and zero if it's even. The result is then printed on the console:
        Console.WriteLine(
            ((integerA & mask) == 1) ? "The integer {0} is odd." : "The integer {0} is even.", integerA);
    }
}