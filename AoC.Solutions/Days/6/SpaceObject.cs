using System.Collections.Generic;
using System.Linq;

namespace AoC.Solutions.Days.Six
{
    public class SpaceObject
    {
        public string Name { get; set; }
        public SpaceObject Parent { get; set; }
        public List<SpaceObject> Children { get; set; }

        public IEnumerable<SpaceObject> GetAnscestors()
        {
            var anscestors = new List<SpaceObject>();

            SpaceObject current = this;
            while (current.Parent != null)
            {
                anscestors.Add(current.Parent);
                current = current.Parent;
            }

            return anscestors;
        }

        public SpaceObject(string name)
        {
            this.Name = name;
            Children = new List<SpaceObject>();
        }
    }
}