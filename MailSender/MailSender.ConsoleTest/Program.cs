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

            Console.WriteLine("Расчет произведения матриц:");

            var task1=Lesson6.Start();

            var wait_all_task = Task.WhenAll(task1);

            Console.WriteLine("\nМатрица C = A * B:\n");
            
            ReadLine();
        }
    }
}
