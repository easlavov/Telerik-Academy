/*Write a program that reads from the console a sequence of positive integer numbers. The sequence ends when empty line is entered. Calculate and print the sum and average of the elements of the sequence. Keep the sequence in List<int>.*/

using System;
using System.Collections.Generic;
using System.Linq;

class PrintSumAndAverage
{
    static void Main()
    {
        // sequence should be kept in a List<int> as per the task
        List<int> sequence = ReadIntegers();
        Console.WriteLine("The sum of the numbers is: " + sequence.Sum());
        Console.WriteLine("The average of the numbers is: " + sequence.Average());
    }

    private static List<int> ReadIntegers()
    {
        Console.WriteLine("Please, enter as many positive integer numbers as you'd like and press Enter when finnished. Enter only one number per line:");
        List<int> sequence = new List<int>();
        string input = Console.ReadLine();
        while (input != string.Empty)
        {
            int num = -1;
            try
            {
                num = int.Parse(input);
                if (num < 0)
                {
                    Console.WriteLine("You should only enter positive numbers!");
                }
                else
                {
                    sequence.Add(num);
                    Console.WriteLine(input + " successfully added!");
                }
            }
            catch (OverflowException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (FormatException)
            {
                Console.WriteLine("You should only enter integer numbers!");
            }
            
            input = Console.ReadLine();
        }

        Console.WriteLine("The numbers you entered are: " + string.Join(", ", sequence));
        return sequence;
    }
}