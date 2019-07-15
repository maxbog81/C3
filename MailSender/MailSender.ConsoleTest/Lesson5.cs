using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;

//1. Написать приложение, считающее в раздельных потоках:
//a.факториал числа N, которое вводится с клавиатуру;
//b.сумму целых чисел до N, которое также вводится с клавиатуры.
//2. * Написать приложение, выполняющее парсинг CSV-файла произвольной структуры и сохраняющее его в обычный TXT-файл.Все операции проходят в потоках.CSV-файл заведомо имеет большой объём.

namespace MailSender.ConsoleTest
{
    static class Lesson5
    {
        static long f = 0;

        static long Factorial(uint n)
        {
            if (n == 0) return 1;
            else
            {
                f = Factorial(n - 1) * n;
                return f;
            }

        }
        public static void Start()
        {
            WriteLine("Введите число:");
            uint n = Convert.ToUInt32(Console.ReadLine());

            var curNum = n;

            //ThreadPool.QueueUserWorkItem(p => Factorial(curNum));

            //WriteLine($"Факториал числа без потока {n} = {Factorial(n)}");

            var f_thread = new Thread(() => Factorial(curNum))
            {
                Name = "Поток обновления часов",
                Priority = ThreadPriority.Lowest,
                IsBackground = true
            };
            f_thread.Start();
            f_thread.Join();

            WriteLine($"Факториал числа через поток {n} = {f}");

            ReadLine();

        }

    }
}
