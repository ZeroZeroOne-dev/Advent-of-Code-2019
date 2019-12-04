using AoC.Solutions.Days.Three;
using Xunit;

namespace AoC.Tests.Days.Three
{
    public class ManhattanSolverTests
    {
        private readonly ManhattanSolver solver;

        public ManhattanSolverTests()
        {
            this.solver = new ManhattanSolver();
        }

        [Theory]
        [InlineData(new[] { "R8", "U5", "L5", "D3" }, new[] { "U7", "R6", "D4", "L4" }, 6)]
        [InlineData(new[] { "R75", "D30", "R83", "U83", "L12", "D49", "R71", "U7", "L72" }, new[] { "U62", "R66", "U55", "R34", "D71", "R55", "D58", "R83" }, 159)]
        [InlineData(new[] { "R98", "U47", "R26", "D63", "R33", "U87", "L62", "D20", "R33", "U53", "R51" }, new[] { "U98", "R91", "D20", "R16", "D67", "R40", "U7", "R15", "U6", "R7" }, 135)]
        public void Can_Find_Closest_Intersection(string[] firstPath, string[] secondPath, int expected)
        {
            var closest = this.solver.GetClosestIntersectionDistance(firstPath, secondPath);

            Assert.Equal(expected, closest);
        }
    }
}