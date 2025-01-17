using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Text;
using Boam3D.Visitors;

namespace Boam3D.Geometry
{
    public class Solid :IGeometry
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
        public IEnumerable<Vertex> GetVertices(){
            List<Vertex> returned_vertex = new List<Vertex>();
                foreach(Facet facet in facets){
                    foreach(Vertex vertex in facet.GetVerticies()){
                        if (!returned_vertex.Contains(vertex)){
                            returned_vertex.Add(vertex);
                            yield return vertex;
                        }
                    }
                } 
        }

        public bool hasVertex(Vertex vertex) {
            return this.GetVertices().Contains(vertex);
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

        public void Accept( GeometryVisitor visitor)
        {
            visitor.VisitSolid(this);
            foreach (Facet facet in facets)
            {
                facet.Accept(visitor);
            }
        }
        public static Solid ReadFromSTL (string s)
        {
            
            Solid returnSolid=new Solid();
            string[] lines =s.Split('\n');
            if (IsFormatIsValid(lines)){
            for (int i = 1; i+7<lines.Length ; i+=7 )
            {
                StringBuilder facetString = new StringBuilder("");
                for (int j = 0; j < 6; j++){
                    facetString.Append(lines[i+j]);
                    facetString.Append("\n");
                }
                facetString.Append(lines[i+6]);
                Facet nextFacet = Facet.ReadFromSTL(facetString.ToString());
                returnSolid.AddFacet(nextFacet);
            }
            return returnSolid;
            }
            else throw new Exception("invalid format");

        }

        private static bool IsFormatIsValid(string[] lines)
                {
                    if (lines.Length <2)
                    {
                        return false;
                    }
                    if (lines[0].Trim() != "solid model")
                    {
                        return false;
                    }
                    if (lines[lines.Length-1].Trim()!= "endsolid model")
                    {
                        return false; 
                    }
                    if (lines.Length%7!=2)
                    {
                        return false;
                    }
                    return true;
                }


    }

}