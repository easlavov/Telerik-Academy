using System;

class TestProgram
{
    static void Main()
    {        
        Console.WriteLine("Testing custom queue class.");
        Console.WriteLine("Class features:");
        Console.WriteLine(" - linked list implementation");
        Console.WriteLine(" - methods Enqueue, Dequeue, Peek, Contains and property Count.");
        Console.WriteLine();
        Console.WriteLine("Creating a LinkedQueue.");
        LinkedQueue<int> queue = new LinkedQueue<int>();
        Console.WriteLine("DONE!" + Environment.NewLine);
        Console.WriteLine("Enqueuing numbers from 1 to 10");
        for (int i = 1; i <= 10; i++)
        {
            queue.Enqueue(i);
        }

        Console.WriteLine("DONE!" + Environment.NewLine);
        Console.WriteLine("Printing queue using custom enumerator:");
        Print(queue);        
        Console.WriteLine("Peeking: " + queue.Peek()); 
        Console.WriteLine();
        Console.WriteLine("Dequeuing 7 elements");
        for (int i = 0; i < 7; i++)
        {
            queue.Dequeue();
        }

        Console.Write("Press any key to continue testing.");
        Console.ReadKey();
        Console.WriteLine();
        Console.WriteLine("Printing queue:");
        Print(queue);
        Console.WriteLine("Enqueuing numbers from 1 to 10");
        for (int i = 1; i <= 10; i++)
        {
            queue.Enqueue(i);
        }

        Console.WriteLine("Peeking: " + queue.Peek());
        Console.WriteLine();
        Console.WriteLine("Printing queue:");
        Print(queue);
        Console.WriteLine("Cheking if queue contains the number 5: " + queue.Contains(5));
        Console.WriteLine("Cheking if queue contains the number -15: " + queue.Contains(-15));
        Console.WriteLine();
        Console.WriteLine("Clearing the queue");
        queue.Clear();
        Console.WriteLine("Cleared");
        Console.WriteLine();
        Console.WriteLine("Printing queue:");
        Print(queue);
        try
        {
            Console.WriteLine("Peeking: ");
            queue.Peek();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }        
    }

    private static void Print(LinkedQueue<int> queue)
    {
        foreach (var item in queue)
        {
            Console.WriteLine(item + " ");
        }

        Console.WriteLine();
    }
}