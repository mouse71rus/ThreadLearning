using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Async.p2
{
    class Program
    {
        // определение асинхронного метода
        static async void FactorialAsync(int n)
        {
            Console.WriteLine($"Начало метода FactorialAsync({n})"); // выполняется синхронно
            await Task.Run(() =>
            {
                int result = 1;
                for (int i = 1; i <= n; i++)
                {
                    result *= i;
                }

                Console.WriteLine($"Факториал равен {result}");                // выполняется асинхронно
                Console.WriteLine($"Конец метода FactorialAsync({n})");
            });
        }
        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.WriteLine("Async.p2");
            Console.WriteLine();

            FactorialAsync(5);   // вызов асинхронного метода
            FactorialAsync(11);   // вызов асинхронного метода

            Console.WriteLine("Hello!");
            Console.ReadKey();
        }
    }
}
