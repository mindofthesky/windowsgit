namespace BackProPagation
{
    public partial class Form1 : Form
    {
        int k, l, n, m = 0, node;
        double theta = 0.5;
        double[,] input = new double[40, 2];
        double[,] output = new double[40, 2];
        double[,] le_w = new double[2, 100];
        double[,] le_v = new double[100, 2];
        double learning_rate, error, hidden1_tmp,hidden2_tmp , hidden_tmp, total_error, tolerate_error;
        double[] hidden;
        double[] hidden_error = new double[100];
        double[] output_error = new double[100];
        double[,] Y_out = new double[40, 2];
        double[,] Y_error = new double[40, 2];
        double[,] hidden_err = new double[40, 100];
        const int lah_input = 2, lah_out = 2, lah_pattern = 40;
        Random random = new Random();
        public Form1()
        {
            InitializeComponent();

        }
        public void aa()
        {
            // node = Convert.ToInt16(textBox1.Text);
            // tolerate_error = Convert.ToDouble(textBox2.Text);
            // learning_rate = Convert.ToDouble(textBox3.Text);
            input[0, 0] = 0.01;


            for (k = 0; k < lah_input; k++)
            {
                for (l = 0; l < node; l++)
                {
                    le_w[k, l] = random.NextDouble();
                }
            }
            for (k = 0; k < node; k++)
            {
                for (l = 0; l < lah_out; l++)
                {
                    le_v[k, l] = random.NextDouble();
                }
            }
        }

        #region tick
        public void tick()
        {
            error = 0;
            for (n = 0; n < lah_pattern; n++)
            {
                for (k = 0; k < node; k++)
                {
                    hidden1_tmp = 0;
                    for (l = 0; l < lah_input; l++)
                    {
                        hidden1_tmp = hidden1_tmp + input[n, l] * le_w[l, k];
                    }
                    hidden[k] = (1 / (1 + Math.Exp(-1.0 * (hidden1_tmp + 1))));
                }
                for (k = 0; k < lah_out; k++)
                {
                    for (l = 0; l < node; l++) 
                    { 
                        hidden2_tmp = hidden2_tmp + hidden[l] * le_w[l, k];
                    }
                    Y_out[n,k] =(1/ (1+ Math.Exp(-1.0 * (hidden2_tmp + 1))));
                }

                for(k =0; k< lah_out; k++)
                {
                    output_error[k] = (output[n, k] - Y_out[n, k]) * ((Y_out[n, k]) * (1- Y_out[n,k]));
                    Y_error[n, k] = output_error[k];

                }
                for(k =0; k<node; k++)
                {
                    hidden_tmp = 0;
                    for(l=0; l<lah_out; l++)
                    {
                        hidden_tmp = hidden_tmp + output_error[l] * le_v[k, l];
                    }
                    hidden_error[k] = (hidden[k] * (1 - hidden[k])) * hidden_tmp;
                    hidden_err[n,k] = hidden_error[k];  
                }
                for(k=0; k< node; k++)
                {
                    for(l =0; l<lah_out; l++)
                    {
                        le_v[k, l] = le_v[k,l] + learning_rate * output_error[l] * hidden[k];
                    }
                }

                for(k=0; k<lah_input; k++)
                {
                    for(l = 0; l<node; l++)
                    {
                        le_w[k,l] = le_w[k,l] + learning_rate * hidden_error[l] * input[n,k];
                    }
                }
                error = error + Math.Abs(Y_error[n, 1]);
            }

            total_error = error / lah_pattern;
            // textbox5.Text = total_error.ToString();
            m = m + 1;
            m.ToString();
            //this.chart >

            if(total_error < tolerate_error)
            {

                for(k=0; k<node; k++)
                {
                    for(l=0; l<lah_out;l++)
                    {
                        le_v[k, n].ToString();
                    }
                }
                for(k=0; k<lah_input; k++)
                {
                    for(l=0; l<node; l++)
                    {
                        le_w[k,l].ToString();
                    }
                }
            }

        }
        #endregion

        public void puts() 
        { 
            
            for(k=0; k<node; k++)
            {
                hidden1_tmp = 0;
                for(l=0; l<lah_input; l++)
                {
                    hidden1_tmp = hidden1_tmp + input[0,l] * le_w[k,l];
                }

                hidden[k] = (1 / (1 + Math.Exp(-1.0 * (hidden1_tmp + 1))));
            }

            for(k=0; k<lah_out; k++)
            {
                hidden2_tmp = 0;
                for(l=0; l<node; l++)
                {
                    hidden2_tmp = hidden2_tmp + hidden[l] * le_v[l,k];
                }
                Y_out[0,k] = (1 /(1 +Math.Exp(-1.0 * (hidden2_tmp+1))));

                if (Y_out[0,k] > theta)
                {

                }
                else
                {

                }
            }
        }
    }
}