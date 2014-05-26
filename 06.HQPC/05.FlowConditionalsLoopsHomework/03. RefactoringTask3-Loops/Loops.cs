using System;

public class Loops
{
    public void Print()
    {
        int[] array = new int[100];
        int length = array.Length;
        bool valueFound = false;
        int expectedValue = 90;
        for (int i = 0; i < length; i++)
        {
            Console.WriteLine(array[i]);
            if (array[i] == expectedValue)
            {
                valueFound = true;
                break;
            }
        }

        // More code here
        if (valueFound)
        {
            Console.WriteLine("Value found!");
        }
        else
        {
            Console.WriteLine("Value not found!");
        }
    }
}