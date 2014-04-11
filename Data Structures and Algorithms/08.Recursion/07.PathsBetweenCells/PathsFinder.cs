using System;
using System.Collections.Generic;

public class PathsFinder
{
    public class Cell
    {
        public int CellRow { get; private set; }
        public int CellCol { get; private set; }

        public Cell(int row, int col, char[,] matrix)
        {
            if (row < 0 || row >= matrix.GetLength(0))
            {
                throw new ArgumentOutOfRangeException();
            }
            if (col < 0 || col >= matrix.GetLength(1))
            {
                throw new ArgumentOutOfRangeException();
            }
            this.CellRow = row;
            this.CellCol = col;
        }

        public override string ToString()
        {
            return string.Format("{0},{1}", this.CellRow, this.CellCol);
        }
    }

    static private char impassableCell;
    static private List<Cell[]> paths;
    static private char[,] matrix;
    static private Stack<Cell> path;
    static private bool[,] visited;

    public static List<Cell[]> FindPaths(char[,] grid, char impassable, Cell start, Cell end)
    {
        matrix = grid;
        paths = new List<Cell[]>();
        impassableCell = impassable;
        visited = new bool[grid.GetLength(0), grid.GetLength(1)];
        path = new Stack<Cell>();
        Traverse(start, end);
        return paths;
    }

    private static void Traverse(Cell current, Cell targetCell)
    {
        path.Push(current);        
        if (current.CellCol == targetCell.CellCol && current.CellRow == targetCell.CellRow)
        {
            Cell[] temp = path.ToArray();
            paths.Add(temp);
            path.Pop(); 
            return;
        }
        if (matrix[current.CellRow, current.CellCol] == impassableCell)
        {
            path.Pop();
            return;
        }
        visited[current.CellRow, current.CellCol] = true;        

        // left
        try
        {
            Cell next = new Cell(current.CellRow, current.CellCol - 1, matrix);
            if (!visited[next.CellRow, next.CellCol])
            {
                Traverse(next, targetCell);
            }
        }
        catch (ArgumentOutOfRangeException)
        {            
            
        }

        // right
        try
        {
            Cell next = new Cell(current.CellRow, current.CellCol + 1, matrix);
            if (!visited[next.CellRow, next.CellCol])
            {
                Traverse(next, targetCell);
            }
        }
        catch (ArgumentOutOfRangeException)
        {

        }

        // up
        try
        {
            Cell next = new Cell(current.CellRow - 1, current.CellCol, matrix);
            if (!visited[next.CellRow, next.CellCol] == true)
            {
                Traverse(next, targetCell);
            }
        }
        catch (ArgumentOutOfRangeException)
        {

        }

        // down
        try
        {
            Cell next = new Cell(current.CellRow + 1, current.CellCol, matrix);
            if (!visited[next.CellRow, next.CellCol] == true)
            {
                Traverse(next, targetCell);
            }
        }
        catch (ArgumentOutOfRangeException)
        {

        }

        visited[current.CellRow, current.CellCol] = false;
    }
}