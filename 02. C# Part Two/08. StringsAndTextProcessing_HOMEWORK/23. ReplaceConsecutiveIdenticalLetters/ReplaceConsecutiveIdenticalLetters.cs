// Write a program that reads a string from the console and replaces all series of consecutive
// identical letters with a single one. Example: "aaaaabbbbbcdddeeeedssaa" -> "abcdedsa".

using System;
using System.Text;

class ReplaceConsecutiveIdenticalLetters
{
    static void Main()
    {
        Console.WriteLine("This program reads a string from the console and replaces all series of consecutive identical letters with a single one.");
        Console.WriteLine();

        // Read a string from the console
        Console.Write("Please, enter a string: ");
        string input = Console.ReadLine();
        // Replace letters
        string replacedLetters = ReplaceLetters(input);
        // Print new string
        Console.WriteLine();
        Console.Write("The new string is: ");
        Console.WriteLine(replacedLetters);
    }

    private static string ReplaceLetters(string input)
    {
        StringBuilder stringBuilder = new StringBuilder();

        // Scan whole string
        // This variable keeps the currents character
        char currentCharacter = input[0];
        stringBuilder.Append(currentCharacter);
        int index = 1;
        while (index < input.Length)
        {
            if (char.IsLetter(input[index]) == false || input[index] != currentCharacter)
            {
                currentCharacter = input[index];
                stringBuilder.Append(currentCharacter);
            }
            index++;
        }
        return stringBuilder.ToString();
    }
}