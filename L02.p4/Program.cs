using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace L02.p4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.WriteLine("L02.p4");
            Console.WriteLine();

            Console.WriteLine($"\nThread ID: {Thread.CurrentThread.ManagedThreadId} was started");

            var th = new Thread(Method);
            th.Start();

            Thread.Sleep(5000);

            th.Abort(); // Calling the Abort() method

            Console.WriteLine($"\nThread ID: {Thread.CurrentThread.ManagedThreadId} was finished");

            Console.ReadKey();
        }

        private static void Method()
        {
            var th = Thread.CurrentThread;
            Console.WriteLine($"\nThread ID: {th.ManagedThreadId} was started");

            for (int i = 0; i < 1000; i++)
            {
                Console.Write("+ ");
                Thread.Sleep(10);
            }

            Console.WriteLine($"\nThread ID: {th.ManagedThreadId} was finished");
            
        }
    }
}
