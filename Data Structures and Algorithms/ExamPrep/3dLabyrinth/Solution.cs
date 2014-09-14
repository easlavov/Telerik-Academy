using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Solution
{
    static const char PASSABLE = '.';
    static const char IMPASSABLE = '#';
    static const char LADDER_UP = 'U';
    static const char LADDER_DOWN = 'D';

    static void Main()
    {
        string[] startingPosition = Console.ReadLine().Split(' ');
        int x = int.Parse(startingPosition[0]);
        int y = int.Parse(startingPosition[1]);
        int z = int.Parse(startingPosition[2]);

        string[] dimensions = Console.ReadLine().Split(' ');
        int l = int.Parse(dimensions[0]);
        int r = int.Parse(dimensions[1]);
        int c = int.Parse(dimensions[2]);

        char[, ,] labyrinth = FillLabyrinth(l, r, c);
        int shortestPathOut = CalcShortestPath(labyrinth, x, y, z);
    }

    private static int CalcShortestPath(char[, ,] labyrinth, int x, int y, int z)
    {
        var queue = new Queue<Cell>();
        Traverse(labyrinth, x, y, z, queue);
    }

    private static void Traverse(char[, ,] labyrinth, int l, int r, int c, Queue<Cell> queue)
    {
        queue.Enqueue(new Cell(l, r, c));

        // Left
        

        // Deeper


        // Right


        // Nearer


        // Upper


        // Bottom
        
    }



    class Cell
    {
        public Cell(int l, int r, int c)
        {
            this.L = l;
            this.R = r;
            this.C = c;
        }

        public int L { get; set; }

        public int R { get; set; }

        public int C { get; set; }
    }

    private static char[, ,] FillLabyrinth(int l, int r, int c)
    {
        char[, ,] labyrinth = new char[l, r, c];
        for (int level = 0; level < l; level++)
        {
            for (int row = 0; row < r; row++)
            {
                string columns = Console.ReadLine();
                for (int col = 0; col < c; col++)
                {
                    labyrinth[level, row, col] = columns[col];
                }
            }
        }

        return labyrinth;
    }
}