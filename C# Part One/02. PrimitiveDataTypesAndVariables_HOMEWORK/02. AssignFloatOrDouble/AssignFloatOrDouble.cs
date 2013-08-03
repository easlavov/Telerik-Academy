// Which of the following values can be assigned to a variable
// of type float and which to a variable of type double: 34.567839023,
// 12.345, 8923.1234857, 3456.091?

using System;

class AssignFloatOrDouble
{
    static void Main()
    {
        // The most appropriate data type is the one that stores the floating-point
        // number with maximum possible precision after the decimal mark:
        double number1 = 34.567839023;
        float number2 = 12.345f;
        double number3 = 8923.1234857;
        float number4 = 3456.091f;

        // Check if numbers are displayed correctly:
        Console.WriteLine("{0}\n{1}\n{2}\n{3}", number1, number2, number3, number4);
    }
}