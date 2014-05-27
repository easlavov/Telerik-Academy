namespace Abstraction
{
    using System;

    /// <summary>
    /// Contains methods that allow the creation and manipulation of rectangles.
    /// </summary>
    public class Rectangle : Figure
    {
        /// <summary>
        /// Represents the width of the rectangle.
        /// </summary>
        private double width;

        /// <summary>
        /// Represents the height of the rectangle.
        /// </summary>
        private double height;

        /// <summary>
        /// Initializes a new instance of the Rectangle class.
        /// </summary>
        /// <param name="width">The rectangle's width.</param>
        /// <param name="height">The rectangle's height/</param>
        public Rectangle(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        /// <summary>
        /// Gets or sets the rectangle's width.
        /// </summary>
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
                    throw new ArgumentOutOfRangeException("Width must be bigger than zero!");
                }

                this.width = value;
            }
        }

        /// <summary>
        /// Gets or sets the rectangle's height.
        /// </summary>
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
                    throw new ArgumentOutOfRangeException("Height must be bigger than zero!");
                }

                this.height = value;
            }
        }

        /// <summary>
        /// Returns the perimeter of the rectangle.
        /// </summary>
        /// <returns>The rectangle's perimeter.</returns>
        public override double CalcPerimeter()
        {
            double perimeter = 2 * (this.Width + this.Height);
            return perimeter;
        }

        /// <summary>
        /// Returns the surface of the rectangle.
        /// </summary>
        /// <returns>The rectangle's surface.</returns>
        public override double CalcSurface()
        {
            double surface = this.Width * this.Height;
            return surface;
        }
    }
}
