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
           // 데이터가 없기때문에 결과값이 없다
           // 정상적인 상황에서는 errorcode를 만나는게 맞다 
           
            try
            {
                Console.WriteLine("선형 하강경사법");
                dataToProcess = csvProcessor.GetTrainingData("data",','); // << data.csv , 엑셀 파일을 줄경우 경사하강법으로 데이터를 넣는다
                Console.WriteLine();
                Console.WriteLine(string.Format("Starting with b = {0} and gradient = {1}", initialValue[0], initialValue[1])); // 초기값 초기화
                Console.WriteLine(string.Format("Initial Relative Error = {0}", linerGDProcessor.ComputeRelativeErrorFromGivenPoint(initialValue[0], initialValue[1], dataToProcess)));

                computedValue = linerGDProcessor.GradientDescentProcess(dataToProcess, initialValue[0], initialValue[1], learningRate, totalIteration);

                Console.WriteLine();
                // 최종 b업데이트값 , m 값
                Console.WriteLine(string.Format("Final value with b = {0} and gradient = {1}", computedValue[0], computedValue[1]));
                Console.WriteLine(string.Format("Final Relative Error = {0}", linerGDProcessor.ComputeRelativeErrorFromGivenPoint(computedValue[0], computedValue[1], dataToProcess)));
                // 최종 상대 에러율 
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
    class CSVProcessor
    {
        /// 트레이닝을 받아올 데이터를 streamReader를 통해 읽어옴 
       public List<double[]> GetTrainingData(string filename, char delmiter)
       {
            // 데이터는 배열형으로 되어있기때문에 배열형으로 데이터를 선언
            List<double[]> data = new List<double[]>();

            // StreamReader로 파일을 이름을 받아오고 데이터를 읽음 
            using(StreamReader reader = new StreamReader(filename))
            {


                // endofStream 데이터의 끝까지 반복 
                // 현재 스트림 위치가 스트림의 끝에 있는지를 나타내는 값을 가져오는 메소드이기때문에
                // 끝이 아니라면 계속 반복
                while (!reader.EndOfStream)
                {
                    var holderValue = reader.ReadLine().Split(delmiter);
                    // holder로 나눠둔 값을 data 로 넣어줌 둘다 double형태인 값이기때문에 [0],[1]에 계속반복하여 넣음 
                    data.Add
                        (
                            new double[]
                            {
                                double.Parse(holderValue[0]),
                                double.Parse(holderValue[1])
                            }
                        );

                }
            }
            // 넣은 데이터를 호출 
            return data;

        }   
    }
    // 선형 경사하강법 클래스 선언
    class LinerGradientDescentProcessor
    {
        // 에러율 
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="points" ></param>
        /// <param name="inital_b" = 손실함수의 초기값 b  데이터의 값은 현재 0></param>
        /// <param name="initial_m" = 손실함수의 초기값 m 데이터의 값은 현재 0></param>
        /// <param name="learningRate" = 학습률의 정의 학습률을 값을 정확히하거나좋게 하는경우 데이터에 하나를 예시로 해도 나쁘지않다
        /// 그래도 최소값으로 선언을하겠다면 정말 작은값으로 선언하여 초기화하는게 낫다></param>
        /// <param name="totalIteration"></param>
        /// <returns></returns>
        public double[] GradientDescentProcess(List<double[]> points, double inital_b, double initial_m, double learningRate, int totalIteration) 
        {
            
            // 초기값을 coputedValue에 넣는다 초기값은 현재 0, 0 ;
            
            double[] computedValue = {inital_b, initial_m};
            for (int iteration=0; iteration< totalIteration; iteration++)
            {
                computedValue = stepGradient(computedValue[0], computedValue[1], points, learningRate);
            }

            return computedValue;
        }
        // 경사 하강법 시작
        public double[] stepGradient(double current_b, double current_m, List<double[]> points, double learningRate) 
        {
            // 점의 갯수는 data.csv파일에서 읽어오기에 점의 x,y 절편은 따로 존재한다 
            // 예시로 x 절편은 집의 크기 , y절편은 집의 가격처럼 
            double totalPoints = points.Count;
            double stepped_b = 0;
            double stepped_m = 0;
            double new_b;
            double new_m;
            double[] computedValue;

            // 경사 하강법 
            foreach (double[] point in points)
            {
                double x = point[0];
                double y = point[1];

                stepped_b += -(2 / totalPoints) * (y - ((current_m * x) + current_b));
                stepped_m += -(2 / totalPoints) * x * (y - ((current_m * x) + current_b));
            }

            new_b = current_b - (learningRate * stepped_b); // 손실함수 b 업데이트
            new_m = current_m - (learningRate * stepped_m); // 손실함수 w 업데이트

            computedValue = new double[] { new_b, new_m };  // 새로운 손실함수 w,b를 업데이트한값을 넣어줌  최종값에 가깝다

            return computedValue;
        }
    }
}