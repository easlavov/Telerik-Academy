// * Read in MSDN about the keyword event in C# and how to publish events. Re-implement the above using
// .NET events and following the best practices.

using System;

class TestProgram
{
    static void Main()
    {
        Console.WriteLine("This program tests an event-driven timer-user logic. The timer is set at 10 seconds and counts backward. Each second the event handles the user request to print the current date and time.");
        Console.WriteLine();
        Timer timer = new Timer(10);
        User user = new User();
        user.SubscribeToTimer(timer);
        timer.Start();
    }
}