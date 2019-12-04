using System;
using AoC.Solutions.Days.Three;

namespace AoC.Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            var solution = new ManhattanSolver();
            var output = solution.Solve();

            Console.WriteLine($"the output is {output}");
        }
    }
}
