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

            // index = 0으로하면 0번째값부터 들고 오기때문에 먼저 타입을 받아오게해줌

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
            // DropStyle 고정 DropDownList 
            string cointos = this.comboBox1.Text;
            //선공후공
            string turn = this.comboBox2.Text;
            //전적 승패
            string outcome = this.comboBox3.Text;
            //내덱 
            string myDeck = this.textBox1.Text;
            //상대덱
            string otherDeck = this.textBox2.Text;
            //비고 
            string etc = this.textBox3.Text;
            //날짜
            DateTime dateTime = DateTime.Now;
            
            ListViewItem item = new ListViewItem();
            // ltem.text 가 0번째값 sub는 0이후의 값이므로 subitem을 넣는경우 0번째 행에 값을 넣지못함
            int count = listView1.Items.Count + 1;
            //count 값을 설정하고 listview 자동으로 값을 넣기위해 카운트하는법은 리스트뷰의 숫자를 세는게 맞음
            // 카운트 판수
            listView1.Items.Add(item);
            item.Text = count.ToString();
            // 코인토스 앞뒤 
            item.SubItems.Add(cointos);
            //이제는 승률을 구현해야함 
            
            int count_frist = 0;
            // 승률이란 전체 플레이 수 중에서 승리만 카운터하면됨 
            int count_win = 0;
            // comboBox3.SelectedIndex = 0; // 이게 승리지
            // 값을 어떻게 들고올거냐? 
            
            
            //  승리 / 전체플레이
            // 승리값만 보면됨 


            cointos.Equals("선공");
            
            // 선후공 
            item.SubItems.Add(turn);
            
            // 결과
            item.SubItems.Add(outcome);
            for (int i = 0; i < count; i++)
                if (outcome == "승리") count_win++;
                else count_win = count_win;
            // 내 덱
            item.SubItems.Add(myDeck);
            // 상대덱 
            item.SubItems.Add(otherDeck);
            // 비고란
            item.SubItems.Add(etc);
            // 날짜값
            item.SubItems.Add(Convert.ToString(DateTime.Now.ToString("yyMMdd")));
            

            #endregion

            #region 승률관련
            ListViewItem item2 = new ListViewItem();
            //리스트뷰2값은 동적으로 계속변경되어야함 리스트 뷰는 값이 변경되면안되는 분야고 동적으로 되지않기때문에 리스트뷰는 제한됨
            // 동적으로 바꿀수 있는건 DataGrid가 아닌가? 정답! 
            int list2count = listView1.Items.Count;
            DataTable table  = new DataTable();
            table.Columns.Add("플레이 수",typeof(string));
            table.Columns.Add("승률",typeof(string));
            // int list2count 값으로정의되잇기때문에 int값연산이 다된다 
            table.Rows.Add(list2count, (count_win/list2count)*100 + "%" + count_win);
            dataGridView1.DataSource = table;
            #endregion
        }



        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void 덱승률확인하기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //지금고민중인요소가있는데 
            // Form2 를 만들어서 보여주느냐 
            //그냥 다보여주느냐
        }
    }
}
