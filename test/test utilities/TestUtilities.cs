using Boam3D.Geometry;

namespace Boam3D.Test.utilities{


public class TestUtilities{

    public static Solid GenerateSolidShape(string pathToFile){
        StreamReader Sr =  new StreamReader(pathToFile);
        string pyramidString = Sr.ReadToEnd();
        Solid pyramid = Solid.ReadFromSTL(pyramidString);
        return pyramid;
    }

    public static Facet buildFacetOnXYPlane()
        {
            Vertex v1 = new Vertex(0,0,0);
            Vertex v2 = new Vertex(1,0,0);
            Vertex v3 = new Vertex(0,1,0);
            return new Facet(v1, v2, v3);
        }

}
}