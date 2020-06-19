using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace L01.p4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.WriteLine("L01.p4");
            Console.WriteLine();

            Thread currentThread = Thread.CurrentThread;
            currentThread.Name = "CurrentThread";
            Console.WriteLine($"Thread: {currentThread.Name}, ID: {currentThread.GetHashCode()}");

            #region Print Method
            var pth1 = new ParameterizedThreadStart(o => 
            {
                Console.WriteLine($"Thread ID: {Thread.CurrentThread.ManagedThreadId} was started");
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine(o);
                    Thread.Sleep(100);
                }
                Console.WriteLine($"Thread ID: {Thread.CurrentThread.ManagedThreadId} was finished");
            });
            Thread thread1 = new Thread(pth1);
            thread1.Start("+ ");

            #endregion

            #region PrintBag Method
            ParameterizedThreadStart pth3 = new ParameterizedThreadStart(o => 
            {
                p3.Bag bag = o as p3.Bag;
                Console.WriteLine($"Thread ID: {Thread.CurrentThread.ManagedThreadId} was started");
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine($"BAG: {bag.Prop1} {bag.Prop2} {string.Format("{0:f}", bag.Prop3)}");
                    Thread.Sleep(100);
                }
                Console.WriteLine($"Thread ID: {Thread.CurrentThread.ManagedThreadId} was finished");
            });
            Thread thread3 = new Thread(pth3);
            thread3.Start(new p3.Bag(2, "second", 19.7));

            #endregion


            Console.WriteLine($"\nThread: {currentThread.Name}, ID: {currentThread.GetHashCode()}, stopped");
            Console.ReadKey();
        }
    }
}
