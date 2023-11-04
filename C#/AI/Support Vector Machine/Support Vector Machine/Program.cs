
namespace SVMP
{
    public class Program
    {
        static void Main(string[] args)
        {
            double[][] train_x = new double[][]
            {
            new double[] {1,2,3},
            new double[] {4,5,6},
            new double[] {7,8,9},
            new double[] {10,11,12},
            new double[] {11,12,13},
            new double[] {12,13,14},
            new double[] {14,15,16},
            new double[] {16,17,18}, 
            new double[] {17,18,19}, 
            new double[] {18,20,21},
            new double[] {20,21,22},
            new double[] {21,22,23},
            new double[] {22,23,24},
            new double[] {23,24,25},
            new double[] {24,25,26},
            new double[] {24,26,27},
            new double[] {24,27,28},
            new double[] {24,28,29}, 
            new double[] {24,29,30},
            };

            int[] train_y = new int[] { -1, -1, -1, -1, 1, 1, 1, 1,1,1,1,1,1,1,1,-1,-1,-1,0};
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
                //Console.WriteLine("  |  " + train_y[i].ToString());
            }
            
            int iter = svm.Train(train_x,train_y, maxint);
            Console.WriteLine("학습" + iter);
            Console.WriteLine("Support vectors:");
            foreach (double[] vec in svm.supportVectors)
            {
                for (int i = 0; i < vec.Length; ++i) Console.Write(vec[i].ToString("F1") + "  ");
                Console.WriteLine("");
            }

            Console.WriteLine("\n가중치: ");
            for (int i = 0; i < svm.weights.Length; ++i) Console.Write(svm.weights[i].ToString("F6") + " ");
            Console.WriteLine("");

            Console.WriteLine("\n바이어스 = " + svm.bias.ToString("F6") + "\n");

            for (int i = 0; i < train_x.Length; ++i)
            {
                double pred = svm.computeDecision(train_x[i]);
                Console.Write("예측 결정값 [" + i + "] = ");
                Console.WriteLine(pred.ToString("F6").PadLeft(10));
            }

            double acc = svm.Accuracy(train_x, train_y);
            Console.WriteLine("\n 모델정확도 = " + acc.ToString("F4"));

