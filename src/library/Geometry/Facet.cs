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
            string[] lines = s.Split('\n');
            if (IsFormatIsValid(lines))
            {
                string[] normal =System.Text.RegularExpressions.Regex.Split(lines[0], @"\s+");
                Vertex NormalVertex = Vertex.ReadFromSTL($"{normal[2]} {normal[3]} {normal[4]}");
                string[] vertex1str = System.Text.RegularExpressions.Regex.Split(lines[2], @"\s+");
                Vertex Vertex1 = Vertex.ReadFromSTL($"{vertex1str[1]} {vertex1str[2]} {vertex1str[3]}");
                string[] vertex2str =System.Text.RegularExpressions.Regex.Split(lines[3], @"\s+");
                Vertex Vertex2 = Vertex.ReadFromSTL($"{vertex2str[1]} {vertex2str[2]} {vertex2str[3]}");
                string[] vertex3str =System.Text.RegularExpressions.Regex.Split(lines[4], @"\s+");
                Vertex Vertex3 = Vertex.ReadFromSTL($"{vertex3str[1]} {vertex3str[2]} {vertex3str[3]}");
                Facet returnFacet =  new Facet (Vertex1, Vertex2, Vertex3);
                Vertex calculatedNormal = returnFacet.getNormal();
                if (!calculatedNormal.Equals(NormalVertex)) {throw new Exception("normal is not correct");}
                return returnFacet;
            }
            else 
            {
                throw new Exception("not correct format");
            }
            
        }

        private static bool IsFormatIsValid(string[] lines)
        {
            if (lines.Length!=7) 
            {
                return false;
            }
            if (!lines[0].StartsWith("facet normal "))
            {
                return false;
            }
            if (lines[1].Trim()!="outer loop")
            {
                return false;
            }
            if (!(lines[2].StartsWith("vertex ")&&lines[3].StartsWith("vertex ")&&lines[4].StartsWith("vertex ")))
            {
                return false;
            }
            if (lines[5].Trim()!="endloop")
            {
                return false;
            }
            if (lines[6].Trim()!="endfacet")
            {
                return false;
            }
            return true;
        }
    }

}