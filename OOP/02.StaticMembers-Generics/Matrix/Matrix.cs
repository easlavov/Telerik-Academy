using System;
using System.Text;

namespace Matrix
{
    public class Matrix<T> where T : IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T> // constraining to numbers only
    {
        // Fields
        private T[][] matrix;
        private readonly int rows;
        private readonly int columns;

        // Constructors
        public Matrix(int rows, int columns)
        {
            this.Arrays = new T[rows][];
            for (int i = 0; i < rows; i++)
            {
                this.Arrays[i] = new T[columns];
            }
            this.rows = rows;
            this.columns = columns;
        }

        // Properties
        private T[][] Arrays
        {
            get { return this.matrix; }
            set { this.matrix = value; }
        }

        // Indexator
        public T this[int row, int column]
        {
            get { return this.Arrays[row][column]; }
            set { this.Arrays[row][column] = value; }
        }

        // Returns number of rows
        public int Rows
        {
            get { return this.rows; }
        }

        // Returns number of columns
        public int Columns
        {
            get { return this.columns; }

        }

        // Overrides
        public static Matrix<T> operator +(Matrix<T> m1, Matrix<T> m2)
        {
            if (m1.Rows != m2.Rows || m1.Columns != m2.Columns)
            {
                throw new ArgumentException("Matrices must be of the same size.");
            }
            Matrix<T> result = new Matrix<T>(m1.Rows, m1.Columns);
            for (int row = 0; row < m1.Rows; row++)
            {
                for (int columns = 0; columns < m1.Columns; columns++)
                {
                    result[row, columns] = (dynamic)m1[row, columns] + m2[row, columns];
                }
            }
            return result;
        }

        public static Matrix<T> operator -(Matrix<T> m1, Matrix<T> m2)
        {
            if (m1.Rows != m2.Rows || m1.Columns != m2.Columns)
            {
                throw new ArgumentException("Matrices must be of the same size.");
            }
            Matrix<T> result = new Matrix<T>(m1.Rows, m1.Columns);
            for (int row = 0; row < m1.Rows; row++)
            {
                for (int columns = 0; columns < m1.Columns; columns++)
                {
                    result[row, columns] = (dynamic)m1[row, columns] - m2[row, columns];
                }
            }
            return result;
        }

        public static Matrix<T> operator *(Matrix<T> m1, Matrix<T> m2)
        {
            if (m1.Rows != m2.Rows || m1.Columns != m2.Columns)
            {
                throw new ArgumentException("Matrices must be of the same size.");
            }
            Matrix<T> result = new Matrix<T>(m1.Rows, m1.Columns);
            for (int row = 0; row < m1.Rows; row++)
            {
                for (int columns = 0; columns < m1.Columns; columns++)
                {
                    result[row, columns] = (dynamic)m1[row, columns] * m2[row, columns];
                }
            }
            return result;
        }

        public static bool operator true(Matrix<T> matrix)
        {
            for (int rows = 0; rows < matrix.Rows; rows++)
            {
                for (int columns = 0; columns < matrix.Columns; columns++)
                {
                    if (matrix[rows, columns] == (dynamic)default(T))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool operator false(Matrix<T> matrix)
        {
            for (int rows = 0; rows < matrix.Rows; rows++)
            {
                for (int columns = 0; columns < matrix.Columns; columns++)
                {
                    if (matrix[rows, columns] != (dynamic)default(T))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            for (int row = 0; row < this.Arrays.Length; row++)
            {
                for (int coloumn = 0; coloumn < this.Arrays[row].Length; coloumn++)
                {
                    builder.Append(this.Arrays[row][coloumn]);
                    builder.Append(' ');
                }
                builder.Append(Environment.NewLine);
            }
            return builder.ToString().TrimEnd();
        }
    }
}
