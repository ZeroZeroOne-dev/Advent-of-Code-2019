using System;
using AoC.Solutions.Days.Six;

namespace AoC.Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Day6Solution();
            var output = solution.Solve();

            Console.WriteLine($"the output is {output}");
            Console.ReadKey();
        }
    }
}
