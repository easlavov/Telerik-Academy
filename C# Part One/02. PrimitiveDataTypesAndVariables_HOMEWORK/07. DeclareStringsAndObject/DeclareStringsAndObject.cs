// Declare two string variables and assign them with “Hello”
// and “World”. Declare an object variable and assign it with
// the concatenation of the first two variables (mind adding an
// interval). Declare a third string variable and initialize it
// with the value of the object variable (you should perform type casting).

using System;

class DeclareStringsAndObject
{
    static void Main()
    {
        string stringHello = "Hello";
        string stringWorld = "World!";
        object helloWorld = stringHello + " " + stringWorld;
        string thirdString = (string)helloWorld;

        // Check
        Console.WriteLine("{0}\n{1}\n{2} - This is an object.\n{3} - This is a string.", 
            stringHello, stringWorld, helloWorld, thirdString);
    }
}