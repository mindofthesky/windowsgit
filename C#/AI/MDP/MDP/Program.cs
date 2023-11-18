using System.Text.RegularExpressions;

class mdp 
{

    public int numstates { get; set; }
    public int numactions { get; set; }
    public double gamma { get; set; }
    public Dictionary<string, double> StateDict;
    public Dictionary<string, double>[][,] transitionMatrix;
    public Dictionary<string, double>[] ActionProbability;
    public double[] Jest;

    public mdp(int numstates, int numactions, double gamma)
    {
        this.numstates = numstates;
        this.numactions = numactions;
        this.gamma = gamma;
        StateDict = new Dictionary<string, double>();
        transitionMatrix = new Dictionary<string, double>[numactions][,];
        ActionProbability = new Dictionary<string, double>[numactions];
        Jest = new double[numactions];
        for (int i = 0; i < numactions; i++) transitionMatrix[i] = new Dictionary<string, double>[numstates, numstates];
    }
    public void read_input(string file)
    {
        string input;
        string[] inputlines;

        try
        {
            var sr = new StreamReader(file);
            input = sr.ReadToEnd();
            inputlines = input.Split('\n');
            foreach(var item in inputlines)
            {
                IEnumerable<string> sequence = Regex.Split(item, @"").Take(2);
                StateDict.Add(sequence.First(), Convert.ToDouble(sequence.ElementAt(1)));

                MatchCollection mc = Regex.Matches(item, @"[a-z][1-9]([0-9]?)*|(\d*\.+\d+)|\d+");
                string[] matches = new string[mc.Count]; 
                int i = 0;
                foreach (Match m  in mc) matches[i++] = m.Value;
                for(i = 2; i< matches.Length; i += 3)
                {
                    ActionProbability[Convert.ToInt32(matches[i].Substring(1)) - 1] = new Dictionary<string, double>() { {matches[i], Convert.ToDouble(matches[i + 2]) }  };
                    transitionMatrix[Convert.ToInt32(matches[i].Substring(1)) - 1][Convert.ToInt32(matches[0].Substring(1)) - 1, Convert.ToInt32(matches[i + 1].Substring(1)) - 1] = ActionProbability[Convert.ToInt32(matches[i].Substring(1)) - 1];
                }
            }
        }
        catch
        {
            throw new Exception();
        }
    }
    public void init()
    {
        for (int i = 0; i < numstates; i++) Jest[i] = 0.0;
    }
    public void value_iter()
    {
        int statenum;
        double zero = 0;
        bool actionexist = false;
        double[] estimate = new double[numstates];
        double[] maxestimate = new double[numstates];
        int maxestindex;
        for(int count =0; count<20; count++)
        {
            foreach(var item in StateDict)
            {
                Match state = Regex.Match(item.Key, @"\d+");
                statenum = Convert.ToInt32(state.Value);
            }
        }
    }
}
