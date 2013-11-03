// Define abstract class Shape with only one abstract method CalculateSurface() and fields width and height.
// Define two new classes Triangle and Rectangle that implement the virtual method and return the surface of
// the figure (height*width for rectangle and height*width/2 for triangle). Define class Circle and suitable
// constructor so that at initialization height must be kept equal to width and implement the CalculateSurface()
// method. Write a program that tests the behavior of  the CalculateSurface() method for different shapes (Circle,
// Rectangle, Triangle) stored in an array.

using System;
using System.Linq;

class TestProgram
{
    static void Main()
    {
        Console.WriteLine("This program tests the Shapes project. It will run a few tests to determine if the code is written correctly.");
        Console.WriteLine();

        Console.WriteLine("Initializing the following shapes and storing them in a Shape array:");
        Console.WriteLine("A rectangle with dimensions 3 and 5.");
        Console.WriteLine("A triangle with dimensions 4 and 2.");
        Console.WriteLine("A circle with radius 5.");
        Console.WriteLine();

        Console.WriteLine("Calculating each shape's area:");
        Rectangle rectangle = new Rectangle(3,5);
        Triangle triangle = new Triangle(4,2);
        Circle circle = new Circle(5);

        Shape[] shapes = { rectangle, triangle, circle };
        foreach (var shape in shapes)
        {
            Type type = shape.GetType();
            Console.WriteLine("{0} area is {1:0.00}", type.Name, shape.CalculateSurface());
        }
        Console.WriteLine();

        Console.WriteLine("END of test program.");
    }
}