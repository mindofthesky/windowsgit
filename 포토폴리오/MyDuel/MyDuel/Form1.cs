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
            dataGridView2.ReadOnly = true;
            dataGridView1.ReadOnly = true;


        }
        // 정적값을 넣고하면 정상적으로 증가함
        // 승리 패배 , 앞면 뒷면, 선공 후공 
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
            // 승률이란 전체 플레이 수 중에서 승리만 카운터하면됨 

            // comboBox3.SelectedIndex = 0; // 이게 승리지
            // 값을 어떻게 들고올거냐? 


            //  승리 / 전체플레이
            // 승리값만 보면됨 


            if (cointos.Equals("선공"))

                // 선후공 
                item.SubItems.Add(turn);

            // 결과

            item.SubItems.Add(outcome);

            // 정적변수를 선언한이유는 
            // 여기서 0을 클릭과 동시에 다시 0으로 변환되기때문에 그래서 승률이라는 개념에 값을 넣어주기 제한됨


            if (outcome.Equals("승리")) win++;
            else if (outcome.Equals("패배")) lose++;

            if (cointos.Equals("앞면")) front++;
            else if (cointos.Equals("뒷면")) back++;

            if (turn.Equals("선공")) turn_frist++;
            else if (turn.Equals("후공")) turn_second++;

            if (turn.Equals("선공") && outcome.Equals("승리")) turn_frist_win++;
            else if (turn.Equals("후공") && outcome.Equals("승리")) turn_second_win++;
            // 내 덱
            item.SubItems.Add(myDeck);
            // 상대덱 
            item.SubItems.Add(otherDeck);
            // 비고란
            item.SubItems.Add(etc);
            // 날짜값
            item.SubItems.Add(Convert.ToString(DateTime.Now.ToString("yyMMdd")));
            // 리스트값을 자동스크롤바
            listView1.Items[listView1.Items.Count - 1].EnsureVisible();

            #endregion

            #region 승률관련
            ListViewItem item2 = new ListViewItem();
            //리스트뷰2값은 동적으로 계속변경되어야함 리스트 뷰는 값이 변경되면안되는 분야고 동적으로 되지않기때문에 리스트뷰는 제한됨
            // 동적으로 바꿀수 있는건 DataGrid가 아닌가? 정답! 
            double list2count = listView1.Items.Count;
            DataTable table = new DataTable();
            table.Columns.Add("플레이 수", typeof(string));
            table.Columns.Add("승률", typeof(string));
            table.Columns.Add("승수", typeof(int));
            table.Columns.Add("패배", typeof(int));
            // int list2count 값으로정의되잇기때문에 int값연산이 다된다 , 줄의 값을 보여주기때문에 다른 Row를 선언하면 추천되지않는다
            table.Rows.Add(list2count, Math.Round(win / list2count * 100) + "%", win, lose);
            DataTable table2 = new DataTable();

            // list2count , count_win 같이 증가하고있기에 100퍼만 고정되버림  >> static으로 해결 사실 이게 좀 바보같은 생각이였던게
            // 계속 버튼을 누르면 0 > 1 증가가 반복하는데 그냥 생각좀해보니까 0을 바깥에 두면 전혀문제없지않나가 맞는 답이맞앗음
            table2.Columns.Add("앞", typeof(string));
            table2.Columns.Add("뒤", typeof(string));
            table2.Columns.Add("선공승률", typeof(string));
            table2.Columns.Add("후공승률", typeof(string));
            // 왜 패배를 들어가면 흠 
            // int 형으로했을때 소수점이 생략되서 0으로 나오기때문에 double형으로 넣으면 오류는 발생하지않으나 소수점은 Math.Round로 처리
            table2.Rows.Add(front, back, Math.Round(turn_frist_win / turn_frist * 100) + "%", Math.Round(turn_second_win / turn_second * 100) + "%");

            dataGridView1.DataSource = table;
            dataGridView2.DataSource = table2;

            //dataGridView1.DataSource= table2;
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
        // enter 처리 금지 
        #region enter datagrid 금지
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
