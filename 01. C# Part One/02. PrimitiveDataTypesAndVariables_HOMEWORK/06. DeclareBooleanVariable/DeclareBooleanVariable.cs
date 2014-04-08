// Declare a boolean variable called isFemale and assign
// an appropriate value corresponding to your gender.

using System;

class DeclareBooleanVariable
{
    static void Main()
    {
        // We declare a boolean value isFemale and assign an appropriate value:
        bool isFemale = false;

        // Check:

        Console.WriteLine("I am a female. This statement is " + isFemale + ".");

        // Alternative solution

        Console.WriteLine("\n\nAlternative solution:");

        Console.Write("Enter 1 if you are a female or 0 if you are not: ");
        byte genderValue = byte.Parse(Console.ReadLine());
        bool isFemaleAlt = genderValue == 1;
        Console.WriteLine("Are you a female? " + isFemaleAlt);
    }
}