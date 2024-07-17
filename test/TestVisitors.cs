using Boam3D.Geometry;
using Boam3D.Visitors;
using Boam3D.Test.utilities;

namespace test{




    public class TestVisitors
    {
        [Theory]
        [InlineData(1,2,3,"../../../test utilities/pyramid.stl")] // pyramid with edges (000) (100) (010) (001)
        [InlineData(0,0,0,"../../../test utilities/pyramid.stl")]
        public void testOffsetVisitor(double XOffset,double YOffset, double ZOffset,string pathToFile)
        {
            //Arrange
            OffsetVisitor offsetVisitor = new OffsetVisitor(XOffset, YOffset, ZOffset);
            Solid pyramid = TestUtilities.GenerateSolidShape(pathToFile); 
            IEnumerable<Vertex> Vertexs = pyramid.GetVertices();
            Vertex[] TestVertecies =Vertexs.Select(ver=> new Vertex(ver.x+XOffset,ver.y+YOffset,ver.z+ZOffset)).ToArray();
            // Act
            pyramid.Accept(offsetVisitor);

            //Assert
            foreach (Vertex v in TestVertecies){
                Assert.True(pyramid.hasVertex(v));
            }




        }
        [Theory]
        [InlineData(1,2,3,"../../../test utilities/pyramid.stl")] // pyramid with edges (000) (100) (010) (001)
        [InlineData(0,0,0,"../../../test utilities/pyramid.stl")]
        public void testscaleVisitor(double XScale,double YScale, double ZScale,string pathToFile)
        {
            //Arrange
            ScaleVisitor offsetVisitor = new ScaleVisitor(XScale, YScale, ZScale);
            Solid pyramid = TestUtilities.GenerateSolidShape(pathToFile); 
            IEnumerable<Vertex> Vertexs = pyramid.GetVertices();
            Vertex[] TestVertecies =Vertexs.Select(ver=> new Vertex(ver.x*XScale,ver.y*YScale,ver.z*ZScale)).ToArray();
            // Act
            pyramid.Accept(offsetVisitor);

            //Assert
            foreach (Vertex v in TestVertecies){
                Assert.True(pyramid.hasVertex(v));
            }
        }
    }
}