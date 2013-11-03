using System;
using System.IO;

namespace ThreeDimensionalSpace
{
    public static class PathStorage
    {
        // Save path to text file
        public static void SavePath(Path pathArray)
        {
            SavePath(pathArray, null);
        }

        public static void SavePath(Path pathArray, string filePath)
        {
            if (filePath == null)
            {
                filePath = "../../PathStorage.txt"; // Project directory 
            }
            try
            {
                StreamWriter writer = new StreamWriter(filePath);
                using (writer)
                {
                    foreach (var point in pathArray.Points)
                    {
                        writer.WriteLine(point);
                    }
                }
            }
            catch (IOException)
            {
                throw new IOException("An error has occured while trying to save the path.");
            }
        }

        // Load path from text file        
        public static Path LoadPath(string filePath)
        {            
            if (filePath == null)
            {
                filePath = "../../PathStorage.txt";
            }
            try
            {
                StreamReader reader = new StreamReader(filePath);
                Path path = new Path();
                using (reader)
                {                    
                    string line = reader.ReadLine();
                    while (line != null)
                    {
                        string[] coords = line.Split(',');
                        int x = int.Parse(coords[0]);
                        int y = int.Parse(coords[1]);
                        int z = int.Parse(coords[2]);
                        path.AddPoint(new Point3D(x, y, z));
                        line = reader.ReadLine();
                    }
                }
                return path;
            }
            catch (IOException)
            {
                throw new IOException("An error has occured while trying to load the path.");
            }
        }
    }
}
