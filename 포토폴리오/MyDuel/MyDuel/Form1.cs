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
            dataGridView2.ReadOnly = true;
            dataGridView1.ReadOnly = true;


        }
        // �������� �ְ��ϸ� ���������� ������
        // �¸� �й� , �ո� �޸�, ���� �İ� 
        static int win = 0;
        static int lose = 0;
        static int front = 0;
        static int back = 0;
        static int turn_frist = 0;
        static int turn_second = 0;
        static double turn_frist_win = 0;
        static double turn_second_win = 0;
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
            // �·��̶� ��ü �÷��� �� �߿��� �¸��� ī�����ϸ�� 

            // comboBox3.SelectedIndex = 0; // �̰� �¸���
            // ���� ��� ���ðų�? 


            //  �¸� / ��ü�÷���
            // �¸����� ����� 


            if (cointos.Equals("����"))

                // ���İ� 
                item.SubItems.Add(turn);

            // ���

            item.SubItems.Add(outcome);

            // ���������� ������������ 
            // ���⼭ 0�� Ŭ���� ���ÿ� �ٽ� 0���� ��ȯ�Ǳ⶧���� �׷��� �·��̶�� ���信 ���� �־��ֱ� ���ѵ�


            if (outcome.Equals("�¸�")) win++;
            else if (outcome.Equals("�й�")) lose++;

            if (cointos.Equals("�ո�")) front++;
            else if (cointos.Equals("�޸�")) back++;

            if (turn.Equals("����")) turn_frist++;
            else if (turn.Equals("�İ�")) turn_second++;

            if (turn.Equals("����") && outcome.Equals("�¸�")) turn_frist_win++;
            else if (turn.Equals("�İ�") && outcome.Equals("�¸�")) turn_second_win++;
            // �� ��
            item.SubItems.Add(myDeck);
            // ��뵦 
            item.SubItems.Add(otherDeck);
            // ����
            item.SubItems.Add(etc);
            // ��¥��
            item.SubItems.Add(Convert.ToString(DateTime.Now.ToString("yyMMdd")));
            // ����Ʈ���� �ڵ���ũ�ѹ�
            listView1.Items[listView1.Items.Count - 1].EnsureVisible();

            #endregion

            #region �·�����
            ListViewItem item2 = new ListViewItem();
            //����Ʈ��2���� �������� ��Ӻ���Ǿ���� ����Ʈ ��� ���� ����Ǹ�ȵǴ� �о߰� �������� �����ʱ⶧���� ����Ʈ��� ���ѵ�
            // �������� �ٲܼ� �ִ°� DataGrid�� �ƴѰ�? ����! 
            double list2count = listView1.Items.Count;
            DataTable table = new DataTable();
            table.Columns.Add("�÷��� ��", typeof(string));
            table.Columns.Add("�·�", typeof(string));
            table.Columns.Add("�¼�", typeof(int));
            table.Columns.Add("�й�", typeof(int));
            // int list2count ���������ǵ��ձ⶧���� int�������� �ٵȴ� , ���� ���� �����ֱ⶧���� �ٸ� Row�� �����ϸ� ��õ�����ʴ´�
            table.Rows.Add(list2count, Math.Round(win / list2count * 100) + "%", win, lose);
            DataTable table2 = new DataTable();

            // list2count , count_win ���� �����ϰ��ֱ⿡ 100�۸� �����ǹ���  >> static���� �ذ� ��� �̰� �� �ٺ����� �����̿�����
            // ��� ��ư�� ������ 0 > 1 ������ �ݺ��ϴµ� �׳� �������غ��ϱ� 0�� �ٱ��� �θ� �������������ʳ��� �´� ���̸¾���
            table2.Columns.Add("��", typeof(string));
            table2.Columns.Add("��", typeof(string));
            table2.Columns.Add("�����·�", typeof(string));
            table2.Columns.Add("�İ��·�", typeof(string));
            // �� �й踦 ���� �� 
            // int ������������ �Ҽ����� �����Ǽ� 0���� �����⶧���� double������ ������ ������ �߻����������� �Ҽ����� Math.Round�� ó��
            table2.Rows.Add(front, back, Math.Round(turn_frist_win / turn_frist * 100) + "%", Math.Round(turn_second_win / turn_second * 100) + "%");

            dataGridView1.DataSource = table;
            dataGridView2.DataSource = table2;

            //dataGridView1.DataSource= table2;
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
        // enter ó�� ���� 
        #region enter datagrid ����
        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int colums = dataGridView1.CurrentCell.ColumnIndex;
                int row = dataGridView1.CurrentCell.RowIndex;
                dataGridView1.CurrentCell = dataGridView1[colums, row];
                e.Handled = true;
            }
        }

        private void dataGridView2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int colums = dataGridView2.CurrentCell.ColumnIndex;
                int row = dataGridView2.CurrentCell.RowIndex;
                dataGridView2.CurrentCell = dataGridView2[colums, row];
                e.Handled = true;
            }
        }
        #endregion
    }
}
