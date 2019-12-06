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
                    case 99:
                        return program;
                    default:
                        return program;
                }

                currentPosition++;
            }

            return program;
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