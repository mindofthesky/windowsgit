using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random_Forest
{
    public class Forest
    {
        public int numTree;
        public int bootStrapSize;
        public int minSampleSplit;
        public int maxDepth;
        public int maxFeatures;
        public List<DescisionTree> trees;

        public Forest(int numTree, int bootStrapSize, int minSampleSplit = 2, int maxDepth = 6, int maxFeatures = 10)
        {
            this.numTree = numTree;
            this.bootStrapSize = bootStrapSize;
            this.minSampleSplit = minSampleSplit;
            this.maxDepth = maxDepth;
            this.maxFeatures = maxFeatures;
            this.trees = new List<DescisionTree> ();
        }
        public void Train(LabeledData[] data)
        {
            for(int i =0; i<numTree; i++)
            {
                LabeledData[] bootStrapped = Bootstrap(data,bootStrapSize);
                DescisionTree tree = new DescisionTree(minSampleSplit, maxDepth, maxFeatures);
                tree.Train(data);
                trees.Add(tree);    
            }
        }
        public Dictionary<int, double> Predict(LabeledData d) 
        {
            Dictionary<int,int> classVotes = new Dictionary<int,int>();
            foreach(DescisionTree tree in trees)
            {
                int yPre = tree.Predict(d);
                if (!classVotes.ContainsKey(yPre)) classVotes.Add(yPre,0);
                classVotes[yPre]++;
            }
            Dictionary<int, double> classPro = new Dictionary<int, double>();
            foreach (var pair in classVotes) classPro.Add(pair.Key, (double)pair.Value / numTree);
            return classPro;
        }
        public static LabeledData[] Bootstrap(LabeledData[] data , int numSamples)
        {
            Random rnd =  new Random();
            List<LabeledData> bootstrappedData = new List<LabeledData>();
            for(int i = 0; i < numSamples; i++)
            {
                int idx = rnd.Next(data.Length);
                bootstrappedData.Add(data[idx]);
            }
            return bootstrappedData.ToArray();
        }
    }
}
