using System.Data;

namespace MyDuel
{
    public partial class Form1 : Form
    {

        public Form1()
        {

            InitializeComponent();
            #region listview 1 setting
            listView1.View = View.Details;
            listView1.BeginUpdate();
            listView1.GridLines = true;

            // index = 0�����ϸ� 0��°������ ��� ���⶧���� ���� Ÿ���� �޾ƿ�������

            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;

            listView1.Columns[0].Width = 50;
            listView1.Columns[1].Width = 70;
            listView1.Columns[2].Width = 50;
            listView1.Columns[3].Width = 50;
            listView1.Columns[4].Width = 80;
            listView1.Columns[5].Width = 80;
            listView1.Columns[6].Width = 90;
            listView1.Columns[7].Width = 55;
            #endregion
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            #region Click Event
            // DropStyle ���� DropDownList 
            string cointos = this.comboBox1.Text;
            //�����İ�
            string turn = this.comboBox2.Text;
            //���� ����
            string outcome = this.comboBox3.Text;
            //���� 
            string myDeck = this.textBox1.Text;
            //��뵦
            string otherDeck = this.textBox2.Text;
            //��� 
            string etc = this.textBox3.Text;
            //��¥
            DateTime dateTime = DateTime.Now;
            
            ListViewItem item = new ListViewItem();
            // ltem.text �� 0��°�� sub�� 0������ ���̹Ƿ� subitem�� �ִ°�� 0��° �࿡ ���� ��������
            int count = listView1.Items.Count + 1;
            //count ���� �����ϰ� listview �ڵ����� ���� �ֱ����� ī��Ʈ�ϴ¹��� ����Ʈ���� ���ڸ� ���°� ����
            // ī��Ʈ �Ǽ�
            listView1.Items.Add(item);
            item.Text = count.ToString();
            // �����佺 �յ� 
            item.SubItems.Add(cointos);
            //������ �·��� �����ؾ��� 
            
            int count_frist = 0;
            
            cointos.Equals("����");
            
            // ���İ� 
            item.SubItems.Add(turn);
            
            // ���
            item.SubItems.Add(outcome);
            // �� ��
            item.SubItems.Add(myDeck);
            // ��뵦 
            item.SubItems.Add(otherDeck);
            // ����
            item.SubItems.Add(etc);
            // ��¥��
            item.SubItems.Add(Convert.ToString(DateTime.Now.ToString("yyMMdd")));

            #endregion

            #region �·�����
            ListViewItem item2 = new ListViewItem();
            //����Ʈ��2���� �������� ��Ӻ���Ǿ���� ����Ʈ ��� ���� ����Ǹ�ȵǴ� �о߰� �������� �����ʱ⶧���� ����Ʈ��� ���ѵ�
            // �������� �ٲܼ� �ִ°� DataGrid�� �ƴѰ�? ����! 
            int list2count = listView1.Items.Count;
            DataTable table  = new DataTable();
            table.Columns.Add("�÷��� ��",typeof(string));
            table.Columns.Add("�·�",typeof(string));
            table.Rows.Add(list2count, "�·�");
            dataGridView1.DataSource = table;
            #endregion
        }



        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void ���·�Ȯ���ϱ�ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //���ݰ�����ο�Ұ��ִµ� 
            // Form2 �� ���� �����ִ��� 
            //�׳� �ٺ����ִ���
        }
    }
}
