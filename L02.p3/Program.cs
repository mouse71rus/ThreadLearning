using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace L02.p3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.WriteLine("L02.p3");
            Console.WriteLine();

            Method();

            Console.ReadKey();
        }

        private static void Method()
        {
            if(Provider.Data < 10)
            {
                Provider.Data++;

                var th = Thread.CurrentThread;
                Console.WriteLine($"\nThread ID: {th.ManagedThreadId} was started");

                var thirdThread = new Thread(Method);
                thirdThread.Start();
                thirdThread.Join();

                Console.WriteLine($"\nThread ID: {th.ManagedThreadId} was finished");
            }                     
        }
    }
}