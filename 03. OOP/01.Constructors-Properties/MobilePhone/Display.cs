using System;

namespace MobilePhone
{
    // TASK 1
    public class Display
    {
        // TASK 2
        // Fields
        private double? size;
        private int? colors;

        // Constructors
        public Display()
            : this(null, null)
        {
        }

        public Display(double? size)
            : this(size, 0)
        {
        }

        public Display(int? colors)
            : this(0, colors)
        {
        }

        public Display(double? size, int? colors)
        {
            this.Size = size;
            this.Colors = colors;
        }

        // TASK 5
        // Properties
        public double? Size
        {
            get
            {
                return this.size;
            }
            set
            {
                if (value < 1.5)
                {
                    throw new ArgumentOutOfRangeException("The specified display size is bellow the allowed minimum.");
                }
                if (value > 6)
                {
                    throw new ArgumentOutOfRangeException("The specified display size is above the allowed maximum.");
                }
                this.size = value;
            }
        }

        public int? Colors
        {
            get
            {
                return this.colors;
            }
            set
            {
                if (value != 32 && value != 16 && value != 256 && value != null)
                {
                    throw new ArgumentException("Display colors value can only be 256, 16 or 32.");
                }
                this.colors = value;
            }
        }

        // Override
        public override string ToString()
        {
            string toDisplay = String.Format(
                "Display size: {0}, Colors: {1}",
                this.Size ?? null, this.Colors ?? null);

            return toDisplay;
        }
    }
}