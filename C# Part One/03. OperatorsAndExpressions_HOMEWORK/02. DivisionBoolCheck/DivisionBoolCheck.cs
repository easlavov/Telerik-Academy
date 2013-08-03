// Write a boolean expression that checks for given integer
// if it can be divided (without remainder) by 7 and 5 in the same time.

using System;

class DivisionBoolCheck
{
    static void Main()
    {
        // Print what the program does:
        Console.WriteLine(
            "This program checks if a given integer is divisible by 7 and 5 at the same time and then prints the result.");
        Console.WriteLine();

        // Instruct the user to enter an integer:
        Console.Write("Please, enter an integer: ");
        int number = int.Parse(Console.ReadLine());
        Console.WriteLine();

        // Declare a boolean expression: if the number is divisible by 5 and 7 at the same time,
        // then it must be divisible by 35 without reminder. The result is then printed.
        bool divideby5and7 = (number % 35) == 0;

        Console.WriteLine(
            divideby5and7 ?
            "The number {0} is divisible by 5 and 7 at the same time." :
            "The number {0} is not divisible by 5 and 7 at the same time.", number);
    }
}
