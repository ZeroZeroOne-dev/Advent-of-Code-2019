using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace AoC.Solutions.Days.Three
{
    public class ManhattanSolver
    {
        public int GetClosestIntersectionDistance(string[] firstPath, string[] secondPath)
        {
            var intersections = GetIntersections(firstPath, secondPath);

            var shortest = intersections
                .Select(kv => kv.Key)
                .Select(p => Math.Abs(p.X) + Math.Abs(p.Y))
                .OrderBy(l => l)
                .First();

            return shortest;
        }

        // part 2
        public int GetStepsFewestCombinedIntersection(string[] firstPath, string[] secondPath)
        {
            var intersections = GetIntersections(firstPath, secondPath);

            var shortest = intersections.Select(kv => kv.Value.Sum(v => v.Steps)).OrderBy(kv => kv).First();

            return shortest;
        }

        private IEnumerable<KeyValuePair<Point, List<PointVisit>>> GetIntersections(string[] firstPath, string[] secondPath)
        {
            var visitedPoints = new Dictionary<Point, List<PointVisit>>();

            AddPathToDictionary(visitedPoints, firstPath, Paths.FirstPath);
            AddPathToDictionary(visitedPoints, secondPath, Paths.SecondPath);

            var intersections = visitedPoints
                .Where(kv => kv.Value.Any(v => v.Visitor == Paths.FirstPath))
                .Where(kv => kv.Value.Any(v => v.Visitor == Paths.SecondPath));

            return intersections;
        }

        private void AddPathToDictionary(Dictionary<Point, List<PointVisit>> visitedPoints, string[] path, Paths pathName)
        {
            var current = new Point
            {
                X = 0,
                Y = 0
            };

            var walkedDistance = 0;

            foreach (var actionAndDistance in path)
            {
                var actionCharacter = actionAndDistance[0];
                var distance = Convert.ToInt32(actionAndDistance.Substring(1));

                for (int i = 0; i < distance; i++)
                {
                    walkedDistance++;
                    DoAction(ref current, actionCharacter);

                    if (visitedPoints.TryGetValue(current, out var visits))
                    {
                        visitedPoints[current].Add(new PointVisit
                        {
                            Visitor = pathName,
                            Steps = walkedDistance
                        });
                    }
                    else
                    {
                        visitedPoints[current] = new List<PointVisit>{
                            new PointVisit{
                                Visitor = pathName,
                                Steps = walkedDistance
                            }
                        };
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

        private struct PointVisit
        {
            public Paths Visitor { get; set; }
            public int Steps { get; set; }
        }

        private enum Paths
        {
            FirstPath = 1,
            SecondPath = 2,
        }


    }
}