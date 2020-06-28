using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Async.p3
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
        static async void FactorialAsync(int n)
        {
            Console.WriteLine($"Начало метода FactorialAsync({n})"); // выполняется синхронно
            int result = await Task.Run(() => Factorial(n) );

            Console.WriteLine($"Факториал равен {result}");
            Console.WriteLine($"Конец метода FactorialAsync({n})");
        }
        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.WriteLine("Async.p3");
            Console.WriteLine();

            FactorialAsync(5);   // вызов асинхронного метода
            FactorialAsync(11);   // вызов асинхронного метода

            Console.WriteLine("Hello!");
            Console.ReadKey();
        }
    }
}
