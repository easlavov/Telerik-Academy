using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CohesionAndCoupling
{
    public class Geometry2D
    {
        public static double CalcDistance(double x1, double y1, double x2, double y2)
        {
            double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
            return distance;
        }
        
        public static double CalcCuboidDiagonalXY(int width, int height)
        {
            double distance = CalcDistance(0, 0, width, height);
            return distance;
        }

        public static double CalcCuboidDiagonalXZ(int width, int depth)
        {
            double distance = CalcDistance(0, 0, width, depth);
            return distance;
        }

        public static double CalcCuboidDiagonalYZ(int height, int depth)
        {
            double distance = CalcDistance(0, 0, height, depth);
            return distance;
        }
    }
}
