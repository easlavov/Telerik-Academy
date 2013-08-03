// Declare two string variables and assign them with following value:
// "The "use" of quotations causes difficulties."	
// Do the above in two different ways: with and without using quoted strings.

using System;

class DeclareTwoStrings
{
    static void Main()
    {
        string first = "The \"use\" of quotations causes difficulties.";
        string second = @"The ""use"" of quotations causes difficulties.";

        // Check:

        Console.WriteLine("{0}\n{1}", first, second);
    }
}