using System;

public class Person
{
    // Fields
    private string name;
    private byte? age;
    
    // Constructors
    public Person(string name)
        : this(name, null)
    {
    }

    public Person(string name, byte? age)
    {
        this.Name = name;
        this.Age = age;
    }

    // Properties
    public string Name
    {
        get
        {
            return this.name;
        }
        set
        {
            this.name = value;
        }
    }

    public byte? Age
    {
        get
        {
            return this.age;
        }
        set
        {
            if (value < 0 || value > 120)
            {
                throw new ArgumentOutOfRangeException("Age must be an integer between 0 and 120.");
            }
            this.age = value;
        }
    }

    // Overrides
    public override string ToString()
    {
        string info = string.Format(
            "Name: {0}, ", this.Name);
        if (this.Age == null)
        {
            info += "Age: unspecified";
        }
        else
        {
            info += string.Format("Age: {0}", this.Age);
        }
        return info;
    }
}