using System;

namespace CohesionAndCoupling
{
    static class Geometry3D
    {                
        
        public static double CalcDistance(double x1, double y1, double z1, double x2, double y2, double z2)
        {
            double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1) + (z2 - z1) * (z2 - z1));
            return distance;
        }

        public static double CalcVolume(int width, int height, int depth)
        {
            double volume = width * height * depth;
            return volume;
        }

        public static double CalcDiagonalXYZ(int width, int height, int depth)
        {
            double distance = CalcDistance(0, 0, 0, width, height, depth);
            return distance;
        }
    }
}