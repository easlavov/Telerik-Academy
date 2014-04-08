// Write a program that creates an array containing all letters from the alphabet (A-Z).
// Read a word from the console and print the index of each of its letters in the array.

using System;

class ReadWordPrintIndexOfLettersInAlphabetArray
{
    static void Main()
    {
        // Print what the program does
        Console.WriteLine("This program creates an array containing all letters from the alphabet (A-Z).");
        Console.WriteLine("Then reads a word from the console and prints the index of each of its letters in the array.");
        Console.WriteLine();

        // Create an alphabet array (both small and capital)
        char[] alphabet = 
        { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l',
            'm', 'n', 'o', 'p', 'r', 'q', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N',
            'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

        // Instruct user to enter a word
        Console.Write("Please, enter a word: ");
        string word = Console.ReadLine();
        char[] characters = word.ToCharArray(0,word.Length);

        // Search the alphabet array for each letter and print its index
        for (int i = 0; i < characters.Length; i++)
        {
            char wantedChar = characters[i];
            for (int j = 0; j < alphabet.Length; j++)
            {
                if (wantedChar == alphabet[j])
                {
                    Console.WriteLine("Character '{0}' from the word '{1}' is indexed at [{2}] in the alphabet array.", wantedChar, word, j);
                }
            }
        }
    }
}