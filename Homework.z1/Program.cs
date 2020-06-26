using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.z1
{
    class Program
    {
        static int SumCh(int ch)
        {
            int sum = 0;

            while (ch > 0)
            {
                sum += ch % 10;
                ch /= 10;
            }

            return sum;
        }


        static void SumParal(int ch)
        {
            int sum = 0;
            int lastCh = ch % 10;
            int ch_b = ch;
            while (ch > 0)
            {
                sum += ch % 10;
                ch /= 10;
            }

            

            if (lastCh == 0 || sum % lastCh == 0)
            {
                Console.WriteLine($"Ch: {ch_b}, Sum: {sum}, Last Ch: {lastCh}, yes");
            }
            else
            {
                Console.WriteLine($"Ch: {ch_b}, Sum: {sum}, Last Ch: {lastCh}, no");
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.WriteLine("Homework.z1");
            Console.WriteLine();

            
            var st_t = DateTime.Now;

            for (int i = 1_000_000_000; i < 2_000_000_000; i++)
            {
                int sum = SumCh(i);
                int lastCh = i % 10;

                if (lastCh == 0 || sum % lastCh == 0)
                {
                    Console.WriteLine($"Ch: {i}, Sum: {sum}, Last Ch: {lastCh}, yes");
                }
                else
                {
                    Console.WriteLine($"Ch: {i}, Sum: {sum}, Last Ch: {lastCh}, no");
                }
            }

            Console.WriteLine($"Singleton: {(DateTime.Now - st_t).TotalMilliseconds}");

            Console.ReadKey();

            st_t = DateTime.Now;

            Parallel.For(1_000_000_000, 2_000_000_000, SumParal);

            Console.WriteLine($"Parallel: {(DateTime.Now - st_t).TotalMilliseconds}");

            Console.ReadKey();
        }
    }
}
