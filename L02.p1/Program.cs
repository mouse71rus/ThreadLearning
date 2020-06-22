using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace L02.p1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.WriteLine("L02.p1");
            Console.WriteLine();

            var mainThread = Thread.CurrentThread;
            mainThread.Name = "CurrentThread";

            Console.WriteLine($"\nThread {mainThread.Name}, ID: {mainThread.ManagedThreadId}");

            var secondThread = new Thread(Method);
            secondThread.Start();
            secondThread.Join();

            for (int i = 0; i < 100; i++)
            {
                Console.Write("- ");
                Thread.Sleep(20);
            }

            Console.WriteLine($"\nThread {mainThread.Name}, ID: {mainThread.ManagedThreadId} was finished");
            Console.ReadKey();
        }

        private static void Method()
        {
            var th = Thread.CurrentThread;
            th.Name = "SecondThread";

            Console.WriteLine($"\nThread {th.Name}, ID: {th.ManagedThreadId}");
            for (int i = 0; i < 100; i++)
            {
                Console.Write("+ ");
                Thread.Sleep(20);
            }

            Console.WriteLine($"\nThread {th.Name}, ID: {th.ManagedThreadId} was finished");
        }
    }
}
