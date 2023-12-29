using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Drawing;

namespace MyDuel
{
    public partial class Form1 : Form
    {
        #region DB����
        string _Server = "localhost";
        string _port = "3306";
        string _Database = "test";
        string _id = "root";
        string _pwd = "1234";
        string _Connection = "";
        #endregion
        #region ����
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
        #endregion
        #region Form �ʱ�ȭ�� 
        public Form1()
        {

            InitializeComponent();
            _Connection = string.Format("Server ={0};Port={1};DataBase={2};Uid={3};Pwd={4};",_Server,_port,_Database,_id,_pwd);
            listView1.View = View.Details;
            listView1.GridLines = true;
            select();

            

            #region combox Defect, listview ũ�� 
            // index = 0�����ϸ� 0��°������ ��� ���⶧���� ���� Ÿ���� �޾ƿ�������
            // dataGridView1,2,3 ������ 
            // AutoSizeColumnsMode > Fill ó�� , dataGridView1.AutoSizeRowsMode = displayed ó��  RowHeadersVisible = False ó�� 
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
            

            #region dataGrid �б���
            dataGridView1.ReadOnly = true;
            dataGridView2.ReadOnly = true;
            dataGridView3.ReadOnly = true;
            #endregion


            #region ������ �̸��ε� 
            // ó�������� ��ϱ� 
            
            #region table DB
            // ������ SELECT ����
            DataTable? table = new DataTable();
            
            table.Columns.Add("�÷��� ��", typeof(string));
            table.Columns.Add("�·�", typeof(string));
            table.Columns.Add("�¼�", typeof(int));
            table.Columns.Add("�й�", typeof(int));
            // string�� SQL 
            string playcout = "SELECT count(No) FROM myduel SET Count;";
            
            // SQL���� �� ����
            string wincount = string.Format("SELECT count(win_lose) FROM myduel where win_lose= '�¸�';");
            string playcount = string.Format("SELECT count(No) FROM myduel;");
            string losecount = string.Format("SELECT count(win_lose) FROM myduel where win_lose= '�й�';");
            try 
            {

                // �̷����ϸ� Gridview���� ���� Ʋ���žƴ� �ذ��� ������
                MySqlConnection mysql = new MySqlConnection(_Connection);
                mysql.Open();

                MySqlCommand win_command = new MySqlCommand(wincount, mysql);
                MySqlCommand play_command = new MySqlCommand(playcount,mysql);
                MySqlCommand lose_command = new MySqlCommand(losecount, mysql);
                // CREATE TABLE �� DROP TABLE ���� ��� ��ȯ ���� 0�Դϴ�. �ٸ� ������ ���� ��쿡�� ��ȯ ���� -1�Դϴ�. 

                // command -1 �� �����Ѵٸ� ������ �߸���ٴ� ���ε� > �ٵ� ���������� �۵����� DB���� ����
                //ExecuteScalar �ϳ��� ���� �ҰŸ� �̰� ���� 
                // �·��� �ؾߵǴµ� SQL�������� �ؾߵǴ°ɱ�?
                // �Ҽ��� ���ְ������ 
                table.Rows.Add(play_command.ExecuteScalar(),Convert.ToDouble(win_command.ExecuteScalar()) 
                    / Convert.ToDouble(play_command.ExecuteScalar()) * 100 + "%", win_command.ExecuteScalar(), lose_command.ExecuteScalar());
                dataGridView1.DataSource = table;
            }
            catch { }
            #endregion

            #region table2 DB
            // datagrid 1, 2 �� ������ SELECT �������� WHERE AND �������� 
            DataTable? table2 = new DataTable();
            table2.Columns.Add("��", typeof(string));
            table2.Columns.Add("��", typeof(string));
            table2.Columns.Add("�����·�", typeof(string));
            table2.Columns.Add("�İ��·�", typeof(string));


            string forntcount = string.Format("SELECT count(cointos) FROM myduel where cointos= '�ո�';");
            string backcount = string.Format("SELECT count(cointos) FROM myduel where cointos= '�޸�';");

            string fristcount = string.Format("SELECT count(cointos) FROM myduel where turn= '����';");
            string secondcount = string.Format("SELECT count(cointos) FROM myduel where turn= '�İ�';");
            
            string turn_frist_count = string.Format("SELECT count(turn) FROM myduel where turn= '����' AND win_lose ='�¸�';");
            string turn_second_count = string.Format("SELECT count(turn) FROM myduel where turn= '�İ�' AND win_lose ='�¸�';");

            try
            {
                MySqlConnection mysql = new MySqlConnection(_Connection);
                mysql.Open();
                // �ո� �޸�
                MySqlCommand forntcommand = new MySqlCommand(forntcount, mysql);
                MySqlCommand backcommand = new MySqlCommand(backcount, mysql);
                // ���� �¸�, �İ� �¸�
                MySqlCommand turnfristcommand = new MySqlCommand(turn_frist_count, mysql);
                MySqlCommand turnsecondcommand = new MySqlCommand(turn_second_count, mysql);
                // ���İ� Ƚ�� 
                MySqlCommand fristcommand = new MySqlCommand(fristcount, mysql);
                MySqlCommand secondcommand = new MySqlCommand(secondcount, mysql);
                // table insert
                table2.Rows.Add(forntcommand.ExecuteScalar(), backcommand.ExecuteScalar(),
                    Convert.ToDouble(turnfristcommand.ExecuteScalar()) / Convert.ToDouble(fristcommand.ExecuteScalar())*100+"%",
                    Convert.ToDouble(turnsecondcommand.ExecuteScalar()) / Convert.ToDouble(secondcommand.ExecuteScalar()) * 100 + "%");
                dataGridView2.DataSource = table2;
            }
            catch { }
            #endregion

            #region table3 DB
            /* TABLE 3�� �ٸ��� ���� 
            * �ߺ��� ��������ʰ� 
            * ���� �ϳ��� �ҷ����� 
            * ������ ���⵵�� �������� 
            * �������� §�ڵ��̱⿡ �������� �Ӹ��ӿ��� �������Ǿ��ִ� ������
            * ���� ������ �޾ƺôµ� ���� ���������� Ʋ���� 
            */
            DataTable table3 = new DataTable();
            // ���������� ���°�� 
            // SELECT DISTINCT date as ��¥,  count(*) AS �Ǽ�, SUM(if(win_lose='�¸�', 1,0) AS win_cnt, SUM(if(win_lose='�й�', 1, 0) AS lose_cnt FROM myduel GROUP BY date ORDER BY date DESC
            table3.Columns.Add("��¥", typeof(string));
            table3.Columns.Add("�Ǽ�", typeof(string));
            table3.Columns.Add("�����佺", typeof(string));
            table3.Columns.Add("�·�", typeof(string));
            // ��¥ , �Ǽ� ������ !
            string date = string.Format("SELECT date AS ��¥ ,count(*) AS �Ǽ�, sum(if(win_lose='�¸�',1,0)) as �¸�, sum(if(win_lose='�й�',1,0)) as �й� FROM myduel GROUP BY date ORDER BY date"); // �� �ҷ������� ���ϴ� ������ �ؾ��Ѵٸ� �������� �ڵ� �ۼ��ʿ� 
            //string date = string.Format("SELECT DISTINCT date FROM myduel;"); 
            // �Ƥ��ƾƾ� ��� ������ �� �θ��� ���� ���������� �̷��� ������ ���°� ���ƺ��̴µ� ���� ��� sql������ ���������ߴ��� �����۵��� �ϴ� 
            // �׷��ٸ� ���� sql ������ �ҷ��;��Ѵ� �׷� ����� ��ø����?  >> �������ٲٴ°� �ְ��
            
            
            // �̿� ���� ��� �����Ͱ� ȣ��Ǿ�������� 
            // ���ϴµ����ʹ�
            /*
             * SELECT DISTINCT count(turn) FROM myduel where date='231211'; �������� ������
             * SELECT DISTINCT count(turn) FROM myduel where date='231212'; �������� �޾ƿ��� 
             * SELECT DISTINCT count(turn) FROM myduel where date={0} break ���� {0} == Null break;
             * ������ Null ���������� ����ؾ���
             */
            
            
            DataRow row;
            try
            {  int a = 0;
                MySqlConnection mysql = new MySqlConnection(_Connection);
                mysql.Open();
                MySqlCommand datecommand = new MySqlCommand(date, mysql);
                //MySqlCommand playcommand = new MySqlCommand(play, mysql);
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                MySqlDataAdapter adapter1 = new MySqlDataAdapter();
               // MySqlDataAdapter adapter = new MySqlDataAdapter(date, mysql);
                adapter.SelectCommand = datecommand;
                //adapter1.SelectCommand = playcommand;
                DataSet ds = new DataSet();

                
                adapter.Fill(ds, "��¥");
                //adapter1.Fill(ds, "2");

               
                dataGridView3.DataSource = ds.Tables["��¥"];
                
                //dataGridView3.DataSource = ds.Tables["2"];
                //table3.Rows.Add(datecommand.ExecuteScalar());
                //dataGridView3.DataSource = table3;
            }
            catch { }
            
            
            
            #endregion

            
            #endregion
        }
         
