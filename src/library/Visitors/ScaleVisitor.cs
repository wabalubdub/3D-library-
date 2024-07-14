using Boam3D.Geometry;

namespace Boam3D.Visitors
{

    public class ScaleVisitor : GeometryVisitor{

        private double ScaleX;
        private double ScaleY;
        private double ScaleZ;
        public ScaleVisitor(double ScaleX, double ScaleY, double ScaleZ){
            this.ScaleX = ScaleX;
            this.ScaleY = ScaleY;
            this.ScaleZ = ScaleZ;
        } 

        public override void VisitVertex(Vertex vertex){
            vertex.x *= ScaleX;
            vertex.y *= ScaleY;
            vertex.z *= ScaleZ;
        }
    }
}