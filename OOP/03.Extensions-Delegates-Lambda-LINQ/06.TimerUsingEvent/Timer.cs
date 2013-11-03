using System;
using System.Threading;

public class Timer
{
    // This is the EventHandler
    public event EventHandler Tick;
    
    // Field
    private int duration;

    // Constructor
    public Timer(int duration)
    {
        this.Duration = duration;
    }

    // This is the event invoker
    protected virtual void OnTick(EventArgs e)
    {
        if (Tick != null)
        {
            Tick(this, e);
        }
    }

    // Property
    public int Duration
    {
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Timer duration must be 1 or longer.");
            }
            this.duration = value;
        }
        get { return this.duration; }
    }

    // Method
    public void Start()
    {
        int countdown = this.Duration;
        while (countdown > 0)
        {
            // The event is invoked when a second passes
            OnTick(EventArgs.Empty);
            countdown--;
            Thread.Sleep(1000);
        }
    }
}