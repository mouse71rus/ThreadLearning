using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace L05.p8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.WriteLine("L05.p8");
            Console.WriteLine();

            var cancellationTokSou = new CancellationTokenSource();
            var ct = cancellationTokSou.Token;
            var task1 = Task.Factory.StartNew(Method, ct, ct);
            Thread.Sleep(3000);
            try
            {
                cancellationTokSou.Cancel();
                task1.Wait();
            }
            catch(AggregateException ex)
            {
                if(task1.IsCanceled)
                {
                    Console.WriteLine("Task was canceled");
                }
                Console.WriteLine($"\t - {ex.InnerException?.Message}");
            }
            catch (OperationCanceledException ex)
            {
                if (task1.IsCanceled)
                {
                    Console.WriteLine("Task was canceled");
                }
                Console.WriteLine($"\t - {ex.InnerException?.Message}");
            }
            finally
            {
                //task1.Dispose();
                //cancellationTokSou.Dispose();
            }
            Console.WriteLine("Main() was finished");
            Console.ReadKey();
        }

        private static void Method(object cancel)
        {
            var token = (CancellationToken)cancel;

            //token.ThrowIfCancellationRequested(); // Won't throw exception
            Console.WriteLine($"Method() CurrentID: {Task.CurrentId} working..");

            for (int i = 0; i < 50; i++)
            {
                if (token.IsCancellationRequested)
                {
                    Console.WriteLine("Request for cancel task");
                    token.ThrowIfCancellationRequested(); // throw exception
                    //throw new OperationCanceledException(token);
                }
                Thread.Sleep(200);
                Console.WriteLine($"Method #{Task.CurrentId}: i = {i}");
            }

            Console.WriteLine($"Method() CurrentID: {Task.CurrentId} was finished");
        }
    }
}
