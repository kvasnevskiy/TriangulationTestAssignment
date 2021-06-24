using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TriangulationTestAssignment.Geometry.Elements
{
    public class Polygon
    {
        private IList<Point> points;

        public Point this[int index]
        {
            get
            {
                return points[index];
            }
        }

        public int Count => points.Count;

        public Polygon(IList<Point> points)
        {
            this.points = points;
        }
    }
}
