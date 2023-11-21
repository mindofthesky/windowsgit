using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random_Forest
{
    public class Util
    {
        public static LabeledData[] ReadData(string dir)
        {

            Dictionary<string, int> labelDict = new Dictionary<string, int>();
            List<LabeledData> dataList = new List<LabeledData>();
            using(FileStream steam = File.OpenRead(dir))
            {
                using(StreamReader sr = new StreamReader(steam))
                {
                    int count = 0;  
                    
                    while(sr.EndOfStream)
                    {
                        string? line = sr.ReadLine();
                        if(count == 0 || line is null)
                        {
                            count++;
                            continue;
                        }
                        string[] splits = line.Split(',');
                        int numCol = splits.Length;
                        if (!labelDict.ContainsKey(splits[numCol - 1])) labelDict.Add(splits[numCol-1], labelDict.Count);
                        double[] Feature = new double[numCol - 1];
                        for (int i = 0; i < numCol - 1; i++) _ = double.TryParse(splits[i], out Feature[i]);

                         dataList.Add(new LabeledData(labelDict[splits[numCol - 1]], Feature));
                    }
                   


                }
            }
            return dataList.ToArray();
        }
        public static LabeledData[] BalanceClasses(LabeledData[] data)
        {
            List<int> classes = data.Select(x=>x.Label).Distinct().ToList();
            List<int> count = new List<int>();

            List<LabeledData> balancedData = new List<LabeledData>();
            foreach(int c in classes) count.Add(data.Where(x=> x.Label == c).Count());
            int minCount = count.Min();
            Dictionary<int, int> classCount = new Dictionary<int, int>();
            foreach (int n in classes) classCount.Add(n, 0);

            for(int i=0; i< data.Length; i++)
                if (classCount[data[i].Label] < minCount)
                {
                    balancedData.Add(data[i]);
                    classCount[data[i].Label]++;
                }
            return balancedData.ToArray();
        }
        public static (LabeledData[] train, LabeledData[]test) Split(LabeledData[] data, double trainAmount = 0.0)
        {
            int numTrain = (int) (data.Length * trainAmount);
            Random random = new Random();
            List<LabeledData> shuffeld = data.OrderBy(x => random.Next()).ToList();
            List<LabeledData> train = new List<LabeledData>();
            List<LabeledData> test = new List<LabeledData>();
            for (int i = 0; i < shuffeld.Count; i++)
                if (i < numTrain) train.Add(shuffeld[i]);
                else test.Add(shuffeld[i]);
            return (train.ToArray(), test.ToArray());
        }
    }
}
