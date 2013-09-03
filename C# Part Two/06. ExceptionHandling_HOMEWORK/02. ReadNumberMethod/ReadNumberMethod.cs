// Write a method ReadNumber(int start, int end) that enters an integer number in given range [start…end].
// If an invalid number or non-number text is entered, the method should throw an exception. 
// Using this method write a program that enters 10 numbers: a1, a2, … a10, such that 1 < a1 < … < a10 < 100

using System;

class ReadNumberMethod
{
    static void Main()
    {
        for (int i = 0; i < 10; i++)
        {
            Console.Write("Number a{0}: ", i + 1);
            if (i == 0)
            {
                ReadNumber(2, 10);
                continue;
            }
            else
            {
                if (i == 9)
                {
                    ReadNumber(i * 10 + 1, 99);
                }
                else
                {
                    ReadNumber(i * 10 + 1, i * 10 + 10);
                }
            }

        }
    }

    static void ReadNumber(int start, int end)
    {
        Console.Write("Enter a number between {0} and {1}: ", start, end);
        try
        {
            int number = int.Parse(Console.ReadLine());

            if (number < start || number > end)
            {
                throw new IndexOutOfRangeException();
            }
        }
        catch (FormatException)
        {

            Console.WriteLine("You have not entered a number!");
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine("The number you entered is outside the allowed range.");
        }

    }
}