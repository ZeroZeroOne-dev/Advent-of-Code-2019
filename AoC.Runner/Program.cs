using System;
using AoC.Solutions.Days.Four;
using AoC.Solutions.Days.One;
using AoC.Solutions.Days.Three;
using AoC.Solutions.Days.Two;

namespace AoC.Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Day3Part2Solver();
            var output = solution.Solve();

            Console.WriteLine($"the output is {output}");
        }
    }
}
