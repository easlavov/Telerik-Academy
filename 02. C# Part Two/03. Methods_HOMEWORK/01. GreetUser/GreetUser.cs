// Write a method that asks the user for his name and prints “Hello, <name>” 
// (for example, “Hello, Peter!”). Write a program to test this method.

using System;

class GreetUserMethod
{
    // This is the program that tests the method:
    static void Main(string[] args)
    {
        // Print program function
        Console.WriteLine("This program test the \"GreetUser\" method. ");
        Console.Write("Press any key to call the method...");
        Console.ReadKey();
        Console.WriteLine();

        // Calling the method
        GreetUser();
    }

    // This is the method:
    static void GreetUser()
    {
        Console.Write("Please, enter your first name: ");
        Console.WriteLine("Hello, {0}!", Console.ReadLine());
    }
}