// Create a class Person with two fields – name and age. Age can be left unspecified (may contain null value.
// Override ToString() to display the information of a person and if age is not specified – to say so. Write 
// a program to test this functionality.

using System;
using System.Linq;

class TestProgram
{
    static void Main()
    {
        Console.WriteLine("Testing the Person project.");
        Console.WriteLine("Creating two instances of the Person class. The first one's age is specified, the second one is not.");
        Console.WriteLine("Printing the two instances using ToString():");
        Person personWithKnownAge = new Person("Atanas Velichkov", 35);
        Console.WriteLine(personWithKnownAge);
        Person personWithUnknownAge = new Person("Petar Kirov");
        Console.WriteLine(personWithUnknownAge);
    }
}