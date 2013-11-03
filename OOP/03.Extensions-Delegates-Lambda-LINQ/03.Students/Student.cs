using System;

public class Student
{
    // Fields
    private string firstName;
    private string lastName;
    private int age;

    // Constructors
    public Student(string firstName, string lastName, int age)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Age = age;
    }

    // Properties
    public string FirstName
    {
        set
        {
            if (value.Length < 2)
            {
                throw new ArgumentException("Student first name must be at least 2 characters");
            }
            if (value.Length > 20)
            {
                throw new ArgumentException("Student first name must be no more than 20 characters");
            }
            this.firstName = value;
        }
        get { return this.firstName; }
    }

    public string LastName
    {
        set
        {
            if (value.Length < 2)
            {
                throw new ArgumentException("Student last name must be at least 2 characters");
            }
            if (value.Length > 20)
            {
                throw new ArgumentException("Student last name must be no more than 20 characters");
            }
            this.lastName = value;
        }
        get { return this.lastName; }
    }

    public int Age
    {
        set
        {
            if (value < 0 || value > 120)
            {
                throw new ArgumentException("Student age must be between 0 and 120.");
            }
            this.age = value;
        }
        get { return this.age; }
    }

    // Methods
    public bool FirstNameBeforeLast()
    {
        int length = this.FirstName.Length;
        if (this.LastName.Length < length) { length = this.LastName.Length; }
        for (int i = 0; i < length; i++)
        {
            if (this.FirstName[i] > this.LastName[i])
            {
                return false;
            }
        }
        return true;
    }
}