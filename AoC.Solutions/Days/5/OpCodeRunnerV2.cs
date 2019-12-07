using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace AoC.Solutions.Days.Five
{
    public class OpCodeRunnerV2 : ISolution
    {

        public int[] Run(int[] program)
        {
            int currentPosition = 0;
            while (currentPosition < program.Length)
            {
                var opAndModes = program[currentPosition];

                int op = opAndModes % 100;
                switch (op)
                {
                    case 1:
                        currentPosition = Sum(program, currentPosition, opAndModes);
                        break;
                    case 2:
                        currentPosition = Multiply(program, currentPosition, opAndModes);
                        break;
                    case 3:
                        currentPosition = Input(program, currentPosition, opAndModes);
                        break;
                    case 4:
                        currentPosition = Ouput(program, currentPosition, opAndModes);
                        break;
                    case 5:
                        currentPosition = JumpIf(JumpMode.NonZero, program, currentPosition, opAndModes);
                        break;
                    case 6:
                        currentPosition = JumpIf(JumpMode.Zero, program, currentPosition, opAndModes);
                        break;
                    case 7:
                        currentPosition = Comparison(ComparisonMode.LessThan, program, currentPosition, opAndModes);
                        break;
                    case 8:
                        currentPosition = Comparison(ComparisonMode.Equals, program, currentPosition, opAndModes);
                        break;
                    case 99:
                        return program;
                    default:
                        return program;
                }

                currentPosition++;
            }

            return program;
        }

        private int Comparison(ComparisonMode comparisonMode, int[] program, int currentPosition, int opAndModes)
        {
            var mode1 = (opAndModes / 100) % 10 == 0 ? Mode.Position : Mode.Immediate;
            var mode2 = (opAndModes / 1000) % 10 == 0 ? Mode.Position : Mode.Immediate;
            //var mode3 = (opAndModes / 10000) % 10 == 0 ? Mode.Position : Mode.Immediate;

            var p1Value = mode1 == Mode.Immediate ? program[++currentPosition] : program[program[++currentPosition]];
            var p2Value = mode2 == Mode.Immediate ? program[++currentPosition] : program[program[++currentPosition]];
            //var param3 = mode3 == Mode.Immediate ? program[++current] : program[program[++current]];

            var resultPos = program[++currentPosition];

            var result = comparisonMode == ComparisonMode.LessThan ? p1Value < p2Value : p1Value == p2Value;

            program[resultPos] = result ? 1 : 0;

            return currentPosition;
        }

        private int JumpIf(JumpMode jumpMode, int[] program, int currentPosition, int opAndModes)
        {
            var mode1 = (opAndModes / 100) % 10 == 0 ? Mode.Position : Mode.Immediate;
            var mode2 = (opAndModes / 1000) % 10 == 0 ? Mode.Position : Mode.Immediate;

            var p1Value = mode1 == Mode.Immediate ? program[++currentPosition] : program[program[++currentPosition]];
            var p2Value = mode2 == Mode.Immediate ? program[++currentPosition] : program[program[++currentPosition]];

            if (
                (jumpMode == JumpMode.NonZero && p1Value == 0) ||
                (jumpMode == JumpMode.Zero && p1Value != 0)
            )
            {
                return currentPosition;
            }

            return p2Value - 1;
        }

        private int Ouput(int[] program, int currentPosition, int opAndModes)
        {
            var mode1 = (opAndModes / 100) % 10 == 0 ? Mode.Position : Mode.Immediate;

            var value = mode1 == Mode.Immediate ? program[++currentPosition] : program[program[++currentPosition]];

            Console.WriteLine($"Received ouput: {value}");

            return currentPosition;
        }

        private int Input(int[] program, int currentPosition, int opAndModes)
        {
            Console.Write("Please give input: ");

            var raw = Console.ReadLine();
            var value = Convert.ToInt32(raw);

            program[program[++currentPosition]] = value;

            return currentPosition;
        }

        public int Multiply(int[] program, int currentPosition, int opAndModes)
        {
            var mode1 = (opAndModes / 100) % 10 == 0 ? Mode.Position : Mode.Immediate;
            var mode2 = (opAndModes / 1000) % 10 == 0 ? Mode.Position : Mode.Immediate;
            //var mode3 = (opAndModes / 10000) % 10 == 0 ? Mode.Position : Mode.Immediate;

            var p1Value = mode1 == Mode.Immediate ? program[++currentPosition] : program[program[++currentPosition]];
            var p2Value = mode2 == Mode.Immediate ? program[++currentPosition] : program[program[++currentPosition]];
            //var param3 = mode3 == Mode.Immediate ? program[++current] : program[program[++current]];

            var result = p1Value * p2Value;

            Console.WriteLine($"Instruction at {currentPosition - 2}: {opAndModes}; {p1Value} * {p2Value} = {result}");

            program[program[++currentPosition]] = result;

            return currentPosition;
        }

        public int Sum(int[] program, int currentPosition, int opAndModes)
        {
            var mode1 = (opAndModes / 100) % 10 == 0 ? Mode.Position : Mode.Immediate;
            var mode2 = (opAndModes / 1000) % 10 == 0 ? Mode.Position : Mode.Immediate;
            //var mode3 = (opAndModes / 10000) % 10 == 0 ? Mode.Position : Mode.Immediate;

            var p1Value = mode1 == Mode.Immediate ? program[++currentPosition] : program[program[++currentPosition]];
            var p2Value = mode2 == Mode.Immediate ? program[++currentPosition] : program[program[++currentPosition]];
            //var param3 = mode3 == Mode.Immediate ? program[++current] : program[program[++current]];

            var result = p1Value + p2Value;

            Console.WriteLine($"Instruction at {currentPosition - 2}: {opAndModes}; {p1Value} + {p2Value} = {result}");

            program[program[++currentPosition]] = result;

            return currentPosition;
        }

        private enum Mode
        {
            Immediate,
            Position
        }

        private enum JumpMode
        {
            NonZero,
            Zero
        }

        private enum ComparisonMode
        {
            LessThan,
            Equals
        }

        public string Solve()
        {
            var file = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "days/5/input.txt");
            var line = File.ReadAllLines(file)[0];
            var raw = line.Split(',');
            var input = raw.Select(r => Convert.ToInt32(r)).ToArray();

            return Run(input).First().ToString();
        }
    }
}