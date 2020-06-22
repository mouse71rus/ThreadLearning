using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace L04.p1
{
    class Program
    {
        private static long count;
        private static long value = 1;
        private static Random rnd = new Random();

        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.WriteLine("L04.p1");
            Console.WriteLine();
                        
            count = 0;
            Thread tRead = new Thread(ReadData) { IsBackground = true };
            tRead.Start();

            Thread[] threads = new Thread[200];
            Console.WriteLine($"Thread.Length: {threads.Length}");

            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(ChangeCount);
                threads[i].Start();
            }


            Console.ReadKey();
        }

        private static void ChangeCount()
        {
            //count += value;
            Interlocked.Add(ref count, value);

            Thread.Sleep(rnd.Next(100, 500));

            //count -= value;
            Interlocked.Add(ref count, -value);
        }

        private static void ReadData()
        {
            while(true)
            {
                long a = Interlocked.Read(ref count);
                Console.WriteLine($"Count: {a}");
                Thread.Sleep(300);
            }
        }
    
    }
}
