// Write a program that finds how many times a substring is contained in 
// a given text (perform case insensitive search).

using System;

class FindCountOfSubstringAppearancesInAText
{
    static void Main()
    {
        Console.WriteLine("This program finds how many times a substring is contained in a given text (case insensitive)");
        Console.WriteLine();
        Console.WriteLine("This is the text: ");
        string text = "We are living in an yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";
        Console.WriteLine(text);
        Console.WriteLine();
        Console.Write("Please, enter susbtring to count its appearances in the text: ");
        string substring = Console.ReadLine();
        int count = SubstringAppearances(text, substring);
        Console.WriteLine("The substring '{0}' appears {1} times.", substring, count);
    }

    private static int SubstringAppearances(string text, string substring)
    {
        // The text is converted to lowercase to allow case insensitive search
        string textLowerCase = text.ToLower();
        int countOfAppearances = 0;
        int index = textLowerCase.IndexOf(substring);
        while (index != -1)
        {
            countOfAppearances++;
            index = textLowerCase.IndexOf(substring, index + 1);
        }
        return countOfAppearances;
    }
}