using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Async.p8
{
    class Program
    {
        static void Factorial(int n)
        {
            if (n < 1)
                throw new Exception($"{n} : число не должно быть меньше 1");
            int result = 1;
            for (int i = 1; i <= n; i++)
            {
                result *= i;
            }
            Console.WriteLine($"Факториал числа {n} равен {result}");
        }

        static async Task DoMultipleAsync()
        {
            Task allTasks = null;

            try
            {
                Task t1 = Task.Run(() => Factorial(-3));
                Task t2 = Task.Run(() => Factorial(-5));
                Task t3 = Task.Run(() => Factorial(-10));

                allTasks = Task.WhenAll(t1, t2, t3);
                await allTasks;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Исключение: " + ex.Message);
                Console.WriteLine("IsFaulted: " + allTasks.IsFaulted);
                foreach (var inx in allTasks.Exception.InnerExceptions)
                {
                    Console.WriteLine("Внутреннее исключение: " + inx.Message);
                }
            }
        }



        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.WriteLine("Async.p8");
            Console.WriteLine();

            var t = DoMultipleAsync();

            Console.ReadKey();
        }
    }
}
