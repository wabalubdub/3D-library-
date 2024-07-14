using Boam3D.Geometry;

namespace Boam3D.Visitors
{
    public abstract class GeometryVisitor {
        public GeometryVisitor() 
        { }

        public virtual void VisitSolid(Solid solid) { }

        public virtual void VisitFacet(Facet facet) { }

        public virtual void VisitVertex(Vertex vertex) { }
    }
}