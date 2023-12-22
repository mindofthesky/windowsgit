using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logistic_Regression
{
     class logisticClassifier
    {
        private int numFeatures;
        private double[] weights;
        private Random rnd;

        public logisticClassifier(int  numFeatures)
        {
            this.numFeatures = numFeatures; // value 3 
            this.weights = new double[numFeatures + 1]; // value 4 
        }
        public double[] Centroids(double[] good, double[] best)
        {   // 특색보다 하나더 많은값 4 centroid 4 
            double[] centroids = new double[this.numFeatures + 1];
            for (int i= 0; i< centroids.Length; i++) centroids[i] = (good[i] + best[i]) * 0.5;
            return centroids;
            
        }
        public double[] Expanded(double[] centroids, double[] worst)
        {
            //expanded = value 4 
            // 값이 계속내려감~ 0이되면 종료
            double[] expanded = new double[this.numFeatures + 1];
            for (int i = 0; i < expanded.Length; i++)  expanded[i] = centroids[i] + ((centroids[i] - worst[i]) * 2);
            return expanded;
        }
        public double[] Reflected(double[] centroids, double[] worst)
        {
            double[] reflected = new double[this.numFeatures + 1];
            for (int i = 0; i < reflected.Length; i++) reflected[i] = 2 * centroids[i] - worst[i];
            return reflected;
        }
        public double[] Contracted(double[] centroids, double[] worst)
        {   // 4 > system.double[] 
            double[] contracted = new double[this.numFeatures + 1];
            for (int i = 0; i < contracted.Length; i++)  contracted[i] = contracted[i] - (0.5 * (centroids[i] - worst[i]));
            // 한없이 1에 가까워짐 
            return contracted;
        }
        public double[] RandomPoint()
        {
            rnd = new Random();
            double[] point = new double[this.numFeatures +1];
            for(int i=0; i < point.Length; i++) point[i] = 20 * rnd.NextDouble();
                //Console.WriteLine("랜덤값" +  point[i]);
            
            return point;
        }
        public double output(double[] dataItem, double[] weights)
        {
            double z = 0.0;
            z += weights[0];
            for (int i = 1; i < dataItem.Length; i++) z += weights[i] * dataItem[i - 1];
            double sigmoid = 1.0 / (1.0 + Math.Exp(-z));
            //Console.WriteLine(sigmoid);
            // 시그모이드 함수는 0 < x < 1 값 내외
            return sigmoid;
        }
        public int Dependent(double[] dataItem, double[] weights)
        {
            double sum = output(dataItem, weights);
            if (sum <= 0) return 0;
            else return 1;
        }
        public double Accuracy(double[][] trainData, double[] weights)
        {
            int correct = 0;
            int wrong = 0;
            int yColumn = trainData[0].Length - 1; 
            for(int i= 0; i< trainData.Length; i++)
            {
                double computed = Dependent(trainData[i],weights);
                double desired = trainData[i][yColumn];
                if(computed == desired) correct++;
                else wrong++;
            }
            double accuracy = (double)correct / (correct + wrong);
            //Console.WriteLine(accuracy);
            return accuracy;
        }
        public double Error(double[][] trainData, double[] weights)
        {
           
            int yColumn = trainData[0].Length - 1; // 3 
            double sumSquaredError = 0.0;
            for (int i = 0; i < trainData.Length; i++)
            {
                double computed = output(trainData[i], weights);
                double desired = trainData[i][yColumn];
                sumSquaredError += (computed - desired) * (computed - desired);
                //Console.WriteLine("종합 에러율 :"  + sumSquaredError);
            }
            return sumSquaredError / trainData.Length;
        }
        private class Solution : IComparable<Solution>
        {
            public double[] weights;
            public double error;
            public Solution(int numFeatures)
            {

                //values =4 
                //this.weight System.double[] 
                this.weights = new double[numFeatures + 1];
                this.error = 0.0;
            }
            public int CompareTo(Solution? other)
            {
                if (this.error < other.error) return -1;
                else if (this.error > other.error) return 1;
                else return 0;
             
            }
        }


        #region Traing 
        // maxEpoche =100; 
        public double[] Train(double[][] trainData, int maxEpochs)
        {
            rnd = new Random();
            Solution[] solutions = new Solution[5];
            for (int i = 0; i < 5; i++)
            {
                //values soultion[0] = new numFeatures 3  >wieghit = 4 
                
                solutions[i] = new Solution(numFeatures);
                //soultion 0 = 4, 
                solutions[i].weights = RandomPoint();
                solutions[i].error = Error(trainData, solutions[i].weights);
            }
            int best = 0;
            int good = 1;
            int worst = 2;

            int epoch = 0;
            // 100 까지 무한반복 
            while (epoch < maxEpochs)
            {
                // 들어오자마자 선증가 1 >
                ++epoch;
                Array.Sort(solutions);
                //soultions 의 값을 알고싶을때는 이걸로 보기
                /* static void PrintKeysAndValues(String solutions)
                {
                    for (int i = 0; i < solutions.Length; i++)
                    {
                        Console.WriteLine("{0}", solutions);
                    }
                    Console.WriteLine();
                } */
                // soulutions = 0.375 start 
                
                double[] bestWeights = solutions[best].weights;
                double[] goodWeights = solutions[good].weights;
                double[] worstWeights = solutions[worst].weights;
                
                double[] centroidWeights = Centroids(goodWeights, bestWeights);

                double[] expandedWeights = Expanded(centroidWeights, worstWeights);
                double expandedError = Error(trainData, expandedWeights);

                if (expandedError < solutions[worst].error)
                {
                    Array.Copy(expandedWeights, worstWeights, numFeatures + 1);
                    solutions[worst].error = expandedError;
                    // Console.WriteLine(expandedError); >> frist 0.375   반복하다보면 0.22로 수렴
                    continue;
                }
                
                double[] reflectedWeights = Reflected(centroidWeights, worstWeights);
                /*
                 * void PrintKeysAndValues(double[] centroidWeights ) Reflected(centroidWeights, worstWeights) 값 보고싶으면 주석을 해제
                   {
                    for (int i = 0; i < reflectedWeights.Length; i++)
                    {
                       Console.WriteLine("reflectedWieghts Data = {0}", reflectedWeights[i]);

                    }
                    Console.WriteLine();
                   }
                  PrintKeysAndValues();
               */
                double reflectedError = Error(trainData, reflectedWeights); // 0.625 >> 0.226 수렴 값을 보고 싶다면 Console.WriteLine(reflectedError);
                
                if (reflectedError < solutions[worst].error)
                {
                    Array.Copy(reflectedWeights, worstWeights, numFeatures + 1);
                    solutions[worst].error = reflectedError;
                    continue;
                }

                double[] contractedWeights = Contracted(centroidWeights, worstWeights);
                /*
                void PrintKeysAndValues(double[] contractedWeights)
                {
                    for (int i = 0; i < contractedWeights.Length; i++)
                    {
                        Console.WriteLine("contractedWeights Data = {0}",contractedWeights[i]);

                    }
                    Console.WriteLine();
                }
                PrintKeysAndValues(contractedWeights); */
                double contractedError = Error(trainData, contractedWeights);
                //Console.WriteLine(contractedError);
                if (contractedError < solutions[worst].error)
                {
                    Array.Copy(contractedWeights, worstWeights, numFeatures + 1);
                    solutions[worst].error = contractedError;
                    //Console.WriteLine(contractedError);
                    continue;
                }

                double[] randomPoint = RandomPoint();
                double randomPointError = Error(trainData, randomPoint);

                if (randomPointError < solutions[worst].error)
                {
                    Array.Copy(randomPoint, worstWeights, numFeatures + 1);
                    solutions[worst].error = randomPointError;
                    //Console.WriteLine("랜덤에러율 " + randomPointError);
                    continue;
                }

                
                for (int i = 0; i < numFeatures + 1; i++)
                {
                    worstWeights[i] = (worstWeights[i] + bestWeights[i]) * 0.5;
                    goodWeights[i] = (goodWeights[i] + bestWeights[i]) * 0.5;
                    //Console.WriteLine(" worst = {0}" ,worstWeights[i]);
                    //Console.WriteLine(" good  = {0}" , goodWeights[i]);
                }
                solutions[worst].error = Error(trainData, worstWeights);
                solutions[good].error = Error(trainData, goodWeights);
                /*
                 * int best = 0;
                   int good = 1;
                   int worst = 2;
                 * 
                 */
            }
            Array.Copy(solutions[best].weights, this.weights, this.numFeatures + 1);
            //double[] > 값을 복사한값을 casting
            return this.weights;
            
        }
        #endregion
    }

}

