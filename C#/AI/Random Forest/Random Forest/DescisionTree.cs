using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Random_Forest
{
    public class DescisionTree
    {
        public DescisionTree? Root { get; private set; }

        public int MinSampleSplit { get; private set; }

        public int MaxDepth { get; private set; }
        public int MaxFeatures { get; private set; }

        public List<int> ShuffledFeatureIndices;

        public DescisionTree(int minSampleSplit, int maxDepth, int maxFeatures)
        {
            MinSampleSplit = minSampleSplit;
            MaxDepth = maxDepth;
            MaxFeatures = maxFeatures;
        }
        public void Train(LabeledData[] data)
        {
            for (int i = 0; i < data[0].Length; i++) ShuffledFeatureIndices.Add(i);
            Random rng = new Random();
            ShuffledFeatureIndices = ShuffledFeatureIndices.OrderBy(x => rng.Next()).ToList();
            MaxFeatures = Math.Min(MaxFeatures, data[0].Length - 1);
            //Root = BuildTree(data);
        }
        public DecisionNode BulidTree(LabeledData[] data , int currentDepth = 0)
        {
            int numSamples = data.Length;
            DecisionNode? node;

            node = new DecisionNode()
            {
                IsLeft = true,
                //vlaue = CalLeafValue(data)
            };
            return node;
        }
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
        public static double CalcGiniIndex(LabeledData[] data)
        {
            double gini = 0.0;

            return 1.0 - gini;
        }
    }
}
