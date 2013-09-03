// Write a program that extracts from a given text all palindromes, e.g. "ABBA", "lamal", "exe".
using System;
using System.Collections.Generic;
using System.Text;

class ExtractPalindromesFromAText
{
    static void Main()
    {
        Console.WriteLine("This program extracts from a given text all palindromes, e.g. ABBA, lamal, exe.");
        Console.WriteLine();

        // Read text
        string text = "Yesterday I listened to ABBA. Lamal is a fictional animal. The exe file is corrupted.";
        string[] palindromes = ExtractPalindromes(text);
        foreach (var palindrome in palindromes)
        {
            Console.WriteLine(palindrome);
        }
    }
  
    private static string[] ExtractPalindromes(string text)
    {
        // TODO: Implement this method
        // Declare a list of strings to hold the palindromes into
        List<string> result = new List<string>();
        // Extract all words with at least 3 letters
        for (int i = 0; i < text.Length; i++)
        {
            int wordFirstIndex, wordLastIndex;
            if (char.IsLetter(text[i]))
            {
                wordFirstIndex = i;
                for (int p = i; p < text.Length; p++)
                {
                    if (char.IsLetter(text[p]) == false)
                    {
                        wordLastIndex = p;
                        // Extract word
                        string word = text.Substring(wordFirstIndex, wordLastIndex - wordFirstIndex);
                        // Check if word has at least 3 letters
                        if (word.Length > 2)
                        {
                            // Check if the extracted word is a palindrome
                            bool palindrome = IsPalindrome(word);
                            if (palindrome == true)
                            {
                                result.Add(word);
                            }
                        }                        
                        i = p;
                        break;
                    }
                }                
            }
        }
        return result.ToArray();
    }

    private static bool IsPalindrome(string word)
    {
        word = word.ToLower();
        StringBuilder stringBuilder = new StringBuilder();
        for (int i = word.Length-1; i >= 0; i--)
        {
            stringBuilder.Append(word[i]);
        }
        string reversedWord = stringBuilder.ToString();
        if (word == reversedWord)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}