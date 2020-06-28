using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Async.p7
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

        static async void FactorialAsync(int n)
        {
            Task task = null;
            try
            {
                task = Task.Run(() => Factorial(n));
                await task;
            }
            catch (Exception ex)
            {
                await Task.Run(() => Console.WriteLine(ex.Message));
                Console.WriteLine(task.Exception.InnerException.Message);
                Console.WriteLine($"IsFaulted: {task.IsFaulted}");
            }
            finally
            {
                await Task.Run(() => Console.WriteLine("await в блоке finally"));
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.WriteLine("Async.p7");
            Console.WriteLine();

            FactorialAsync(-4);
            FactorialAsync(6);

            Console.ReadKey();
        }
    }
}
