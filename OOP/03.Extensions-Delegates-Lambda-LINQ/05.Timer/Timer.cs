// Using delegates write a class Timer that has can execute certain method at each t seconds.

using System;
using System.Threading;

public delegate void PrinterDelegate();

public class Timer
{
    // Fields
    private int timeInterval;
    private int? totalCalls;
    PrinterDelegate deleg;

    // Constructor
    public Timer(PrinterDelegate deleg, int timeInterval)
        : this(deleg, timeInterval, null)
    {
    }

    public Timer(PrinterDelegate deleg, int timeInterval, int? totalCalls)
    {
        this.Delegate = deleg;
        this.TotalCalls = totalCalls;
        this.TimeInterval = timeInterval;
    }

    // Properties
    public int TimeInterval
    {
        get { return this.timeInterval; }
        set { this.timeInterval = value; }
    }

    public int? TotalCalls
    {
        get { return this.totalCalls; }
        set { this.totalCalls = value; }
    }

    public PrinterDelegate Delegate
    {
        get { return this.deleg; }
        set { this.deleg = value; }
    }

    // Methods
    public void RunTimer()
    {
        int counter = 0;
        while (true)
        {
            this.Delegate();
            counter++;
            if (counter == this.TotalCalls) { break; }
            Thread.Sleep(this.TimeInterval * 1000);
        }
    }
}