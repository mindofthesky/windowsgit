
using static Navie_Bayes.Algorithms<T>;

namespace Navie_Bayes 
{ 
    public class Program
    {
	
    private static readonly string[] LABELS = {
            "atheism","auto","baseball","christian","crypt","electronics","graphics","guns","hockey","ibm",
            "mac","medical","mideast","motorcycles","politics","religion","sale","space","windows","winx"};

    public static void Main(string[] args)
    {
        if (args.Length != 2)
        {
            Console.WriteLine("Please use 2 arguments: splits/train# splits/test#");
            return;
        }
        string train = args[0];
        string test = args[1];

        string dir = Path.GetDirectoryName(Path.GetDirectoryName(train));
        string dataPath = Path.Combine(dir, "data");

        string[] files = File.ReadAllLines(train);

        Dictionary<string, string> examples = new Dictionary<string, string>(files.Length);
        foreach (string file in files) examples.Add(file, File.ReadAllText(Path.Combine(dataPath, file)));


        files = File.ReadAllLines(test);
        Dictionary<string, string> tests = new Dictionary<string, string>(files.Length);
        foreach (string file in files) tests.Add(file, File.ReadAllText(Path.Combine(dataPath, file)));

        Algorithm algo = new Algorithm();

     
        algo.LearnNaiveBayes(examples, LABELS);

     
        algo.Classfiy(tests, LABELS);

        foreach (KeyValuePair<string, string> entry in algo.classifier) Console.WriteLine(entry.Key + " " + entry.Value);

       
      }
    }
}