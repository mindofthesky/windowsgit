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
                //�����佺
                string cointos = this.comboBox1.Text;
                //�����İ�
                string turn = this.comboBox2.Text;
                //���� 



                // argment error ������ �ƹ��͵� �ȳ��ͼ� ã����
            }
            catch(Exception ex) { }



            DateTime dateTime = DateTime.Now;
            
        }
    }
}
