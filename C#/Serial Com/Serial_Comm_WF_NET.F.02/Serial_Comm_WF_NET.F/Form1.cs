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
        string sendwith;
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
                button2.Enabled = true; button3.Enabled= false;
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(serialPort1.IsOpen)
            {   
                serialPort1.Close();
                progressBar1.Value = 0;
                button2.Enabled = true;
                button3.Enabled = false;
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(serialPort1.IsOpen)
            {
                data = textBox1.Text;
                if(sendwith == "writeLine")
                {
                    serialPort1.WriteLine(data);
                }else if (sendwith == "write")
                {
                    serialPort1.Write(data);
                }
               
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                serialPort1.DtrEnable = true;
            }
            else { serialPort1.DtrEnable = false; }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox2.Checked)
            {
                serialPort1.DtrEnable = true;
            }
            else { serialPort1.DtrEnable = false;}
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button2.Enabled = true;
            button3.Enabled = false;
            checkBox1.Checked = false;
            serialPort1.DtrEnable = false;
            checkBox2.Checked = false;
            serialPort1.RtsEnable = false;
            button1.Enabled = false;
            checkBox5.Enabled = false;
            checkBox6.Enabled = false;
            sendwith = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int dataOutLangth = textBox1.TextLength;
            label7.Text = string.Format("{0:00}", dataOutLangth);
            if (checkBox4.Checked)
            {
                textBox1.Text = textBox1.Text.Replace(Environment.NewLine, "");
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                button1.Enabled = false;
            }
            else
            {
                button1.Enabled = false;
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(checkBox4.Checked) {
                if (e.KeyCode == Keys.Enter)
                {
                    if (serialPort1.IsOpen)
                    {
                        data = textBox1.Text;
                        if (sendwith == "writeLine")
                        {
                            serialPort1.WriteLine(data);
                        }
                        else if (sendwith == "write")
                        {

                        }
                    }
                }
            }
        }

        private void checkBox6_CheckStateChanged(object sender, EventArgs e)
        {
            sendwith = "write";
            checkBox6.Checked = true;
            checkBox5.Checked = false;
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked)
            {
                sendwith = "writeLine";
                checkBox6.Checked = false;
                checkBox5.Checked = true;
            }
        }
    }
}
