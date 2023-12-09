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
        double resivedata = 0;

        public Form2()
        {

            InitializeComponent();
            listView1.View = View.Details;
            listView1.GridLines = true;
            DataTable table = new DataTable();
            table.Columns.Add("플레이수", typeof(string));
            table.Columns.Add("승률", typeof(string));

            table.Rows.Add(resivedata, 1);

            dataGridView1.DataSource = table;

        }
        public Form2(double ls)
        {

           

        }
        static int win;
        static int count = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            string myDeck = this.textBox1.Text;
            //상대덱
            string otherDeck = this.textBox2.Text;
            ListViewItem item = new ListViewItem();
            item.Text = myDeck;
            listView1.Items.Add(item);
            item.SubItems.Add(otherDeck);
            DataTable table = new DataTable();
            table.Columns.Add("플레이수", typeof(string));
            table.Columns.Add("승률",typeof(string));

            table.Rows.Add(resivedata, 1);

            dataGridView1.DataSource = table;
        }
    }
}
