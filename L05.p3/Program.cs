using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace L05.p3
{
    class Program
    {
        private static void Method()
        {
            Console.WriteLine($"Method() CurrentID: {Task.CurrentId} working..");

            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(100);
                Console.WriteLine($"Method #{Task.CurrentId}: i = {i}");
            }

            Console.WriteLine($"Method() CurrentID: {Task.CurrentId} was finished");
        }

        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.WriteLine("L05.p3");
            Console.WriteLine();

            var task1 = new Task(Method);
            var task2 = new Task(Method);

            task1.Start();
            task2.Start();

            Console.WriteLine($"task1: {task1.Id}");
            Console.WriteLine($"task2: {task2.Id}");


            for (int i = 0; i < 10; i++)
            {
                Console.Write("- ");
                Thread.Sleep(50);
            }

            

            //Главный поток будет дожидаться окончания task1, task2
            task1.Wait();
            task2.Wait();

            Console.WriteLine("Main() was finished");
            Console.ReadKey();
        }
    }
}
