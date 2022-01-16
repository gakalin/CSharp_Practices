using System;
using System.Linq;

namespace plinq_custom_aggregation
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //var sum = Enumerable.Range(1, 1000).Sum();

            //var sum = Enumerable.Range(1, 1000)
            //    .Aggregate(0, (i, acc) => i+acc);

            var sum = ParallelEnumerable.Range(1, 1000)
                .Aggregate(
                    0,
                    (partialSum, i) => partialSum += i,
                    (total, subTotal) => total += subTotal,
                    i => i);

            Console.WriteLine($"sum = {sum}");
            
        }
    }
}