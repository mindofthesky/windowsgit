using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMLLib.KMeans
{
    public class KMeansEventArgs
    {
        private List<Centroid> _centroidList;
        public List<Centroid> CentroidList
        {
            get { return _centroidList; }
        }

        private double[][] _dataset;
        public double[][] Dataset
        {
            get { return _dataset; }
        }

        public KMeansEventArgs(List<Centroid> centroidList, double[][] dataset)
        {
            _centroidList = centroidList;
            _dataset = dataset;
        }
    }
}
