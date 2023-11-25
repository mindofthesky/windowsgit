// See https://aka.ms/new-console-template for more information
using Random_Forest;

LabeledData[] data = Util.ReadData("C\\tmep\\.csv");
data = Util.BalanceClasses(data);
(var train, var test) = Util.Split(data);

DescisionTree tree = new DescisionTree(2, 6, data[0].Length);
tree.Train(train);
int numCorrect = 0; 
foreach (LabeledData d in train)
{
    int yPred = tree.Predict(d);
    if(yPred == d.Label) numCorrect++;
}
Console.WriteLine($"Decision tree train accuracy :{((double)numCorrect / train.Length):F3}, ({numCorrect}/{train.Length})");

Forest forest = new Forest(300, train.Length, 10,4,12);

forest.Train(train);

numCorrect = 0;

foreach (LabeledData d in train)
{
    Dictionary<int,double> pro = forest.Predict(d);
    double maxpro = double.MinValue;
    int chose = -1;
    foreach (var pair in pro)
    {
        if (pair.Value > maxpro)
        {
            maxpro = pair.Value;
            chose = pair.Key;
        }
    }
    if (chose == d.Label) numCorrect ++;
}

numCorrect = 0;

foreach (LabeledData d in test)
{
    Dictionary<int, double> pros = forest.Predict(d);
    double maxprosa = double.MinValue;
    int chosea = -1;
    foreach(var pair in pros)
    {
        if(pair.Value > maxprosa)
        {
            maxprosa = pair.Value;
            chosea = pair.Key;
        }
        if(chosea == d.Label) numCorrect++;
    }
}