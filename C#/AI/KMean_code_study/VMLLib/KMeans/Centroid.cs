using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VMLLib.KMeans
{
    public class Centroid
    {
        /// <summary>
        /// 변수 선언 
        /// 배열 <parma = double[] array 배열 >
        /// </summary>
        private double[] _array;
        private List<double[]> _oldPaintsList;
        private List<double[]> _ClosestPointsList;
        private static Random random = new Random();
        public double[] Array
        {
            get { return _array; }
        }

        public Color _color;

        public Color CentroidColor
        {
            get { return _color; }
        }
        public Centroid(double[][] dataSet)
        {
            _color = Color.White;
            List<Tuple<double, double>> minmaxPoint = Misc.GetMinMaxPoints(dataSet);

            _array = new double[minmaxPoint.Count];
            int i = 0;
            foreach(Tuple<double,double> tuple in minmaxPoint)
            {
                double minimum = tuple.Item1;
                double maximum = tuple.Item2;
                double element = random.NextDouble() * (maximum - minimum) + maximum;
                _array[i] = element;
                i++;
            }
            _oldPaintsList = new List<double[]>();  
            _ClosestPointsList = new List<double[]>();
        }
        public Centroid(double[][] dataSet, Color color)
        {
            _color = color;

            List<Tuple<double, double>> minMaxPoints = Misc.GetMinMaxPoints(dataSet);

            _array = new double[minMaxPoints.Count];

            int i = 0;

            foreach(Tuple<double, double> tuple in minMaxPoints)
            {
                double minimum = tuple.Item1;
                double maximum = tuple.Item2;
                double element = random.NextDouble() * (maximum - minimum) + maximum;
                _array[i] = element;
                i++;
            }
            _oldPaintsList = new List<double[]>();
            _ClosestPointsList = new List<double[]>();
        }


        public void addPoint(double[] closetArray)
        {
            _ClosestPointsList.Add(closetArray);
        }
        public void DrawMe(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.FillEllipse(new SolidBrush(_color), (float)_array[0], (float)_array[1], 15, 15);

            foreach (double[] point in _ClosestPointsList)
            {
                g.DrawEllipse(new Pen(_color, 2.0f), (float)point[0], (float)point[1], 10, 10);
            }
        }
        public void MoveCentroid()
        {
            List<double> resultVector = new List<double>();
            if (_ClosestPointsList.Count == 0) return;

            for(int j =0; j < _ClosestPointsList[0].GetLength(0); j++)
            {
                double sum = 0.0;
                for(int i = 0; i <_ClosestPointsList.Count; i++)
                {
                    sum += _ClosestPointsList[i][j];
                }
                sum /= _ClosestPointsList.Count; ;
                resultVector.Add(sum);
            }
            _array = resultVector.ToArray();
        }

        public bool HasChanged()
        {
            bool result = true;
            if (_oldPaintsList.Count != _ClosestPointsList.Count) return true;
            if(_oldPaintsList.Count == 0 || _ClosestPointsList.Count == 0) return false;
            for(int i =0; i < _ClosestPointsList.Count; i++)
            {
                double[] oldPoit = _oldPaintsList[i];
                double[] currentPoint = _ClosestPointsList[i];

                for(int j =0; j <oldPoit.Length; j++)
                {
                    if (oldPoit[j] != currentPoint[j])
                    {
                        result = false; break;
                    }
                }
            }
            return !result;
        }
        public void Reset()
        {
            _oldPaintsList = Misc.Clone(_ClosestPointsList);
            _ClosestPointsList.Clear();
        }

        public override string ToString()
        {
            return String.Join(",", _array);
        }
    }
}
