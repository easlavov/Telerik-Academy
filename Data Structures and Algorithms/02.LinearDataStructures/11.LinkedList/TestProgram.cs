using System;

class TestProgram
{
    static void Main()
    {
        Console.WriteLine("Testing custom linked list class.");
        Console.WriteLine("Class features:");
        Console.WriteLine(" - singly linked implementation;");
        Console.WriteLine(" - methods AddLast, AddFirst, AddAfter, AddBefore");
        Console.WriteLine();
        Console.WriteLine("Creating a linked list.");
        LinkedListCustom<int> list = new LinkedListCustom<int>();
        Console.WriteLine("DONE" + Environment.NewLine);
        Console.WriteLine("Adding the numbers form 1 to 10 as nodes using the AddLast method.");
        for (int i = 1; i <= 10; i++)
        {
            list.AddLast(i);
        }
        Console.WriteLine("DONE. " + "The number of nodes in the list is " + list.Count + Environment.NewLine);
        Console.WriteLine("Printing node values using a custom enumerator.");
        PrintList(list);
        Console.WriteLine("DONE" + Environment.NewLine);
        Console.WriteLine("Adding the number 100 using the AddFirst method");
        list.AddFirst(100);
        PrintList(list);
        Console.WriteLine("DONE" + Environment.NewLine);
        Console.WriteLine("Adding the number 13 using the AddFirst method again.");
        list.AddFirst(13);
        PrintList(list);
        Console.WriteLine("DONE" + Environment.NewLine);
        Console.WriteLine("Inserting the number -10 between 9 and 10 using the AddBefore method.");
        list.AddBefore(list.LastItem, -10);
        PrintList(list);
        Console.WriteLine("DONE" + Environment.NewLine);
        Console.WriteLine("Inserting the number -50 between 13 and 100 using the AddAfter method.");
        list.AddAfter(list.FirstItem, -50);
        PrintList(list);
        Console.WriteLine("DONE. " + "The number of nodes in the list is " + list.Count + Environment.NewLine);
    }
  
    private static void PrintList(LinkedListCustom<int> list)
    {
        foreach (var node in list)
        {
            Console.Write(node + " ");
        }
        Console.WriteLine();
    }       
}