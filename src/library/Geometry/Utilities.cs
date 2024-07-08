namespace Boam3D.Geometry
{
    public static class Utilities{

        public static bool IsEdgeInFacet(Edge edge, Facet facet)
        {
            if (!facet.GetVerticies().Contains(edge.v1)){return false;}
            else if (!facet.GetVerticies().Contains(edge.v2)){return false;}
            return true;
        }
    }
}
