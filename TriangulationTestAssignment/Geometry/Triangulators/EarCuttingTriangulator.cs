using System.Collections.Generic;
using System.Linq;
using System.Windows;
using TriangulationTestAssignment.Geometry.Elements;

namespace TriangulationTestAssignment.Geometry.Triangulators
{
    public class EarCuttingTriangulator : ITriangulator
    {
        public int[] Triangulate(Polygon polygon)
        {
            int startCalculatedIndex = 0;
            int[] calculatedIndices = new int[(polygon.Count - 2) * 3];
           
            List<int> indexList = Enumerable.Range(0, polygon.Count).ToList();

            while (indexList.Count >= 3)
            {
                for (int i = 0; i < indexList.Count; i++)
                {
                    int previousIndex = GetIndex(indexList, i - 1);
                    int currentIndex = GetIndex(indexList, i);
                    int nextIndex = GetIndex(indexList, i + 1);

                    Point currentVertex = polygon[currentIndex];
                    Point previousVertex = polygon[previousIndex];
                    Point nextVertex = polygon[nextIndex];

                    Vector previousVector = previousVertex - currentVertex;
                    Vector nextVector = nextVertex - currentVertex;

                    if (Vector.CrossProduct(previousVector, nextVector) > 0)
                    {
                        if (IsTriangleCanBeEar(polygon, previousVertex, currentVertex, nextVertex))
                        {
                            calculatedIndices[startCalculatedIndex++] = previousIndex;
                            calculatedIndices[startCalculatedIndex++] = currentIndex;
                            calculatedIndices[startCalculatedIndex++] = nextIndex;

                            indexList.Remove(currentIndex);

                            break;
                        }
                    }
                }
            }

            return calculatedIndices;
        }

        private bool IsTriangleCanBeEar(Polygon polygon, Point a, Point b, Point c)
        {
            for (int i = 0; i < polygon.Count; i++)
            {
                var currentPoint = polygon[i];

                if (currentPoint == a || currentPoint == b || currentPoint == c)
                {
                    continue;
                }

                if (IsPointInTriangle(currentPoint, a, b, c))
                {
                    return false;
                }
            }

            return true;
        }

        private bool IsPointInTriangle(Point p, Point a, Point b, Point c)
        {
            Vector ab = b - a;
            Vector bc = c - b;
            Vector ca = a - c;

            Vector ap = p - a;
            Vector bp = p - b;
            Vector cp = p - c;

            return !(Vector.CrossProduct(ab, ap) > 0.0 || Vector.CrossProduct(bc, bp) > 0.0 || Vector.CrossProduct(ca, cp) > 0.0);
        }

        private int GetIndex(IList<int> indexList, int index)
        {
            if (index >= indexList.Count)
            {
                return indexList[index % indexList.Count];
            }
            else if (index < 0)
            {
                return indexList[index + indexList.Count];
            }
            else
            {
                return indexList[index];
            }
        }
    }
}
