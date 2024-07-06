namespace Boam3D.Geometry
{
public class Edge
{
    public Vertex v1 { get; set; }
    public Vertex v2 { get; set; }

    public Edge(Vertex v1, Vertex v2)
    {
        this.v1 = v1;
        this.v2 = v2;
    }
}

}