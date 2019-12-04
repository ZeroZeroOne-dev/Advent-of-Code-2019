using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Solutions.Days.Three
{
    public class ManhattanSolver : ISolution
    {
        public int GetClosestIntersectionDistance(string[] firstPath, string[] secondPath)
        {
            var visitedPoints = new Dictionary<Point, int>();

            AddPathToDictionary(visitedPoints, firstPath);
            AddPathToDictionary(visitedPoints, secondPath);

            var intersections = visitedPoints.Where(kv => kv.Value > 1).Select(kv => kv.Key);
            var shortest = intersections.Select(p => Math.Abs(p.X) + Math.Abs(p.Y)).OrderBy(l => l).First();

            return shortest;
        }

        private void AddPathToDictionary(Dictionary<Point, int> visitedPoints, string[] path)
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
                        visitedPoints[current] = ++visits;
                    }
                    else
                    {
                        visitedPoints[current] = 1;
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

        public string Solve()
        {
            throw new System.NotImplementedException();
        }

        private struct Point
        {
            public int X { get; set; }
            public int Y { get; set; }
        }
    }
}