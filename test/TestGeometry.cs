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
        [InlineData(".\\..\\..\\..\\test utilities\\pyramid.stl", 4)]
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
            // Given
            throw new NotImplementedException();
        
            // When
        
            // Then
        }

        [Theory]
        [InlineData(".\\..\\..\\..\\test utilities\\pyramid.stl", 0,0,0,1,1,1)]
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