using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace decsion
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // 파일 위치 지정 
            string path = "C:\\Users\\mindo\\source\\repos\\DecisionTree\\DecisionTree\\bin\\breast-cancer.data";
            List<string> row = File.ReadAllLines(path).ToList();
            
            List<List<string>> Tree = ProcessData(row);
            CreateTree(Tree);
            for (int i =0; i< row.Count; i++) {
                CreateTree(Tree);

            }
        }
        public static void CreateTree(List<List<string>> tree, int add = 0)
        {
            List<string> decisionValues = CreateDecisionValues(tree);
            List<Dictionary<string, int>> countOfValues = PrepareDictionary(tree);
            Console.WriteLine();

        }
        public static List<string> CreateDecisionValues(List<List<string>> tree)
        {
            List<string> decisionValues = new List<string>();
            foreach (List<string> row in tree) if (!decisionValues.Contains(row.LastOrDefault())) decisionValues.Add(row.LastOrDefault()); 
            // yes, no data 부분 파싱
            return decisionValues;
        }
        public static List<List<string>> ProcessData(List<string> rows)
        {
            List<List<string>> properSet = new List<List<string>>();
            for (int i = 0; i < rows.Count; i++) properSet.Add(rows[i].Split(',').ToList());
            // 모든 줄의 데이터를 읽어오기
            return properSet;
        }
        public static List<Dictionary<string, int>> PrepareDictionary(List<List<string>> proper)
        {
            List<Dictionary<string,int>> countofvalue = new List<Dictionary<string,int>>();
            for (int i = 0; i < proper.FirstOrDefault().Count; i++)  countofvalue.Add(checkpro(i, proper)); 
            return countofvalue;
        }
        public static Dictionary<string, int> checkpro (int col, List<List<string>> proper)
        {
            Dictionary<string, int> valuesForColumn = new Dictionary<string, int>();
            for (int i = 0; i < proper.Count; i++)
            {
                if (valuesForColumn.ContainsKey(proper[i][col])) valuesForColumn[proper[i][col]]++;
                else valuesForColumn[proper[i][col]] = 1;
                Console.WriteLine(valuesForColumn[proper[i][col]]);
            }
            return valuesForColumn;
        }
        public static List<double> CountEntropies(List<Dictionary<string, int>> conterValue, List<List<string>> proper)
        {
            List<double> entropies = new List<double>();
            for (int i = 0; i < conterValue.Count; i++) entropies.Add(CountEntropy(conterValue[i], proper.Count));
            return entropies;
        }
        public static double CountEntropy(Dictionary<string, int> dic, int sum)
        {
            List<double> elements = new List<double>();
            foreach(int element in dic.Values)
            {
                double todo = (double)element / sum;
                if (element == 0) elements.Add(0);
                else elements.Add(todo * Math.Log2(todo));
            }

            return -elements.Sum();
        }
    }

}//