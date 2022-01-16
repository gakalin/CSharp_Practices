using System;
using System.Threading;
using System.Threading.Tasks;

namespace parallel_threadLocalStorage
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int sum = 0;

            Parallel.For(1, 1001, 
                () => 0,
                (x, state, tls) =>
                {
                    tls += x;
                    Console.WriteLine($"task {Task.CurrentId} has sum {tls}");
                    return tls;
                },
                partialSum =>
                {
                    Console.WriteLine($"partial value of task {Task.CurrentId} is {partialSum}");
                    Interlocked.Add(ref sum, partialSum);
                });
            Console.WriteLine($"sum of 1...1000 = {sum}");
        }
    }
}