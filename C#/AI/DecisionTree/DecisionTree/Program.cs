using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
// 149 , 27, 17 error 
namespace decsion
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // 파일 위치 지정 
            string path = @"C:\\Users\\mindo\\source\\repos\\DecisionTree\\DecisionTree\\bin\\breast-cancer.data";
            List<string> row = File.ReadAllLines(path).ToList();
            
            List<List<string>> tree = ProcessData(row);
            CreateTree(tree);
            Console.ReadKey();
           
        }
        public static void CreateTree(List<List<string>> tree, int add = 0)
        {

            List<string> decisionValues = CreateDecisionValues(tree);
            List<Dictionary<string, int>> countOfValues = PrepareDictionary(tree);
            List<double> entropy = CountEntropies(countOfValues, tree);
            List<double> informationfor = InformationFunc(countOfValues, tree, decisionValues);
            List<double> gain = Checkgain(countOfValues, informationfor, entropy); // error 여기 
            List<double> gainratio = countgainratio(gain, entropy);
            (double, int) biggain = selectgainratio(gainratio);
            int att = biggain.Item2;
            double attval = biggain.Item1;
            if(att != 0)
            {
                Console.WriteLine("Att: " + (att + 1));
                IOrderedEnumerable<string> value = valuein(tree, att).OrderBy(x=>x);
                foreach(string values in value)
                {
                    Console.WriteLine(new string(' ', add) + values);
                    List<List<string>> newDecisionset = new List<List<string>>();
                    foreach(List<string> row in tree)
                    {
                        if (row[att] == values) newDecisionset.Add(row);
                    }
                    CreateTree(newDecisionset,add + 4);
                }
                
            }
            else Console.WriteLine("D : " + tree.LastOrDefault().LastOrDefault());
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
            List<Dictionary<string, int>> countofvalue = new List<Dictionary<string, int>>();
            for (int i = 0; i < proper.FirstOrDefault().Count; i++) countofvalue.Add(checkpro(i, proper));
            return countofvalue;
        }
        public static List<string> CreateDecisionValues(List<List<string>> tree)
        {
            List<string> decisionValues = new List<string>();
            foreach (List<string> row in tree) if(!decisionValues.Contains(row.LastOrDefault())) decisionValues.Add(row.LastOrDefault()); 
            // yes, no data 부분 파싱
            return decisionValues;
        }
        public static List<double> CountEntropies(List<Dictionary<string, int>> conterValue, List<List<string>> proper)
        {
            List<double> entropies = new List<double>();
            for (int i = 0; i < conterValue.Count; i++) entropies.Add(CountEntropy(conterValue[i], proper.Count));
            return entropies;
        }

        public static Dictionary<string, int> checkpro (int col, List<List<string>> proper)
        {
            Dictionary<string, int> valuesForColumn = new Dictionary<string, int>();
            for (int i = 0; i < proper.Count; i++)
            {
                if (valuesForColumn.ContainsKey(proper[i][col])) valuesForColumn[proper[i][col]]++;
                else valuesForColumn[proper[i][col]] = 1;             
            }
            return valuesForColumn;
        }
        
        public static double CountEntropy(Dictionary<string, int> dic, int sum)
        {   //엔트로피 지수 
            List<double> elements = new List<double>();
            foreach(int element in dic.Values)
            {
                double todo = (double)element / sum; //범주안에 10개 파란점 빨간점 6개가있다면 10/16 , 6/16 으로 나누는 값 
                if (element == 0) elements.Add(0);
                else elements.Add(todo * Math.Log2(todo)); // 엔트로피 지수 
                
            }
            Console.WriteLine(-elements.Sum()); // 엔트로피 지수의 합 
            return -elements.Sum();
        }
        public static List<double> InformationFunc(List<Dictionary<string,int>> countofvalue, List<List<string>> proset, List<string> decisonvalue) 
        {
            // 정보함수
            List<double> InformationFunc = new List<double>();
            for(int i =0; i < countofvalue.Count -1; i++)
            {
                Dictionary<string, Dictionary<string, int>> attributevalue = Attributevalue(i, proset);
                List<double> listofvalue = new List<double>();
                foreach(KeyValuePair<string,int> x in countofvalue[i])
                {
                    int sum = attributevalue[x.Key].Values.Sum();
                    double entropy = CountEntropy(GetDictionaryForEntropy(attributevalue, x.Key,decisonvalue),sum);
                    listofvalue.Add((double)x.Value/ proset.Count * entropy);
                }
                listofvalue.Add(listofvalue.Sum());
            }
            return InformationFunc;

        }
        public static Dictionary<string,Dictionary<string,int>> Attributevalue(int col, List<List<string>> proset)
        {
            Dictionary<string, Dictionary<string,int>> attributeToValue = new Dictionary<string, Dictionary<string,int>>();
            for (int i = 0; i < proset.Count; i++)
            {
                string key = proset[i][col];
                string value = proset[i][proset.FirstOrDefault().Count - 1];
                if (attributeToValue.ContainsKey(key))
                {
                    if (attributeToValue[key].ContainsKey(value)) attributeToValue[key][value]++;
                    else attributeToValue[key][value] = 1;
                }
                else attributeToValue[key] = new Dictionary<string, int> { { value, 1 } };
            }
            return attributeToValue;
        }
        public static Dictionary<string, int> GetDictionaryForEntropy(Dictionary<string, Dictionary<string, int>> attributeToValue, string key, List<string> decisionValues)
        {
            Dictionary<string, int> toReturn = new Dictionary<string, int>();
            for (int i = 0; i < decisionValues.Count; i++)
            {
                attributeToValue[key].TryGetValue(decisionValues[i], out int value);
                toReturn.Add(decisionValues[i], value);
            }
            return toReturn;
        }
        public static List<double> Checkgain(List<Dictionary<string, int>> countofValues, List<double> inforvalues, List<double> entropy)
        {
            List<double> gain = new List<double>();
            for (int i = 0; i < countofValues.Count-1; i++) gain.Add(entropy.LastOrDefault() - inforvalues[i]);
            return gain;
        }
        public static List<double> countgainratio(List<double> gain , List<double> entropy)
        {
            List<double> gainratio = new List<double>();    
            for(int i=0; i< gain.Count; i++)
            {
                if (entropy[i] != 0) gainratio.Add(gain[i] / entropy[i]);
                else gainratio.Add(0);
            }
            return gainratio;
        }
        public static (double,int) selectgainratio(List<double> gainratio)
        {
            double biggestgain = 0;
            int biggestindex = 0;
            for (int i = 0; i < gainratio.Count; i++)
            {
                if (gainratio[i] >= biggestgain)
                {
                    biggestgain = gainratio[i];
                    biggestindex = i;   
                }
            }
            return (biggestgain,biggestindex);
        }
        public static List<string> valuein (List<List<string>> proset, int attributindex)
        {
            List<string > value =new List<string>();
            for (int i = 0; i < proset.Count; i++) value.Add(proset[i][attributindex]);
            return value.Distinct().ToList();
        }
    }

}