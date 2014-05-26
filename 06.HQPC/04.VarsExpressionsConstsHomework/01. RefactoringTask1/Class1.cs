using System;

public class Dimensions
{
    private double width, height;

    public Dimensions(double width, double height)
    {
        this.width = width;
        this.height = height;
    }

    /// <summary>
    /// Returns the dimensions of a figure rotated by certain angle.
    /// </summary>
    /// <param name="dimensions">The dimensions of the figure to be rotated.</param>
    /// <param name="angle">The angle of rotation.</param>
    /// <returns></returns>
    public static Dimensions GetDimensionsAfterRotation(Dimensions dimensions, double angle)
    {
        double sine = Math.Abs(Math.Sin(angle));
        double cosine = Math.Abs(Math.Cos(angle));
        
        double newWidth = (sine * dimensions.height) + (cosine * dimensions.width);
        double newHeight = (sine * dimensions.width) + (cosine * dimensions.height);

        var newSize = new Dimensions(newWidth, newHeight);
        return newSize;
    }
}

