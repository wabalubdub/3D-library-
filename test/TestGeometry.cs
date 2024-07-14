using System.Runtime.Intrinsics;
using Boam3D.Geometry;
using System.IO;
using Newtonsoft.Json.Linq;
namespace test;

public class TestGeometry
{
    [Fact]
    public void RunFirstTest()
    {
        //Arrange
        //Act
        //Assert
        Assert.Equal(1,1);
    }

    [Fact]
    public void TestGetNormalFacet()
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

    [Fact]
    public void TestNormalizeVertex()
    {
        //Arrange
        Vertex v1 = new Vertex(30,5,-20);
        Vertex v2 = new Vertex(0,0,10);
        Vertex v3 = new Vertex(1,1,1);
        //Act
        v1.normalize();
        v2.normalize();
        v3.normalize();
        //Assert

        Assert.Equal(0.824,v1.x,0.01);Assert.Equal(0.137,v1.y,0.01);Assert.Equal(-0.549,v1.z,0.01);
        Assert.Equal(0,v2.x,0.01);Assert.Equal(0,v2.y,0.01);Assert.Equal(1, v2.z,0.01);
        Assert.Equal(0.577,v3.x,0.01);
    }

    [Fact]
    public void TestLoadSolidFacet()
    {
        //Arrange 
        StreamReader Sr = new StreamReader(".\\..\\..\\..\\test utilities\\20mm_cube.stl");
        string cubeString = Sr.ReadToEnd();
        Sr = new StreamReader(".\\..\\..\\..\\test utilities\\pyramid.stl");
        string pyramidString = Sr.ReadToEnd();
        //Act
        Solid cube = Solid.ReadFromSTL(cubeString);
        Solid pyramid = Solid.ReadFromSTL(pyramidString);
        //Assert
        Assert.IsType<Solid>(cube);
        Assert.Equal(12,cube.CountFacets());

        Assert.IsType<Solid>(cube);
        Assert.Equal(4, pyramid.CountFacets());
    }

}