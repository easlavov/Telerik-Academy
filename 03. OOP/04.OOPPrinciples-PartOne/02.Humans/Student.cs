using System;

public class Student : Human
{
    // Fields
    private byte grade;

    // Constructor
    public Student(string firstName, string lastName, byte grade)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Grade = grade;
    }

    // Properties
    public byte Grade
    {
        get
        {
            return this.grade;
        }
        set
        {
            this.grade = value;
        }
    }
}

