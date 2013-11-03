// In the school there are classes of students. Each class has a set of teachers.

using System;
using System.Collections.Generic;

public class Class : ICommentable
{
    // Fields
    private List<Student> students;
    private List<Teacher> teachers;
    private string textIdentifier;
    private string comment;

    // Constructors
    public Class(string textIdentifier,List<Student> students ,List<Teacher> teachers)
    {
        this.Students = students;
        this.TextIdentifier = textIdentifier;
        this.Teachers = teachers;
    }

    // Properties
    public List<Student> Students
    {
        get
        {
            return this.students;
        }
        set
        {
            this.students = value;
        }
    }

    public List<Teacher> Teachers
    {
        get
        {
            return this.teachers;
        }
        set
        {
            this.teachers = value;
        }
    }

    public string TextIdentifier
    {
        get { return this.textIdentifier; }
        set
        {
            this.textIdentifier = value;
        }
    }

    private string Comment
    {
        get
        {
            return this.comment;
        }
        set
        {
            this.comment = value;
        }
    }

    // Implementations
    public void SetComment(string comment)
    {
        this.Comment = comment;
    }

    public string GetComment()
    {
        return string.Format("{0} comment: {1}", this.TextIdentifier, this.Comment);
    }

    // Overrides
    public override string ToString()
    {
        string info = this.TextIdentifier + Environment.NewLine;
        info += "Students:" + Environment.NewLine;
        foreach (var student in this.Students)
        {
            info+=student.ToString();
        }
        info += Environment.NewLine;
        info += "Teachers:" + Environment.NewLine;
        foreach (var teacher in this.Teachers)
        {
            info+=teacher.ToString();
            info += Environment.NewLine;
        }
        return info;
    }
}