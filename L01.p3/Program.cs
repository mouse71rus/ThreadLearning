using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace L01.p3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.WriteLine("L01.p3");
            Console.WriteLine();

            Thread currentThread = Thread.CurrentThread;
            currentThread.Name = "CurrentThread";
            Console.WriteLine($"Thread: {currentThread.Name}, ID: {currentThread.GetHashCode()}");

            #region Print Method
            ParameterizedThreadStart pth1 = new ParameterizedThreadStart(Print);
            Thread thread1 = new Thread(pth1);
            thread1.Start("+ ");

            #endregion

            #region Print Method {2}
            ParameterizedThreadStart pth2 = new ParameterizedThreadStart(Print);
            Thread thread2 = new Thread(pth2);
            thread2.Start(new Bag(10, "ten", 10.0));

            #endregion

            #region PrintBag Method
            ParameterizedThreadStart pth3 = new ParameterizedThreadStart(PrintBag);
            Thread thread3 = new Thread(pth3);
            thread3.Start(new Bag(2, "second", 19.7));

            #endregion


            Console.WriteLine($"\nThread: {currentThread.Name}, ID: {currentThread.GetHashCode()}, stopped");
            Console.ReadKey();
        }

        static void Print(object o)
        {
            Console.WriteLine($"Thread ID: {Thread.CurrentThread.ManagedThreadId} was started");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(o);
                Thread.Sleep(100);
            }
            Console.WriteLine($"Thread ID: {Thread.CurrentThread.ManagedThreadId} was finished");
        }

        static void PrintBag(object o)
        {
            Bag bag = o as Bag;
            Console.WriteLine($"Thread ID: {Thread.CurrentThread.ManagedThreadId} was started");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"BAG: {bag.Prop1} {bag.Prop2} {string.Format("{0:f}", bag.Prop3)}");
                Thread.Sleep(100);
            }
            Console.WriteLine($"Thread ID: {Thread.CurrentThread.ManagedThreadId} was finished");
        }
    }
}
