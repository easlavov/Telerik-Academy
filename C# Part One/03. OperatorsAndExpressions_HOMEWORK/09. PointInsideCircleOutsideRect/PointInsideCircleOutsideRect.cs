// Write an expression that checks for given point (x, y) if it is within 
// the circle K( (1,1), 3) and out of the rectangle R(top=1, left=-1, width=6, height=2).

using System;

class PointInCircle
{
    static void Main()
    {
        // Print what the program does:
        Console.WriteLine(
            "This program checks if a given point (x,  y) is within a circle K ((1, 1) 3) and outside a rectangle R (top=1, left=-1, width=6, height=2).");
        Console.WriteLine();

        // Declare the radius and coordinates of the circle:
        int circleX = 1;
        int circleY = 1;
        int radius = 3;
        Console.WriteLine("The radius of the circle is 3.");

        // Instruct user to enter coordinates:
        Console.WriteLine("Enter the coordinates to determine if a point is inside the circle and outside the rectangle: ");
        Console.Write("Enter 'X': ");
        double x = double.Parse(Console.ReadLine());
        Console.Write("Enter 'Y': ");
        double y = double.Parse(Console.ReadLine());

        // Declare a boolean expression that checks if the user-specified point is within the circle:
        bool insideCircle = ((x - circleX) * (x - circleX) + (y - circleY) * (y - circleY)) <= radius * radius; // Using the Pythagorean theorem.
        Console.WriteLine(insideCircle ? "The point with the given coordinates is inside the circle." :
            "The point with the given coorinates is outside the circle.");

        // Declare a boolean expression that checks if the user-specified point is outside the rectangle:
        bool outsideRectangle = (x < 1 | x > 7) | (y > -1 | y < -3);
        Console.WriteLine(outsideRectangle ? "The point with the given coorinates is outside the rectangle."
            : "The point with the given coorinates is inside the rectangle.");

        bool finalCheck = insideCircle & outsideRectangle;
        Console.WriteLine(finalCheck ? "The point is inside the circle and outside the rectangle." :
            "The point is either outside the circle, inside the rectangle or both.");
    }
}