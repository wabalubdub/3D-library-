using System.Runtime.Intrinsics;
using Boam3D.Geometry;
namespace test;

public class TestGeometry
{
    [Fact]
    public void runFirtsTest()
    {
        //Arrange
        //Act
        //Assert
        Assert.Equal(1,1);
    }

    [Fact]
    public void TestNormalizeFacet()
    {
       //Arrange
       Facet f = buildFacetOnXYPlane();
        //Act
        Vertex v1 = f.getNormal();
        //Assert
        Assert.Equal(0,v1.x,0.01);
        Assert.Equal(0,v1.y,0.01);
        Assert.Equal(1,v1.z,0.01);
    }
    public static Facet buildFacetOnXYPlane()
    {
        Vertex v1 = new Vertex(0,0,0);
        Vertex v2 = new Vertex(1,0,0);
        Vertex v3 = new Vertex(0,1,0);
        return new Facet(v1, v2, v3);
    }


}