using System;
using System.Collections.Generic;

namespace ThreeDimensionalSpace
{
    // I have decided to declare a non-static Path class because paths are infinite
    public class Path
    {
        // The path is an array
        private List<Point3D> points = new List<Point3D>();

        // The default empty constructor is sufficient

        // Get property
        public List<Point3D> Points
        {
            get { return this.points; }
        }

        // Adds an item of type Point3D to the array
        public void AddPoint(Point3D point)
        {
            this.points.Add(point);
        }

        // Clears the path array
        public void ClearPath()
        {
            this.Points.Clear();
        }
    }
}
