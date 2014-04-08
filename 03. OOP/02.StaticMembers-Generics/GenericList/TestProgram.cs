using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericList
{
    class TestProgram
    {
        static void Main()
        {
            Console.WriteLine("Hello! This program tests the functionality of the GenericList project. It will run a few tests to determine if the code has been written correctly. Enjoy!");
            Console.WriteLine();
            Console.WriteLine("Creating a new generic list of type GenericList<int> and printing it on the console (empty list)");
            GenericList<int> list = new GenericList<int>();
            Console.WriteLine(list.ToString());
            Console.WriteLine();
            List<int> testList = new List<int>();
            testList.Add(3);

            // Testing "add" method
            Console.WriteLine("Adding 4 elements to the list and printing list after each addition:");
            list.AddElement(5);
            Console.WriteLine(list.ToString());
            list.AddElement(89);
            Console.WriteLine(list.ToString());
            list.AddElement(-15);
            Console.WriteLine(list.ToString());
            list.AddElement(7);
            Console.WriteLine(list.ToString());
            Console.WriteLine();

            // Testing "remove" method
            Console.WriteLine("Removing elements at positions 2, 2 and 0 consecutively and printing list after each removal:");
            list.RemoveElement(2);
            Console.WriteLine(list.ToString());
            list.RemoveElement(2);
            Console.WriteLine(list.ToString());
            list.RemoveElement(0);
            Console.WriteLine(list.ToString());
            Console.WriteLine("Press any key to continue testing...");
            Console.ReadKey();
            Console.WriteLine();
            Console.WriteLine("Adding a new element and prinitng the list:");
            list.AddElement(33);
            Console.WriteLine(list.ToString());
            Console.WriteLine();

            // Testing "insert" method
            Console.WriteLine("Inserting '3' at position 1:");
            list.InsertElement(1, 3);
            Console.WriteLine(list.ToString());
            Console.WriteLine("Inserting '-4' at position 0:");
            list.InsertElement(0, -4);
            Console.WriteLine(list.ToString());
            Console.WriteLine("Inserting '-16' at position 3:");
            list.InsertElement(3, -16);
            Console.WriteLine(list.ToString());
            Console.WriteLine();

            // Testing class by doing larger amount of operations
            Console.WriteLine("Adding 50 elements to the list and printing it:");
            for (int i = 0; i <= 50; i++)
            {
                list.AddElement(i);
            }
            Console.WriteLine(list.ToString());
            Console.WriteLine();
            Console.WriteLine("Removing 25 elements from the list and printing it:");
            for (int i = 0; i <= 25; i++)
            {
                list.RemoveElement(i);
            }
            Console.WriteLine(list.ToString());
            Console.WriteLine();
            Console.WriteLine("Inserting 15 elements in the list and printing it:");
            for (int i = 0; i <= 15; i++)
            {
                list.InsertElement(i, i + 3);
            }
            Console.WriteLine(list.ToString());
            Console.WriteLine();

            // Testing "search" method
            Console.WriteLine("Trying to find element with value 15:");
            Console.WriteLine("The element has index [{0}]", list.FindElement(15));
            Console.WriteLine();

            // Testing "min" and "max" methods
            Console.WriteLine("Finding the value of the smallest and the biggest elements in the list:");
            Console.WriteLine("The smallest element is {0}", list.Min<int>());
            Console.WriteLine("The biggest element is {0}", list.Max<int>());
            Console.WriteLine();

            // Testing "clear" method
            Console.WriteLine("Clearing the list and printing it on the console:");
            list.ClearList();
            Console.WriteLine(list.ToString());

            // Saying good bye!
            Console.WriteLine("The test of the GenericList project has been completed successfully! Have a nice day!");
        }
    }
}