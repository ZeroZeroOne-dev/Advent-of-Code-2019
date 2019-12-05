using System.IO;
using System.Reflection;

namespace AoC.Solutions.Days.Three
{
    public class Day3Part1Solver : ISolution
    {
        private readonly ManhattanSolver manhattanSolver;

        public Day3Part1Solver()
        {
            this.manhattanSolver = new ManhattanSolver();
        }

        public string Solve()
        {
            var file = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "days/3/input.txt");

            var lines = File.ReadAllLines(file);

            var firstPath = lines[0].Split(',');
            var secondPath = lines[1].Split(',');

            var result = this.manhattanSolver.GetClosestIntersectionDistance(firstPath, secondPath);

            return result.ToString();
        }

    }

    public class Day3Part2Solver : ISolution
    {
        private readonly ManhattanSolver manhattanSolver;

        public Day3Part2Solver()
        {
            this.manhattanSolver = new ManhattanSolver();
        }

        public string Solve()
        {
            var file = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "days/3/input.txt");

            var lines = File.ReadAllLines(file);

            var firstPath = lines[0].Split(',');
            var secondPath = lines[1].Split(',');

            var result = this.manhattanSolver.GetStepsFewestCombinedIntersection(firstPath, secondPath);

            return result.ToString();
        }

    }
}