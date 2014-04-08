// Write a program that prints an isosceles triangle of 9 
// copyright symbols ©. Use Windows Character Map to find
// the Unicode code of the © symbol. Note: the © symbol may
// be displayed incorrectly.

using System;

class PrintIsoscelesTriangle
{
    static void Main()
    {
        Console.WriteLine("  \u00A9");
        Console.WriteLine(" \u00A9\u00A9\u00A9");
        Console.WriteLine("\u00A9\u00A9\u00A9\u00A9\u00A9");
    }
}