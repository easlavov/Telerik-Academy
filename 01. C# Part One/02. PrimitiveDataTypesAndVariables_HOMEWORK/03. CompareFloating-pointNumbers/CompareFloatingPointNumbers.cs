// Write a program that safely compares floating-point numbers
// with precision of 0.000001. Examples: (5.3 ; 6.01) -> false;
// (5.00000001 ; 5.00000003) -> true

using System;

class CompareFloatingPointNumbers
{
    static void Main()
    {
        Console.WriteLine("This program safely compares floating-point numbers with precision of 0.000001.");
        Console.Write("Enter number 1: ");
        float number1 = float.Parse(Console.ReadLine());
        Console.Write("Enter number 2: ");
        float number2 = float.Parse(Console.ReadLine());

        // We create a bool that would return the result as shown in the example above:
        bool areEqual = (number1 == number2);
        if (areEqual == false)
        {
            bool bigger = number1 > number2;
            Console.WriteLine(bigger ? "Number 1 is bigger." : "Number 2 is bigger.");
        }
        else
        {
            Console.WriteLine("The two numbers are equal.");
        }
        // We now have a program that safely compares two floating-point numbers with precision of 0.000001.
    }
}