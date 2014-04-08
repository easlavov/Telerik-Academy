using System;

public class InvalidRangeException<T> : SystemException where T : struct, IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
{
    // Fields
    private T start;
    private T end;

    // Constructors
    public InvalidRangeException(string msg, T start, T end)
        : this(msg, start, end, null)
    { }

    public InvalidRangeException(string msg, T start, T end, Exception innerEx)
        : base(msg, innerEx)
    {
        this.start = start;
        this.end = end;
    }    

    // Properties
    public T Start
    {
        get
        {
            return this.start;
        }
    }

    public T End
    {
        get
        {
            return this.end;
        }
    }
}