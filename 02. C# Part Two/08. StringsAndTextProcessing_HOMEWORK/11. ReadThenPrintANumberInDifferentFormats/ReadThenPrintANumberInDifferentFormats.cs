// Write a program that reads a number and prints it as a decimal number, hexadecimal number,
// percentage and in scientific notation. Format the output aligned right in 15 symbols.

using System;

class ReadThenPrintANumberInDifferentFormats
{
    static void Main()
    {
        Console.WriteLine("This program reads a number and prints it as a decimal number, hexadecimal number, percentage and in scientific notation.");
        Console.WriteLine();

        // Read number from console
        Console.Write("Please, enter an integer: ");
        int number = int.Parse(Console.ReadLine());

        // Print decimal
        PrintDecimal(number);
        PrintHexadecimal(number);
        PrintPercentage(number);
        PrintScientific(number);
    }

    static void PrintDecimal(int number)
    {
        string format = "{0,15}";
        Console.WriteLine("Decimal:\n" + String.Format(format, number));
    }

    static void PrintHexadecimal(int number)
    {
        string format = "{0,15:X}";
        Console.WriteLine("Hexadecimal:\n" + String.Format(format, number));
    }

    static void PrintPercentage(int number)
    {
        string format = "{0,15:P}";
        Console.WriteLine("Percentage:\n" + String.Format(format, number));
    }

    static void PrintScientific(int number)
    {
        string format = "{0,15:E}";
        Console.WriteLine("Scientific:\n" + String.Format(format, number));
    }
}