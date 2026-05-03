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
            _values = values;

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
                    return this._values[r, c];
                else
                    Console.WriteLine("Проблемы с диапазоном! -1");
                return -1;
            }
            set
            {
                if (r >= 0 && r < Rows && c >= 0 && c < Cols)
                    this._values[r, c] = value;
                else
                    Console.WriteLine("Проблемы с диапазоном!");
            }
        }
        public void Print()
        {
            for (int i = 0; i < this.Rows; i++)
            {
                for(int j = 0; j < this.Cols; j++)
                {
                    Console.Write($"{this[i,j]} ");
                }
                Console.WriteLine();
            }
        }
        // матрица на матрицу
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

            for(int i = 0; i < leastRows; i++)
            {
                for(int j = 0; j < leastCols; j++)
                {
                    temp[i, j] = AnsForIndex(i, j, left, right);
                }
            }

            return new Matrix(temp, leastRows, leastCols);
        }

        public static Matrix operator *(Matrix left, double right)
        {
            double[,] temp;
            temp = new double[left.Rows, left.Cols];

            for(int i = 0; i < left.Rows; i++)
            {
                for(int j = 0; j < left.Cols; j++)
                {
                    temp[i, j] = left[i, j] * right;
                }
            }

            return new Matrix(temp, left.Rows, left.Cols);
        }


        public static Matrix operator +(Matrix left, Matrix right)
        {
            double[,] temp;
            if (left.Rows != right.Rows || left.Cols != right.Cols)
            {
                temp = new double[1, 1] { { -1 } };
                return new Matrix(temp, 1, 1);
            }

            temp = new double[left.Rows, right.Cols];

            for(int i = 0; i < left.Rows; i++)
            {
                for(int j = 0; j < left.Cols; j++)
                {
                    temp[i,j] = left[i,j] + right[i,j];
                }    
            }

            return new Matrix(temp, left.Rows, left.Cols);
        }

        public static Matrix operator +(Matrix left, double right)
        {
            double[,] temp;
            temp = new double[left.Rows, left.Cols];

            for (int i = 0; i < left.Rows; i++)
            {
                for (int j = 0; j < left.Cols; j++)
                {
                    temp[i, j] = left[i, j] + right;
                }
            }

            return new Matrix(temp, left.Rows, left.Cols);
        }

        public static Matrix operator -(Matrix left, Matrix right)
        {
            double[,] temp;
            if (left.Rows != right.Rows || left.Cols != right.Cols)
            {
                temp = new double[1, 1] { { -1 } };
                return new Matrix(temp, 1, 1);
            }

            temp = new double[left.Rows, right.Cols];

            for (int i = 0; i < left.Rows; i++)
            {
                for (int j = 0; j < left.Cols; j++)
                {
                    temp[i, j] = left[i, j] - right[i, j];
                }
            }

            return new Matrix(temp, left.Rows, left.Cols);
        }
        public static Matrix operator -(Matrix left, double right)
        {
            double[,] temp;
            temp = new double[left.Rows, left.Cols];

            for (int i = 0; i < left.Rows; i++)
            {
                for (int j = 0; j < left.Cols; j++)
                {
                    temp[i, j] = left[i, j] - right;
                }
            }

            return new Matrix(temp, left.Rows, left.Cols);
        }

        public static bool operator <(Matrix left, Matrix right)
        {
            double sum1 = 0, sum2 = 0;
            for(int i = 0;i < left.Rows;i++)
            {
                for(int j = 0;j < left.Cols;j++)
                {
                    sum1 += left[i, j];
                }
            }
            for (int i = 0; i < right.Rows; i++)
            {
                for (int j = 0; j < right.Cols; j++)
                {
                    sum2 += right[i, j];
                }
            }

            return sum1 < sum2;
        }

        public static bool operator >(Matrix left, Matrix right)
        {
            double sum1 = 0, sum2 = 0;
            for (int i = 0; i < left.Rows; i++)
            {
                for (int j = 0; j < left.Cols; j++)
                {
                    sum1 += left[i, j];
                }
            }
            for (int i = 0; i < right.Rows; i++)
            {
                for (int j = 0; j < right.Cols; j++)
                {
                    sum2 += right[i, j];
                }
            }

            return sum1 > sum2;
        }

        public static bool operator ==(Matrix left, Matrix right)
        {
            double sum1 = 0, sum2 = 0;
            for (int i = 0; i < left.Rows; i++)
            {
                for (int j = 0; j < left.Cols; j++)
                {
                    sum1 += left[i, j];
                }
            }
            for (int i = 0; i < right.Rows; i++)
            {
                for (int j = 0; j < right.Cols; j++)
                {
                    sum2 += right[i, j];
                }
            }

            return sum1 == sum2;
        }

        public static bool operator !=(Matrix left, Matrix right)
        {
            double sum1 = 0, sum2 = 0;
            for (int i = 0; i < left.Rows; i++)
            {
                for (int j = 0; j < left.Cols; j++)
                {
                    sum1 += left[i, j];
                }
            }
            for (int i = 0; i < right.Rows; i++)
            {
                for (int j = 0; j < right.Cols; j++)
                {
                    sum2 += right[i, j];
                }
            }

            return sum1 != sum2;
        }

        private static double AnsForIndex(int index, int jndex, Matrix a, Matrix b)
        {

            double num = 0;

            for(int i = 0, j = 0; i < a.Cols || j < b.Rows; i++, j++)
            {

                if(i == 0)
                {
                    num += a[index, i] * b[j, jndex];
                    //Console.Write(index + " " + jndex + " = " + a[index, i] + " * " + b[j, jndex] + " ");
                }
                else
                {
                    num += a[index, i] * b[j, jndex];
                    //Console.Write(a[index, i] + " * " + b[j, jndex] + "\n");
                }
                
            }
            //Console.WriteLine();

            return num;

        }

        
    }
}
