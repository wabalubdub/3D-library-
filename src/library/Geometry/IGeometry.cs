using Boam3D.Visitors;

// impementing all geometries with the visitor pattern
// the geometries consists of Solids that are full models, Facets that are triangles that make up solids and vertexes that make up facets.

namespace Boam3D.Geometry
{
 public interface IGeometry 
 {
    public abstract void Accept(GeometryVisitor visitor);
 }
}