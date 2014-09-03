using System;

class TestProgram
{
    static void Main()
    {
        Console.WriteLine("Creating an instance of the custom PriorityQueue class and adding 8 integers to it in non-increasing randomized order.");
        var priorityQueue = new PriorityQueue<int>();
        priorityQueue.Enqueue(5);
        priorityQueue.Enqueue(3);
        priorityQueue.Enqueue(2);
        priorityQueue.Enqueue(5);
        priorityQueue.Enqueue(15);
        priorityQueue.Enqueue(6);
        priorityQueue.Enqueue(0);
        priorityQueue.Enqueue(-8);

        Console.WriteLine("Printing the queue:");
        PrintQueue(priorityQueue);

        Console.WriteLine("Dequeuing and displaying the first 5 elements");
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine("Dequeuing the number {0}", priorityQueue.Dequeue());
        }

        Console.WriteLine("Printing the queue after the removal:");
        PrintQueue(priorityQueue);

        Console.WriteLine("Adding 5 more integers to the queue in non-increasing randomized order.");
        priorityQueue.Enqueue(9);
        priorityQueue.Enqueue(20);
        priorityQueue.Enqueue(13);
        priorityQueue.Enqueue(2);
        priorityQueue.Enqueue(7);

        Console.WriteLine("Printing the queue after the addition:");
        PrintQueue(priorityQueue);
    }

    private static void PrintQueue(PriorityQueue<int> priorityQueue)
    {
        Console.WriteLine(priorityQueue.ToString());
    }
}