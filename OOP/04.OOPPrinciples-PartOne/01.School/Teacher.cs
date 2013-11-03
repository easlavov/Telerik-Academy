// Both teachers and students are people.

using System;
using System.Collections.Generic;

public class Teacher : Person
{
    // Fields
    private List<Discipline> disciplines;

    // Constructors
    public Teacher(string name, List<Discipline> disciplines)
    {
        this.Name = name;
        this.Disciplines = disciplines;
    }

    // Properties
    public List<Discipline> Disciplines
    {
        set { this.disciplines = value; }
        get { return this.disciplines; }
    }

    // Overrides
    public override string ToString()
    {
        string info = string.Format(
            "Name: {0}" + Environment.NewLine, this.Name);
        foreach (var discipline in this.Disciplines)
        {
            info += discipline.ToString() + Environment.NewLine;
        }        
        return info;
    }
}