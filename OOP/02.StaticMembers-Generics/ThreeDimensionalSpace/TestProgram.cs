using System;
using System.Linq;

namespace ThreeDimensionalSpace
{
    class TestProgram
    {
        static void Main()
        {
            // Explanation
            Console.WriteLine("Hello! This program tests the functionality of the ThreeDimensionalSpace project. It will run a few tests to determine if the code has been written correctly. Enjoy!");
            Console.WriteLine();

            // Testing PointZero property
            Console.WriteLine("Testing PointZero property:");
            Console.WriteLine(Point3D.PointZero);
            Console.WriteLine();

            // Testing calculation of distance between two points in 3D space
            Console.WriteLine("Testing calculation of distance between two points in 3D space:");
            Console.WriteLine(CalcDistance.Calculate(new Point3D(1, -3, 6), new Point3D(2, 5, -15)));
            Console.WriteLine();

            // Testing Path class
            Console.WriteLine("Testing Path class. Creating new instance of the Path class and adding three points with different coordinates to it.");
            Path testPath = new Path();
            testPath.AddPoint(new Point3D(15, 3, 6));
            testPath.AddPoint(new Point3D(-5, 6, 15));
            testPath.AddPoint(new Point3D(3, 4, 200));
            Console.WriteLine("This is the path contained in the test instance of the Path class:");
            foreach (var point in testPath.Points)
            {
                Console.WriteLine(point);
            }
            Console.WriteLine();

            // Testing path saving method of the PathStorage class
            Console.WriteLine("Testing the path saving method of the PathStorage class:");
            PathStorage.SavePath(testPath);
            Console.WriteLine("Save successful. Look for PathStorage.txt in the project directory.");
            Console.WriteLine();

            // Testing path loading method of the PathStorage class
            Console.WriteLine("Testing the path loading method of the PathStorage class:");
            Path loadedPath = PathStorage.LoadPath(null);
            Console.WriteLine("This is the loaded path:");
            foreach (var point in loadedPath.Points)
            {
                Console.WriteLine(point);
            }
            Console.WriteLine();
            Console.WriteLine("The test of the ThreeDimensionalSpace project has been completed successfully! Have a nice day!");
        }
    }
}
