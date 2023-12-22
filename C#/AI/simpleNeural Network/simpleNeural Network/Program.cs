using System.Data;

class neuralNetwork
{
    public Random random;
    public int SynapseMatrixColumns { get; }
    public int SynapseMatrixLines { get; }
    public double[,] SynapsesMatrix { get; private set; }
    public neuralNetwork(int synapseMatrixColumns, int synapseMatrixLines)
    {
        SynapseMatrixColumns = synapseMatrixColumns;
        SynapseMatrixLines = synapseMatrixLines;
        _Init();
    }
    public void _Init()
    {
        random = new Random(1);
        GetnerateSynapsesMatrix();
    }
    public void GetnerateSynapsesMatrix()
    {
        SynapsesMatrix = new double[SynapseMatrixLines, SynapseMatrixColumns];
        for(int i = 0; i < SynapseMatrixLines; i++)
            for(int j = 0; j <SynapseMatrixColumns; j++) SynapsesMatrix[i,j] = (2* random.NextDouble()) -1;
    }
    public double[,] CalculateSigmoid(double[,] matrix)
    {
        int rowLeng = matrix.GetLength(0);
        int colLeng = matrix.GetLength(1);
        for (int i = 0; i<rowLeng; i++)
            for( int j = 0; j<colLeng; j++)
            {
                double value = matrix[i, j];
                matrix[i, j] = 1 / (1 + Math.Exp(value * -1));
            }

        return matrix;
    }
    public static double[,] MatrixDotProduct(double[,] matrixa, double[,] matrixb)
    {
        double rowa = matrixa.GetLength(0);
        double cola = matrixa.GetLength(1);

        double rowb = matrixb.GetLength(0);
        double colb = matrixb.GetLength(1);

        if (cola != rowb) throw new Exception();

        double[,] result = new double[(int)rowa, (int)rowb];
        for (int i = 0; i < rowa; i++)
            for (int j = 0; j < colb; j++)
                for (int k = 0; k < rowb; k++) result[i, j] += matrixa[i, k] * matrixb[k, j];
        return result;
    }
    public double[,] Think(double[,] input)
    {
        double[,] productof = MatrixDotProduct(input, SynapsesMatrix);
        return CalculateSigmoid(productof);
    }
    public static double[,] MatrixTranspose(double[,] matrix)
    {
        int w = matrix.GetLength(0);
        int h = matrix.GetLength(1);
        double[,] result = new double[h,w];
        for(int i = 0; i<w; i++)
            for(int j = 0; j<h; j++)
                result[j,i]= matrix[i,j];
        return result;
    }
    public double[,] MatrixSum(double[,] matrixa, double[,] matrixb)
    {
        int rowa = matrixa.GetLength(0);
        int cola = matrixb.GetLength(1);
        double[,] result = new double[rowa, cola];
        for(int i = 0; i<rowa; i++)
            for(int j = 0; j<cola; j++)
                result[i,j] = matrixa[i,j] + matrixb[i,j];
        return result;
    }
    public double[,] MatrixSubstract(double[,] matrixa, double[,] matrixb)
    {
        var rowa = matrixa.GetLength(0);
        var cola = matrixa.GetLength(1);
        double[,] result = new double[rowa, cola];
        for(int i = 0; i<rowa; i++)
            for(int j = 0; j<cola; j++)
                result[i,j] = matrixa[i,j] - matrixb[i,j];
        return result;
    }
    public double[,] MatrixProduct(double[,] matrixa, double[,] matrixb)
    {
        int rowa = matrixa.GetLength(0);
        int cola = matrixa.GetLength(1);
        double[,] result = new double[rowa, cola];
        for (int i = 0; i < rowa; i++)
            for (int j = 0; j < cola; j++)
                result[i, j] = matrixa[i, j] * matrixb[i, j];
        return result;
    }
    public void Train(double[,] traininputmatrix, double[,] trainoutputmatrix, int interaction)
    {
        for(int i = 0; i<interaction; i++)
        {
            double[,] output = Think(traininputmatrix);
            double[,] error = MatrixSubstract(traininputmatrix, output);
            double[,] simgmod = CalculateSigmoid(output);
            double[,] error_sigmod = MatrixProduct(error, simgmod);

            double[,] adj = MatrixDotProduct(MatrixTranspose(traininputmatrix), simgmod);


            SynapsesMatrix = MatrixSum(SynapsesMatrix, adj);

        }
    }
}