using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Random_Forest
{
    public class DescisionTree
    {
        public DescisionTree? Root { get; private set; }

        public int MinSampleSplit { get; private set; }

        public int MaxDepth { get; private set; }
        public int MaxFeatures { get; private set; }

        public List<int> ShuffledFeatureIndices;
        //의사 결정트리 나무 
        public DescisionTree(int minSampleSplit, int maxDepth, int maxFeatures)
        {
            MinSampleSplit = minSampleSplit;
            MaxDepth = maxDepth;
            MaxFeatures = maxFeatures;
            ShuffledFeatureIndices = new List<int>();
        }
        public void Train(LabeledData[] data)
        {
            for (int i = 0; i < data[0].Length; i++) ShuffledFeatureIndices.Add(i);
            Random rng = new Random();
            ShuffledFeatureIndices = ShuffledFeatureIndices.OrderBy(x => rng.Next()).ToList();
            // 특징 나무 하나를 섞는다
            MaxFeatures = Math.Min(MaxFeatures, data[0].Length - 1);
            // Root = BulidTree(data);
        }
        public DecisionNode BulidTree(LabeledData[] data, int currentDepth = 0)
        {
            int numSamples = data.Length;
            DecisionNode node;
            if (numSamples > MinSampleSplit && currentDepth <= MaxDepth)
            {
                (node, LabeledData[] left, LabeledData[] right) = GetBestSplit(data);
                if (node.InfoGain > 0)
                {
                    node.LeftNode = BulidTree(left, currentDepth++);
                    node.RigthNode = BulidTree(right, currentDepth++);
                    return node;
                }
            }
            node = new DecisionNode()
            {
                IsLeft = true,
                vlaue = CalLeafValue(data)
            };
            return node;
        }
        // 튜플 형식 > 튜플형식으로 리터럴값을 반환
        public (DecisionNode node, LabeledData[] left, LabeledData[] right) GetBestSplit(LabeledData[] data)
        {
            double maxInfogain = double.MinValue;
            DecisionNode bestNode = new DecisionNode();
            LabeledData[] bestLeft = new LabeledData[0];
            LabeledData[] bestRight = new LabeledData[0];

            for(int i= 0; i< MaxFeatures; i++)
            {
                int index = ShuffledFeatureIndices[i];
                var theset = data.Select(x => x[index]).Distinct();
                foreach(double the in theset)
                {
                    (LabeledData[] left, LabeledData[] right) = Split(data, index, the);
                    double currentGain = CalaInformationGain(data, left, right);
                    if (currentGain > maxInfogain)
                    {
                        maxInfogain = currentGain;
                        bestNode = new DecisionNode()
                        {
                            Index = index,
                            Threshold = the,
                            InfoGain = currentGain
                        };
                        bestLeft = left;
                        bestRight = right;  
                    }
                }
            }
            return (bestNode, bestLeft, bestRight);
        }

        public static (LabeledData[] left , LabeledData[] right) Split(LabeledData[] data, int featureIdx, double theset)
        {
            LabeledData[] leftData = data.Where(x => x[featureIdx] <= theset).ToArray();
            LabeledData[] rightData = data.Where(x => x[featureIdx] > theset).ToArray();
            return (leftData, rightData);
        }
        public static double CalaInformationGain(LabeledData[] parentData , LabeledData[] leftChildData, LabeledData[] rightChildData)
        {
            double leftWeight = (double)leftChildData.Length / parentData.Length;
            double rightWeight = (double)rightChildData.Length / parentData.Length;

            double parentGini = CalcGiniIndex(parentData);
            double childrenGini = (leftWeight * CalcGiniIndex(leftChildData)) + (rightWeight * CalcGiniIndex(rightChildData));

            return parentGini - childrenGini;
        }
        public int CalLeafValue(LabeledData[] data)
        {
            if (data.Length == 0) throw new ArgumentException();
            List<int> classes = data.Select(x=> x.Label).Distinct().ToList();
            int[] counts = new int[classes.Count];
            foreach(LabeledData d in data)
                for(int i = 0; i < classes.Count; i++)
                    if (classes[i] == d.Label)
                    {
                        counts[i]++;
                        break;
                    }

            int maxCount = 0;
            int bestIndex = -1;

            for (int i = 0; i< counts.Length; i++)
                if (counts[i] > maxCount)
                {
                    bestIndex = i;
                    maxCount = counts[i];
                }
            return classes[bestIndex];
        }
        public static double CalcGiniIndex(LabeledData[] data)
        {
            List<int> classes = data.Select(x=> x.Label).Distinct().ToList();
            double gini = 0.0;
            int n = data.Length;
            foreach(int c in classes)
            {
                int numMembers = data.Where(x=> x.Label == c).Count();
                double pro = (double)numMembers / n;
                gini += (pro * pro);
            }

            return 1.0 - gini;
        }
        // 예측값 d 인값
        public int Predict(LabeledData d)
        {
            if (Root == null) throw new Exception();
            return 1;
            //return MakePrediction(d, Root);
        }
        // 배열형 x 
        public int Predict(double[] x)
        {
            if (Root == null) throw new Exception();
            return 1;
        }
        public int MakePrediction(double[] x, DecisionNode node)
        {
            if (node.IsLeft) return node.vlaue;
            else if (x[node.Index] <= node.Threshold)
            {
                if (node.LeftNode == null) throw new Exception();
                return MakePrediction(x, node.LeftNode);
            }
            else
            {
                if(node.RigthNode == null) throw new Exception();
                return MakePrediction(x, node.RigthNode);
            }
        }
        public int MakePrediction(LabeledData d , DecisionNode node)
        {
            if(node.IsLeft) return node.vlaue;
            else if (d[node.Index]<= node.Threshold)
            {
                if(node.LeftNode==null) throw new Exception();
                return MakePrediction(d,node.LeftNode);
            }
            else
            {
                if(node.RigthNode==null) throw new Exception();
                return MakePrediction(d,node.RigthNode);    
            }
        }
    }
}
