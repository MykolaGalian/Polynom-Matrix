using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1_Polynom
{
    public class Polynom
    {
        //массив коэффициентов полинома
        double[] ArrCoef;

        public Polynom(double[] arr)
        {            
            ArrCoef = arr;
        }

        public static Polynom operator +(Polynom A, Polynom B)
        {
            int maxItem = Math.Max(A.ArrCoef.Length, B.ArrCoef.Length);

            double[] arrC = new double[maxItem];


            for (int i = 0; i < maxItem; i++)
            {
                double a = 0, b = 0;
                if (i < A.ArrCoef.Length) { a = A[i]; }
                if (i < B.ArrCoef.Length) { b = B[i]; }

                arrC[i] = a + b;
            }
            return new Polynom(arrC);
        }
        public static Polynom operator -(Polynom A, Polynom B)
        {
            int maxItem = Math.Max(A.ArrCoef.Length, B.ArrCoef.Length);

            double[] arrC = new double[maxItem];


            for (int i = 0; i < maxItem; i++)
            {
                double a = 0, b = 0;
                if (i < A.ArrCoef.Length) { a = A[i]; }
                if (i < B.ArrCoef.Length) { b = B[i]; }

                arrC[i] = a - b;
            }
            return new Polynom(arrC);
        }
        public static Polynom operator *(Polynom A, Polynom B)
        {
            int maxItem = A.ArrCoef.Length + B.ArrCoef.Length - 1;

            double[] arrC = new double[maxItem];


            for (int i = 0; i < A.ArrCoef.Length; i++)
            {
                for (int j = 0; j < B.ArrCoef.Length; j++)
                {
                    arrC[i + j] += A[i] * B[j];
                }
            }
            return new Polynom(arrC);
        }

        //вывод полинома
        public static void PrintPolynom(Polynom A)
        {
            for (int i = 0; i <= A.ArrCoef.Length - 1; i++)
            {
                Console.Write(A.ArrCoef[i] + "X" + "^" + (A.ArrCoef.Length - 1 - i) + " + ");
            }
            Console.WriteLine(0 + "\n");
        }

        public double this[int i]
        {           

            get
            {
                if (i <= 0 || i > this.ArrCoef.Length-1) throw new Exception("Wrong index");
                return ArrCoef[i];
            }
            set
            {
                if (i <= 0 || i > this.ArrCoef.Length-1) throw new Exception("Wrong index");
                ArrCoef[i] = value;
            }
        }

        //вывод степени полинома
        public static void DegPolynom(Polynom A)
        {
            Console.WriteLine("Степень полинома " + (A.ArrCoef.Length - 1) + "\n");
        }
    }
}
