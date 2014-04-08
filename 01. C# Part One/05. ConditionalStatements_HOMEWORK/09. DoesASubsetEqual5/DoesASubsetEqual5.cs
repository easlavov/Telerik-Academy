//We are given 5 integer numbers. Write a program that checks if 
// the sum of some subset of them is 0. Example: 3, -2, 1, 1, 8 -> 1+1-2=0.

using System;

class DoesASubsetEqualZero
{
    static void Main()
    {
        // Print what the program does:
        Console.WriteLine("This program checks if the sum of some subset of 5 user-input integers is 0.");

        // Instruct user to enter five integers:
        Console.Write("Please, enter integer 1: ");
        int integerOne = int.Parse(Console.ReadLine());
        Console.Write("Please, enter integer 2: ");
        int integerTwo = int.Parse(Console.ReadLine());
        Console.Write("Please, enter integer 3: ");
        int integerThree = int.Parse(Console.ReadLine());
        Console.Write("Please, enter integer 4: ");
        int integerFour = int.Parse(Console.ReadLine());
        Console.Write("Please, enter integer 5: ");
        int integerFive = int.Parse(Console.ReadLine());

        // If we have only two numbers:
        bool doesEqualZeroTwo = integerOne + integerTwo == 0;

        // If we have three numbers (note that sums already declared in the previous bools are excluded):
        bool doesEqualZeroThree = integerOne + integerThree == 0
            || integerTwo + integerThree == 0
            || integerOne + integerTwo + integerThree == 0;

        // If we have four numbers:
        bool doesEqualZeroFour = integerOne + integerFour == 0
            || integerTwo + integerFour == 0
            || integerThree + integerFour == 0
            || integerOne + integerTwo + integerFour == 0
            || integerOne + integerThree + integerFour == 0
            || integerTwo + integerThree + integerFour == 0
            || integerOne + integerTwo + integerThree + integerFour == 0;

        // If we have five numbers:
        bool doesEqualZeroFive = integerOne + integerFive == 0
            || integerTwo + integerFive == 0
            || integerThree + integerFive == 0
            || integerFour + integerFive == 0
            || integerOne + integerTwo + integerFive == 0
            || integerOne + integerThree + integerFive == 0
            || integerTwo + integerThree + integerFive == 0
            || integerTwo + integerFour + integerFive == 0
            || integerThree + integerFour + integerFive == 0
            || integerOne + integerTwo + integerThree + integerFive == 0
            || integerOne + integerTwo + integerFour + integerFive == 0
            || integerOne + integerThree + integerFour + integerFive == 0
            || integerTwo + integerThree + integerFour + integerFive == 0
            || integerOne + integerTwo + integerThree + integerFour + integerFive == 0;

        if (doesEqualZeroTwo || doesEqualZeroThree || doesEqualZeroFour || doesEqualZeroFive)
        {
            Console.WriteLine("There is a subset of numbers within the sequence that add up to zero.");
        }
        else
        {
            Console.WriteLine("No sum of any subset of numbers within the sequence equals zero.");
        }
    }
}