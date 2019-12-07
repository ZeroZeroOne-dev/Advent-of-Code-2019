using AoC.Solutions.Days.Five;
using Xunit;

namespace AoC.Tests.Days.Five
{
    public class OpCodeRunnerV2Tests
    {
        private readonly OpCodeRunnerV2 runner;

        public OpCodeRunnerV2Tests()
        {
            this.runner = new OpCodeRunnerV2();
        }

        [Theory]
        //[InlineData(new[] { 1002, 4, 3, 4, 33 }, new[] { 1002, 4, 3, 4, 99 })]
        //[InlineData(new[] { 1001, 4, 3, 4, 33 }, new[] { 1001, 4, 3, 4, 36 })]
        [InlineData(new[] { 1105, 1, 3, 99 }, new[] { 1105, 1, 3, 99 })]
        public void Can_Run_Program(int[] input, int[] expected)
        {
            var result = this.runner.Run(input);

            Assert.Equal(expected, result);
        }
    }
}