using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDZ5
{
    public class Matrix
    {
        private double[,] _values;

        private int _grade;

        public int Grade
        {
            get {  return _grade; }
        }
        public int Rows { get; }
        public int Cols { get; }

        public Matrix(double[,] values, int rows, int cols)
        {
            values = new double[rows, cols];

            Rows = rows; 
            Cols = cols;

            if(rows == cols)
            {
                _grade = cols;
            }
            else if(rows > cols)
            {
                _grade = cols;
            }
            else
            {
                _grade = rows;
            }
        }

        public double this[int r, int c]
        {
            get
            {
                if (r >= 0 && r < Rows && c >= 0 && c < Cols)
                    return _values[r, c];
                else
                    Console.WriteLine("Проблемы с диапазоном! -1");
                return -1;
            }
            set
            {
                if (r >= 0 && r < Rows && c >= 0 && c < Cols)
                    _values[r, c] = value;
                else
                    Console.WriteLine("Проблемы с диапазоном!");
            }
        }

        public static Matrix operator *(Matrix left, Matrix right)
        {
            int leastRows, leastCols;
            double[,] temp;
            if(left.Cols != right.Rows)
            {
                temp = new double[1, 1] { { -1 } };
                return new Matrix(temp, 1, 1);
            }
            if(left.Rows > right.Rows)
            {
                leastRows = right.Rows;
            }
            else
            {
                leastRows= left.Rows;
            }

            if(right.Cols > left.Cols)
            {
                leastCols = left.Cols;
            }
            else
            {
                leastCols = right.Cols;
            }

            temp = new double[leastRows, leastCols];

            double num;

            for(int i = 0; i < leastRows; i++)
            {
                for(int j = 0; j < leastCols; j++)
                {
                    for (int k = 0; k < leastRows; k++)
                    {
                        for(int l = 0; l < leastCols; l++)
                        {
                            num += left[k, l] * right[k, l];
                        }
                    }
                }
            }

        }
    }
}
