using System;

public class Circle : Shape
{
    public Circle(double radius)
    {
        this.Width = radius;
        this.Height = radius;
    }

    public override double CalculateSurface()
    {
        return Math.PI * Width * Height;
    }
}