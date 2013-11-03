using System;

public class User
{
    // This method is used to subscribe the User class instance to the timer
    // It can also be declared in the class constructor
    public void SubscribeToTimer(Timer timer)
    {
        timer.Tick += PrintDateTime;
    }

    void PrintDateTime(object sender, EventArgs e)
    {
        // Simply print current date and time when the event occurs
        Console.WriteLine(DateTime.Now);
    }
}

