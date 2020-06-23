using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace L05.p6
{
    class Program
    {
        private static void Method1()
        {
            Console.WriteLine($"Method1() CurrentID: {Task.CurrentId} working..");

            for (int i = 0; i < 20; i++)
            {
                Thread.Sleep(150);
                Console.WriteLine($"Method1 #{Task.CurrentId}: i = {i} +");
            }

            Console.WriteLine($"Method1() CurrentID: {Task.CurrentId} was finished");
        }

        private static void Method2(Task t)
        {
            Console.WriteLine($"Method2() CurrentID: {Task.CurrentId} working..");

            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(100);
                Console.WriteLine($"Method2 #{Task.CurrentId}: i = {i} -");
            }

            Console.WriteLine($"Method2() CurrentID: {Task.CurrentId} was finished");
        }

        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.WriteLine("L05.p6");
            Console.WriteLine();

            var task1 = new Task(Method1);
            
            
            var task2 = task1.ContinueWith(Method2);

            task1.Start();
            task2.Wait();
            //task1.Start(); // Task already running
            //task2.Start(); // Task already running

            Console.WriteLine($"task1: {task1.Id}");
            Console.WriteLine($"task2: {task2.Id}");

            
            

            Console.WriteLine("Main() was finished");
            Console.ReadKey();
        }
    }
}
