using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Async.p4
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
            Console.WriteLine($"Факториал равен {result}");
        }

        // Определение асинхронного метода
        // Формально метод FactorialAsync не использует оператор return для возвращения результата. 
        // Однако если в асинхронном методе выполняется в выражении await асинхронная операция, 
        // то мы можем возвращать из метода объект Task.
        static async Task FactorialAsync(int n)
        {
            await Task.Run(() => Factorial(n));
        }
        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.WriteLine("Async.p4");
            Console.WriteLine();

            Task a = FactorialAsync(5);
            Task b = FactorialAsync(6);

            Console.WriteLine($"Task #1, ID: {a.Id}");
            Console.WriteLine($"Task #2, ID: {b.Id}");

            Console.WriteLine("Некоторая работа");

            Console.ReadKey();
        }
    }
}
