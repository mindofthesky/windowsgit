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

       
        double resivedata = 0;
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
            //string mydeck = string.Format("SELECT * FORM myduel WHERE = {0}", textBox1.Text);
            DataTable table = new DataTable();
            table.Columns.Add("총 플레이수", typeof(string));
            table.Columns.Add("상대덱 승수", typeof(string));
            


            dataGridView1.DataSource = table;
            // 데이터 전달 됨 
            listView1.Items.Add(Form1.listcut);
            // 명시적 값만 가능함

            // DB를 들고온다면 전혀 문제없이 구현이 가능하지않을까?
            // 이래서 디비를 구현한다고 보는데 >> 구현완료 승패 보기 완료 
            //
        }
        public string select { get; set; }
        
        private void button1_Click(object sender, EventArgs e)
        {
            string myDeck = this.textBox1.Text;
            //상대덱
            string otherDeck = this.textBox2.Text;
            // 아래 코드를 사용할거지만 test용 mydeck, erermindeck 
            string mydeck = string.Format("SELECT count(win_lose) as 승리 FROM myduel where mydeck= '{0}';", textBox1.Text);
            string emermindeck = string.Format("SELECT count(win_lose) as 승리 FROM myduel where mydeck='{0}' and otherdeck='{1}' and win_lose='승리';", textBox1.Text, textBox2.Text);
            //test 용코드 
            //string mydeck = string.Format("SELECT count(win_lose) as 승리 FROM myduel where mydeck= '퓨어리';");
            //string emermindeck = string.Format("SELECT FROM myduel where ={0}",textBox2.Text);
            //현재 버그는 item > 빈칸 하나 24-1-12


            _Connection = string.Format("Server ={0};Port={1};DataBase={2};Uid={3};Pwd={4};", _Server, _port, _Database, _id, _pwd);
            // item[0] 내덱
            
            ListViewItem item = new ListViewItem(myDeck);
            item.SubItems[1].Text= otherDeck;


            DataTable table = new DataTable();
            table.Columns.Add("총 플레이수", typeof(string));
            table.Columns.Add("상대덱 승수",typeof(string));
            try
            {
                MySqlConnection mysql = new MySqlConnection(_Connection);
                mysql.Open();
                
                MySqlCommand deckcheck_command = new MySqlCommand(mydeck, mysql);
                MySqlCommand otherdeck_command = new MySqlCommand(emermindeck, mysql);
                table.Rows.Add(deckcheck_command.ExecuteScalar(), otherdeck_command.ExecuteScalar());
                dataGridView1.DataSource = table;
            }
            catch (Exception ex) { MessageBox.Show("error"); }
            

            

            
            
        }
    }
}
