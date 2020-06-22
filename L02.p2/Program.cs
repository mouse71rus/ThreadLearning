using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace L02.p2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.WriteLine("L02.p2");
            Console.WriteLine();

            var mainThread = Thread.CurrentThread;
            mainThread.Name = "CurrentThread";

            Console.WriteLine($"\nThread {mainThread.Name}, ID: {mainThread.ManagedThreadId}");

            var secondThread = new Thread(Method);
            secondThread.Start();
            //secondThread.Join();

            for (int i = 0; i < 100; i++)
            {
                Console.Write("- ");
                Thread.Sleep(25);
            }

            Console.WriteLine($"\nThread {mainThread.Name}, ID: {mainThread.ManagedThreadId} was finished");
            Console.ReadKey();
        }

        private static void Method()
        {
            var th = Thread.CurrentThread;
            th.Name = "SecondThread";
            Console.WriteLine($"\nThread {th.Name}, ID: {th.ManagedThreadId}");

            var thirdThread = new Thread(Method2);
            thirdThread.Start();
            thirdThread.Join();
            
            for (int i = 0; i < 100; i++)
            {
                Console.Write("+ ");
                Thread.Sleep(20);
            }

            Console.WriteLine($"\nThread {th.Name}, ID: {th.ManagedThreadId} was finished");
        }
        private static void Method2()
        {
            var th2 = Thread.CurrentThread;
            th2.Name = "ThirdThread";

            Console.WriteLine($"\nThread {th2.Name}, ID: {th2.ManagedThreadId}");
            for (int i = 0; i < 100; i++)
            {
                Console.Write("* ");
                Thread.Sleep(20);
            }

            Console.WriteLine($"\nThread {th2.Name}, ID: {th2.ManagedThreadId} was finished");
        }

    }
}
