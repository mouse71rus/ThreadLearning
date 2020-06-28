using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// REQUIRE C# 8.0 (vs 2019)
namespace Async.p10
{
    class Program
    {
        //static async Task Main()
        //{
        //    await foreach (var number in GetNumbersAsync())
        //    {
        //        Console.WriteLine(number);
        //    }
        //}

        //public static async IAsyncEnumerable<int> GetNumbersAsync()
        //{
        //    for (int i = 0; i < 10; i++)
        //    {
        //        await Task.Delay(100);
        //        yield return i;
        //    }
        //}

        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.WriteLine("Async.p9");
            Console.WriteLine();

            //Main();

            Console.ReadKey();
        }
    }
}