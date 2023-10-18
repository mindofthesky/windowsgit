namespace VMLLib.KMeans
{
    public interface IDistance
    {
        double Run(double[] array1, double[] array2);
    }
}
