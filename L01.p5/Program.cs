using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace L01.p5
{
    class Program
    {
        static void Log()
        {
            while (true)
            {
                Console.WriteLine($"Log: {DateTime.Now.ToLongTimeString()}");
                Thread.Sleep(100);
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.WriteLine("L01.p5");
            Console.WriteLine();

            Thread t = new Thread(Log);
            t.Start();
            t.IsBackground = true; // Specify that this thread is background

            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine("\tMain thread");
                Thread.Sleep(100);
            }

            
            // Application will stop the thread "t" here
        }
    }
}