using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L01.p1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.WriteLine("L01.p1");
            Console.WriteLine();

            Console.WriteLine("Start.. ");

            for (int i = 0; i < 100; i++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("+ ");
            }

            for (int i = 0; i < 100; i++)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("- ");
            }

            Console.ReadKey();
        }
    }
}