        #endregion
        // Update , listview , datagrid �� ����
        #region listview1, datagrid 1,2,3
        private void button1_Click(object sender, EventArgs e)
        {
            // ���� ���� ���� > No �ڵ������� �߰� 20 > ���εǴ°� �����ʿ�
            /*
             Auto Increment �� ������ 
             �ٸ�������� �ʱ�ȭ ã�ƺ��߰���
             */

            // null�̵������� null �Է� ���ް� ��Ŀ�� 
            #region null üũ 
            bool check;
            if (string.IsNullOrWhiteSpace(textBox1.Text) != false || string.IsNullOrWhiteSpace(textBox2.Text) != false)
            {
                MessageBox.Show("�����͸� �־��ּ���");
                if (string.IsNullOrWhiteSpace(textBox1.Text)) { textBox1.Focus(); }
                else if(string.IsNullOrWhiteSpace(textBox2.Text)) 
                {
                textBox2.Focus(); 
                }
                //textbox3 ���ĭ�̱⶧���� null���� ��������� 
                // db Ȯ�� ��� null ó���� �ȵ����� 

                /*
                 ALTER TABLE myduel AUTO_INCREMENT=1;
                 SET @COUNT = 0;
                 UPDATE myduel SET `myduel.No`=@COUNT:=@COUNT+1; No�� ������ ó���Ǿ ����� �������� 
                 */
                check = false;
                // textbox1 �� �Է¸��ص� ����̵� �������� or(||) ó���� �ذ� 
                // DB ���� �ذ��ʿ�
            }// false�̸� else ���� �����ʱ⶧���� true�϶��� if > check�� �ް� ������ ó�� ���� 
            #endregion
             #region ���� ������ó�� 
            else
            {
                check = true;
                if (check == true)
                {
                    #region CRUD INSERT �Ϸ�
                    /* DB�� �迭�� 
                     * no = 0 
                     * cointos =1
                     * turn = 2
                     * win_lose =3
                     * mydeck = 4
                     * otherdeck = 5
                     * etc =6
                     * date 7 
                     */
                    try
                    {
                        using (MySqlConnection mysql = new MySqlConnection(_Connection))
                        {
                            mysql.Open();
                            // 1 2 3 4 5 6 7 �� �����ϴϱ� �������� 0,1,2,3,4,5,6 ���� ���� ���������� �����ذ� 
                            string insertQuery = string.Format("INSERT INTO myduel (Cointos, turn, win_lose, mydeck , otherdeck, etc, date) VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}');",
                            this.comboBox1.Text, this.comboBox2.Text, this.comboBox3.Text, this.textBox1.Text, this.textBox2.Text, this.textBox3.Text, DateTime.Now.ToString("yyMMdd"));
                            MySqlCommand command = new MySqlCommand(insertQuery, mysql);
                            if (command.ExecuteNonQuery() != 1)
                            {
                                MessageBox.Show("Query error");
                            }
                            // �ߺ��Ǳ� ������ �����ϱ����� 
                            listView1.Items.Clear();
                            select();
                        }
                    }
                    catch (Exception ex) { MessageBox.Show(ex.ToString()); }

                    #endregion

                    #region Click Event DB����
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
                    //listView1.Items.Add(item);
                    //item.Text = count.ToString();
                    // �����佺 �յ� 
                    //item.SubItems.Add(cointos);
                    //������ �·��� �����ؾ��� 
                    // �·��̶� ��ü �÷��� �� �߿��� �¸��� ī�����ϸ�� 

                    // comboBox3.SelectedIndex = 0; // �̰� �¸���
                    // ���� ��� ���ðų�? 


                    //  �¸� / ��ü�÷���
                    // �¸����� ����� 

                    // ���İ� 
                    //item.SubItems.Add(turn);
                    // ���
                    //item.SubItems.Add(outcome);
                    // �� ��
                    //item.SubItems.Add(myDeck);
                    // ��뵦 
                    //item.SubItems.Add(otherDeck);
                    // ����
                    //item.SubItems.Add(etc);
                    // ��¥��
                    //item.SubItems.Add(Convert.ToString(DateTime.Now.ToString("yyMMdd")));
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

                    #region Table 1 Start DB


                    DataTable? table = new DataTable();
                    table.Columns.Add("�÷��� ��", typeof(string));
                    table.Columns.Add("�·�", typeof(string));
                    table.Columns.Add("�¼�", typeof(int));
                    table.Columns.Add("�й�", typeof(int));
                    //����Ʈ��2���� �������� ��Ӻ���Ǿ���� ����Ʈ ��� ���� ����Ǹ�ȵǴ� �о߰� �������� �����ʱ⶧���� ����Ʈ��� ���ѵ�
                    // �������� �ٲܼ� �ִ°� DataGrid�� �ƴѰ�? ����! 
                    double list2count = listView1.Items.Count;

                    #region table1 DB ��ȯ
                    try
                    {

                        // int list2count ���������ǵ��ձ⶧���� int�������� �ٵȴ� , ���� ���� �����ֱ⶧���� �ٸ� Row�� �����ϸ� ��õ�����ʴ´�

                        string wincount = string.Format("SELECT count(win_lose) FROM myduel where win_lose= '�¸�';");
                        string playcount = string.Format("SELECT count(No) FROM myduel;");
                        string losecount = string.Format("SELECT count(win_lose) FROM myduel where win_lose= '�й�';");


                        // �̷����ϸ� Gridview���� ���� Ʋ���žƴ� �ذ��� ������
                        MySqlConnection mysql = new MySqlConnection(_Connection);
                        mysql.Open();
                        MySqlCommand win_command = new MySqlCommand(wincount, mysql);
                        MySqlCommand play_command = new MySqlCommand(playcount, mysql);
                        MySqlCommand lose_command = new MySqlCommand(losecount, mysql);
                        // Double���� �Ҽ�������
                        table.Rows.Add(play_command.ExecuteScalar(), (Convert.ToInt32(win_command.ExecuteScalar()) / Convert.ToInt32(play_command.ExecuteScalar())) * 100 + "%",
                            win_command.ExecuteScalar(), lose_command.ExecuteScalar());
                        dataGridView1.DataSource = table;
                        // OK Click �̺�Ʈ������ �����۵�

                    }
                    catch { }
                    #endregion
                    //table.Rows.Add(list2count, Math.Round(win / list2count * 100) + "%", win, lose);
                    #endregion Table 1 End 

                    #region Table 2 Start DB

                    #region DB ���� ����
                    /*
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
                    */
                    #endregion
                    DataTable? table2 = new DataTable();
                    table2.Columns.Add("��", typeof(string));
                    table2.Columns.Add("��", typeof(string));
                    table2.Columns.Add("�����·�", typeof(string));
                    table2.Columns.Add("�İ��·�", typeof(string));


                    string forntcount = string.Format("SELECT count(cointos) FROM myduel where cointos= '�ո�';");
                    string backcount = string.Format("SELECT count(cointos) FROM myduel where cointos= '�޸�';");

                    string fristcount = string.Format("SELECT count(cointos) FROM myduel where turn= '����';");
                    string secondcount = string.Format("SELECT count(cointos) FROM myduel where turn= '�İ�';");

                    string turn_frist_count = string.Format("SELECT count(turn) FROM myduel where turn= '����' AND win_lose ='�¸�';");
                    string turn_second_count = string.Format("SELECT count(turn) FROM myduel where turn= '�İ�' AND win_lose ='�¸�';");

                    try
                    {
                        MySqlConnection mysql = new MySqlConnection(_Connection);
                        mysql.Open();
                        // �ո� �޸�
                        MySqlCommand forntcommand = new MySqlCommand(forntcount, mysql);
                        MySqlCommand backcommand = new MySqlCommand(backcount, mysql);
                        // ���� �¸�, �İ� �¸�
                        MySqlCommand turnfristcommand = new MySqlCommand(turn_frist_count, mysql);
                        MySqlCommand turnsecondcommand = new MySqlCommand(turn_second_count, mysql);
                        // ���İ� Ƚ�� 
                        MySqlCommand fristcommand = new MySqlCommand(fristcount, mysql);
                        MySqlCommand secondcommand = new MySqlCommand(secondcount, mysql);
                        // table insert
                        table2.Rows.Add(forntcommand.ExecuteScalar(), backcommand.ExecuteScalar(),
                            Convert.ToDouble(turnfristcommand.ExecuteScalar()) / Convert.ToDouble(fristcommand.ExecuteScalar()) * 100 + "%",
                            Convert.ToDouble(turnsecondcommand.ExecuteScalar()) / Convert.ToDouble(secondcommand.ExecuteScalar()) * 100 + "%");
                        dataGridView2.DataSource = table2;
                    }
                    catch { }



                    //table3.Rows.Add("");
                    //table3.Rows.Add(DateTime.Now.ToString("yyMMdd"), count_day, front + ":" + back);`
                    //if (DateTime.Now.ToString("yyMMdd") != (DateTime.Now.ToString("yyMMdd")))
                    //{
                    //  table3.Rows.Add(DateTime.Now.ToString("yyMMdd"), count_day, front + ":" + back);
                    //}





                    #endregion

                    #region Table 3 Start DB
                    // table3 �� ��� ��¥���� �佺, �Ǽ�, �·��� �������� 

                    #region ���� ���� Ŭ���̺�Ʈ 
                    // ��¥���� ����Ǿ���� 
                    // ��¥�� ��¥�� ���� �ٸ� 
                    // �Ǽ��� �����͸� �̾Ƴ��°� ������ 
                    /*
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
                    }*/
                    #endregion
                    DataTable table3 = new DataTable();
                    // ���������� ���°�� 
                    // SELECT DISTINCT date as ��¥,  count(*) AS �Ǽ�, SUM(if(win_lose='�¸�', 1,0) AS win_cnt, SUM(if(win_lose='�й�', 1, 0) AS lose_cnt FROM myduel GROUP BY date ORDER BY date DESC
                    table3.Columns.Add("��¥", typeof(string));
                    table3.Columns.Add("�Ǽ�", typeof(string));
                    table3.Columns.Add("�����佺", typeof(string));
                    table3.Columns.Add("�·�", typeof(string));
                    // ��¥ , �Ǽ� ������ !
                    string date = string.Format("SELECT date AS ��¥ ,count(*) AS �Ǽ�, sum(if(win_lose='�¸�',1,0)) as �¸�, sum(if(win_lose='�й�',1,0)) as �й� FROM myduel GROUP BY date ORDER BY date"); // �� �ҷ������� ���ϴ� ������ �ؾ��Ѵٸ� �������� �ڵ� �ۼ��ʿ� 
                                                                                                                                                                                                  // �̿� ���� ��� �����Ͱ� ȣ��Ǿ�������� 
                                                                                                                                                                                                  // ���ϴµ����ʹ�
                    try
                    {
                        // ���� ������ 
                        int a = 0;
                        MySqlConnection mysql = new MySqlConnection(_Connection);
                        mysql.Open();
                        MySqlCommand datecommand = new MySqlCommand(date, mysql);
                        MySqlDataAdapter adapter = new MySqlDataAdapter(date, mysql);
                        adapter.SelectCommand = datecommand;
                        DataSet ds = new DataSet();
                        adapter.Fill(ds, "��¥");
                        dataGridView3.DataSource = ds.Tables["��¥"];
                    }
                    catch { }


                    #endregion Table3 End


                    #region ��2�� ���� ������ 
                    // ������ �׷��� �̷� �����͸� �����ȵ�
                    //listcut = Convert.ToString(list2count);
                    // �����͸� �����ٿ����ߺ����� �����͸� ����ϰ� ����� 
                    // ��� �����ϴ°� �� ���� > ������� ����
                    #endregion
                }
            }
            
        }
            #endregion
        #endregion

