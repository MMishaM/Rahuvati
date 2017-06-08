using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rahuvati
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] x = new double[] { 1.5, 1.95, 2.4, 2.85, 3.3 };
            double[] y = new double[] { 73, 6, 115, 48, 81 };
            double[] b0 = new double[3];
            double[] di = new double[5];
            double[] bi = new double[5];
            double[] am = new double[4];
            double[] ci = new double[4];



            double[,] A = new double[3, 3];
            A[0, 0] = 4; A[0, 1] = 1; A[0, 2] = 0;
            A[1, 0] = 1; A[1, 1] = 4; A[1, 2] = 1;
            A[2, 0] = 0; A[2, 1] = 1; A[2, 2] = 4;

            //обратная матрица СмОбратная
            double[,] AInverse = new double[3, 3];
            double[,] ACopy = new double[3, 3];


            //задаем обратную матрицу как единичную           
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (i == j) { AInverse[i, j] = 1; }
                    else { AInverse[i, j] = 0; }
                    ACopy[i, j] = A[i, j];    //создаем копию матрицы См
                }
            }
            Console.WriteLine("ACopy");
            print(ACopy);
         

          

            //прямой ход
            for (int k = 0; k < 3; ++k)
            {
                double div = ACopy[k, k];
                for (int m = 0; m < 3; ++m)
                {// делим строку на выбранный элемент === 1  ф  ф
                    ACopy[k, m] /= div;
                    AInverse[k, m] /= div;
                }
                for (int i = k + 1; i < 3; ++i) //идем по столбц ниже полученой единицы
                {
                    double multi = ACopy[i, k]; //элемент, который хотим занулить
                    for (int j = 0; j < 3; ++j)// элемент по счету в строке i
                    {
                        ACopy[i, j] -= multi * ACopy[k, j];
                        AInverse[i, j] -= multi * AInverse[k, j];
                    }
                }

            }

         

            //обратный ход            
            for (int kk = 3 - 1; kk > 0; kk--)
            {
                ACopy[kk, 3 - 1] /= ACopy[kk, kk];
                AInverse[kk, 3 - 1] /= ACopy[kk, kk];

                for (int i = kk - 1; i + 1 > 0; i--)
                {
                    double multi2 = ACopy[i, kk];
                    for (int j = 0; j < 3; j++)
                    {
                        ACopy[i, j] -= multi2 * ACopy[kk, j];
                        AInverse[i, j] -= multi2 * AInverse[kk, j];
                    }
                }
            }

           

            Console.WriteLine("A^-1");
            print(AInverse);
          

          /*  Console.WriteLine("проверка матрицы Copy");
            double[,] Ee = new double[3, 3];
            int flagA = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (i == j) { Ee[i, j] = 1; }
                    else { Ee[i, j] = 0; }
                    if (Ee[i, j] != ACopy[i, j]) { Console.WriteLine("i=" + i); Console.WriteLine("ошибка! матрица не единичная!"); }
                    else { flagA = 1; }
                }
            }
            if (flagA == 1) { Console.WriteLine("матрица Copy стала единичной"); }
          

            //проверка СмОбратной
            //CmObrat*Cm
            double[,] ProverkaA = new double[3, 3];
            for (int i = 0; i < 3; i++)//строки
            {
                for (int j = 0; j < 3; j++)//столбцы
                {
                    for (int k = 0; k < 3; k++)
                    {
                        ProverkaA[i, j] += AObrat[i, k] * A[k, j];
                    }
                }
            }

            Console.WriteLine("проверка матрицы Proverka");
            int flag11 = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (Math.Abs(Ee[i, j] - ProverkaA[i, j]) > 0.002) { Console.WriteLine("ошибка! матрица не единичная!"); }
                    else { flag11 = 1; }
                }
            }
            if (flag11 == 1) { Console.WriteLine("матрица стала единичной"); }*/



            double a = x[0];
            double b = x[4];
            double h = (b - a) / 4;
            double h1 = (b - a) / 20;

            Console.WriteLine(" B0  ");
            for (int i = 0; i <= 2; i++)
            {
                b0[i] = 3 * (y[i + 2] - 2 * y[i + 1] + y[i]);
                Console.Write(b0[i] + " ");

            }
            Console.WriteLine();

            Console.WriteLine("di");
            for (int i =0; i < 5; i++)
            {
                di[i] = y[i];
                            
                Console.Write(di[i]  + " ");
            }


             Console.WriteLine("B");
             bi[0] = 0;
             bi[1] = AInverse[0, 0] * b0[0] + AInverse[0, 1] * b0[1] + AInverse[0, 2] * b0[2];
             bi[2] += AInverse[1, 0] * b0[0] + AInverse[1, 1] * b0[1] + AInverse[1, 2] * b0[2];
             bi[3] += AInverse[2, 0] * b0[0] + AInverse[2, 1] * b0[1] + AInverse[2, 2] * b0[2];
             bi[4] = 0;
             for (int i = 0; i <= 3; i++)
             {
                 Console.Write(bi[i] + "  ");
             }




            Console.WriteLine();
            Console.WriteLine("A ");
            for (int i = 0; i <= 3; i++)
            {
                am[i] = (bi[i + 1] - bi[i]) / 3;

                Console.Write(am[i] + "  ");
            }




            Console.WriteLine();
            Console.WriteLine("C ");

            for (int i = 0; i <= 3; i++)
            {
                ci[i] = (di[i + 1] - di[i]) - bi[i] - am[i];
                Console.Write(ci[i] + "  ");
            }


            /* Console.WriteLine("B");



             for (var i = 0; i < 5; i++)
             {
                 if (i == 0)
                 {
                     bi[i] = 0;
                 }
                 else
                 {

                     bi = multiply(AInverse, b0);
                 }
                     Console.Write(bi[i-1] + " ");


             }*/



            Console.ReadLine();
        }



        static double[] multiply(double[,] matrix, double[] vector)
        {
            double[] result = new double[5];
            for (int i = 0; i < 3; i++)
            {
               

                result[i] = 0;
                for (int j = 0; j < 3; j++)
                {
                   
                                       

                        result[i] += vector[j] * matrix[i, j];
                    
                    
                }
            }

            return result;
            
        }

        



        static void print(double[,] m)
        {
            Console.WriteLine();
            for (var i = 0; i < m.GetLength(0); ++i)
            {
                for (var j = 0; j < m.GetLength(1); ++j)
                {
                    Console.Write("{0:0.00}\t", m[i, j]);
                }
                Console.WriteLine();
            }
        }


    }
}
