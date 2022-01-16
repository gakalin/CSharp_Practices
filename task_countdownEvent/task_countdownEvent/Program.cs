using System;
using System.Threading;
using System.Threading.Tasks;

namespace task_countdownEvent
{
    internal class Program
    {
        private static int taskCount = 5;
        private static CountdownEvent cte = new CountdownEvent(taskCount);
        private static Random random = new Random();
        
        public static void Main(string[] args)
        {
            for (int i = 0; i < taskCount; i++)
            {
                Task.Factory.StartNew(() =>
                {
                    Console.WriteLine($"entering task {Task.CurrentId}");
                    Thread.Sleep(random.Next(3000));
                    cte.Signal();
                    Console.WriteLine($"exiting task {Task.CurrentId}");
                });
            }

            var finalTask = Task.Factory.StartNew(() =>
            {
                Console.WriteLine($"waiting for other tasks to complete in {Task.CurrentId}");
                cte.Wait();
                Console.WriteLine("all tasks completed");
            });

            finalTask.Wait();
        }
    }
}