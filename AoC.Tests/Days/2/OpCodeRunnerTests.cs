using AoC.Solutions.Days.Two;
using Xunit;

namespace AoC.Tests.Days.Two
{
    public class OpCodeRunnerTests
    {
        private readonly OpCodeRunner runner;

        public OpCodeRunnerTests()
        {
            this.runner = new OpCodeRunner();
        }

        [Theory]
        [InlineData(new[] { 1, 0, 0, 0, 99 }, new[] { 2, 0, 0, 0, 99 })]
        [InlineData(new[] { 2, 3, 0, 3, 99 }, new[] { 2, 3, 0, 6, 99 })]
        [InlineData(new[] { 2, 4, 4, 5, 99, 0 }, new[] { 2, 4, 4, 5, 99, 9801 })]
        [InlineData(new[] { 1, 1, 1, 4, 99, 5, 6, 0, 99 }, new[] { 30, 1, 1, 4, 2, 5, 6, 0, 99 })]
        public void Can_Run_OpCode(int[] input, int[] expected)
        {
            var result = this.runner.Run(input);

            Assert.Equal(expected, result);
        }
    }
}