using System;

namespace CohesionAndCoupling
{
    class TaskExamples
    {
        static void Main()
        {
            
            try
            {
                Console.WriteLine(FileExtractor.GetFileExtension("example"));                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine(FileExtractor.GetFileExtension("example.pdf"));
            Console.WriteLine(FileExtractor.GetFileExtension("example.new.pdf"));

            try
            {
                Console.WriteLine(FileExtractor.GetFileNameWithoutExtension("example"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine(FileExtractor.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(FileExtractor.GetFileNameWithoutExtension("example.new.pdf"));

            Console.WriteLine("Distance in the 2D space = {0:f2}",
                Geometry2D.CalcDistance(1, -2, 3, 4));
            Console.WriteLine("Distance in the 3D space = {0:f2}",
                Geometry3D.CalcDistance(5, 2, -1, 3, -6, 4));

            int cuboidWidth = 3;
            int cuboidHeight = 4;
            int cuboidDepth = 5;
            Console.WriteLine("Volume = {0:f2}", Geometry3D.CalcVolume(cuboidWidth,cuboidHeight,cuboidDepth));
            Console.WriteLine("Diagonal XYZ = {0:f2}", Geometry3D.CalcDiagonalXYZ(cuboidWidth, cuboidHeight, cuboidDepth));
            Console.WriteLine("Diagonal XY = {0:f2}", Geometry2D.CalcCuboidDiagonalXY(cuboidWidth, cuboidHeight));
            Console.WriteLine("Diagonal XZ = {0:f2}", Geometry2D.CalcCuboidDiagonalXZ(cuboidWidth, cuboidDepth));
            Console.WriteLine("Diagonal YZ = {0:f2}", Geometry2D.CalcCuboidDiagonalYZ(cuboidHeight, cuboidDepth));
        }
    }
}
