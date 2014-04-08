using System;

public abstract class Human
{
    // Fields
    private string firstName;
    private string lastName;

    // Properties
    public string FirstName
    {
        get
        {
            return this.firstName;
        }
        set
        {
            this.firstName = value;
        }
    }

    public string LastName
    {
        get
        {
            return this.lastName;
        }
        set
        {
            this.lastName = value;
        }
    }
}

