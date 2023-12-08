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
            
            // dataGridView1,2,3
            // AutoSizeColumnsMode > Fill 처리 , dataGridView1.AutoSizeRowsMode = displayed 처리  RowHeadersVisible = False 처리 

            dataGridView1.ReadOnly = true;
            dataGridView2.ReadOnly = true;
            dataGridView3.ReadOnly = true;



            #region 데이터 미리로드 
            double list2count = listView1.Items.Count;
            DataTable? table = new DataTable();
            table.Columns.Add("플레이 수", typeof(string));
            table.Columns.Add("승률", typeof(string));
            table.Columns.Add("승수", typeof(int));
            table.Columns.Add("패배", typeof(int));
            table.Rows.Add(list2count, Math.Round(win / list2count * 100) + "%", win, lose);


            DataTable? table2 = new DataTable();
            table2.Columns.Add("앞", typeof(string));
            table2.Columns.Add("뒤", typeof(string));
            table2.Columns.Add("선공승률", typeof(string));
            table2.Columns.Add("후공승률", typeof(string));
            table2.Rows.Add(front, back, Math.Round(turn_frist_win / turn_frist * 100) + "%", Math.Round(turn_second_win / turn_second * 100) + "%");

            DataTable table3 = new DataTable();
            table3.Columns.Add("날짜", typeof(string));
            table3.Columns.Add("판수", typeof(string));
            table3.Columns.Add("코인토스", typeof(string));
            table3.Columns.Add("승률", typeof(string));
            table3.Rows.Add(DateTime.Now.ToString("yyMMdd"), list2count, front + ":" + back);
            dataGridView1.DataSource = table;
            dataGridView2.DataSource = table2;
            dataGridView3.DataSource = table3;
            #endregion
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
        static int count_day = 0;
        static int but_count = 0;
        // 날짜 하루를 참조하는값은 누구있지?
        // 시작할때만 값을 가져오면 값을 비교할수있다 
        static string aa = DateTime.Now.ToString("yyMMdd");
        // 정적변수는 가상머신 부팅 순간에서만 물러오기때문에
        // Event랑 상관이없다

        public double ls;
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

            // 선후공 
            item.SubItems.Add(turn);
            // 결과
            item.SubItems.Add(outcome);
            // 내 덱
            item.SubItems.Add(myDeck);
            // 상대덱 
            item.SubItems.Add(otherDeck);
            // 비고란
            item.SubItems.Add(etc);
            // 날짜값
            item.SubItems.Add(Convert.ToString(DateTime.Now.ToString("yyMMdd")));
            //item.SubItems.Add("dd"+aa); >> 정적인 값이 맞는데 
            // 리스트값을 자동스크롤바
            listView1.Items[listView1.Items.Count - 1].EnsureVisible();

            // 정적변수를 선언한이유는 
            // 여기서 0을 클릭과 동시에 다시 0으로 변환되기때문에 그래서 승률이라는 개념에 값을 넣어주기 제한됨

            //결과에대한 가산 
            if (outcome.Equals("승리")) win++;
            else if (outcome.Equals("패배")) lose++;
            //코인토스에 대한 가산
            if (cointos.Equals("앞면")) front++;
            else if (cointos.Equals("뒷면")) back++;
            // 선후공에 따른 가산
            if (turn.Equals("선공")) turn_frist++;
            else if (turn.Equals("후공")) turn_second++;
            // 선공승리, 후공 승리 판단
            if (turn.Equals("선공") && outcome.Equals("승리")) turn_frist_win++;
            else if (turn.Equals("후공") && outcome.Equals("승리")) turn_second_win++;

            #endregion

            
            #region Table 1 Start 

            ListViewItem item2 = new ListViewItem();
            //리스트뷰2값은 동적으로 계속변경되어야함 리스트 뷰는 값이 변경되면안되는 분야고 동적으로 되지않기때문에 리스트뷰는 제한됨
            // 동적으로 바꿀수 있는건 DataGrid가 아닌가? 정답! 
            double list2count = listView1.Items.Count;
            
            DataTable? table = new DataTable();
            table.Columns.Add("플레이 수", typeof(string));
            table.Columns.Add("승률", typeof(string));
            table.Columns.Add("승수", typeof(int));
            table.Columns.Add("패배", typeof(int));
            // int list2count 값으로정의되잇기때문에 int값연산이 다된다 , 줄의 값을 보여주기때문에 다른 Row를 선언하면 추천되지않는다
            table.Rows.Add(list2count, Math.Round(win / list2count * 100) + "%", win, lose);

            #endregion Table 1 End 

            #region Table 2 Start
            // Table nullable 을 써도 해결방법은 없다 NaN처리는 다른 방법이 필요하다
            DataTable? table2 = new DataTable();

            // list2count , count_win 같이 증가하고있기에 100퍼만 고정되버림  >> static으로 해결 사실 이게 좀 바보같은 생각이였던게
            // 계속 버튼을 누르면 0 > 1 증가가 반복하는데 그냥 생각좀해보니까 0을 바깥에 두면 전혀문제없지않나가 맞는 답이맞앗음
            table2.Columns.Add("앞", typeof(string));
            table2.Columns.Add("뒤", typeof(string));
            table2.Columns.Add("선공승률", typeof(string));
            table2.Columns.Add("후공승률", typeof(string));
            // 왜 패배를 들어가면 흠 
            
            double win_f = 0;
            double win_s = 0;
            // int 형으로했을때 소수점이 생략되서 0으로 나오기때문에 double형으로 넣으면 오류는 발생하지않으나 소수점은 Math.Round로 처리
            table2.Rows.Add(front, back, Math.Round(turn_frist_win / turn_frist * 100) + "%", Math.Round(turn_second_win / turn_second * 100) + "%");
            




            //table3.Rows.Add("");
            //table3.Rows.Add(DateTime.Now.ToString("yyMMdd"), count_day, front + ":" + back);`
            //if (DateTime.Now.ToString("yyMMdd") != (DateTime.Now.ToString("yyMMdd")))
            //{
            //  table3.Rows.Add(DateTime.Now.ToString("yyMMdd"), count_day, front + ":" + back);
            //}
           

            #region 폼데이터 보내기
            // 데이터가 listview에서 변환되는 값이라 listview가 아니면 변환이 안되는건가?
            Form2 frm2 = new Form2(ls);
            frm2.Owner = this;


            
             
            #endregion

           

            #endregion

            #region Table3 Start 
            // table3 의 경우 날짜마다 토스, 판수, 승률을 나눠야함 


            // 날짜마다 가산되어야함 
            // 날짜와 날짜는 서로 다름 
            // 판수의 데이터를 뽑아내는게 문젠데 
            DataTable? table3 = new DataTable();
            table3.Columns.Add("날짜", typeof(string));
            table3.Columns.Add("판수", typeof(string));
            table3.Columns.Add("코인토스", typeof(string));
            table3.Columns.Add("승률", typeof(string));

            //Convert.ToInt32(DateTime.Now.ToString("yyMMdd").Equals("yyMMdd"));

            if (aa != DateTime.Now.ToString("yyMMdd")) count_day++;
            table3.Rows.Add(DateTime.Now.ToString("yyMMdd"), list2count, front + ":" + back);
            // 1206이되면 다시 하나인채로 유지된다 음 `
            // 첫번째값이 없는데 던지면값이 없으니까... 
            but_count++;
            // 이전값 참조해야됨 시발 
            // 리스트뷰값을 참조할수없다면 날짜값을 가지고 있을애가필요함 
            if (but_count > 1)
            {
                //item.SubItems[7].Text 이값은 계속 그값을 불러와서 값이 같을수밖에없다 
                // 정적변수로 값을 비교한다면 DateTime.Now는 계속 값을 오늘이겠지만 내일이 될때는 DateTime은 값이 같을수 없기때문에 
                // table이 계속 추가되는 방식으로하고싶은데 날짜가 변경됨에따라 
                if (aa != DateTime.Now.ToString("yyMMdd"))
                {
                    table3.Rows.Add(DateTime.Now.ToString("yyMMdd"), count_day, front + ":" + back);
                    DataRow row = table3.NewRow();
                    // 데이터가 들어옴에따라 다시 원래값으로 되돌아가버림 1206> 1207은 2개가 출력되고
                    // 1206이되면 다시 하나가되버림
                    foreach (DataRow dr in table3.Rows)
                    {
                        row["날짜"] = DateTime.Now.ToString("yyMMdd");
                        row["판수"] = count_day;
                        row["코인토스"] = front + ":" + back;
                        row["승률"] = Math.Round(win / list2count) * 100 + "%";
                    }


                }
            }
            #endregion Table3 End

            dataGridView1.DataSource = table;
            dataGridView2.DataSource = table2;
            dataGridView3.DataSource = table3;
        }



        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void 덱승률확인하기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Owner = this;
            frm.Show();
            //this.Hide(); >>> 애가 문제임 
            // Hide 의 문제점은 메모리를 계속 점유해서 다음 실행에 문제가 존재함 
            //Form1.Dispose();
            
            
        }
        #region enter datagrid 금지
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
                // 이걸 추가하게되면 클릭에 대한 이벤트가 전혀 일어나지않음 원래의 경우 
                // 컬럼이 반응을하지만 아래의 값을 처리함으로 전혀 반응이 일어나지않게함
                int colums = dataGridView1.CurrentCell.ColumnIndex;
                int row = dataGridView1.CurrentCell.RowIndex;
                dataGridView3.CurrentCell = dataGridView1[colums, row];
                // enter에 대한 이벤트 처리
                e.Handled = true;
            }

        }

        private void dataGridView1_DragDrop(object sender, DragEventArgs e)
        {
            
        }
    }
}
