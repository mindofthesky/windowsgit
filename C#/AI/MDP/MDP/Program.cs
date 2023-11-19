using System.Text.RegularExpressions;

namespace MDP
{
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
            // 이거 파일없어서 에러납니다
            try
            {
                var sr = new StreamReader(file);
                input = sr.ReadToEnd();
                inputlines = input.Split('\n');
                foreach (var item in inputlines)
                {
                    IEnumerable<string> sequence = Regex.Split(item, @"").Take(2);
                    StateDict.Add(sequence.First(), Convert.ToDouble(sequence.ElementAt(1)));

                    MatchCollection mc = Regex.Matches(item, @"[a-z][1-9]([0-9]?)*|(\d*\.+\d+)|\d+");
                    string[] matches = new string[mc.Count];
                    int i = 0;
                    foreach (Match m in mc) matches[i++] = m.Value;
                    for (i = 2; i < matches.Length; i += 3)
                    {
                        ActionProbability[Convert.ToInt32(matches[i].Substring(1)) - 1] = new Dictionary<string, double>() { { matches[i], Convert.ToDouble(matches[i + 2]) } };
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
            for (int count = 0; count < 20; count++)
            {
                foreach (var item in StateDict)
                {
                    Match state = Regex.Match(item.Key, @"\d+");
                    statenum = Convert.ToInt32(state.Value);
                    for (int j = 0; j < numstates; j++)
                    {
                        for (int i = 0; i < numstates; i++)
                        {
                            actionexist = true;
                            estimate[j] += transitionMatrix[j][statenum - 1, i]["a" + (j + 1)] * Jest[i];
                        }
                        if (actionexist == false) estimate[j] = -1 / zero;
                        actionexist = false;
                    }
                    maxestimate[statenum - 1] = item.Value + gamma * estimate.Max();
                    maxestindex = estimate.ToList().IndexOf(estimate.Max()) + 1;
                    Console.WriteLine("(" + item.Key + " " + "a" + maxestimate + " " + maxestimate[statenum - 1] + ")");
                    for (int i = 0; i < estimate.Length; i++) estimate[i] = 0;
                }
                Console.WriteLine();
                if (count == 0)
                    for (int i = 0; i < numstates; i++) Jest[i] = StateDict["s" + (i + 1)];
                else for (int i = 0; i < Jest.Length; i++) Jest[i] = maxestimate[i];
            }
        }
        static void Main(string[] args)
        {

            Console.WriteLine("Enter number of states[space] number of actions[space] input file[space] and discount factor(gamma)");
            string[] arguments = Regex.Split(Console.ReadLine(), @" ");
            try
            {
                string input = arguments[2];
                mdp Mop = new mdp(Convert.ToInt32(arguments[0]), Convert.ToInt32(arguments[1]), Convert.ToDouble(arguments[3]));

                
                Mop.read_input(input);
                Mop.init();
                Mop.value_iter();
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("Error: " + ex + "\n\n Check if all the 4 parameters were given. Rerun and try giving the 4 parameters.\n exitting...");
                throw;
            }
            catch (FormatException ex)
            {

                Console.WriteLine("Error: " + ex + "\n\n The input arguments have not been provided in the expected format,Rerun and try giving the 4 parameters in correct format.\n exitting... ");
                throw;
            }

            Console.WriteLine("\n Press any key to continue...");
            Console.ReadKey();
        }
    }

}