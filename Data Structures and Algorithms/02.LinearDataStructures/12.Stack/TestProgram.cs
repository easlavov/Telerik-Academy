// Implement the ADT stack as auto-resizable array. Resize the capacity on demand (when no space is available to add / insert a new element).
using System;

class TestProgram
{
    static void Main()
    {
        Console.WriteLine("Testing custom stack class.");
        Console.WriteLine("Class features:");
        Console.WriteLine(" - array implementation;");
        Console.WriteLine(" - methods Push, Pop, Peek, Contains and property Count.");
        Console.WriteLine();
        Console.WriteLine("Creating an instance of the class Stack(custom):");
        StackCustom<int> stack = new StackCustom<int>();
        Console.WriteLine("DONE!" + Environment.NewLine);
        Console.WriteLine("Using Push(), insert numbers from 1 to 10");
        for (int i = 1; i <= 10; i++)
        {
            stack.Push(i);
        }

        Console.WriteLine("DONE!" + Environment.NewLine);
        Console.WriteLine("Using custom enumerator, print the content of the stack:");
        PrintStack(stack);
        Console.WriteLine("DONE!" + Environment.NewLine);
        Console.WriteLine("Print the count of elements: " + stack.Count);
        Console.WriteLine("Peek at top element: " + stack.Peek());
        Console.WriteLine("DONE!" + Environment.NewLine);
        Console.WriteLine("Remove top 5 elements using Pop():");
        for (int i = 0; i < 5; i++)
        {
            stack.Pop();
        }

        Console.WriteLine("DONE!" + Environment.NewLine);
        Console.WriteLine("Print the count of elements: " + stack.Count);
        Console.WriteLine("Peek at top element: " + stack.Peek());
        PrintStack(stack);
        Console.WriteLine("DONE!" + Environment.NewLine);
        Console.WriteLine("Using Push(), insert numbers from 1 to 10");
        for (int i = 1; i <= 10; i++)
        {
            stack.Push(i);
        }

        Console.WriteLine("Print the stack again:");
        PrintStack(stack);
        Console.WriteLine("DONE!" + Environment.NewLine);
        Console.WriteLine("Check if stack contains the number -15: " + stack.Contains(-15));
        Console.WriteLine("DONE!" + Environment.NewLine);
        Console.WriteLine("Check if stack contains the number 10: " + stack.Contains(10));
        Console.WriteLine("DONE!" + Environment.NewLine);
        Console.WriteLine("Clear the stack using Clear().");
        stack.Clear();
        try
        {
            Console.WriteLine("Peek at top element: ");
            stack.Peek();
        }
        catch (InvalidOperationException e)
        {
            Console.WriteLine(e.Message);            
        }
    }
  
    private static void PrintStack(StackCustom<int> stack)
    {
        foreach (var num in stack)
        {
            Console.Write(num + " ");
        }

        Console.WriteLine();
    }
}