using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace L02.p6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.WriteLine("L02.p6");
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
                try
                {
                    Console.Write("+ ");
                    Thread.Sleep(10);
                }
                catch (ThreadAbortException e)
                {
                    Console.WriteLine($"\nException: {e.Message}");
                    Console.WriteLine("\nSomebody called my Abort() method :(");
                    Console.WriteLine("But I'll work continue! :D");
                   
                    Thread.ResetAbort(); // Calling ResetAbort() method that canceling Abort for current thread
                }

            }

            Console.WriteLine($"\nThread ID: {th.ManagedThreadId} was finished");

        }
    }
}
