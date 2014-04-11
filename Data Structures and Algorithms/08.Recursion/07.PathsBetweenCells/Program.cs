using System;

class Program
{
    static void Main(string[] args)
    {
        char[,] matrix =
        {
            { ' ', ' ',' ', ' ',' ',},
            { ' ', '*',' ', ' ',' ',},
            { ' ', '*','*', ' ',' ',},
            { ' ', '*',' ', ' ',' ',},
        };

        var paths = PathsFinder.FindPaths(matrix, '*', new PathsFinder.Cell(3, 0, matrix), new PathsFinder.Cell(0,3,matrix));

        Console.WriteLine(paths.Count);
    }
}