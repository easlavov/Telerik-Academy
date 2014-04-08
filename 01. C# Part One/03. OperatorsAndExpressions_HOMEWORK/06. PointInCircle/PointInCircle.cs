// Write an expression that checks if given point (x,  y) is within a circle K(O, 5).

using System;

class PointInCircle
{
    static void Main()
    {
        // Print what the program does:
        Console.WriteLine(
            "This program checks if a given point (x,  y) is within a circle K (O, 5).");
        Console.WriteLine();

        // Declare the radius:
        int radius = 5;
        Console.WriteLine("The radius of the circle is 5.");

        // Instruct user to enter coordinates:
        Console.WriteLine("Enter the coordinates to determine if a point is inside the circle: ");
        Console.Write("Enter 'X': ");
        double x = double.Parse(Console.ReadLine());
        Console.Write("Enter 'Y': ");
        double y = double.Parse(Console.ReadLine());

        // Declare a boolean expression that checks if the user-specified point is within the circle:
        bool inside = ((x * x) + (y * y)) <= (radius * radius); // Using the Pythagorean theorem 
        Console.WriteLine(inside ? "The point with the given coordinates is inside the circle." :
            "The point with the given coorinates is outside the circle.");
    }
}