using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace L02.p7
{
    class ThreadWrapper
    {
        private static bool endCalculations;
        private Thread t;
        private int args;

        public ThreadPriority Priority { set { t.Priority = value; } }

        static ThreadWrapper()
        {
            endCalculations = false;
        }

        public ThreadWrapper()
        {
            t = new Thread(Calc);
            args = 1_000_000; // LOL. It's work
        }

        private void Calc()
        {
            while (!endCalculations && args != 0)
            {
                args--;
            }

            endCalculations = true;
            Console.WriteLine($"\nThread ID: {Thread.CurrentThread.ManagedThreadId} was finished. Priority: {t.Priority}. Args: {args}");
        }

        public void Start()
        {
            t.Start();
        }
    }
}