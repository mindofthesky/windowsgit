using System.Data;

namespace MyDuel
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {

            InitializeComponent();
            
            listView1.View = View.Details;
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
            
            // dataGridView1,2,3
            // AutoSizeColumnsMode > Fill ó�� , dataGridView1.AutoSizeRowsMode = displayed ó��  RowHeadersVisible = False ó�� 

            dataGridView1.ReadOnly = true;
            dataGridView2.ReadOnly = true;
            dataGridView3.ReadOnly = true;



            #region ������ �̸��ε� 
            double list2count = listView1.Items.Count;
            DataTable? table = new DataTable();
            table.Columns.Add("�÷��� ��", typeof(string));
            table.Columns.Add("�·�", typeof(string));
            table.Columns.Add("�¼�", typeof(int));
            table.Columns.Add("�й�", typeof(int));
            table.Rows.Add(list2count, Math.Round(win / list2count * 100) + "%", win, lose);


            DataTable? table2 = new DataTable();
            table2.Columns.Add("��", typeof(string));
            table2.Columns.Add("��", typeof(string));
            table2.Columns.Add("�����·�", typeof(string));
            table2.Columns.Add("�İ��·�", typeof(string));
            table2.Rows.Add(front, back, Math.Round(turn_frist_win / turn_frist * 100) + "%", Math.Round(turn_second_win / turn_second * 100) + "%");

            DataTable table3 = new DataTable();
            table3.Columns.Add("��¥", typeof(string));
            table3.Columns.Add("�Ǽ�", typeof(string));
            table3.Columns.Add("�����佺", typeof(string));
            table3.Columns.Add("�·�", typeof(string));
            table3.Rows.Add(DateTime.Now.ToString("yyMMdd"), list2count, front + ":" + back);
            dataGridView1.DataSource = table;
            dataGridView2.DataSource = table2;
            dataGridView3.DataSource = table3;
            #endregion
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
        static int count_day = 0;
        static int but_count = 0;
        // ��¥ �Ϸ縦 �����ϴ°��� ��������?
        // �����Ҷ��� ���� �������� ���� ���Ҽ��ִ� 
        static string aa = DateTime.Now.ToString("yyMMdd");
        // ���������� ����ӽ� ���� ���������� �������⶧����
        // Event�� ����̾���
        public static string listcut;
        public static string datacut;
       
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
            //item.SubItems.Add("dd"+aa); >> ������ ���� �´µ� 
            // ����Ʈ���� �ڵ���ũ�ѹ�
            listView1.Items[listView1.Items.Count - 1].EnsureVisible();

            // ���������� ������������ 
            // ���⼭ 0�� Ŭ���� ���ÿ� �ٽ� 0���� ��ȯ�Ǳ⶧���� �׷��� �·��̶�� ���信 ���� �־��ֱ� ���ѵ�

            //��������� ���� 
            if (outcome.Equals("�¸�")) win++;
            else if (outcome.Equals("�й�")) lose++;
            //�����佺�� ���� ����
            if (cointos.Equals("�ո�")) front++;
            else if (cointos.Equals("�޸�")) back++;
            // ���İ��� ���� ����
            if (turn.Equals("����")) turn_frist++;
            else if (turn.Equals("�İ�")) turn_second++;
            // �����¸�, �İ� �¸� �Ǵ�
            if (turn.Equals("����") && outcome.Equals("�¸�")) turn_frist_win++;
            else if (turn.Equals("�İ�") && outcome.Equals("�¸�")) turn_second_win++;

            #endregion

            
            #region Table 1 Start 

            ListViewItem item2 = new ListViewItem();
            //����Ʈ��2���� �������� ��Ӻ���Ǿ���� ����Ʈ ��� ���� ����Ǹ�ȵǴ� �о߰� �������� �����ʱ⶧���� ����Ʈ��� ���ѵ�
            // �������� �ٲܼ� �ִ°� DataGrid�� �ƴѰ�? ����! 
            double list2count = listView1.Items.Count;
            
            DataTable? table = new DataTable();
            table.Columns.Add("�÷��� ��", typeof(string));
            table.Columns.Add("�·�", typeof(string));
            table.Columns.Add("�¼�", typeof(int));
            table.Columns.Add("�й�", typeof(int));
            // int list2count ���������ǵ��ձ⶧���� int�������� �ٵȴ� , ���� ���� �����ֱ⶧���� �ٸ� Row�� �����ϸ� ��õ�����ʴ´�
            table.Rows.Add(list2count, Math.Round(win / list2count * 100) + "%", win, lose);

            #endregion Table 1 End 

            #region Table 2 Start
            // Table nullable �� �ᵵ �ذ����� ���� NaNó���� �ٸ� ����� �ʿ��ϴ�
            DataTable? table2 = new DataTable();

            // list2count , count_win ���� �����ϰ��ֱ⿡ 100�۸� �����ǹ���  >> static���� �ذ� ��� �̰� �� �ٺ����� �����̿�����
            // ��� ��ư�� ������ 0 > 1 ������ �ݺ��ϴµ� �׳� �������غ��ϱ� 0�� �ٱ��� �θ� �������������ʳ��� �´� ���̸¾���
            table2.Columns.Add("��", typeof(string));
            table2.Columns.Add("��", typeof(string));
            table2.Columns.Add("�����·�", typeof(string));
            table2.Columns.Add("�İ��·�", typeof(string));
            // �� �й踦 ���� �� 
            
            double win_f = 0;
            double win_s = 0;
            // int ������������ �Ҽ����� �����Ǽ� 0���� �����⶧���� double������ ������ ������ �߻����������� �Ҽ����� Math.Round�� ó��
            table2.Rows.Add(front, back, Math.Round(turn_frist_win / turn_frist * 100) + "%", Math.Round(turn_second_win / turn_second * 100) + "%");





            //table3.Rows.Add("");
            //table3.Rows.Add(DateTime.Now.ToString("yyMMdd"), count_day, front + ":" + back);`
            //if (DateTime.Now.ToString("yyMMdd") != (DateTime.Now.ToString("yyMMdd")))
            //{
            //  table3.Rows.Add(DateTime.Now.ToString("yyMMdd"), count_day, front + ":" + back);
            //}





            #endregion
            #region �������� ������
            // �����Ͱ� listview���� ��ȯ�Ǵ� ���̶� listview�� �ƴϸ� ��ȯ�� �ȵǴ°ǰ�?
           



            #endregion


            #region Table3 Start 
            // table3 �� ��� ��¥���� �佺, �Ǽ�, �·��� �������� 


            // ��¥���� ����Ǿ���� 
            // ��¥�� ��¥�� ���� �ٸ� 
            // �Ǽ��� �����͸� �̾Ƴ��°� ������ 
            DataTable? table3 = new DataTable();
            table3.Columns.Add("��¥", typeof(string));
            table3.Columns.Add("�Ǽ�", typeof(string));
            table3.Columns.Add("�����佺", typeof(string));
            table3.Columns.Add("�·�", typeof(string));

            //Convert.ToInt32(DateTime.Now.ToString("yyMMdd").Equals("yyMMdd"));

            if (aa != DateTime.Now.ToString("yyMMdd")) count_day++;
            table3.Rows.Add(DateTime.Now.ToString("yyMMdd"), list2count, front + ":" + back);
            // 1206�̵Ǹ� �ٽ� �ϳ���ä�� �����ȴ� �� `
            // ù��°���� ���µ� �����鰪�� �����ϱ�... 
            but_count++;
            // ������ �����ؾߵ� �ù� 
            // ����Ʈ�䰪�� �����Ҽ����ٸ� ��¥���� ������ �����ְ��ʿ��� 
            if (but_count > 1)
            {
                //item.SubItems[7].Text �̰��� ��� �װ��� �ҷ��ͼ� ���� �������ۿ����� 
                // ���������� ���� ���Ѵٸ� DateTime.Now�� ��� ���� �����̰����� ������ �ɶ��� DateTime�� ���� ������ ���⶧���� 
                // table�� ��� �߰��Ǵ� ��������ϰ������ ��¥�� ����ʿ����� 
                if (aa != DateTime.Now.ToString("yyMMdd"))
                {
                    table3.Rows.Add(DateTime.Now.ToString("yyMMdd"), count_day, front + ":" + back);
                    DataRow row = table3.NewRow();
                    // �����Ͱ� ���ȿ����� �ٽ� ���������� �ǵ��ư����� 1206> 1207�� 2���� ��µǰ�
                    // 1206�̵Ǹ� �ٽ� �ϳ����ǹ���
                    foreach (DataRow dr in table3.Rows)
                    {
                        row["��¥"] = DateTime.Now.ToString("yyMMdd");
                        row["�Ǽ�"] = count_day;
                        row["�����佺"] = front + ":" + back;
                        row["�·�"] = Math.Round(win / list2count) * 100 + "%";
                    }


                }
            }
            #endregion Table3 End


            listcut = Convert.ToString(list2count);

            dataGridView1.DataSource = table;
            dataGridView2.DataSource = table2;
            dataGridView3.DataSource = table3;
        }



        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void ���·�Ȯ���ϱ�ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f2 = new Form2();
            f2.Owner = this;
            f2.Show();
            listView1.Text = f2.select;
            listView1.Text = "Select a Student";
            //this.Hide(); >>> �ְ� ������ 
            // Hide �� �������� �޸𸮸� ��� �����ؼ� ���� ���࿡ ������ ������ 
            //Form1.Dispose();
            
            
        }
        #region enter datagrid ����
        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;

            }
        }

        private void dataGridView2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
            }
        }
        #endregion

        private void dataGridView3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // �̰� �߰��ϰԵǸ� Ŭ���� ���� �̺�Ʈ�� ���� �Ͼ������ ������ ��� 
                // �÷��� ������������ �Ʒ��� ���� ó�������� ���� ������ �Ͼ���ʰ���
                int colums = dataGridView1.CurrentCell.ColumnIndex;
                int row = dataGridView1.CurrentCell.RowIndex;
                dataGridView3.CurrentCell = dataGridView1[colums, row];
                // enter�� ���� �̺�Ʈ ó��
                e.Handled = true;
            }

        }

        private void dataGridView1_DragDrop(object sender, DragEventArgs e)
        {
            
        }
    }
}
