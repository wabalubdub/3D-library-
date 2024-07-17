using System.Runtime.Intrinsics;
using Boam3D.Geometry;
using System.IO;
using Newtonsoft.Json.Linq;
using Boam3D.Test.utilities;
namespace test{

    public class TestGeometry
    {

        [Fact]
        public void TestGetNormalFacet()
        {
        //Arrange
        Facet f = TestUtilities.buildFacetOnXYPlane();
            //Act
            Vertex v1 = f.getNormal();
            //Assert
            Assert.Equal(0,v1.x,0.01);
            Assert.Equal(0,v1.y,0.01);
            Assert.Equal(1,v1.z,0.01);
        }
        
        [Theory]
        [InlineData (30,5,-20,0.824,0.137,-0.549)]
        [InlineData(0,0,10,0,0,1)]
        [InlineData (1,1,1,0.577,0.577,0.577)]
        public void TestNormalizeVertex(double x, double y, double z, double expectedX, double expectedY, double expectedZ)
        {
            //Arrange
            Vertex v = new Vertex(x,y,z);

            //Act
            v.normalize();

            //Assert

            Assert.Equal(expectedX,v.x,0.01);Assert.Equal(expectedY,v.y,0.01);Assert.Equal(expectedZ,v.z,0.01);
        }

        [Theory]
        [InlineData("../../../test utilities/pyramid.stl", 4)]
        public void TestLoadSolidFacet(string pathToFile, int numberOfFacets)
        {
            //Arrange  //Act
            Solid Shape = TestUtilities.GenerateSolidShape(pathToFile);
            
            //Assert
            Assert.IsType<Solid>(Shape);
            Assert.Equal(numberOfFacets,Shape.CountFacets());
        }
        
        [Fact(Skip="unsure what this method should do (*repeating vertices)")]
        public void TestgetVertecies() // missing this test because im not sure what i want this function to do exactly
        {
            // Arrange
            Vertex v1 = new Vertex(0,0,0);
            Vertex v2 = new Vertex(1,1,1);
            Vertex v3 = new Vertex(2,1,1);
            Vertex v4 = new Vertex(1,2,2);

            Facet f1 = new Facet(v1,v2,v3);
            Facet f2 = new Facet(v2,v1,v4);
            Facet f3 = new Facet(v3,v2,v4);
            Facet f4 = new Facet(v1,v3,v4);

            Solid solidWithOneFacet = new Solid([f1]);
            Solid solidWithTwoFacet = new Solid([f1,f2]);
            Solid solidWithFourFacet = new Solid([f1,f2,f3,f4]);
        
            // Act
            Vertex[] oneFacetVertexes = solidWithOneFacet.GetVertices().ToArray();
            Vertex[] twoFacetVertexes = solidWithTwoFacet.GetVertices().ToArray();
            Vertex[] fourFacetVertexes = solidWithFourFacet.GetVertices().ToArray();

            // Assert
            
            Assert.Equal(3, oneFacetVertexes.Length); 
            Assert.Contains(v1,oneFacetVertexes);
            Assert.Contains(v2,oneFacetVertexes);
            Assert.Contains(v3,oneFacetVertexes);

            Assert.Equal(4, twoFacetVertexes.Length); 
            Assert.Contains(v1,twoFacetVertexes);
            Assert.Contains(v2,twoFacetVertexes);
            Assert.Contains(v3,twoFacetVertexes);
            Assert.Contains(v4,twoFacetVertexes);

            Assert.Equal(4, fourFacetVertexes.Length); 
            Assert.Contains(v1,fourFacetVertexes);
            Assert.Contains(v2,fourFacetVertexes);
            Assert.Contains(v3,fourFacetVertexes);
            Assert.Contains(v4,fourFacetVertexes);



        }

        [Theory]
        [InlineData("../../../test utilities/pyramid.stl", 0,0,0,1,1,1)]
        public void TesthasVertex(string pathToFile, double vertexInShapeX, double vertexInShapeY, double vertexInShapeZ, double vertexNotInShapeX, double vertexNotInShapeY,double vertexNotInShapeZ)
        {
            // Given
            Vertex VertexInShape = new Vertex(vertexInShapeX,vertexInShapeY,vertexInShapeZ);
            Vertex VertexNotInShape = new Vertex(vertexNotInShapeX, vertexNotInShapeY, vertexNotInShapeZ);
            Solid shape = TestUtilities.GenerateSolidShape(pathToFile);
            // When
            bool ShapeHasVertexInShape = shape.hasVertex(VertexInShape);
            bool ShapeDosentHaveVertexNotInShape = shape.hasVertex(VertexNotInShape);
        
            // Then
            Assert.True(ShapeHasVertexInShape);
            Assert.False(ShapeDosentHaveVertexNotInShape);
        }
    }
}