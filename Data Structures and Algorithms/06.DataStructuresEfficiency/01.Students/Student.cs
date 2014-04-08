using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Student : IComparable
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }

    public Student(string firstName, string lastName)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
    }

    public int CompareTo(object obj)
    {
        Student secondStudent = obj as Student;
        if (secondStudent == null)
        {
            throw new ArgumentException();
            
        }

        int byLastName = this.LastName.CompareTo(secondStudent.LastName);
        int byFirstName = this.FirstName.CompareTo(secondStudent.FirstName);
        if (byLastName != 0)
        {
            return byLastName;
        }
        else
        {
            return byFirstName;
        }
    }

    public override string ToString()
    {
        return string.Format("{0} {1}", this.FirstName, this.LastName);
    }
}