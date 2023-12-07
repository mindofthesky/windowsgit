using MyDuel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace MyDuel
{
    public partial class Form2 : Form
    {
        Form1 frm1 = new Form1();

        public Form2()
        {

            InitializeComponent();
            listView1.View = View.Details;
            listView1.GridLines = true;
            DataTable? table2 = new DataTable();
            table2.Columns.Add("플레이 수", typeof(string));
            table2.Columns.Add("승률", typeof(string));
            table2.Columns.Add("승수", typeof(int));
            table2.Columns.Add("패배", typeof(int));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string myDeck = this.textBox1.Text;
            //상대덱
            string otherDeck = this.textBox2.Text;
        }
    }
}
