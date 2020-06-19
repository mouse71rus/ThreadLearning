using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace L01.p6
{
    class Program
    {
        static object saucepan = new object(); // Important object

        static void ThreadMethod(object arg)
        {
            Argument a = arg as Argument;
            int ID = Thread.CurrentThread.ManagedThreadId;
            lock (saucepan) // If comment this line, Application wil work incorrect
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.ForegroundColor = a.Color;
                    Console.WriteLine($"Thread ID: {ID} => {a.Text}");
                    Thread.Sleep(20);
                    Console.ResetColor();
                }
            }
        }


        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.WriteLine("L01.p5");
            Console.WriteLine();

            Thread cookJob = new Thread(ThreadMethod);
            cookJob.Start(new Argument("Готовит борщ", ConsoleColor.Red));

            Thread cookJack = new Thread(ThreadMethod);
            cookJack.Start(new Argument("Готовит компот", ConsoleColor.Yellow));

            Thread cookOleg = new Thread(ThreadMethod);
            cookOleg.Start(new Argument("Готовит Салат", ConsoleColor.Green));

            ThreadMethod(new Argument("Готовит кашу", ConsoleColor.White));

            Console.ReadKey();
        }
    }
}