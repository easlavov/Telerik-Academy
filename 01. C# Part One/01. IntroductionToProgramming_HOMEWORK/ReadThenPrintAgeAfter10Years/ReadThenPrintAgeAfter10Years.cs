// Write a program to read your age from the console and print how old you will be after 10 years.

using System;

class ReadThenPrintAgeAfter10Years
{
    static void Main()
    {       
        Console.Write("To learn how old you will be in 10 years enter your current age: ");
        byte age = Convert.ToByte(Console.ReadLine());

        Console.WriteLine("Your age in ten years will be " + (age + 10) + ".");
    }
}