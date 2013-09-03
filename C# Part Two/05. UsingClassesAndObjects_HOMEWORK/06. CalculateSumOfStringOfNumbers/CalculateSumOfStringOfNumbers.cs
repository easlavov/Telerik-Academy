// You are given a sequence of positive integer values written into a string,
// separated by spaces. Write a function that reads these values from given 
// string and calculates their sum. Example: string = "43 68 9 23 318" -> result = 461

using System;

class CalculateSumOfStringOfNumbers
{
    static void Main()
    {
        // Explain the program
        Console.WriteLine("This program tests a method that reads values written into a string separated by spaces and calculates their sum.");
        Console.WriteLine();
        Console.WriteLine("The string is hard-coded. Edit the code to test.");

        // Edit to test
        string sequence = "1 10 15 30"; // Sums to 56

        // Print test result
        Console.WriteLine("The sequence is {0}.", sequence);
        Console.WriteLine("The sum of the sequence is {0}.", SumString(sequence));
        
    }

    static int SumString(string sequence)
    {
        // This int variable holds the sum
        int sum = 0;
        // This string variable holds the current number
        string number = "";
        // The string is scanned from beginning to end
        for (int i = 0; i < sequence.Length; i++)
        {
            // If the element is not whitespace it is added to the 'number' string
            if (sequence[i] != ' ')
            {
                number += sequence[i];
            }
            // If whitespace is found the current number string is parsed and added to the sum
            else
            {
                int toAdd = int.Parse(number);
                sum += toAdd;
                // The variable is reset for the next number
                number = "";
            }
            // When the loop reaches the end of the string the number is parsed and added to the sum
            if (i == sequence.Length - 1)
            {
                int toAdd = int.Parse(number);
                sum += toAdd;
            }
        }
        return sum;
    }
}