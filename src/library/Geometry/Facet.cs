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
            sb.Append($"facet normal {this.getNormal()}\n");
            sb.Append("outer loop\n");
            foreach (Vertex vertex in this.GetVerticies()){
                sb.Append($"vertex {vertex}\n");
            }
            sb.Append("endloop\n");
            sb.Append("endfacet");
            return sb.ToString();
        } 

        public static Facet ReadFromSTL (string s)
        {
            IEnumerator<string> lines = s.Split('\n').AsEnumerable<string>().GetEnumerator();
            lines.MoveNext();
            if (!lines.Current.StartsWith("facet normal")){ throw new Exception("facet, doesn't start with facet"); }
            string normal =lines.Current.Substring(13);//remove the facet normal part
            Vertex NormalVertex = Vertex.ReadFromSTL(normal);
            if (!lines.MoveNext()){throw new Exception("not correct format"); }
            if (!lines.Current.StartsWith("outer loop")){throw new Exception("not correct format");} 
            if (!lines.MoveNext()){throw new Exception("not correct format"); }
            if (!lines.Current.StartsWith("vertex ")){throw new Exception("not correct format");}
            string vertex1str =lines.Current.Substring(7);
            Vertex Vertex1 = Vertex.ReadFromSTL(vertex1str);
            if (!lines.MoveNext()){throw new Exception("not correct format"); }
            if (!lines.Current.StartsWith("vertex ")){throw new Exception("not correct format");}
            string vertex2str =lines.Current.Substring(7);
            Vertex Vertex2 = Vertex.ReadFromSTL(vertex2str);
            if (!lines.MoveNext()){throw new Exception("not correct format"); }
            if (!lines.Current.StartsWith("vertex ")){throw new Exception("not correct format");}
            string vertex3str =lines.Current.Substring(7);
            Vertex Vertex3 = Vertex.ReadFromSTL(vertex3str);
            if (!lines.MoveNext()){throw new Exception("not correct format"); }
            if (!lines.Current.StartsWith("endloop")){throw new Exception("not correct format");}
            if (!lines.MoveNext()){throw new Exception("not correct format"); }
            if (!lines.Current.StartsWith("endfacet")){throw new Exception("not correct format");}
            Facet returnFacet =  new Facet (Vertex1, Vertex2, Vertex3);
            Vertex calculatedNormal = returnFacet.getNormal();
            if (!calculatedNormal.Equals(NormalVertex)) {throw new Exception("normal is not correct");}
            return returnFacet;
        }
    }

}