using Boam3D.Geometry;

namespace Boam3D.Test.utilities{


public class TestUtilities{

    public static Solid GenerateSolidShape(string pathToFile){
        StreamReader Sr =  new StreamReader(pathToFile);
        string pyramidString = Sr.ReadToEnd();
        Solid pyramid = Solid.ReadFromSTL(pyramidString);
        return pyramid;
    }
}
}