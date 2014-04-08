// Create a program that assigns null values to an integer
// and to double variables. Try to print them on the console,
// try to add some values or the null literal to them and see
// the result.

using System;

class AssignNullValues
{
    static void Main()
    {
        // Assign null vallues to to an integer and to double variables.
        int? integerNumber = null;
        double? doubleNumber = null;

        // Try to print them on the console:
        Console.WriteLine("This is an integer variable with 'null' value - > " + integerNumber);
        Console.WriteLine("This is a double variable with 'null' value - > " + doubleNumber);
        // Null is nothing

        // Try to add some values or the null literal to them and see the result.
        integerNumber += 135;
        doubleNumber += 45.8;
        Console.WriteLine("This is the integer variable with 'null' value + 135 - > " + integerNumber);
        Console.WriteLine("This is the double variable with 'null' value + 45.8 - > " + doubleNumber);
        // Null + something is still null, therefore nothing.        
    }
}