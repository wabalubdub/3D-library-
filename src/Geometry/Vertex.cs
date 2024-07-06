using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace Boam3D.Geometry
{
    public class Vertex
    {
        public double x{ get; private set; }
        public double y{ get; private set; }
        public double z{ get; private set; }

        private double Length; 

        public Vertex( double x, double y, double z ) 
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.CalculateLength();
        }

        private void CalculateLength()
        {
            this.Length = (double)Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2) + Math.Pow(z, 2));
        }

        public static Vertex subtract( Vertex v1, Vertex v2){
            return new Vertex(  v1.x - v2.x,  v1.y - v2.y, v1.z - v2.z );
        }

        public void normalize()
        {
            this.x = this.x/this.Length;
            this.y = this.y/this.Length;
            this.z = this.z/this.Length;
            this.Length = 1;

        }
        public override string ToString(){
            return $"{x} {y} {z}";
        }

        public static Vertex Cross ( Vertex v1, Vertex v2)
        {
                return new Vertex( v1.y*v2.z-v1.z*v2.y,v1.z*v2.x-v1.x*v2.z,v1.x*v2.y-v1.y*v2.x);
        }
    }
}