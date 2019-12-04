using System;
using AoC.Solutions.Days.Four;

namespace AoC.Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Day4Solution();
            var output = solution.Solve();

            Console.WriteLine($"the output is {output}");
        }
    }
}
