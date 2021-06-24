using TriangulationTestAssignment.Geometry.Elements;

namespace TriangulationTestAssignment.Geometry.Triangulators
{
    interface ITriangulator
    {
        int[] Triangulate(Polygon polygon);
    }
}
