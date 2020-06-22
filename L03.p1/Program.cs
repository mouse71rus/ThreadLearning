using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace L03.p1
{
    class Program
    {
        static Random rnd = new Random();

        static void ThreadTask(object o)
        {
            Console.WriteLine($"Thread #{Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(rnd.Next(3000, 5000));
        }

        static void GetThreadPoolInformation()
        {
            int workerThreadAvailable, completionPortThreadAvailable;
            ThreadPool.GetAvailableThreads(out workerThreadAvailable, out completionPortThreadAvailable);

            int workerThreadMax, completionPortThreadMax;
            ThreadPool.GetMaxThreads(out workerThreadMax, out completionPortThreadMax);

            Console.WriteLine($"Thread available in ThreadPool: {workerThreadAvailable} from {workerThreadMax}");
            Console.WriteLine($"Thread available for port in ThreadPool: {completionPortThreadAvailable} from {completionPortThreadMax}");
            Console.WriteLine();
        }


        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.WriteLine("L03.p1");
            Console.WriteLine();

            GetThreadPoolInformation();
            Console.ReadKey();

            for (int i = 0; i < 30; i++)
            {
                if (i < 10)
                {
                    ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadTask));
                }
                GetThreadPoolInformation();
                Thread.Sleep(500);
            }



            Console.ReadKey();
        }
    }
}
