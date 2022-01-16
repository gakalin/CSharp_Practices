using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace parallel_loops
{
    internal class Program
    {
        public static IEnumerable<int> Range(int start, int end, int step)
        {
            for (int i = start; i < end; i += step)
            {
                yield return i;
            }
        }
        
        public static void Main(string[] args)
        {
            var a = new Action(() => Console.WriteLine($"first {Task.CurrentId}"));
            var b = new Action(() => Console.WriteLine($"second {Task.CurrentId}"));
            var c = new Action(() => Console.WriteLine($"third {Task.CurrentId}"));
            
            Parallel.Invoke(a,b,c);
            
            Parallel.For(1, 11, i =>
            {
                Console.WriteLine($"{i * i}\t");
            });

            string[] words = {"oh", "what", "a", "day"};

            Parallel.ForEach(words, word =>
            {
                Console.WriteLine($"{word} has length {word.Length} (task {Task.CurrentId})");
            });

            Parallel.ForEach(Range(1, 20, 3), Console.WriteLine);
        }
    }
}