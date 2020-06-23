using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace L05.p7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.WriteLine("L05.p7");
            Console.WriteLine();

            var task1 = Task<int>.Factory.StartNew(TaskResult);
            //Thread.Sleep(1500);
            Console.WriteLine($"Task #{task1.Id} Result: {task1.Result}");

            var task2 = Task<double>.Factory.StartNew(Sum, 10);
            //Thread.Sleep(1500);
            Console.WriteLine($"Task #{task2.Id} Result: {task2.Result}");

            Console.WriteLine("Main() was finished");
            Console.ReadKey();
        }

        static int TaskResult()
        {
            Thread.Sleep(1000);

            return 255 + 144;
        }

        static double Sum(object arg)
        {
            int o = (int)arg;
            double sum = 0;
            
            while (o > 0)
            {
                sum += o--;
            }

            return sum;
        }
    }
}