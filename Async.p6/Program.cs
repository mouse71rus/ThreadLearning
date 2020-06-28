using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Async.p6
{
    class Program
    {
        static void Factorial(int n)
        {
            int result = 1;
            for (int i = 1; i <= n; i++)
            {
                result *= i;
            }

            Console.WriteLine($"Факториал {n}! равен {result}");
        }
        static async Task FactorialAsync()
        {
            Console.WriteLine($"Начало метода FactorialAsync");
            // Задачи выполняется последовательно (синхроннно)
            await Task.Run(() => Factorial(5));
            await Task.Run(() => Factorial(2));
            await Task.Run(() => Factorial(7));
            Console.WriteLine($"Конец метода FactorialAsync");
        }
        static async Task FactorialAsync2()
        {
            Console.WriteLine($"Начало метода FactorialAsync2");
            // Задачи выполняется последовательно (синхроннно)
            var t1 = Task.Run(() => Factorial(5));
            var t2 = Task.Run(() => Factorial(2));
            var t3 = Task.Run(() => Factorial(7));

            await Task.WhenAll(t1, t2, t3);
            Console.WriteLine($"Конец метода FactorialAsync2");
        }
        static async void MainAsync()
        {
            Console.WriteLine("1:");
            await FactorialAsync();

            Console.WriteLine("2:");
            await FactorialAsync2();
        }

        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.WriteLine("Async.p6");
            Console.WriteLine();

            MainAsync();   // вызов асинхронного метода


            Console.WriteLine("Hello from Main Method!");
            Console.ReadKey();
        }
    }
}
