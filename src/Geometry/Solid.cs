using System.Text;

namespace Boam3D.Geometry
{
    public class Solid 
    {
        private List<Facet> facets;

        public Solid(IEnumerable<Facet> facets)
        {
            this.facets = facets.ToList();
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
    }
}