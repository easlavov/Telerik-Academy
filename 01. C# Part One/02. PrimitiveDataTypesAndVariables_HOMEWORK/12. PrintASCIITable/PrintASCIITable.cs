// Find online more information about ASCII and write a program
// that prints the entire ASCII table of characters on the console.

using System;

class PrintASCIITable
{
    static void Main()
    {
        for (byte i = 0; i <= 127; i++)
        {
            char c = (char)i;
            Console.WriteLine("Code: " + i.ToString() + " Character: " + c);
        }
    }
}