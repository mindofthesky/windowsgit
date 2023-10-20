using System.Configuration;
using System.IO.Enumeration;

namespace Gradient_desent
{
    class Program
    {
        static double learningRate = double.Parse(ConfigurationManager.AppSettings["LearningRate"]); // 학습률 
        static int totalIteration = int.Parse(ConfigurationManager.AppSettings["TotalIteration"]); // 반복횟수
        static CSVProcessor csvProcessor = new CSVProcessor(); // 파일을읽어올 데이터 선언
        static LinerGradientDescentProcessor linerGDProcessor = new LinerGradientDescentProcessor();
        static List<double[]> dataToProcess = new List<double[]>();
        static double[] initialValue = {0,0};
        static double[] computedValue;
        static void Main(string[] args)
        {
            // 데이터가 없기때문에 데이터를 넣어주면 하강경사법으로 출력이됨! 
           // 코드 주석은 이해하고 만들기 대작전 시작 
            try
            {
                Console.WriteLine("선형 하강경사법");
                dataToProcess = csvProcessor.GetTrainingData("data",',');
                Console.WriteLine();
                Console.WriteLine(string.Format("Starting with b = {0} and gradient = {1}", initialValue[0], initialValue[1]));
                Console.WriteLine(string.Format("Initial Relative Error = {0}", linerGDProcessor.ComputeRelativeErrorFromGivenPoint(initialValue[0], initialValue[1], dataToProcess)));

                computedValue = linerGDProcessor.GradientDescentProcess(dataToProcess, initialValue[0], initialValue[1], learningRate, totalIteration);

                Console.WriteLine();
                Console.WriteLine(string.Format("Final value with b = {0} and gradient = {1}", computedValue[0], computedValue[1]));
                Console.WriteLine(string.Format("Final Relative Error = {0}", linerGDProcessor.ComputeRelativeErrorFromGivenPoint(computedValue[0], computedValue[1], dataToProcess)));

            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
    class CSVProcessor
    {
        
       public List<double[]> GetTrainingData(string filename, char delmiter)
       {

            List<double[]> data = new List<double[]>();
            using(StreamReader reader = new StreamReader(filename))
            {
                while(!reader.EndOfStream)
                {
                    var holderValue = reader.ReadLine().Split(delmiter);
                    data.Add(
                        new double[]
                        {
                            double.Parse(holderValue[0]),
                            double.Parse(holderValue[1])
                        }
                        );

                }
            }
            return data;

        }   
    }
    class LinerGradientDescentProcessor
    {
        public double ComputeRelativeErrorFromGivenPoint(double b, double gradient, List<double[]> points) 
        {
            double totalError = 0;
            double x, y = 0;
            foreach (double[] point in points)
            {
                x = point[0];
                y = point[1];
                totalError += Math.Pow((y - (gradient * x + b)), 2);
            }

            return totalError / points.Count;
        }
        public double[] GradientDescentProcess(List<double[]> points, double inital_b, double initial_m, double learningRate, int totalIteration) 
        {
            double[] computedValue = {inital_b, initial_m};
            for (int iteration=0; iteration< totalIteration; iteration++)
            {
                computedValue = stepGradient(computedValue[0], computedValue[1], points, learningRate);
            }

            return computedValue;
        }
        public double[] stepGradient(double current_b, double current_m, List<double[]> points, double learningRate) 
        {
            double totalPoints = points.Count;
            double stepped_b = 0;
            double stepped_m = 0;
            double new_b;
            double new_m;
            double[] computedValue;
            foreach (double[] point in points)
            {
                double x = point[0];
                double y = point[1];

                stepped_b += -(2 / totalPoints) * (y - ((current_m * x) + current_b));
                stepped_m += -(2 / totalPoints) * x * (y - ((current_m * x) + current_b));
            }

            new_b = current_b - (learningRate * stepped_b);
            new_m = current_m - (learningRate * stepped_m);

            computedValue = new double[] { new_b, new_m };  

            return computedValue;
        }
    }
}