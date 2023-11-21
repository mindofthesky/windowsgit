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