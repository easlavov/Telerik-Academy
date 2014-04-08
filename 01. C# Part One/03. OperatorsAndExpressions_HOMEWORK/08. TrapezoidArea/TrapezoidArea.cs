// Write an expression that calculates trapezoid's area by given sides a and b and height h.

using System;

class TrapezoidArea
{
    static void Main()
    {
        // Print what the program does:
        Console.WriteLine(
            "This program calculates trapezoid's area by given sides a, b and height h.");
        Console.WriteLine();

        // Instruct the user to enter both sides and height:
        Console.Write("Please, enter side A: ");
        double sideA = double.Parse(Console.ReadLine());
        Console.Write("Please, enter side B: ");
        double sideB = double.Parse(Console.ReadLine());
        Console.Write("Please, enter height: ");
        double height = double.Parse(Console.ReadLine());

        // Calculate and print area.
        double area = (((sideA + sideB) / 2) * height);
        Console.WriteLine("The area of a trapezoid with sides a = {0}, side b = {1} and height = {2} is {3}.",
            sideA, sideB, height, area);
    }
}
