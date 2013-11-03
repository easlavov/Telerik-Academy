// Disciplines have name, number of lectures and number of exercises.

using System;

public class Discipline : ICommentable
{
    // Fields
    private string name;
    private byte lectures;
    private byte exercises;
    private string comment;

    // Constructors
    public Discipline(string name, byte lectures, byte exercises)
    {
        this.Name = name;
        this.Lectures = lectures;
        this.Exercises = exercises;
    }

    // Properties
    public string Name
    {
        get { return this.name; }
        set
        {
            this.name = value;
        }
    }

    public byte Lectures
    {
        get { return this.lectures; }
        set
        {
            this.lectures = value;
        }
    }

    public byte Exercises
    {
        get { return this.exercises; }
        set
        {
            this.exercises = value;
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
        return string.Format("{0} comment: {1}", this.Name, this.Comment);
    }

    // Overrides
    public override string ToString()
    {
        string info = string.Format(
            "Discipline: {0}, Lectures: {1}, Exercises: {2}", this.Name, this.Lectures, this.Exercises);
        if (this.Comment != null)
        {
            info += string.Format(", {0}", this.Comment);
        }
        return info;
    }
}