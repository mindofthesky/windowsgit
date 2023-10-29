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
            double[][] rawData = data.data; // 데이터값 배열 

            SplitTrainTestData(rawData, 80, out double[][] train, out double[][] test);
            int numOfFeatures = 3;
            int maxEpochs = 100;
            int[] column = new int[] { 0, 2 };
            
            logisticClassifier logisticClassifier = new logisticClassifier(numOfFeatures);
            double[] bestWeights = logisticClassifier.Train(train, maxEpochs);
            ShowData(rawData, 30, 3, true);
            //Normalize(rawData, column);
            ShowVector(bestWeights, 4, true);
             

        }
        static void ShowData(double[][] data , int? numRows, int?  decimals, bool indices)
        {
            // 데이터를 보여줌 
            for(int i=0; i< numRows; ++i)
            {
                if (indices == true) Console.WriteLine("[" + i.ToString().PadLeft(2) + "]");
                
                for(int j =0; j < data[i].Length; ++j)
                {
                    double v = data[i][j];
                    if (v >= 0.0) Console.WriteLine(" "); 
                    Console.Write(v.ToString("F" + decimals) + " ");
                }
                Console.WriteLine("\n");
            }
            
            Console.WriteLine(" . . . ");
            int lastRow = data.Length - 1;

            if (indices == true) Console.WriteLine("[" + lastRow.ToString().PadLeft(2) + "]");
            
            for (int j= 0; j< data[lastRow].Length; ++j)
            {
                double v = data[lastRow][j];
                if (v >= 0.0) Console.WriteLine(" ");         
                //Console.Write(v.ToString("D" + decimals) + " ");
            }
        }
        static void ShowVector(double[] vector, int decimals, bool newLine)
        {
            for (int i = 0; i < vector.Length; ++i)
                Console.Write(vector[i].ToString("F" + decimals) + " ");
            Console.WriteLine(" ");
            if (newLine == true)
                Console.WriteLine(" ");
        }
        public static double[][] Normalize(double[][] rawData, int[] columns)
        {
            int rows=  rawData.Length;
            int cols = rawData[0].Length;
            double[][] Mean_STD = new double[2][];
            double[][] normalizerddata = new double[rawData.Length][];

            for(int i=0; i<2; i++)
            {
                Mean_STD[i] = new double[cols];
            }
            for(int i=0; i< cols; i++)
            {
                double sum = 0;
                for(int j =0; j< rows; j++) sum += Mean_STD[j][i];
                double mean = sum / rows;
                Mean_STD[0][i] = mean;
                double sumsquares = 0;
                for (int k = 0; k < rows; k++) sumsquares += (rawData[k][i] - mean) * (rawData[k][i] - mean);
                double stdDev = Math.Sqrt(sumsquares / rows);
                Mean_STD[1][i] = stdDev;

            }
            for(int i=0; i< columns.Length; i++)
            {
                int column = columns[i];
                double mean = Mean_STD[0][column];
                double stdDev = Mean_STD[1][column];
                for(int j =0; j< rows; j++) rawData[j][column] = (rawData[j][column] - mean) / stdDev;
            }
            return Mean_STD;
        }
        public void SplitTrainTestData(double[][] rawData, double percentForTrain, out double[][] train, out double[][] test)
        {
            train = rawData.Take((int)Math.Floor(rawData.Length * (percentForTrain / 100))).ToArray();
            test = rawData.Skip((int)Math.Floor(rawData.Length * (percentForTrain / 100))).ToArray();

            Console.WriteLine($"Creating train ({percentForTrain}%) and test ({100 - percentForTrain}%) matrices");
        }
    }

}
