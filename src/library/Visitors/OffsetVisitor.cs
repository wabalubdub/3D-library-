using Boam3D.Geometry;

namespace Boam3D.Visitors
{
    public class OffsetVisitor : GeometryVisitor{

        private double OffsetX;
        private double OffsetY;
        private double OffsetZ;
        public OffsetVisitor(double OffsetX, double OffsetY, double OffsetZ){
            this.OffsetX = OffsetX;
            this.OffsetY = OffsetY;
            this.OffsetZ = OffsetZ;
        } 

        public override void VisitVertex(Vertex vertex){
            vertex.x += OffsetX;
            vertex.y += OffsetY;
            vertex.z += OffsetZ;
        }

    }
}