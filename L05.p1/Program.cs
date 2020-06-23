using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace L05.p1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.WriteLine("L05.p1");
            Console.WriteLine();

            var a = new Action(Method);
            var task = new Task(a);
            task.Start();
            for (int i = 0; i < 100; i++)
            {
                Console.Write("- ");
                Thread.Sleep(50);
            }

            Console.WriteLine("Main() was finished");

            Console.ReadKey();
        }

        private static void Method()
        {
            Console.WriteLine("Method working..");

            for (int i = 0; i < 20; i++)
            {
                Thread.Sleep(500);
                Console.WriteLine($"Method: i = {i}");
            }

            Console.WriteLine("Method() was finished");
        }
    }
}
