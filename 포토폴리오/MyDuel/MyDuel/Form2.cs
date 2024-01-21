using MyDuel;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace MyDuel
{
   
    public partial class Form2 : Form
    {

       
        
        string _Server = "localhost";
        string _port = "3306";
        string _Database = "test";
        string _id = "root";
        string _pwd = "1234";
        string _Connection = "";
        
        public Form2()
        {

            InitializeComponent();
            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.Columns[0].Width = 200;
            listView1.Columns[1].Width = 200;
            dataGridView1.ReadOnly = true;
            

            // 데이터 전달 됨 

            // 빈칸의 원인 
            //listView1.Items.Add(Form1.listcut);
            // 명시적 값만 가능함

            // DB를 들고온다면 전혀 문제없이 구현이 가능하지않을까?
            // 이래서 디비를 구현한다고 보는데 >> 구현완료 승패 보기 완료 
            
        }
        public string select { get; set; }
        static int count = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            //listView1.Clear();
            // 2번 클릭부터 clear! 
            count++;
            
            string myDeck = this.textBox1.Text;
            //상대덱
            string otherDeck = this.textBox2.Text;
            dataGridView1.ClearSelection();
            
            // 아래 코드를 사용할거지만 test용 mydeck, erermindeck 
            string mydeck = string.Format("SELECT count(win_lose) as 승리 FROM myduel where mydeck= '{0}';", textBox1.Text);
            string emermindeck = string.Format("SELECT count(win_lose) as 승리 FROM myduel where mydeck='{0}' and otherdeck='{1}' and win_lose='승리';", textBox1.Text, textBox2.Text);
            string count_deck = string.Format("SELECT count(win_lose) from myduel where mydeck='{0}' and otherdeck='{1}';", textBox1.Text,textBox2.Text);
            string mydeck_win = string.Format("SELECT count(win_lose) from myduel where mydeck='{0}' and win_lose='승리';",textBox1.Text);
            string wincount = string.Format("SELECT count(win_lose) FROM myduel where win_lose= '승리';");
            //test 용코드 
            //string mydeck = string.Format("SELECT count(win_lose) as 승리 FROM myduel where mydeck= '퓨어리';");
            //string emermindeck = string.Format("SELECT FROM myduel where ={0}",textBox2.Text);
            //현재 버그는 item > 빈칸 하나 24-1-12 > 사유 listcut 이전 from2 데이터를 받아오는데 썼던 더미코드가 살아있었다> 1-13


            _Connection = string.Format("Server={0};Port={1};DataBase={2};Uid={3};Pwd={4};", _Server, _port, _Database, _id, _pwd);
            // item[0] 내덱
            // 첫번쨰 칸 빈칸은 왜 발생하는가  >> 더미코드때문에 
            ListViewItem item = new ListViewItem(myDeck);
            item.SubItems.Add(otherDeck);
            listView1.Items.Add(item);
            if (count % 2 == 0)
            {
                listView1.Clear();
                // 다삭제는 아니다 
                item = new ListViewItem(myDeck);
                item.SubItems.Add(otherDeck);
                listView1.Items.Add(item);
            }
            DataTable table = new DataTable();
            table.Columns.Add("총 플레이수", typeof(string));
            table.Columns.Add("상대덱 승수",typeof(string));
            table.Columns.Add("상대덱 승률", typeof(string));
            table.Columns.Add("내덱 총승률", typeof(string));
            try
            {
                MySqlConnection mysql = new MySqlConnection(_Connection);
                mysql.Open();
                
                MySqlCommand deckcheck_command = new MySqlCommand(mydeck, mysql);
                MySqlCommand otherdeck_command = new MySqlCommand(emermindeck, mysql);
                MySqlCommand count_deck_command = new MySqlCommand(count_deck, mysql);
                MySqlCommand my_deck_command = new MySqlCommand(mydeck_win, mysql);
                MySqlCommand win_command = new MySqlCommand(wincount, mysql);
                table.Rows.Add(deckcheck_command.ExecuteScalar(), otherdeck_command.ExecuteScalar(),
                                Math.Round(Convert.ToDouble(otherdeck_command.ExecuteScalar()) / Convert.ToDouble(count_deck_command.ExecuteScalar()), 1) * 100 + "%",
                                Math.Round(Convert.ToDouble(my_deck_command.ExecuteScalar()) / Convert.ToDouble(win_command.ExecuteScalar()), 1) * 100 + "%");
                dataGridView1.DataSource = table;
            }
            catch (Exception ex) { MessageBox.Show("error"); }
                 
        }
    }
}
