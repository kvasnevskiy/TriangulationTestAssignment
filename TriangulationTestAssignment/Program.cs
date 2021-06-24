using System.Collections.Generic;
using System.Windows;
using TriangulationTestAssignment.Geometry;
using TriangulationTestAssignment.Geometry.Elements;
using TriangulationTestAssignment.Geometry.Triangulators;

namespace TriangulationTestAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            Polygon polygon = 
                new Polygon(
                    new List<Point>
                    {
                        new Point(1.0, 6.0),
                        new Point(4.0, 4.0),
                        new Point(8.0, 7.0),
                        new Point(11.0, 3.0),
                        new Point(2.0, 2.0)
                    });

            ITriangulator triangulator = new EarCuttingTriangulator();
            int[] indices = triangulator.Triangulate(polygon);
        }
    }
}
