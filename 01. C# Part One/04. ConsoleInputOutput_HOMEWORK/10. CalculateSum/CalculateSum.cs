// Write a program to calculate the sum (with accuracy of 0.001): 1 + 1/2 - 1/3 + 1/4 - 1/5 + ...

using System;

class CalculateSum
{
    static void Main()
    {
        // Print what the program does:
        Console.WriteLine("This program calculates the sum (with accuracy of 0.001): 1 + 1/2 - 1/3 + 1/4 - 1/5 + ...");

        // Declare variables.
        double number = 1; // This is the first number of the sequence.
        double divider = 2; // This is the first denominator.
        double check; // This variable is used to accumulate a sum that represents the precision.
      
        do
        {
            // Step 1
            number += (1 / divider); // Here we ADD (1/divider) to the number
            divider += 1; // The divider is increased by 1 with each step.
            check = (1 / divider);

            // Step 2
            number -= (1 / divider); // Here we SUBSTRACT (1/divider) from the number
            divider += 1;
            check = (1 / divider);            
        } 
        while (check >= 0.001);

        // Print the sum.
        Console.WriteLine("The sum is: {0:0.000}", number);
    }
}