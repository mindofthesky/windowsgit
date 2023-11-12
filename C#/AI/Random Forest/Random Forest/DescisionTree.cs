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
    }
}
