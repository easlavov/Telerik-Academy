// Both teachers and students are people.

using System;

public class Student : Person
{
    // Fields
    private byte classNumber;

    // Constructors
    public Student(string name, byte classNumber)
    {
        this.Name = name;
        this.ClassNumber = classNumber;
    }

    // Properties
    public byte ClassNumber
    {
        get
        {
            return this.classNumber;
        }
        set
        {
            if (value <1)
            {
                throw new ArgumentException("Student number should be at least 1");
            }
            this.classNumber = value;
        }
    }

    // Overrides
    public override string ToString()
    {
        string info = string.Format(
            "Name: {0}, Number {1}", this.Name, this.ClassNumber);        
        info += Environment.NewLine;
        return info;
    }
}
