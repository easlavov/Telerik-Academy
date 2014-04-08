// Current project solves task 1

using System;
using System.Text;

class TestProgram
{
    static void Main()
    {
        Console.WriteLine("This program tests a substring extension for the StringBuilder class.");
        Console.WriteLine(@"A new instance of the StringBuilder class is created then a Pesho string is appended.");
        Console.WriteLine("The program then prints the substrings with parameters: ");
        StringBuilder testBuilder = new StringBuilder();
        testBuilder.Append("Pesho");
        Console.Write("2,2: ");
        Console.WriteLine(testBuilder.Substring(2, 2));
        Console.Write("3,1: ");
        Console.WriteLine(testBuilder.Substring(3, 1));
        Console.Write("0,5: ");
        Console.WriteLine(testBuilder.Substring(0, 5));
        Console.Write("0,3: ");
        Console.WriteLine(testBuilder.Substring(0, 3));
    }
}