using System.Data;

namespace MyDuel
{
    public partial class Form1 : Form
    {
        DataGridView data = new DataGridView();
        public Form1()
        {
            InitializeComponent();
            listView1.View = View.Details;
            listView1.BeginUpdate();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            ListView lvl = new ListView();
            ListViewItem item = new ListViewItem();

            
            try
            {
                //코인토스
                string cointos = this.comboBox1.Text;
                //선공후공
                string turn = this.comboBox2.Text;
                //전적 



                // argment error 이전에 아무것도 안나와서 찾는중
            }
            catch(Exception ex) { }



            DateTime dateTime = DateTime.Now;
            
        }
    }
}
