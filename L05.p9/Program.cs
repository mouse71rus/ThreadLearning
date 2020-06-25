using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace L05.p9
{
    class Program
    {
        static int[] array;

        static void Fill(int i)
        {
            array[i] = i / 1000;
        }

        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.WriteLine("L05.p9");
            Console.WriteLine();

            array = new int[500_000_000];

            var st_t = DateTime.Now;

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = i / 1000;
            }

            Console.WriteLine($"Singleton: {(DateTime.Now - st_t).TotalMilliseconds}");

            Console.ReadKey();

            st_t = DateTime.Now;

            Parallel.For(0, array.Length, Fill);

            Console.WriteLine($"Parallel: {(DateTime.Now - st_t).TotalMilliseconds}");

            Console.ReadKey();
        }
    }
}
