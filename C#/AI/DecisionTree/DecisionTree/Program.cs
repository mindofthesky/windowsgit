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
            string path = "C:\\Users\\mindo\\source\\repos\\DecisionTree\\DecisionTree\\bin\\breast-cancer.data";
            List<string> row = File.ReadAllLines(path).ToList();
            List<List<string>> Tree = ProcessData(row);
            CreateTree(Tree);
        }
        public static void CreateTree(List<List<string>> tree, int add = 0)
        {
            List<string> decisionValues = CreateDecisionValues(tree);
            List<Dictionary<string, int>> countOfValues = PrepareDictionary(tree);

        }
        public static List<string> CreateDecisionValues(List<List<string>> tree)
        {
            List<string> decisionValues = new List<string>();
            foreach (List<string> row in tree) if (!decisionValues.Contains(row.LastOrDefault())) decisionValues.Add(row.LastOrDefault());
            return decisionValues;
        }
        public static List<List<string>> ProcessData(List<string> rows)
        {
            List<List<string>> properSet = new List<List<string>>();
            for (int i = 0; i < rows.Count; i++) properSet.Add(rows[i].Split(',').ToList());
            return properSet;
        }
        public static List<Dictionary<string, int>> PrepareDictionary(List<List<string>> proper)
        {
            List<Dictionary<string,int>> countofvalue = new List<Dictionary<string,int>>();
            for (int i = 0; i < proper.FirstOrDefault().Count; i++) countofvalue.Add(checkpro(i,proper));
            return countofvalue;
        }
        public static Dictionary<string, int> checkpro (int col, List<List<string>> proper)
        {
            Dictionary<string, int> valuesForColumn = new Dictionary<string, int>();
            for (int i = 0; i < proper.Count; i++)
            {
                if (valuesForColumn.ContainsKey(proper[i][col]))
                    valuesForColumn[proper[i][col]]++;
                else
                    valuesForColumn[proper[i][col]] = 1;
            }
            return valuesForColumn;
        }
    }

}//