using System;

namespace ThreeDimensionalSpace
{
    public static class CalcDistance
    {
        public static double Calculate(Point3D pointA, Point3D pointB)
        {
            // Implemented Euclidean distance formula
            return Math.Sqrt(
                (pointA.X - pointB.X) * (pointA.X - pointB.X) +
                (pointA.Y - pointB.Y) * (pointA.Y - pointB.Y) +
                (pointA.Z - pointB.Z) * (pointA.Z - pointB.Z));
        }
    }
}
