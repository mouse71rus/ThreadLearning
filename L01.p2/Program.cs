using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace L01.p2
{
    class Program
    {
        private static void Sount()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("+ ");
                Thread.Sleep(10);
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.WriteLine("L01.p2");
            Console.WriteLine();

            Console.WriteLine("Start.. ");

            ThreadStart ts = new ThreadStart(Sount);
            Thread secondThread = new Thread(ts);
            secondThread.Start();

            for (int i = 0; i < 100; i++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("- ");
                Thread.Sleep(5);
            }

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\nFinish.. ");
            Console.ReadKey();
        }
    }
}
