// Write a program that reads the coefficients a, b and c of a quadratic equation ax2+bx+c=0 and solves it (prints its real roots).

using System;

class SolveQuadraticEquation
{
    static void Main()
    {
        Console.WriteLine("This program solves quadratic equations.");

        // Declare variables
        double constantA, constantB, constantC, x1, x2, discriminant;

        // Input variables
        Console.Write(@"Please, enter constant 'a': ");
        constantA = double.Parse(Console.ReadLine());
        Console.Write(@"Please, enter constant 'b': ");
        constantB = double.Parse(Console.ReadLine());
        Console.Write(@"Please, enter constant 'c': ");
        constantC = double.Parse(Console.ReadLine());

        // Check if the equation is quadratic:
        if (constantA < 0)
        {
            Console.WriteLine("The given constants don't constitute a quadratic equation.");
        }
        // If the equation is quadratic, the program continues:
        else
        {
            discriminant = (constantB * constantB) - (4 * constantA * constantC);
            if (discriminant < 0)
            {
                Console.WriteLine("The quadratic equation does not have real roots.");
            }
            else if (discriminant == 0)
            {
                x1 = -constantB / (2 * constantA);
                Console.WriteLine("The quadratic equation's only real root is {0}.", x1);
            }
            else if (discriminant > 0)
            {
                x1 = (-constantB + Math.Sqrt(discriminant)) / (2 * constantA);
                x2 = (-constantB - Math.Sqrt(discriminant)) / (2 * constantA);
                Console.WriteLine("The quadratic equation's real roots are {0} and {1}.", x1, x2);
            }
        }
    }
}