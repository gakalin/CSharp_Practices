using System;
using System.Threading;
using System.Threading.Tasks;

namespace task_semaphoreSlim
{
    internal class Program
    {
        
        public static void Main(string[] args)
        {
             var semaphore = new SemaphoreSlim(2, 10);

             for (int i = 0; i < 20; i++)
             {
                 Task.Factory.StartNew(() =>
                 {
                     Console.WriteLine($"entering task {Task.CurrentId}");
                     semaphore.Wait(); // releasecount--
                     Console.WriteLine($"processing task {Task.CurrentId}");
                 });
             }

             while (semaphore.CurrentCount <= 2)
             {
                 Console.WriteLine($"semaphore count: {semaphore.CurrentCount}");
                 Console.ReadKey();
                 semaphore.Release(2);
             }

        }
    }
}