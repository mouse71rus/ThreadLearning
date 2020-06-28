using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Async.p5
{
    class Program
    {
        static int Factorial(int n)
        {
            int result = 1;
            for (int i = 1; i <= n; i++)
            {
                result *= i;
            }

            return result;
        }
        static async Task<int> FactorialAsync(int n)
        {
            Console.WriteLine($"Начало метода FactorialAsync({n})"); // выполняется синхронно
            int result = await Task.Run(() => Factorial(n));
            Console.WriteLine($"Конец метода FactorialAsync({n})");
            return result;
        }

        static async void MainAsync(int n)
        {
            int result = await FactorialAsync(n);
            Console.WriteLine($"Факториал равен {result}");
        }

        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.WriteLine("Async.p5");
            Console.WriteLine();

            MainAsync(5);   // вызов асинхронного метода
            MainAsync(11);   // вызов асинхронного метода

            Console.WriteLine("Hello!");
            Console.ReadKey();
        }
    }
}