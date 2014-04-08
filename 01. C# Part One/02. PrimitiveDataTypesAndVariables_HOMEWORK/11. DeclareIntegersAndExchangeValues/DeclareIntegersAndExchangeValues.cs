// Declare  two integer variables and assign them with 5 and 10
// and after that exchange their values.

using System;

class DeclareIntegersAndExchangeValues
{
    static void Main()
    {
        int a = 5;
        int b = 10;

        // Check:

        Console.WriteLine("Integer A: " + a);
        Console.WriteLine("Integer B: " + b);

        // We avoid the use of thir variable:
        a = b + a; // a = 15 
        b = a - b; // b = 5
        a = a - b; // a = 10

        // Check:

        Console.WriteLine("\nAfter exchange:");
        Console.WriteLine("Integer A: " + a);
        Console.WriteLine("Integer B: " + b);
    }
}