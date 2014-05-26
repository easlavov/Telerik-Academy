namespace Methods
{
    using System;

    public class Methods
    {
        /// <summary>
        /// Returns a triangle area by given three sides.
        /// </summary>
        /// <param name="a">side A</param>
        /// <param name="b">side B</param>
        /// <param name="c">side C</param>
        /// <returns>The area of the triangle.</returns>
        public static double CalcTriangleArea(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentOutOfRangeException("Sides should be positive.");
            }

            if (!CanFormTriangle(a, b, c))
            {
                throw new ArgumentException("The three sides can not form a triangle.");
            }

            double p = (a + b + c) / 2;
            double area = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            return area;
        }

        /// <summary>
        /// Returns if three lengths can form a triangle.
        /// </summary>
        /// <param name="a">length A</param>
        /// <param name="b">length B</param>
        /// <param name="c">length C</param>
        /// <returns>If the lengths can form a triangle.</returns>
        private static bool CanFormTriangle(double a, double b, double c)
        {
            if (a + b <= c)
            {
                return false;
            }

            if (a + c <= b)
            {
                return false;
            }

            if (b + c <= a)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Returns a digit's English name.
        /// </summary>
        /// <param name="number">A digit.</param>
        /// <returns>The digit's English name.</returns>
        public static string DigitToEnglish(int number)
        {
            switch (number)
            {
                case 0: return "zero";
                case 1: return "one";
                case 2: return "two";
                case 3: return "three";
                case 4: return "four";
                case 5: return "five";
                case 6: return "six";
                case 7: return "seven";
                case 8: return "eight";
                case 9: return "nine";
            }

            throw new ArgumentOutOfRangeException("Number should be between 0 and 9.");
        }

        /// <summary>
        /// Returns the biggest value of the passed integer arguments
        /// </summary>
        /// <param name="elements">The integer arguments.</param>
        /// <returns>The biggest value.</returns>
        public static int FindMax(params int[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                throw new ArgumentNullException("Arguments array is empty.");
            }

            for (int i = 1; i < elements.Length; i++)
            {
                if (elements[i] > elements[0])
                {
                    elements[0] = elements[i];
                }
            }

            return elements[0];
        }

        /// <summary>
        /// Prints an object as a number by specified format.
        /// </summary>
        /// <param name="number">The number as object.</param>
        /// <param name="format">The format.</param>
        public static void PrintAsNumber(object number, string format)
        {
            if (!IsNumber(number))
            {
                throw new ArgumentException("The passed argument is not a number.");
            }

            if (format != "f" || format != "%" || format != "r")
            {
                throw new ArgumentException("Wrong format.");
            }

            if (format == "f")
            {
                Console.WriteLine("{0:f2}", number);
                return;
            }

            if (format == "%")
            {
                Console.WriteLine("{0:p0}", number);
                return;
            }

            if (format == "r")
            {
                Console.WriteLine("{0,8}", number);
                return;
            }
        }

        /// <summary>
        /// Returns if an object is parsable to number.
        /// </summary>
        /// <param name="number">The object.</param>
        /// <returns>A bool that tells if the object is parasable to number.</returns>
        private static bool IsNumber(object number)
        {
            double num;
            bool isNumber = double.TryParse(number.ToString(), out num);
            return isNumber;
        }

        /// <summary>
        /// Calculates the distance between two points.
        /// </summary>
        /// <param name="x1">x1</param>
        /// <param name="y1">y1</param>
        /// <param name="x2">x2</param>
        /// <param name="y2">y2</param>
        /// <returns>The distance between the two points.</returns>
        public static double CalcDistance(double x1, double x2, double y1, double y2)
        {
            double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
            return distance;
        }

        /// <summary>
        /// Returns if a line is horizontal.
        /// </summary>
        /// <param name="x1">x1</param>
        /// <param name="y1">y1</param>
        /// <param name="x2">x2</param>
        /// <param name="y2">y2</param>
        /// <returns>A bool indicating if the line is horizontal.</returns>
        public static bool IsHorizontal(double x1, double x2, double y1, double y2)
        {
            bool isHorizontal = (y1 == y2);
            return isHorizontal;
        }

        /// <summary>
        /// Returns if a line is vertical.
        /// </summary>
        /// <param name="x1">x1</param>
        /// <param name="y1">y1</param>
        /// <param name="x2">x2</param>
        /// <param name="y2">y2</param>
        /// <returns>A bool indicating if the line is vertical.</returns>
        public static bool IsVertical(double x1, double x2, double y1, double y2)
        {
            bool isVertical = (x1 == x2);
            return isVertical;
        }
    }
}
