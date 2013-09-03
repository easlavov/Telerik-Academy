// Write a program that reads from the console a string of maximum 20 characters. 
// If the length of the string is less than 20, the rest of the characters should 
// be filled with '*'. Print the result string into the console.

using System;
using System.Text;

class ReadStringFillAsterisks
{
    static void Main()
    {
        Console.WriteLine("This program reads from the console a string of maximum 20 characters. If the length of the string is less than 20, the rest of the characters will be filled with '*'.");
        Console.WriteLine();

        // Read input string
        string input = "";
        while (true)
        {
            Console.Write("Please, enter a string with maximum of 20 chars: ");
            string toAdd = Console.ReadLine();
            if (toAdd.Length <= 20)
            {
                input += toAdd;
                break;
            }
            else
            {
                Console.WriteLine("You should enter a string with 20 chars or less. Try again.");
            }
        }
        Console.WriteLine();        
        string result = AppendAsterisks(input);
        Console.Write("Asterisks are added if needed. The resulting string is: {0}", result);
        Console.WriteLine();
    }

    private static string AppendAsterisks(string input)
    {
        StringBuilder stringBuilder = new StringBuilder(20);
        stringBuilder.Append(input);
        while (stringBuilder.Length < 20)
        {
            stringBuilder.Append('*');
        }
        string result = stringBuilder.ToString();
        return result;
    }
}
