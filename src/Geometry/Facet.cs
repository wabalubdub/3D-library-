using System.Dynamic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Boam3D.Geometry
    {
    public class Facet 
    {
        private Vertex v1;
        private Vertex v2;
        private Vertex v3;
        
        public Facet(Vertex v1, Vertex v2, Vertex v3){
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;
        }

        public IEnumerable<Vertex> GetVerticies(){
            yield  return v1;
            yield return v2;
            yield return v3;
        }

        public Vertex getNormal ()
        {
            Vertex line12 = Vertex.subtract(this.v2, this.v1);
            Vertex line13 = Vertex.subtract(this.v3 , this.v1);
            Vertex normal = Vertex.Cross(line12, line13);
            normal.normalize();
            return normal;
        }

        public override string ToString (){
            StringBuilder sb = new StringBuilder();
            sb.Append($"facet normal {this.getNormal}\n");
            sb.Append("outer loop\n");
            foreach (Vertex vertex in this.GetVerticies()){
                sb.Append($"vertex {vertex}\n");
            }
            sb.Append("endloop\n");
            sb.Append("endfacet\n");
            return sb.ToString();
        } 

    }

}