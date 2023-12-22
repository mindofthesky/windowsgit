using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Navie_Bayes
{
    public class Algorithms<T> : ICollection<T>
    {
        public Dictionary<T, int> d;
        public Algorithms() { d = new Dictionary<T, int>(); }
        public Algorithms(int capacity) { d = new Dictionary<T, int>(capacity); }

        public Algorithms(IEnumerable<T> col) : this() { AddRange(col); }

        public IDictionary<T, int> D { get { return d; } }
        public int this[T key] { get { return d[key]; } }
        public int Count { get { return d.Count; } }
        public int totalWordCount = 0;
        public int TotalWordCount
        {
            get { return totalWordCount; }
            set { totalWordCount = value; }
        }
        public virtual void Add(T item)
        {
            if (!d.ContainsKey(item)) d.Add(item, 1);
            else d[item]++;
        }
        public void AddRange(IEnumerable<T> col) { foreach (T item in col) Add(item); }
        public bool Contains(T item) { return d.ContainsKey(item); }
        public bool Remove(T item) { return d.Remove(item); }
        public void Clear() { d.Clear(); }
        public void CopyTo(T[] array, int arrayIndex) { d.Keys.CopyTo(array, arrayIndex); }
        public bool IsReadOnly { get { throw new NotImplementedException(); } }
        public IEnumerator<T> GetEnumerator() { return d.Keys.GetEnumerator(); ; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { return d.Keys.GetEnumerator(); }

        public T[] ToArray()
        {
            List<T> lista = new List<T>(d.Keys);
            return lista.ToArray();
        }
        public class Algorithm
        {
            public const double Base = 2.0d;
            public const string REGEX_WORD = @"[a-zA-Z]";
            public static readonly Regex regex = new Regex(REGEX_WORD, RegexOptions.Compiled);

            public Algorithms<string> voca = new Algorithms<string>();
            public Dictionary<string, Algorithms<string>> docs = new Dictionary<string, Algorithms<string>>();
            public Dictionary<string, double> prior = new Dictionary<string, double>();
            public Dictionary<string, Dictionary<string, double>> fea = new Dictionary<string, Dictionary<string, double>>();
            public Dictionary<string, string> classifier = new Dictionary<string, string>();

            public void LearnNaiveBayes(Dictionary<string, string> exmaple, string[] label)
            {
                Dictionary<string, int> match = new Dictionary<string, int>(label.Length);
                foreach (string labels in label)
                {
                    match.Add(labels, 0);
                    docs.Add(labels, new Algorithms<string>());
                    fea.Add(labels, new Dictionary<string, double>());
                }
                double exampleCount = (double)exmaple.Count;
                ICollection<string> word;
                foreach(KeyValuePair<string,string> entry in exmaple)
                {
                    word = GetWord(entry.Value);
                }

            }
            public void Remove(int p,string[] labes)
            {
                List<KeyValuePair<string,int>> list = new List<KeyValuePair<string, int>>(voca.D);
                list.Sort(delegate (KeyValuePair<string, int> e1, KeyValuePair<string, int> e2) { return e1.Value.CompareTo(e2.Value); });
                list.Reverse();
                for (int i = 0; i <p; i++)
                {
                    voca.Remove(list[i].Key);
                    foreach(string key in labes) docs[key].Remove(list[i].Key);
                }
            }
            public void Classfiy(Dictionary<string, string> test, string[] labels)
            {
                Dictionary<string, double> heap;
                ICollection<string> position;
                List<double> sorter;
                foreach(KeyValuePair<string,string> doc in test)
                {
                    heap = new Dictionary<string, double>();
                    foreach(string key in labels)
                    {
                        double v = prior[key];
                        foreach (string ai in position) v += GetLogHood(key, ai);
                        heap.Add(key, v);
                    }
                    sorter = new List<double>();
                    sorter.Sort();
                    foreach(KeyValuePair<string, double> entry in heap) if(entry.Value == sorter[0]) classifier.Add(doc.Key, entry.Key);
                }
            }
            public double GetLogHood(string key, string ai)
            {
                double result;
                if (fea[key].TryGetValue(ai, out result)) return result;

                result = Calhood(0, docs[key].totalWordCount, ai);
                fea[key][ai] = result;
                return result;
            }
            public double Calhood(int nk, int n, string w)
            {
                int m = voca.Count;
                double q = 0d;
                int num = 0, demon = 0;
                foreach (Algorithms<string> doc in docs.Values)
                {
                    num += doc.Contains(w) ? doc[w] : 0;
                    demon += doc.TotalWordCount;
                }
                q = ((double)(num + 1) / (demon + voca.Count));
                double result = Math.Abs(Math.Log(
                                    ((double)n / (n + m)) * ((double)nk / n)
                                    + ((double)m / (n + m)) * q
                                , Base));
                return result;
            }
            public ICollection<string> GetWord(string text) { return GetWord(text, false); }
            private ICollection<string> GetWord(string text, bool check)
            {
                string filter = text.ToLower();
                List<string> words = new List<string>();
                foreach (Match m in re.Matches(filter))
                {
                    
                    if (m.Value.Length > 2 && (!check || (check && voca.Contains(m.Value))))  words.Add(m.Value);
                   
                }
                return words;
            }
            public static string[] TostringArray<K,V>(IDictionary<K,V> dict)
            {
                string[] result = new string[dict.Count];
                int i = 0;
                foreach (KeyValuePair<K, V> entry in dict) result[i++] = string.Format("{0}:{1}", entry.Key, entry.Value);
                return result;
            }
        }
    }
}
