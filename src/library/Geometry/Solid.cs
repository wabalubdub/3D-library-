using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Text;

namespace Boam3D.Geometry
{
    public class Solid 
    {
        private List<Facet> facets;

        public Solid()
        {
            this.facets = new List<Facet>();
        }

        public Solid(IEnumerable<Facet> facets)
        {
            this.facets = facets.ToList();
        }

        public void AddFacet(Facet facet)
        {
            facets.Add(facet);
        }
        public int CountFacets(){
            return facets.Count;
            
        }

        public override string ToString(){
            StringBuilder sb = new StringBuilder();
            sb.Append("solid model\n");
            foreach (Facet facet in facets){
                sb.Append(facet.ToString());
                sb.Append("\n");
            }
            sb.Append("endsolid model");
            return sb.ToString();
        }

        public static Solid ReadFromSTL (string s)
        {
            Solid returnSolid=new Solid();
            IEnumerator<string> lines = (IEnumerator<string>)s.Split('\n').AsEnumerable<string>().GetEnumerator();
            lines.MoveNext();
            if (!lines.Current.StartsWith("solid model")){
                throw new Exception("unrecognized format, solid model isn't the first line");
            }
            try {lines.MoveNext();} catch {throw  new Exception("unrecognized format, no body");}
            while (!lines.Current.StartsWith("endsolid model")){
                StringBuilder facetString = new StringBuilder("");
                while (!lines.Current.StartsWith( "endfacet"))
                {
                    facetString.Append(lines.Current);
                    facetString.Append("\n");
                    try {lines.MoveNext();} catch {throw  new Exception("unrecognized format, no endfacet decleration");}
                }
                facetString.Append(lines.Current);
                Facet nextFacet = Facet.ReadFromSTL(facetString.ToString());
                returnSolid.AddFacet(nextFacet);
                lines.MoveNext();
            }
            return returnSolid;

        }
    }
}