        #region CRUD Read 
        private void select()
        {

            /* DB�� �迭�� 
             * no = 0 
             * cointos =1
             * turn = 2
             * win_lose =3
             * mydeck = 4
             * otherdeck = 5
             * etc =6
             * date 7 
             */
            // select ��ȸ�� ������ 
            try
            {
                using (MySqlConnection mysql = new MySqlConnection(_Connection))
                {
                    mysql.Open();
                    string selectQurey = string.Format("SELECT * FROM myduel");
                    MySqlCommand comm = new MySqlCommand(selectQurey, mysql);
                    MySqlDataReader tables = comm.ExecuteReader();
                    //if (comm.ExecuteNonQuery() != 1) MessageBox.Show(" ���ۺ� error"); << �������� 
                    // ������� ���ƿ��������� ���� �޾ƿ��⶧���� �̰� �����ʿ䰡����
                    // �����͸� �̸� �־�ð� Ȯ�ΰ�� ���������� insert�Ȱ� Read�ؿ�
                    while (tables.Read())
                    {
                        ListViewItem item = new ListViewItem();
                        item.Text = tables["No"].ToString();
                        item.SubItems.Add(tables["Cointos"].ToString());
                        item.SubItems.Add(tables["turn"].ToString());
                        item.SubItems.Add(tables["win_lose"].ToString());
                        item.SubItems.Add(tables["mydeck"].ToString());
                        item.SubItems.Add(tables["otherdeck"].ToString());
                        item.SubItems.Add(tables["etc"].ToString());
                        item.SubItems.Add(tables["date"].ToString());
                        listView1.Items.Add(item);
                    }
                    tables.Close();
                }
            }
            catch(Exception ex) { MessageBox.Show(ex.ToString()); }
        }
        #endregion
        #region CRUD Update ������
        private void table()
        {
            using (MySqlConnection mysql = new MySqlConnection(_Connection))
                {
                    mysql.Open();
                    try
                        {
                            DataTable? table = new DataTable();
                            table.Columns.Add("�÷��� ��", typeof(string));
                            table.Columns.Add("�·�", typeof(string));
                            table.Columns.Add("�¼�", typeof(int));
                            table.Columns.Add("�й�", typeof(int));
           


                            //int list2count ���������ǵ��ձ⶧���� int�������� �ٵȴ� , ���� ���� �����ֱ⶧���� �ٸ� Row�� �����ϸ� ��õ�����ʴ´�

                
                            string playcount = string.Format("SELECT count(No) FROM myduel;");
                            // DB���� SQL ������ ����� �ߵ��ư�
                            string wincount = string.Format("SELECT count(win_lose) FROM myduel where win_lose= '�¸�';");
                            string losecount = string.Format("SELECT count(win_lose) FROM myduel where win_lose= '�й�';");
                            // �·������� ���� double switch
                            double playcount_string_change_double = Convert.ToInt32(playcount);
                            double win_lose_string_change_double = Convert.ToInt32(wincount);
                            //MySqlCommand commnad = new MySqlCommand();
                            // win, lose count �ݿ��̾ȵ�
                            MessageBox.Show("error", "�¸�" + wincount + "�й� " + losecount);
                            table.Rows.Add(playcount, Math.Round(win_lose_string_change_double / playcount_string_change_double * 100) + "%", wincount, losecount);
                // �Ⱦ����ڵ� 
                        }
                        catch { }
            }
           

        }
        #endregion

        #region Form2����
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
            // �ᱹ�� DB ������ �ؾ��� >> DB���� ! 
            
        }
        #endregion

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
        
        #region �巡�׳� �̷��� ���� �ҷ��ߴµ� ���� ���� x 
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
        #endregion
    }
}
