using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

   // 1. Даны 2 двумерных матрицы.Размерность 100х100 каждая. Напишите приложение, производящее параллельное умножение матриц. Матрицы заполняются случайными целыми числами от 0 до10

namespace MailSender.ConsoleTest
{
    static class Lesson6
    {
        public static async void Start()
        {
            //Console.WriteLine("Введите размерность первой матрицы: ");
            //int[,] A = new int[Convert.ToInt32(Console.ReadLine()), Convert.ToInt32(Console.ReadLine())];
            int dim=1000;
            Random rand = new Random();
            int[,] A = new int[dim, dim];
            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < A.GetLength(1); j++){
                    
                    A[i, j] = rand.Next(0, 10);

                }
            }
            //Console.WriteLine("Введите размерность второй матрицы: ");
            //int[,] B = new int[Convert.ToInt32(Console.ReadLine()), Convert.ToInt32(Console.ReadLine())];
            int[,] B = new int[dim, dim];

            for (int i = 0; i < B.GetLength(0); i++)
            {
                for (int j = 0; j < B.GetLength(1); j++)
                {
                    B[i, j] = rand.Next(0, 10);
                }
            }

            //Console.WriteLine("\nМатрица A:");
            //Print(A);
            //Console.WriteLine("\nМатрица B:");
            //Print(B);
            var start = DateTime.Now;
            int[,] C = await Task.Run(() => Multiplication(A, B)); 
            //Print(C);
            Console.WriteLine("\nРасчет окончен \nВремя вычисления = {0}", DateTime.Now - start);

        }
        static int[,] Multiplication(int[,] a, int[,] b)
        {
            if (a.GetLength(1) != b.GetLength(0)) throw new Exception("Матрицы нельзя перемножить");
            int[,] r = new int[a.GetLength(0), b.GetLength(1)];

            Parallel.For(0, a.GetLength(0), i =>
            {
                Parallel.For(0, b.GetLength(1), j =>
                    {
                        Parallel.For(0, b.GetLength(0), k => { r[i, j] += a[i, k] * b[k, j]; });
                    });
            });

            //for (int i = 0; i < a.GetLength(0); i++)
            //{
            //    for (int j = 0; j < b.GetLength(1); j++)
            //    {
            //        for (int k = 0; k < b.GetLength(0); k++)
            //        {
            //            r[i, j] += a[i, k] * b[k, j];
            //        }
            //    }
            //}
            return r;
        }
        static void Print(int[,] a)
        {
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    Console.Write("{0} ", a[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}

