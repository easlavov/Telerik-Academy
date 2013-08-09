// Write a program that can solve these tasks:
// Reverses the digits of a number
// Calculates the average of a sequence of integers
// Solves a linear equation a * x + b = 0
//		Create appropriate methods.
//		Provide a simple text-based menu for the user to choose which task to solve.
//		Validate the input data:
// The decimal number should be non-negative
// The sequence should not be empty
// a should not be equal to 0

using System;

class SolveMultipleTasks
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Please, select an operation:");
            Console.WriteLine("1. Reverse the digits of a number.");
            Console.WriteLine("2. Calculate the average of a sequence of integers.");
            Console.WriteLine("3. Solve a linear equation a * x + b = 0");
            string operation = "";
            while (true)
            {
                Console.Write("Enter the desired operation number and press Enter: ");
                operation = Console.ReadLine();

                if (operation == "1" || operation == "2" || operation == "3")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong input. Try again.");
                }
            }

            if (operation == "1")
            {                
                decimal number = 0;
                while (true)
                {
                    Console.Write("Please, enter a positive number: ");
                    number = decimal.Parse(Console.ReadLine());
                    if (number > 0)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("The number should be positive.");
                    }
                }                
                number = ReverseDigits(number);
                Console.WriteLine("Reversing digits: {0}", number);
                Console.Write("Press any key to perform another operation.");
                Console.ReadKey();
                Console.WriteLine();
                Console.WriteLine("**********");
                Console.WriteLine();
            }

            if (operation == "2")
            {
                int size = 0;
                while (true)
                {
                    Console.Write("Please, enter the length of the sequence: ");
                    size = int.Parse(Console.ReadLine());
                    if (size > 0)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("The sequence can't be empty.");
                    }
                }                
                int[] array = new int[size];
                for (int i = 0; i < array.Length; i++)
                {
                    Console.Write("Enter number {0}: ", i + 1);
                    array[i] = int.Parse(Console.ReadLine());
                }
                decimal average = Average(array);
                Console.WriteLine("The average of this sequence is {0}", average);
                Console.Write("Press any key to perform another operation.");
                Console.ReadKey();
                Console.WriteLine();
                Console.WriteLine("**********");
                Console.WriteLine();
            }

            if (operation == "3")
            {
                int a, b;
                while (true)
                {
                    Console.Write("Enter 'a': ");
                    a = int.Parse(Console.ReadLine());
                    if (a != 0)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("'a' can't equal zero.");
                    }
                }
                Console.Write("Enter 'b': ");
                b = int.Parse(Console.ReadLine());
                decimal result = SolveLinearEquation(a, b);
                Console.WriteLine("'x' is {0}", result);
                Console.Write("Press any key to perform another operation.");
                Console.ReadKey();                
                Console.WriteLine();
                Console.WriteLine("**********");
                Console.WriteLine();
            }
        }
    }    

    // Reversal method
    static decimal ReverseDigits(decimal number)
    {
        string numStr = number.ToString();
        string newNum = "";
        for (int i = numStr.Length - 1; i >= 0; i--)
        {
            newNum += numStr[i];
        }
        return decimal.Parse(newNum);
    }

    // Average calculator
    static decimal Average(int[] sequence)
    {
        decimal average = 0;
        foreach (var number in sequence)
        {
            average += number;
        }
        return average /= sequence.Length;
    }

    // Linear equation solver
    private static decimal SolveLinearEquation(decimal a, decimal b)
    {
        // a * x + b = 0
        decimal result = -b / a;
        return result;
    }
}