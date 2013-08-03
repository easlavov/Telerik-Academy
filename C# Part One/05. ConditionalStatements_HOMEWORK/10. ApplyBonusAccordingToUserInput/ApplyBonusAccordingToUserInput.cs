// Write a program that applies bonus scores to given scores in the range [1..9]. 
// The program reads a digit as an input. If the digit is between 1 and 3, the program multiplies it by 10;
// if it is between 4 and 6, multiplies it by 100; if it is between 7 and 9, multiplies it by 1000.
// If it is zero or if the value is not a digit, the program must report an error.
// Use a switch statement and at the end print the calculated new value in the console.

using System;

class ApplyBonusAccordingToUserInput
{
    static void Main()
    {
        // Print what the program does:
        Console.WriteLine(
            "This program reads a digit as an input. If the digit is between 1 and 3, the program multiplies it by 10; " +
            "if it is between 4 and 6, multiplies it by 100; if it is between 7 and 9, multiplies it by 1000. " + 
            "If it is zero or if the value is not a digit, the program must report an error.");
        Console.WriteLine();
        short digit;

        while (true)
        {
            // Instruct user to enter a digit:
            Console.Write("Please, enter a digit (1-9): ");
            try
            {
                digit = short.Parse(Console.ReadLine());
            }
            catch (System.FormatException)
            {
                Console.WriteLine("Wrong input");
                break;
            }

            if ((digit > 0) && (digit < 10))
            {
                switch (digit)
                {
                    case 1:
                    case 2:
                    case 3:
                        digit *= 10;
                        Console.WriteLine("The digit has been multiplied by 10. It now has value of {0}.", digit);
                        break;
                    case 4:
                    case 5:
                    case 6:
                        digit *= 100;
                        Console.WriteLine("The digit has been multiplied by 100. It now has value of {0}.", digit);
                        break;
                    case 7:
                    case 8:
                    case 9:
                        digit *= 1000;
                        Console.WriteLine("The digit has been multiplied by 1000. It now has value of {0}.", digit);
                        break;
                }
            }
            else
            {
                // Error report:
                Console.WriteLine("You have not entered a digit or you have entered 0.");
            }
        }
       
    }
}