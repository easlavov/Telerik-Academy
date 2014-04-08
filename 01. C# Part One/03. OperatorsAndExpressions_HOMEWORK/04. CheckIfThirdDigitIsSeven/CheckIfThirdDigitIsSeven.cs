// Write an expression that checks for given integer if its
// third digit (right-to-left) is 7. E. g. 1732 -> true.

using System;

class CheckIfThirdDigitIsSeven
{
    static void Main()
    {
        // Print what the program does:
        Console.WriteLine(
            "This program checks for given integer if its third digit (right-to-left) is 7.");
        Console.WriteLine();

        // Instruct the user to enter integer value:
        Console.Write("Please, enter an integer: ");
        int number = int.Parse(Console.ReadLine());
        Console.WriteLine();

        // Declare a boolean variable that checks if 3rd digit is seven, then print the result:
        bool check = ((number / 100) % 10) == 7;
        Console.WriteLine(
            (check) ? "The third digit of number {0} is seven." :
            "The third digit of number {0} is not seven.", number);
    }
}
