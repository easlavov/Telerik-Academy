// Both teachers and students are people. Students have name... Teachers have name...

using System;

public abstract class Person : ICommentable
{
    // Fields
    private string name;
    private string comment;

    // Properties
    public string Name
    {
        set
        {
            if (value.Length < 4)
            {
                throw new ArgumentException("Person name should be at least 4 characters");
            }
            this.name = value;
        }
        get { return this.name; }
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
        return string.Format("{0} comment: {1}",this.Name, this.Comment);
    }
}