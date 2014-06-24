namespace MatrixWalk
{
    using System;
    using System.Text;

    public class Matrix
    {
        private const int MIN_SIZE = 1;
        private const int MAX_SIZE = 100;
        private const int DIRECTIONS_COUNT = 8;
        private int size = 3;
        private int[,] matrix;
        private int row = 0;
        private int col = 0;

        public Matrix(int dimentions)
        {
            this.Size = dimentions;

            this.matrix = new int[this.size, this.size];

            this.FindAvailableCell();
            this.FillAvailableCells();
        }

        public int Size
        {
            get
            {
                return this.size;
            }

            set
            {
                if (value < MIN_SIZE || MAX_SIZE < value)
                {
                    string message = string.Format("Matrix size must be a value between {0} and {1}",
                                                    MIN_SIZE,
                                                    MAX_SIZE);

                    throw new ArgumentOutOfRangeException(message);
                }

                this.size = value;
            }
        }

        private void GetDirection(ref int dirRow, ref int dirCol)
        {
            int[] directionRow = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] directionCol = { 1, 0, -1, -1, -1, 0, 1, 1 };

            int currentDir = 0;

            for (int dirIndex = 0; dirIndex < DIRECTIONS_COUNT; dirIndex++)
            {
                if (directionRow[dirIndex] == dirRow && directionCol[dirIndex] == dirCol)
                {
                    currentDir = dirIndex;
                    break;
                }
            }

            if (currentDir == DIRECTIONS_COUNT - 1)
            {
                dirRow = directionRow[0];
                dirCol = directionCol[0];
                return;
            }

            dirRow = directionRow[currentDir + 1];
            dirCol = directionCol[currentDir + 1];
        }

        private bool IsCellAvailable(int row, int col)
        {
            int[] directionRow = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] directionCol = { 1, 0, -1, -1, -1, 0, 1, 1 };

            for (int dirIndex = 0; dirIndex < DIRECTIONS_COUNT; dirIndex++)
            {
                int nextRow = row + directionRow[dirIndex];

                if (!this.IsInRange(nextRow))
                {
                    directionRow[dirIndex] = 0;
                }

                int nextCol = col + directionCol[dirIndex];

                if (!this.IsInRange(nextCol))
                {
                    directionCol[dirIndex] = 0;
                }
            }

            return this.IsNextCellEmpty(row, col, directionRow, directionCol);
        }

        private void FindAvailableCell()
        {
            this.row = 0;
            this.col = 0;

            for (int currRow = 0; currRow < this.size; currRow++)
            {
                for (int currCol = 0; currCol < this.size; currCol++)
                {
                    if (this.matrix[currRow, currCol] == 0)
                    {
                        this.row = currRow;
                        this.col = currCol;
                        return;
                    }
                }
            }
        }

        private void FillAvailableCells()
        {
            int directionRow = 1;
            int directionCol = 1;
            int number = 1;

            while (true)
            {
                this.matrix[this.row, this.col] = number;

                if (!this.IsCellAvailable(this.row, this.col))
                {
                    this.FindAvailableCell();
                    if (this.IsCellAvailable(this.row, this.col))
                    {
                        number++;
                        this.matrix[this.row, this.col] = number;
                        directionRow = 1;
                        directionCol = 1;
                    }
                    else
                    {
                        break;
                    }
                }

                int nextRow = this.row + directionRow;
                int nextCol = this.col + directionCol;

                if (!this.IsInRange(nextRow) || 
                    !this.IsInRange(nextCol) ||
                    this.matrix[nextRow, nextCol] != 0)
                {
                    while (!this.IsInRange(nextRow) || !this.IsInRange(nextCol) || this.matrix[nextRow, nextCol] != 0)
                    {
                        this.GetDirection(ref directionRow, ref directionCol);

                        nextRow = this.row + directionRow;
                        nextCol = this.col + directionCol;
                    }
                }

                this.row = nextRow;
                this.col = nextCol;
                number++;
            }
        }

        public override string ToString()
        {
            StringBuilder matrixAsStirng = new StringBuilder();

            for (int row = 0; row < this.size; row++)
            {
                for (int col = 0; col < this.size; col++)
                {
                    matrixAsStirng.AppendFormat("{0,4}", this.matrix[row, col]);
                }

                matrixAsStirng.Append("\r\n");
            }

            return matrixAsStirng.ToString();
        }

        private bool IsNextCellEmpty(int row, int col, int[] directionRow, int[] directionCol)
        {
            for (int dirIndex = 0; dirIndex < DIRECTIONS_COUNT; dirIndex++)
            {
                int nextRow = row + directionRow[dirIndex];
                int nextCol = col + directionCol[dirIndex];

                if (this.matrix[nextRow, nextCol] == 0)
                {
                    return true;
                }
            }

            return false;
        }

        private bool IsInRange(int value)
        {
            if (value < 0 || this.size <= value)
            {
                return false;
            }

            return true;
        }
    }
}
