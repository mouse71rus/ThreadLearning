using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace L02.p7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.WriteLine("L02.p7");
            Console.WriteLine();
            
            ThreadWrapper[] threads = new ThreadWrapper[]
            {
                new ThreadWrapper() {Priority = ThreadPriority.Lowest},
                new ThreadWrapper() {Priority = ThreadPriority.Highest},
                new ThreadWrapper() {Priority = ThreadPriority.Normal},
            };

            foreach (var item in threads)
            {
                item.Start();
            }

            Console.ReadKey();
        }
    }
}
