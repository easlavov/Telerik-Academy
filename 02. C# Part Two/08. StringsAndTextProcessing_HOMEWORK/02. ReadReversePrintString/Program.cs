// Write a program that reads a string, reverses it and prints the result at the console.
// Example: "sample" -> "elpmas".
using System;
using System.Text;

class ReadReversePrintString
{
    static void Main()
    {
        Console.WriteLine("This program reads a string, reverses it and prints the result at the console.");
        Console.WriteLine();

        // Read string
        Console.Write("Please, enter a string: ");
        string inputString = Console.ReadLine();

        // Declare a new string and call reversal method
        string reversedString = ReverseString(inputString).ToString();

        // Print result
        Console.WriteLine("The reversed string is: {0}", reversedString);
    }

    private static StringBuilder ReverseString(string inputString)
    {
        StringBuilder stringBuilder = new StringBuilder();
        // The chars of the string are added to the string builder backwards
        for (int i = inputString.Length - 1; i >= 0; i--)
        {
            stringBuilder.Append(inputString[i]);
        }
        return stringBuilder;
    }
}