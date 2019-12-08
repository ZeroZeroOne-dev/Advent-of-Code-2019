using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Solutions.Days.Six
{
    public class OrbitCountFinder
    {
        private Dictionary<string, SpaceObject> spaceObjects;

        public int GetTotalOrbits(string[] relationMap)
        {
            MapObjects(relationMap);

            var root = spaceObjects.Values.First(s => s.Parent == null);

            return spaceObjects.Values.Sum(s => GetStepsFrom(s, root));
        }

        public int GetOrbitTransfers(string[] relationMap)
        {
            MapObjects(relationMap);

            var you = spaceObjects["YOU"];
            var santa = spaceObjects["SAN"];

            var youAnscestors = you.GetAnscestors();
            var santaAnscestors = santa.GetAnscestors();

            var earliestCommon = youAnscestors.Intersect(santaAnscestors).First();

            return GetStepsFrom(you.Parent, earliestCommon) + GetStepsFrom(santa.Parent, earliestCommon);
        }

        private void MapObjects(string[] relationMap)
        {
            spaceObjects = new Dictionary<string, SpaceObject>();

            foreach (var relation in relationMap)
            {
                var parentChild = relation.Split(')');
                var parentName = parentChild[0];
                var childName = parentChild[1];

                var parent = GetSpaceObject(parentName);
                var child = GetSpaceObject(childName);

                parent.Children.Add(child);
                child.Parent = parent;
            }
        }

        private int GetStepsFrom(SpaceObject lastChild, SpaceObject target, int count = 0)
        {
            if (lastChild.Name != target.Name)
            {
                count += 1;
                count = GetStepsFrom(lastChild.Parent, target, count);
            }

            return count;
        }

        private SpaceObject GetSpaceObject(string parentName)
        {
            if (spaceObjects.TryGetValue(parentName, out var spaceObject))
            {
                return spaceObject;
            }

            var newSpaceObject = new SpaceObject(parentName);
            spaceObjects.Add(parentName, newSpaceObject);

            return newSpaceObject;
        }
    }
}