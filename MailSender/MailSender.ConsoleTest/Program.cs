using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;




namespace MailSender.ConsoleTest
{
    class Program
    {
        //private static async Task PrintAsync(string str) { await Task.Delay(1000); Console.WriteLine(str); }
        static void Main(string[] args)
        {
            //Lesson5.Start();
            //var task1= PrintAsync("qwerty");

            //Console.WriteLine("Расчет произведения матриц:");
            //var start = DateTime.Now;
            var task1 = Lesson6.Start();

            //Task.WhenAll(task1).Wait();

            //Console.WriteLine("\nРасчет окончен \nВремя вычисления = {0}", DateTime.Now - start);

            ReadLine();
        }
    }
}
