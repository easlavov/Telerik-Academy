namespace Abstraction
{
    using System;

    /// <summary>
    /// Contains methods that allow the creation and manipulation of circles.
    /// </summary>
    public class Circle : Figure
    {
        /// <summary>
        /// Represents the radius of the circle.
        /// </summary>
        private double radius;
        
        /// <summary>
        /// Initializes a new instance of the Circle class.
        /// </summary>
        /// <param name="radius">The radius of the circle.</param>
        public Circle(double radius)
        {
            this.Radius = radius;
        }

        /// <summary>
        /// Gets or sets the radius of the circle.
        /// </summary>
        public double Radius
        {            
            get
            {
                return this.radius;
            } 

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Radius must be bigger than zero!");
                }

                this.radius = value;
            }
        }

        /// <summary>
        /// Returns the perimeter of the circle.
        /// </summary>
        /// <returns>The perimeter of the circle.</returns>
        public override double CalcPerimeter()
        {
            double perimeter = 2 * Math.PI * this.Radius;
            return perimeter;
        }

        /// <summary>
        /// Returns the surface of the circle.
        /// </summary>
        /// <returns>The surface of the circle.</returns>
        public override double CalcSurface()
        {
            double surface = Math.PI * this.Radius * this.Radius;
            return surface;
        }
    }
}
