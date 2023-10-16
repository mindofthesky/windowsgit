using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Serial_Comm_WF_NET.F
{
    public partial class Form1 : Form
    {
        string data;
        public Form1()
        {
            InitializeComponent();
            string[] port = SerialPort.GetPortNames();
            comboBox1.Items.AddRange(port);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.PortName = comboBox1.Text;
                serialPort1.BaudRate = Convert.ToInt32(comboBox2.Text);
                serialPort1.DataBits = Convert.ToInt32(comboBox3.Text);
                serialPort1.StopBits = (StopBits)Enum.Parse(typeof(StopBits), comboBox4.Text);
                serialPort1.Parity = (Parity)Enum.Parse(typeof(Parity), comboBox5.Text);

                serialPort1.Open();
                progressBar1.Value = 100;

            }catch (Exception ex) 
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(serialPort1.IsOpen)
            {
                serialPort1.Close();
                progressBar1.Value = 0;
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(serialPort1.IsOpen)
            {
                data = textBox1.Text;
                serialPort1.WriteLine(data);
            }
        }
    }
}
