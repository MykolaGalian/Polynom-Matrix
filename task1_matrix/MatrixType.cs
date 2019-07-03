using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1_matrix
{
    public class MatrixType
    {
        float[,] mat;

       
        public int Column { get; set; }
        public int Row { get; set; }


        
        public MatrixType(int n)
        {
            if (n <= 0) throw new NegativeDimensionsArgMatrix("Negative matrix dimensions arg");
            mat = new float[n, n];
            Row = Column = n;
        }

        public MatrixType(int n, int m)
        {
            if (n <= 0 || m <= 0) throw new NegativeDimensionsArgMatrix("Negative matrix dimensions arg");

            mat = new float[n, m];
            Row = n;
            Column = m;
        }

        // индексатор
        public float this[int i, int j]
        {
            get { return mat[i, j]; }
            set { mat[i, j] = value; }
        }

        //перегружаем оператор для сложение матриц
        public static MatrixType operator +(MatrixType first, MatrixType second)
        {

            if (first.Row != second.Row || first.Column != second.Column) throw new MatrixDimensionExeption("Matrices with diferent dimension");


            MatrixType mat = new MatrixType(first.Row, first.Column);

            for (int i = 0; i < first.Row; i++)
                for (int j = 0; j < first.Column; j++)
                    mat[i, j] = first[i, j] + second[i, j];
            return mat;
        }

        //перегружаем оператор для вычитание матриц
        public static MatrixType operator -(MatrixType first, MatrixType second)
        {
            if (first.Row != second.Row || first.Column != second.Column) throw new MatrixDimensionExeption("Matrices with diferent dimension");


            MatrixType mat = new MatrixType(first.Row, first.Column);

            for (int i = 0; i < first.Row; i++)
                for (int j = 0; j < first.Column; j++)
                    mat[i, j] = first[i, j] - second[i, j];
            return mat;
        }

        //перегружаем оператор для произведения матриц
        public static MatrixType operator *(MatrixType first, MatrixType second)
        {
            if (first.Row != second.Row || first.Column != second.Column) throw new MatrixDimensionExeption("Matrices with diferent dimension");


            MatrixType mat = new MatrixType(first.Row, first.Column);

            for (int i = 0; i < first.Row; i++)
            {
                for (int j = 0; j < second.Column; j++)
                {
                    float sum = 0;
                    for (int r = 0; r < second.Row; r++)
                        sum += first[i, r] * second[r, j];
                    mat[i, j] = sum;
                }
            }
            return mat;
        }


        //перегружаем оператор  ==
        public static bool operator ==(MatrixType first, MatrixType second)
        {
            if (first.Row != second.Row || first.Column != second.Column) throw new MatrixDimensionExeption("Matrices with diferent dimension");


            MatrixType mat = new MatrixType(first.Row, first.Column);

            for (int i = 0; i < first.Row; i++)
                for (int j = 0; j < first.Row; j++)
                {
                    if (first[i, j] != second[i, j]) return false;
                }

            return true;
        }

        //перегружаем оператор  !=
        public static bool operator !=(MatrixType first, MatrixType second)
        {
            if (first.Row != second.Row || first.Column != second.Column) throw new MatrixDimensionExeption("Matrices with diferent dimension");


            MatrixType mat = new MatrixType(first.Row, first.Column);

            for (int i = 0; i < first.Row; i++)
                for (int j = 0; j < first.Row; j++)
                {
                    if (first[i, j] == second[i, j]) return false;
                }
            return true;
        }

        public override int GetHashCode()
        {
            return (int)this.mat[0, 0] ^ (int)this.mat[0, 1];
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || this.GetType().Equals(obj.GetType())) return false;
            else
            {

                MatrixType m = (MatrixType)obj;


                if (m.Row != this.Row || m.Column != this.Column) throw new MatrixDimensionExeption("Matrices with diferent dimension");


                MatrixType mat = new MatrixType(m.Row, m.Column);

                for (int i = 0; i < m.Row; i++)
                    for (int j = 0; j < m.Row; j++)
                    {
                        if (this[i, j] != m[i, j]) return false;
                    }

                return true;
            }
        }

        public MatrixType CopyMatrix(MatrixType m)
        {
            MatrixType newMat = new MatrixType(m.Row, m.Column);

            for (int i = 0; i < m.Row; i++)
                for (int j = 0; j < m.Column; j++)
                    newMat[i, j] = m[i, j];

            return newMat;
        }
    }
}

