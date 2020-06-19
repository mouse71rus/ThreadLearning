using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace L01.p2
{
    class Program
    {
        private static void Sound()
        {
            Thread soundThread = Thread.CurrentThread;
            soundThread.Name = "SoundThread";

            Console.WriteLine($"Thread: {soundThread.Name}, ID: {soundThread.GetHashCode()}");
            for (int i = 0; i < 100; i++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("+ ");
                Thread.Sleep(10);
            }
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($"\nThread: {soundThread.Name}, ID: {soundThread.GetHashCode()}, stopped");
        }

        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.WriteLine("L01.p2");
            Console.WriteLine();

            Console.WriteLine("Start.. ");
            
            Thread secondThread = new Thread(Sound); // Так тоже можно
            secondThread.Start();


            Thread currentThread = Thread.CurrentThread;
            currentThread.Name = "CurrentThread";
            Console.WriteLine($"Thread: {currentThread.Name}, ID: {currentThread.GetHashCode()}");

            for (int i = 0; i < 100; i++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("- ");
                Thread.Sleep(5);
            }

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($"\nThread: {currentThread.Name}, ID: {currentThread.GetHashCode()}, stopped");
            Console.ReadKey();
        }
    }
}
