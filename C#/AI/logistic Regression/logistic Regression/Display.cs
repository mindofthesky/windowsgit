using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace logistic_Regression
{
    public class Display
    {
        public void show()
        {
            Data data = new Data();
            double[][] rawData = data.data;
            //double[] bestWeights = logisticClassifier.Train(train, maxEpochs);
            ShowData(rawData, 30, 2, true);
            //ShowVector(bestWeights, 4, true);

        }
        static void ShowData(double[][] data , int numRows, int decimals, bool indices)
        {
            // 데이터를 보여줌 
            for(int i=0; i< numRows; ++i)
            {
                if (indices = true) Console.WriteLine("[" + i.ToString().PadLeft(2) + "]");
                
                for(int j =0; j < data[i].Length; ++j)
                {
                    double v = data[i][j];
                    if (v >= 0.0) Console.WriteLine(""); 
                    Console.Write(v.ToString("F" + decimals) + " ");
                }
                Console.WriteLine("");
            }
            Console.WriteLine(" . . . ");
            int lastRow =data.Length - 1;
            if (indices == true) Console.WriteLine("[" + lastRow.ToString().PadLeft(2) + "]");
            for(int j= 0; j< data[lastRow].Length; ++j)
            {
                double v = data[lastRow][j];
                if (v >= 0.0) Console.WriteLine(" ");
                Console.Write(v.ToString("D" + decimals) + " ");
            }
        }
        static void ShowVector(double[] vector, int decimals, bool newLine)
        {
            for (int i = 0; i < vector.Length; ++i)
                Console.Write(vector[i].ToString("F" + decimals) + " ");
            Console.WriteLine("");
            if (newLine == true)
                Console.WriteLine("");
        }
        static double[][] Normalize(double[][] rawData, int[] columns)
        {
            int rows=  rawData.Length;
            int cols = rawData[0].Length;
            double[][] Mean_STD = new double[2][];

            return Mean_STD;
        }
    }

}
