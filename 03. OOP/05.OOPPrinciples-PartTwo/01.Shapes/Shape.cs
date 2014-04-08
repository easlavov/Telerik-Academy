using System;

public abstract class Shape
{
    // Fields
    private double width;
    private double height;

    // Properties
    public double Width
    {
        get
        {
            return this.width;
        }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException("The width of the shape must be bigger than zero!");
            }
            this.width = value;
        }
    }

    public double Height
    {
        get
        {
            return this.height;
        }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException("The height of the shape must be bigger than zero!");
            }
            this.height = value;
        }
    }

    // Methods
    public abstract double CalculateSurface();
}