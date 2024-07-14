using Boam3D.Geometry;

namespace Boam3D.Visitors
{
    public class GeometryVisitor {
        public GeometryVisitor() 
        { }

        public void VisitSolid(Solid solid) { }

        public void VisitFacet(Facet facet) { }

        public void VisitVertex(Vertex vertex) { }
    }
}