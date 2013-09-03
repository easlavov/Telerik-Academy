// Write methods that calculate the surface of a triangle by given:
// Side and an altitude to it; Three sides; Two sides and an angle between them. Use System.Math.

using System;

class CalculateTriangleSurface
{
    // Test program
    static void Main()
    {
        Console.WriteLine("This program tests 3 methods that calculate the surface of a triangle.");
        // Declare test sides, height and angles
        double sideA = 5;
        int angleAB = 90;
        double sideB = 12;
        double sideC = 13;
        double heightA = 12;

        // Call the methods
        Console.WriteLine("Calculated by side and height: {0}", TriangeSurface(sideA, heightA));
        Console.WriteLine("Calculated by three sides: {0}", TriangleSurface(sideA, sideB, sideC));
        Console.WriteLine("Calculated by two sides and an angle betwwen them: {0}", TriangleSurface(sideA, sideB, angleAB));
    }

    static double TriangeSurface(double side, double height)
    {
        double surface = (side * height) / 2;
        return surface;
    }

    static double TriangleSurface(double sideA, double sideB, double sideC)
    {
        double semiPerimeter = (sideA + sideB + sideC) / 2;
        // Heron's formula
        double surface = Math.Sqrt(semiPerimeter * (semiPerimeter - sideA) * (semiPerimeter - sideB) * (semiPerimeter - sideC));
        return surface;
    }

    static double TriangleSurface(double sideA, double sideB, int angle)
    {
        // angle * Math.PI / 180 - return sin as grades, instead of radians
        double surface = (sideA * sideB * Math.Sin(angle * Math.PI / 180)) / 2;
        return surface;
    }
}