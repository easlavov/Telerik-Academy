// We are given a school. In the school there are classes of students.

using System;
using System.Collections.Generic;

public class School
{
    // Fields
    private List<Class> classes;

    // Constructors
    public School(List<Class> classes)
    {
        this.Classes = classes;
    }

    // Properties
    public List<Class> Classes
    {
        get
        {
            return this.classes;
        }
        set
        {
            this.classes = value;
        }
    }

    // Overrides
    public override string ToString()
    {
        string info = string.Empty;
        foreach (var c in this.Classes)
        {
            info+=c.ToString();
        }
        return info;
    }
}