using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMLLib.KMeans
{
    public class EuclideanDistance : IDistance
    {
        public double Run(double[] array1, double[] array2)
        {
            double res = 0.0;
            for(int i =0; i< array1.Length; i++)
            {
                res += Math.Pow(array1[i] - array2[i], 2);
            }

            return Math.Sqrt(res);
        }
    }
}
