// Write an expression that calculates rectangle’s area by given width and height.

using System;

class RectangleAreaAndPerimeter
{
    static void Main()
    {
        // Note: a rectangle does not have height, but sides (length and width);
        // Print what the program does:
        Console.WriteLine(
            "This program prints a rectangle's area by given length and width.");
        Console.WriteLine();

        // Instruct the user to enter values:
        Console.Write("Enter rectangle length: ");
        double rectSideA = double.Parse(Console.ReadLine());
        Console.Write("Enter rectangle width: ");
        double rectSideB = double.Parse(Console.ReadLine());

        // Perform calculation and print the result:
        double rectangleArea = rectSideA * rectSideB;
        Console.WriteLine(
            "The area of the rectangle is: {0}", rectangleArea);
    }
}
