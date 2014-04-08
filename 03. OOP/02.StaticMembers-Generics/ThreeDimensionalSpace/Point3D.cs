using System;

namespace ThreeDimensionalSpace
{
    public struct Point3D
    {
        private static readonly Point3D pointZero = new Point3D(0, 0, 0);
        
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public Point3D(int x, int y, int z)
            : this()
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public static Point3D PointZero
        {
            get { return pointZero; }
        }

        public override string ToString()
        {
            string threeDPoint = string.Format("{0},{1},{2}",
                this.X, this.Y, this.Z);
            return threeDPoint;
        }
    }
}
