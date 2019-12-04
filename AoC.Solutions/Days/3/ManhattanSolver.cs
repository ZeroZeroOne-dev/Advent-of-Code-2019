using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace AoC.Solutions.Days.Three
{
    public class ManhattanSolver : ISolution
    {
        public int GetClosestIntersectionDistance(string[] firstPath, string[] secondPath)
        {
            var visitedPoints = new Dictionary<Point, Paths>();

            AddPathToDictionary(visitedPoints, firstPath, Paths.FirstPath);
            AddPathToDictionary(visitedPoints, secondPath, Paths.SecondPath);

            var intersections = visitedPoints
                .Where(kv =>
                    kv.Value.HasFlag(Paths.FirstPath) &&
                    kv.Value.HasFlag(Paths.SecondPath))
                .Select(kv => kv.Key);

            var shortest = intersections
                .Select(p => Math.Abs(p.X) + Math.Abs(p.Y))
                .OrderBy(l => l)
                .First();

            return shortest;
        }

        private void AddPathToDictionary(Dictionary<Point, Paths> visitedPoints, string[] path, Paths pathName)
        {
            var current = new Point
            {
                X = 0,
                Y = 0
            };

            foreach (var actionAndDistance in path)
            {
                var actionCharacter = actionAndDistance[0];
                var distance = Convert.ToInt32(actionAndDistance.Substring(1));

                for (int i = 0; i < distance; i++)
                {
                    DoAction(ref current, actionCharacter);

                    if (visitedPoints.TryGetValue(current, out var visits))
                    {
                        visitedPoints[current] = visits | pathName;
                    }
                    else
                    {
                        visitedPoints[current] = pathName;
                    }
                }
            }
        }

        private static void DoAction(ref Point current, char action)
        {
            switch (action)
            {
                case 'U':
                    current.Y += 1;
                    break;
                case 'D':
                    current.Y -= 1;
                    break;
                case 'R':
                    current.X += 1;
                    break;
                case 'L':
                    current.X -= 1;
                    break;
                default:
                    throw new Exception("Unknown action");
            }
        }

        private struct Point
        {
            public int X { get; set; }
            public int Y { get; set; }
        }

        [Flags]
        private enum Paths
        {
            FirstPath = 1,
            SecondPath = 2,
        }

        public string Solve()
        {
            var file = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "days/3/input.txt");

            var lines = File.ReadAllLines(file);

            var firstPath = lines[0].Split(',');
            var secondPath = lines[1].Split(',');

            var result = GetClosestIntersectionDistance(firstPath, secondPath);

            return result.ToString();
        }
    }
}