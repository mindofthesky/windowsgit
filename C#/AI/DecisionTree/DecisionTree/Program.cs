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
            CreateTree(tree);
        }
        public static void CreateTree(List<List<string>> tree, int add = 0)
        {
            List<string> decisionValues = CreateDecisionValues(tree);
        }
        public static List<string> CreateDecisionValues(List<List<string>> tree)
        {
            List<string> decisionValues = new List<string>();
            foreach (List<string> row in tree) if (!decisionValues.Contains(row.LastOrDefault())) decisionValues.Add(row.LastOrDefault());
            return decisionValues;
        }
    }
   
}