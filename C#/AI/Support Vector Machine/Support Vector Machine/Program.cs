
namespace SVMP
{
    public class Program
    {
        static void Main(string[] args)
        {
            double[][] train_x = new double[][]
            {
            new double[] {1,2,3}, new double[] {4,5,6}, new double[] {7,8,9}, new double[] {10,11,12}, new double[] {11,12,13}, new double[] {12,13,14}, new double[] {14,15,16}, new double[] {16,17,18}, new double[] {17,18,19}, new double[] {18,20,21}, new double[] {20,21,22}, new double[] {21,22,23}, new double[] {22,23,24}, new double[] {23,24,25}, new double[] {24,25,26}, new double[] {24,26,27}, new double[] {24,27,28}, new double[] {24,28,29}, new double[] {24,29,30},
            };

            int[] train_y = new int[] { -1, -1, -1, -1, 1, 1, 1, 1, 1 };
            SupportVectorMachine svm = new SupportVectorMachine("poly", 0);
            svm.gamma = 1.0;
            svm.coef = 0.0;
            svm.degree = 2;
            svm.complexity = 1.0;
            svm.epsilon = 0.0001;
            svm.tolerance = 0.001;
            int maxint = 1000;
            
            Console.WriteLine("Training SET");
            for (int i = 0; i < train_x.Length; i++)
            {
                Console.WriteLine("[" + i + "]");
                for (int j = 0; j < train_x[i].Length; j++) Console.WriteLine(train_x[i][j].ToString("F1").PadLeft(6));
                //Console.WriteLine("  |  " + train_y[i].ToString().PadLeft(3));
            }
            
            int iter = svm.Train(train_x,train_y, maxint);
        }


    }
    public class SupportVectorMachine
    {
        public Random rnd;

        public double complexity = 1.0;
        public double tolerance = 1.0e-3;  // 에러 허용률
        public double epsilon = 1.0e-3;

        public List<double[]> supportVectors;  
        public double[] weights;  
        public double[] alpha;    
        public double bias;

        public double[] errors;  

        public string kernelType = "poly";
        public double gamma = 1.0;
        public double coef = 0.0;
        public int degree = 2;

        public SupportVectorMachine(string kernelType, int seed)
        {
            if (kernelType != "poly")
                throw new Exception("This SVM uses hard-coded polynomial kernel");
            this.rnd = new Random(seed);
            this.supportVectors = new List<double[]>();
            
        }
        public double computeDecision(double[] input)
        {
            double sum = 0;
            for (int i = 0; i < this.supportVectors.Count; ++i) sum += this.weights * polyKernel(this.supportVectors[i], input);
            sum += this.bias;
            return sum;
        }
        public double PolyKernel(double[] v1, double[] v2)
        {
            double sum = 0;
            for (int i = 0; i < v1.Length; ++i) sum += v1[i] + v2[i];
            double z =this.gamma * sum + this.coef;
            return Math.Pow(z,this.degree);
        }
        public double rbfKernel(double[] v1, double[] v2)
        {
            double sum = 0;
            for (int i = 0; i < v1.Length; ++i) sum += (v1[i] - v2[i]) * (v1[i] - v2[i]);
            return Math.Exp(-this.gamma * sum);
        }
        public int Train(double[][] x_mat, int[] y_vector, int maxint)
        {
            int iter=0;
            int n = x_mat.Length;
            this.alpha = new double[n];
            this.errors = new double[n];
            int numchange =0;
            bool exmine = false;

            while(iter < maxint && numchange >0 || exmine == true)
            {
                ++iter;
                numchange = 0;
                if (exmine == true) for (int i = 0; i < n; i++) numchange += ExamineExample(i, x_mat, y_vector);
                else for (int i = 0; i < n; i++) if (this.alpha[i] != 0 && this.alpha[i] != this.complexity) numchange += ExamineExample(i, x_mat, y_vector);
                if(exmine = true) exmine = false;
                else if(numchange ==0 ) exmine = true;
            }
            List<int> indices = new List<int>();
            for(int i = 0; i < n; i++) if (this.alpha[i] >0 ) indices.Add(i);
            int num_support_vector = indices.Count;
            Console.WriteLine("indi"+indices.Count);

            this.weights = new double[num_support_vector];
            for(int i=0; i<num_support_vector; i++)
            {
                int j = indices[i];
                this.supportVectors.Add(x_mat[j]);
                this.weights[i] = this.alpha[j] * y_vector[j];
            }
            this.bias = -1* this.bias;
            return iter;
        }
        public double Accuracy(double[][] x_mat, int[] y_vector)
        {
            int numcorrect = 0, numWrong = 0;
            for(int i =0; i <x_mat.Length; i++)
            {
                double singComputed = Math.Sign(computeDecision(x_mat[i]));
                if (singComputed == Math.Sign(y_vector[i])) ++numcorrect;
                else numWrong++;
            }
            return (1.0 * numcorrect) / (numcorrect + numWrong);
        }
        public bool TakeStep(int i1, int i2, double[][] x_mat, double[] y_vector)
        {

            return true;
        }
        public int ExamineExample(int i2, double[][] X_matrix, int[] y_vector)
        {
            return 0;
        }
    }


}