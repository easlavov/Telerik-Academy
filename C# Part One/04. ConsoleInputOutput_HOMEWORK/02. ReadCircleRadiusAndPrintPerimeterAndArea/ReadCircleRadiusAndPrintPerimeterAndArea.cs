// Write a program that reads the radius r of a circle
// and prints its perimeter and area.

using System;

class ReadCircleRadiusAndPrintPerimeterAndArea
{
    static void Main()
    {
        Console.WriteLine("This program reads the radius of a circle and" + 
            " prints its perimeter and area.");
        Console.WriteLine();

        // User enters circle radius
        Console.Write("Please, enter the radius of the circle: ");
        string string1 = Console.ReadLine();
        double radius = double.Parse(string1);
        Console.WriteLine();

        // The program calcualtes the perimeter and the area of the circle and prints them
        double circlePerimeter = 2 * Math.PI * radius;
        double circleArea = Math.PI * (radius * radius);
        Console.WriteLine("The perimeter of the circle is {0:0.00}", circlePerimeter);
        Console.WriteLine("The area of the circle is {0:0.00}", circleArea);
        Console.WriteLine();
    }
}