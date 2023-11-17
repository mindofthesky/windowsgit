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
}
