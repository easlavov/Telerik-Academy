// Write a program that, depending on the user's choice inputs int, double or string variable. If the variable 
// is integer or double, increases it with 1. If the variable is string, appends "*" at its end. The program
// must show the value of that variable as a console output. Use switch statement.

using System;

class PerformOperationsDependingOnUserInput
{
    static void Main()
    {
        // Print what the program does:
        Console.WriteLine("This program, depending on the user's choice inputs int, double or string variable. If the variable is integer or double, increases it with 1. If the variable is string, appends * at its end. The program shows the value of that variable as a console output.");
        
        // Ask the user wether he wants to input an integer, a double or a string variable.
        Console.WriteLine("Please, choose from the list by typing the corresponding number and pressing Enter: ");
        Console.WriteLine("(1) If you want to input an integer.");
        Console.WriteLine("(2) If you want to input a double.");
        Console.WriteLine("(3) If you want to input a string.");
        Console.Write("Your choice: ");
        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                Console.Write("Please, enter an integer: ");
            int integer = int.Parse(Console.ReadLine());
            integer++;
            Console.WriteLine("The integer has been increased by one. It now has value of {0}.", integer); break;
            case 2:
                Console.Write("Please, enter a floating-point number: ");
            double doubleNumber = double.Parse(Console.ReadLine());
            doubleNumber++;
            Console.WriteLine("The number has been increased by one. It now has value of {0}.", doubleNumber); break;
            case 3:
                Console.Write("Please, enter a string: ");
            string str = Console.ReadLine();
            str += "*";
            Console.WriteLine("An * has been added to the string. It now looks like this: < {0} >.", str); break;
            default: Console.WriteLine("Wrong input."); break;
        }        
    }
}