            double[] unknown = new double[] { 3, 5, 7 };
            double predDecVal = svm.computeDecision(unknown);
            Console.WriteLine("\n예측 정확도 (3.0 5.0 7.0) = " + predDecVal.ToString("F3"));
            int predLabel = Math.Sign(predDecVal);
            Console.WriteLine("\n예측 라벨링  (3.0 5.0 7.0) = " + predLabel);
            Console.ReadLine();
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
            for (int i = 0; i < this.supportVectors.Count; ++i) sum += this.weights[i] * PolyKernel(this.supportVectors[i], input);
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
            for(int i =0 ; i <x_mat.Length; ++i)
            {
                double singComputed = Math.Sign(computeDecision(x_mat[i]));
                if (singComputed == Math.Sign(y_vector[i])) ++numcorrect;
                else ++numWrong;
            }
            return (1.0 * numcorrect) / (numcorrect + numWrong);
        }
        public bool TakeStep(int i1, int i2, double[][] x_mat, int[] y_vector)
        {
            if(i1 == i2 ) return false;
            double c = this.complexity;
            double eps = this.epsilon;

            double[] x1 = x_mat[i1];
            double alph1 = this.alpha[i1];
            double y1 = y_vector[i1];
            double e1;

            if (alph1 > 0 && alph1 < c) e1 = this.errors[i1];
            else e1 = ComputeAll(x1, x_mat, y_vector);
            double[] x2 = x_mat[i2];
            double alph2 = this.alpha[i2];
            double y2 = y_vector[i2];
            double e2;
            if(alph2 > 0 && alph2 < c) e2= this.errors[i2];
            else e2 =ComputeAll(x2,x_mat, y_vector);
            double s = y1 * y2;
            double l, h;
            if (y1 != y2) { l = Math.Max(0, alph2 + alph1 - c); h = Math.Min(c, alph1 + alph2); }
            else { l = Math.Max(0, alph2 + alph1 - c); h = Math.Min(c, alph1 + alph2); }
            if (l == h) return false;
            double k11 = PolyKernel(x1, x1);
            double k12 = PolyKernel(x1, x2);
            double k22 = PolyKernel(x2, x2);
            double eta = k11 + k22 - 2 * k12;
            double a1, a2;

            if(eta > 0)
            {
                a2 = alph2 - y2 * (e2 - e1) / eta;
                if (a2 >= h) a2 = h;
                else if (a2 <= l) a2 = l;
            }
            else
            {
                double f1 = y1 * (e1 + this.bias) - alph1 * k11 - s * alph2 * k12;
                double f2 = y2 * (e2 + this.bias) - alph2 * k22 -s * alph1 * k12;
                double l1 = alph1 + s * (alph2 - l);
                double h1 = alph2 + s * (alph2 - h);
                double loj = (l1 * f1) + (l * f2) + (0.5 * l1 * l1 * k11) + (0.5 * l * l * k22) + (s * l * l1 * k12);
                double hoj = (h1 * f1) + (h * f2) + (0.5 * h1 * h1 * k11) + (0.5 * h * h * k22) + (s * h * h1 * k12);
                if (loj < hoj - eps) a2 = l;
                else if (loj > hoj + eps) a2 = h;
                else a2 = alph2;
            }

            if (Math.Abs(a2 - alph2) < eps * (a2 + alph2 + eps))
                return false;

            a1 = alph1 + s * (alph2 - a2); 
            double b1 = e1 + y1 * (a1 - alph1) * k11 +  y2 * (a2 - alph2) * k12 + this.bias;
            double b2 = e2 + y1 * (a1 - alph1) * k12 +  y2 * (a2 - alph2) * k22 + this.bias;
            double newb;
            if (0 < a1 && c > a1) newb = b1;
            else if (0 < a2 && c > a2) newb = b2;
            else newb = (b1 + b2) / 2;
            double deltab = newb - this.bias;
            this.bias = newb;
            double delta1 = y1 * (a1 - alph1);
            double delta2 = y2 * (a2 - alph2);

            for (int i = 0; i < x_mat.Length; ++i)
            {
                if (0 < this.alpha[i] && this.alpha[i] < c) this.errors[i] += delta1 * PolyKernel(x1, x_mat[i]) + delta2 * PolyKernel(x2, x_mat[i]) - deltab;
            }

            this.errors[i1] = 0.0;
            this.errors[i2] = 0.0;
            this.alpha[i1] = a1;  
            this.alpha[i2] = a2;

            return true;
        }
        public int ExamineExample(int i2, double[][] x_mat, int[] y_vector)
        {
            double c = this.complexity;
            double tol = this.tolerance;

            double[] x2 = x_mat[i2]; 
            double y2 = y_vector[i2];  
            double alph2 = this.alpha[i2];

            double e2;
            if (alph2 > 0 && alph2 < 2) e2 = this.errors[i2];
            else e2 = ComputeAll(x2, x_mat, y_vector);
            double r2 = y2 * e2;
            if ((r2 < -tol && alph2 < c) || (r2 > tol) && alph2 > 0)
            {
                int i1 = -1;
                double maxerr = 0;
                for(int i =0; i< x_mat.Length; ++i)
                {
                    double e1 = this.errors[i];
                    double delerr = Math.Abs(e2 - e1);
                    if(delerr > maxerr) { maxerr = delerr; i1 = i; }
                }
                if (i1 >= 0 && TakeStep(i1, i2, x_mat, y_vector)) return 1;

                int rnd1 = this.rnd.Next(x_mat.Length);
                for(i1 =rnd1; i1<x_mat.Length; ++i1) if (this.alpha[i1] > 0 && this.alpha[i1] <c ) if(TakeStep(i1,i2,x_mat,y_vector)) return 1;
                for(i1=0; i1< rnd1; ++i1) if (this.alpha[i1] > 0 && this.alpha[i1] < c) if(TakeStep(i1,i2,x_mat,y_vector)) return 1;
                rnd1 = this.rnd.Next(x_mat.Length);
                for (i1 = rnd1; i1 < x_mat.Length; ++i1) if (TakeStep(i1, i2, x_mat, y_vector)) return 1;
                
                for (i1 = 0; i1 < rnd1; ++i1)if (TakeStep(i1, i2, x_mat, y_vector)) return 1;
                
            }
            
               
            return 0;
        }

        public double ComputeAll(double[] vector , double[][] x_mat , int[] y_vector)
        {
            double sum = -this.bias;
            for (int i = 0; i < x_mat.Length; ++i) if (this.alpha[i] > 0) sum += this.alpha[i] * y_vector[i] * PolyKernel(x_mat[i], vector);
            return sum;
        }
    }


}