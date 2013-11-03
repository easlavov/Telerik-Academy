using System;

public class Rectangle : Shape
{
    public Rectangle(double width, double height)
    {
        this.Width = width;
        this.Height = height;
    }

    public override double CalculateSurface()
    {
        return this.Width * this.Height;
    }
}