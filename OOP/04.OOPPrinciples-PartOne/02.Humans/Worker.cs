using System;

public class Worker : Human
{
    // Fields
    private decimal weekSalary;
    private int workHoursPerDay;

    // Constructors
    public Worker(string firstName, string lastName, decimal weekSalary, int workHoursPerDay)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.WeekSalary = weekSalary;
        this.WorkHoursPerDay = workHoursPerDay;
    }

    // Properties
    public decimal WeekSalary
    {
        get
        {
            return this.weekSalary;
        }
        set
        {
            this.weekSalary = value;
        }
    }

    public int WorkHoursPerDay
    {
        get
        {
            return this.workHoursPerDay;
        }
        set
        {
            this.workHoursPerDay = value;
        }
    }

    // Methods
    public decimal MoneyPerHour()
    {
        // Assuming work week is 5 days
        return (this.WeekSalary / 5) / this.WorkHoursPerDay;
    }
}