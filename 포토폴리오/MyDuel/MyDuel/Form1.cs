using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace MyDuel
{
    public partial class Form1 : Form
    {
        #region DB변수
        string _Server = "localhost";
        string _port = "3306";
        string _Database = "test";
        string _id = "root";
        string _pwd = "1234";
        string _Connection = "";
        #endregion
        #region 사용안함 변수
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
        public static string listcut;
        public static string datacut;
        #endregion
        #region Form 초기화값 
        
        public Form1()
        {
            
            InitializeComponent();
            _Connection = string.Format("Server ={0};Port={1};DataBase={2};Uid={3};Pwd={4};",_Server,_port,_Database,_id,_pwd);
            listView1.View = View.Details;
            listView1.GridLines = true;


            // 첫번째행 클릭만 처리하면 끝인데 

            /*
             * 얘 안먹혀서 form에서 처리하니까 해결완료함
             * multselect false 처리 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView2.AllowUserToDeleteRows = false;
            */
            dataGridView1.CurrentCell = null;
            select();



            #region combox Defect, listview 크기 
            // index = 0으로하면 0번째값부터 들고 오기때문에 먼저 타입을 받아오게해줌
            // dataGridView1,2,3 설정값 
            // AutoSizeColumnsMode > Fill 처리 , dataGridView1.AutoSizeRowsMode = displayed 처리  RowHeadersVisible = False 처리 
            
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            
            listView1.Columns[0].Width = 49;
            listView1.Columns[1].Width = 70;
            listView1.Columns[2].Width = 50;
            listView1.Columns[3].Width = 50;
            listView1.Columns[4].Width = 80;
            listView1.Columns[5].Width = 80;
            listView1.Columns[6].Width = 85;
            listView1.Columns[7].Width = 55;

            #endregion
           
            #region dataGrid 읽기모드
            dataGridView1.ReadOnly = true;
            dataGridView2.ReadOnly = true;
            dataGridView3.ReadOnly = true;
            
            
            #endregion


            #region 데이터 미리로드 
            // 처음시작이 얘니까 

            #region table DB
            // 간단한 SELECT 구문
            DataTable? table = new DataTable();
            
            table.Columns.Add("플레이 수", typeof(string));
            table.Columns.Add("승률", typeof(string));
            table.Columns.Add("승수", typeof(int));
            table.Columns.Add("패배", typeof(int));
            // string의 SQL 
            string playcout = "SELECT count(No) FROM myduel SET Count;";
            
            // SQL문에 들어갈 포맷
            string wincount = string.Format("SELECT count(win_lose) FROM myduel where win_lose= '승리';");
            string playcount = string.Format("SELECT count(No) FROM myduel;");
            string losecount = string.Format("SELECT count(win_lose) FROM myduel where win_lose= '패배';");
            try 
            {

                // 이렇게하면 Gridview에서 나옴 틀린거아님 해결은 했지만
                MySqlConnection mysql = new MySqlConnection(_Connection);
                mysql.Open();

                MySqlCommand win_command = new MySqlCommand(wincount, mysql);
                MySqlCommand play_command = new MySqlCommand(playcount,mysql);
                MySqlCommand lose_command = new MySqlCommand(losecount, mysql);
                // CREATE TABLE 및 DROP TABLE 문의 경우 반환 값은 0입니다. 다른 형식의 문의 경우에는 반환 값이 -1입니다. 

                // command -1 이 리턴한다면 쿼리가 잘못됬다는 뜻인데 > 근데 정상적으로 작동은함 DB에선 정상 >>  EndExecuteNonQuery() 로 생긴 에러
                //ExecuteScalar 하나의 값만 할거면 이걸 쓰자 >> 해결
                // 승률을 해야되는데 SQL형식으로 해야되는걸까 >> 예 
                // 소수점 없애고싶은데 Math.Round(DB쿼리, 2)로 소수점 삭제 완료

                table.Rows.Add(play_command.ExecuteScalar(),Math.Round(Convert.ToDouble(win_command.ExecuteScalar()) 
                    / Convert.ToDouble(play_command.ExecuteScalar()),2) * 100 + "%", win_command.ExecuteScalar(), lose_command.ExecuteScalar());
                
                dataGridView1.DataSource = table;
                dataGridView1.CurrentCell = null;

            }
            catch { }
            
            #endregion

            #region table2 DB
            // datagrid 1, 2 는 간단한 SELECT 구문에서 WHERE AND 까지지만 
            DataTable? table2 = new DataTable();
            table2.Columns.Add("앞", typeof(string));
            table2.Columns.Add("뒤", typeof(string));
            table2.Columns.Add("선공승률", typeof(string));
            table2.Columns.Add("후공승률", typeof(string));


            string forntcount = string.Format("SELECT count(cointos) FROM myduel where cointos= '앞면';");
            string backcount = string.Format("SELECT count(cointos) FROM myduel where cointos= '뒷면';");

            string fristcount = string.Format("SELECT count(cointos) FROM myduel where turn= '선공';");
            string secondcount = string.Format("SELECT count(cointos) FROM myduel where turn= '후공';");
            
            string turn_frist_count = string.Format("SELECT round((count(turn)),1) FROM myduel where turn= '선공' AND win_lose ='승리';");
            string turn_second_count = string.Format("SELECT count(turn) FROM myduel where turn= '후공' AND win_lose ='승리';");

            try
            {
                MySqlConnection mysql = new MySqlConnection(_Connection);
                mysql.Open();
                // 앞면 뒷면
                MySqlCommand forntcommand = new MySqlCommand(forntcount, mysql);
                MySqlCommand backcommand = new MySqlCommand(backcount, mysql);
                // 선공 승리, 후공 승리
                MySqlCommand turnfristcommand = new MySqlCommand(turn_frist_count, mysql);
                MySqlCommand turnsecondcommand = new MySqlCommand(turn_second_count, mysql);
                // 선후공 횟수 
                MySqlCommand fristcommand = new MySqlCommand(fristcount, mysql);
                MySqlCommand secondcommand = new MySqlCommand(secondcount, mysql);
                // table insert
                
                table2.Rows.Add(forntcommand.ExecuteScalar(), backcommand.ExecuteScalar(),
                    Math.Round(Convert.ToDouble(turnfristcommand.ExecuteScalar()) / Convert.ToDouble(fristcommand.ExecuteScalar()),1)*100+"%",
                    Math.Round(Convert.ToDouble(turnsecondcommand.ExecuteScalar()) / Convert.ToDouble(secondcommand.ExecuteScalar()),1) * 100 + "%");
                dataGridView2.DataSource = table2;
            }
            catch { }
            #endregion

            #region table3 DB
            /* TABLE 3는 다르게 진행 
            * 중복을 허용하지않고 
            * 값을 하나만 불러오며 
            * 쿼리의 복잡도를 높여보자 
            * 생각으로 짠코드이기에 논리형식은 머리속에서 정리가되어있는 상태임
            * 조금 도움을 받아봤는데 역시 쿼리접근이 틀렸음 
            */
            DataTable table3 = new DataTable();
            // 정상적으로 들어가는경우 
            // SELECT DISTINCT date as 날짜,  count(*) AS 판수, SUM(if(win_lose='승리', 1,0) AS win_cnt, SUM(if(win_lose='패배', 1, 0) AS lose_cnt FROM myduel GROUP BY date ORDER BY date DESC
            
            // 날짜 , 판수 데이터 !
            string date = string.Format("SELECT date AS 날짜 ,count(*) AS 판수, sum(if(win_lose='승리',1,0)) as 승리, sum(if(win_lose='패배',1,0)) as 패배 FROM myduel GROUP BY date ORDER BY date"); // 다 불러오지만 원하는 쿼리를 해야한다면 다중쿼리 코드 작성필요 
            //string date = string.Format("SELECT DISTINCT date FROM myduel;"); 
            // 아ㅏ아아아 모든 구문을 다 부르는 경우는 가능하지만 이러면 이중을 쓰는게 나아보이는데 위에 모든 sql쿼리를 가져오라했더니 정상작동을 하니 
            // 그렇다면 다중 sql 쿼리로 불러와야한다 그럼 방법은 중첩쿼리?  >> 쿼리가바꾸는게 최고다
            
            
            // 이와 같은 계속 데이터가 호출되어야하지만 
            // 원하는데이터는
            /*
             * SELECT DISTINCT count(turn) FROM myduel where date='231211'; 이쿼리가 끝나면
             * SELECT DISTINCT count(turn) FROM myduel where date='231212'; 이쿼리를 받아오고 
             * SELECT DISTINCT count(turn) FROM myduel where date={0} break 조건 {0} == Null break;
             * >> 한줄로 해결완료 
             * 쿼리가 Null 만날때까지 계속해야함
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

                
                adapter.Fill(ds, "날짜");
                //adapter1.Fill(ds, "2");

               
                dataGridView3.DataSource = ds.Tables["날짜"];
                
                //dataGridView3.DataSource = ds.Tables["2"];
                //table3.Rows.Add(datecommand.ExecuteScalar());
                //dataGridView3.DataSource = table3;
            }
            catch { }
            
            
            
            #endregion

            
            #endregion
        }
         
        #endregion
        // Update , listview , datagrid 값 관련
        #region listview1, datagrid 1,2,3
        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.CurrentCell = null;
            dataGridView2.CurrentCell = null;
            dataGridView3.CurrentCell = null;
            
            // 현재 오류 수정 > No 자동오름이 추가 20 > 으로되는거 수정필요
            /*
             Auto Increment 
             특징상 1 , 2, 3, 4 
             4가 삭제된다고 4를 다시 넣는것이 아님 
             정확히는 4는 이미 저장된 값이기때문에 5부터 시작하게됨 5부터 다시 하기 위해서는 
             항상 auto_increment= 1 로 하는  set 3줄 코드를작성해야함 그 해결 방법은 
             다른방법으로 초기화 완료 > 24.01.05 해결 완료 '해결 방법 주석'을 확인 
             24로 시작되는 에러 발생중
             */

            // null이들어갈수없게 null 입력 못받게 포커스 
            #region null 체크 
            bool check;
            if (string.IsNullOrWhiteSpace(textBox1.Text) != false || string.IsNullOrWhiteSpace(textBox2.Text) != false)
            {
                MessageBox.Show("데이터를 넣어주세요");
                if (string.IsNullOrWhiteSpace(textBox1.Text)) { textBox1.Focus(); }
                else if(string.IsNullOrWhiteSpace(textBox2.Text)) 
                {
                textBox2.Focus(); 
                }
                //textbox3 비고칸이기때문에 null을 넣어도 괜찮음 
                // db 확인 결과 null 처리가 안되있음 
                // db에서는 null 아닌 빈칸으로 들어가서 데이터가 들어간 상태로 처리됨
                #region 해결 방법 주석 
                /* 
                 ALTER TABLE myduel AUTO_INCREMENT=1;
                 SET @COUNT = 0;
                 UPDATE myduel SET `No` =@COUNT:=@COUNT+1;
                 NO는 기본적으로 예약어니 `No`를 적용 문제는 이게아니였고 
                 다른 문제였음 You are using safe update mode 모드가 다중 테이블 처리를 할려해서 계속 막히던것 이걸 사용하면 
                 정상적으로 숫자를 0부터 시작해서 15까지 가능했다  
                 mysqlworkbench 환경에서였기때문에 서술한다면
                 실행후 mysql 비밀번호로 로그인이후 
                 Edit > preferences -> safe mode 제일 아래 해체후 workbrench 재시작 필요 
                 프로그램 재기동후 확인 > 빈칸없이 1234 순서대로 적용확인 
                >> 아직도 숫자가 있는건지 확인중 
                 */
                #endregion
                check = false;
                // textbox1 에 입력만해도 출력이됨 문제있음 or(||) 처리로 해결 
                // DB 문제 해결필요
            }// false이면 else 절에 가지않기때문에 true일때문 if > check를 받고 데이터 처리 시작 
            #endregion
             #region else 이후 데이터처리 
            else
            {
                check = true;
                if (check == true)
                {
                    dataGridView1.AllowUserToAddRows = false;
                    dataGridView2.AllowUserToDeleteRows = false;
                    #region CRUD INSERT 완료
                    /* DB의 배열값 
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
                            // 1 2 3 4 5 6 7 로 시작하니까 에러였음 0,1,2,3,4,5,6 으로 넣으 정상적으로 에러해결 
                            string insertQuery = string.Format("INSERT INTO myduel (Cointos, turn, win_lose, mydeck , otherdeck, etc, date) VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}');",
                            this.comboBox1.Text, this.comboBox2.Text, this.comboBox3.Text, this.textBox1.Text, this.textBox2.Text, this.textBox3.Text, DateTime.Now.ToString("yyMMdd"));
                            MySqlCommand command = new MySqlCommand(insertQuery, mysql);
                            if (command.ExecuteNonQuery() != 1)
                            {
                                MessageBox.Show("Query error");
                            }
                            // 중복되기 이전에 삭제하기위함 
                            listView1.Items.Clear();
                            select();
                        }
                    }
                    catch (Exception ex) { MessageBox.Show(ex.ToString()); }

                    #endregion

                    #region Click Event DB이전
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
                    //listView1.Items.Add(item);
                    //item.Text = count.ToString();
                    // 코인토스 앞뒤 
                    //item.SubItems.Add(cointos);
                    //이제는 승률을 구현해야함 
                    // 승률이란 전체 플레이 수 중에서 승리만 카운터하면됨 

                    // comboBox3.SelectedIndex = 0; // 이게 승리지
                    // 값을 어떻게 들고올거냐? 


                    //  승리 / 전체플레이
                    // 승리값만 보면됨 

                    // 선후공 
                    //item.SubItems.Add(turn);
                    // 결과
                    //item.SubItems.Add(outcome);
                    // 내 덱
                    //item.SubItems.Add(myDeck);
                    // 상대덱 
                    //item.SubItems.Add(otherDeck);
                    // 비고란
                    //item.SubItems.Add(etc);
                    // 날짜값
                    //item.SubItems.Add(Convert.ToString(DateTime.Now.ToString("yyMMdd")));
                    //item.SubItems.Add("dd"+aa); >> 정적인 값이 맞는데 
                    // 리스트값을 자동스크롤바

                    //listView1.Items[listView1.Items.Count - 1].EnsureVisible();

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

                    #region Table 1 Start DB


                    DataTable? table = new DataTable();
                    table.Columns.Add("플레이 수", typeof(string));
                    table.Columns.Add("승률", typeof(string));
                    table.Columns.Add("승수", typeof(int));
                    table.Columns.Add("패배", typeof(int));
                    //리스트뷰2값은 동적으로 계속변경되어야함 리스트 뷰는 값이 변경되면안되는 분야고 동적으로 되지않기때문에 리스트뷰는 제한됨
                    // 동적으로 바꿀수 있는건 DataGrid가 아닌가? 정답! 
                    string list2count = listView1.Items.ToString();

                    #region table1 DB 변환
                    try
                    {

                        // int list2count 값으로정의되잇기때문에 int값연산이 다된다 , 줄의 값을 보여주기때문에 다른 Row를 선언하면 추천되지않는다

                        string wincount = string.Format("SELECT count(win_lose) FROM myduel where win_lose= '승리';");
                        string playcount = string.Format("SELECT count(No) FROM myduel;");
                        string losecount = string.Format("SELECT count(win_lose) FROM myduel where win_lose= '패배';");


                        // 이렇게하면 Gridview에서 나옴 틀린거아님 해결은 했지만
                        MySqlConnection mysql = new MySqlConnection(_Connection);
                        mysql.Open();
                        MySqlCommand win_command = new MySqlCommand(wincount, mysql);
                        MySqlCommand play_command = new MySqlCommand(playcount, mysql);
                        MySqlCommand lose_command = new MySqlCommand(losecount, mysql);
                        // Double형의 소수점문제 > math.Round > 소수점 올림 
                        table.Rows.Add(play_command.ExecuteScalar(), Math.Round(Convert.ToDouble(win_command.ExecuteScalar())
                                        / Convert.ToDouble(play_command.ExecuteScalar()), 2) * 100 + "%", win_command.ExecuteScalar(), lose_command.ExecuteScalar());
                        dataGridView1.DataSource = table;
                        // OK Click 이벤트에서도 정상작동

                    }
                    catch { }
                    #endregion
                    //table.Rows.Add(list2count, Math.Round(win / list2count * 100) + "%", win, lose);
                    #endregion Table 1 End 

                    #region Table 2 Start DB

                    #region DB 이전 버전
                    /*
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
                    */
                    #endregion
                    DataTable? table2 = new DataTable();
                    table2.Columns.Add("앞", typeof(string));
                    table2.Columns.Add("뒤", typeof(string));
                    table2.Columns.Add("선공승률", typeof(string));
                    table2.Columns.Add("후공승률", typeof(string));


                    string forntcount = string.Format("SELECT count(cointos) FROM myduel where cointos= '앞면';");
                    string backcount = string.Format("SELECT count(cointos) FROM myduel where cointos= '뒷면';");

                    string fristcount = string.Format("SELECT count(cointos) FROM myduel where turn= '선공';");
                    string secondcount = string.Format("SELECT count(cointos) FROM myduel where turn= '후공';");

                    string turn_frist_count = string.Format("SELECT count(turn) FROM myduel where turn= '선공' AND win_lose ='승리';");
                    string turn_second_count = string.Format("SELECT count(turn) FROM myduel where turn= '후공' AND win_lose ='승리';");

                    try
                    {
                        MySqlConnection mysql = new MySqlConnection(_Connection);
                        mysql.Open();
                        // 앞면 뒷면
                        MySqlCommand forntcommand = new MySqlCommand(forntcount, mysql);
                        MySqlCommand backcommand = new MySqlCommand(backcount, mysql);
                        // 선공 승리, 후공 승리
                        MySqlCommand turnfristcommand = new MySqlCommand(turn_frist_count, mysql);
                        MySqlCommand turnsecondcommand = new MySqlCommand(turn_second_count, mysql);
                        // 선후공 횟수 
                        MySqlCommand fristcommand = new MySqlCommand(fristcount, mysql);
                        MySqlCommand secondcommand = new MySqlCommand(secondcount, mysql);
                        // table insert
                        table2.Rows.Add(forntcommand.ExecuteScalar(), backcommand.ExecuteScalar(),
                            Math.Round(Convert.ToDouble(turnfristcommand.ExecuteScalar()) / Convert.ToDouble(fristcommand.ExecuteScalar()),2) * 100 + "%",
                            Math.Round(Convert.ToDouble(turnsecondcommand.ExecuteScalar()) / Convert.ToDouble(secondcommand.ExecuteScalar()),2) * 100 + "%");
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
                    // table3 의 경우 날짜마다 토스, 판수, 승률을 나눠야함 

                    #region 이전 버전 클릭이벤트 
                    // 날짜마다 가산되어야함 
                    // 날짜와 날짜는 서로 다름 
                    // 판수의 데이터를 뽑아내는게 문젠데 
                    /*
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
                    }*/
                    #endregion
                    DataTable table3 = new DataTable();
                    // 정상적으로 들어가는경우 
                    // SELECT DISTINCT date as 날짜,  count(*) AS 판수, SUM(if(win_lose='승리', 1,0) AS win_cnt, SUM(if(win_lose='패배', 1, 0) AS lose_cnt FROM myduel GROUP BY date ORDER BY date DESC
                    table3.Columns.Add("날짜", typeof(string));
                    table3.Columns.Add("판수", typeof(string));
                    table3.Columns.Add("코인토스", typeof(string));
                    table3.Columns.Add("승률", typeof(string));
                    // 날짜 , 판수 데이터 !
                    string date = string.Format("SELECT date AS 날짜 ,count(*) AS 판수, sum(if(win_lose='승리',1,0)) as 승리, sum(if(win_lose='패배',1,0)) as 패배 FROM myduel GROUP BY date ORDER BY date"); // 다 불러오지만 원하는 쿼리를 해야한다면 다중쿼리 코드 작성필요 
                                                                                                                                                                                                  // 이와 같은 계속 데이터가 호출되어야하지만 
                                                                                                                                                                                                  // 원하는데이터는
                    try
                    {
                        // 현재 에러남 
                        int a = 0;
                        MySqlConnection mysql = new MySqlConnection(_Connection);
                        mysql.Open();
                        MySqlCommand datecommand = new MySqlCommand(date, mysql);
                        MySqlDataAdapter adapter = new MySqlDataAdapter(date, mysql);
                        adapter.SelectCommand = datecommand;
                        DataSet ds = new DataSet();
                        adapter.Fill(ds, "날짜");
                        dataGridView3.DataSource = ds.Tables["날짜"];
                    }
                    catch { }


                    #endregion Table3 End


                    #region 폼2에 보낼 데이터 
                    // 성공함 그런데 이런 데이터만 가선안됨
                    listcut = Convert.ToString(list2count);
                    // 데이터를 보낼바에는중복적인 데이터를 사용하게 만들고 
                    // 디비를 구현하는게 더 나음 > 디비구현의 이유
                    #endregion
                }
            }
            
        }
            #endregion 
        #endregion

        #region CRUD Read 
        private void select()
        {

            /* DB의 배열값 
             * no = 0 
             * cointos =1
             * turn = 2
             * win_lose =3
             * mydeck = 4
             * otherdeck = 5
             * etc =6
             * date 7 
             */
            // select 조회는 정상적 
            try
            {
                using (MySqlConnection mysql = new MySqlConnection(_Connection))
                {
                    mysql.Open();
                    string selectQurey = string.Format("SELECT * FROM myduel");
                    MySqlCommand comm = new MySqlCommand(selectQurey, mysql);
                    MySqlDataReader tables = comm.ExecuteReader();
                    //if (comm.ExecuteNonQuery() != 1) MessageBox.Show(" 시작부 error"); << 에러원인 
                    // 결과값이 돌아오지않을때 값을 받아오기때문에 이게 있을필요가없다
                    // 데이터를 미리 넣어봤고 확인결과 정상적으로 insert된걸 Read해옴
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
        #region CRUD Update 사용안함
        private void table()
        {
            using (MySqlConnection mysql = new MySqlConnection(_Connection))
                {
                    mysql.Open();
                    try
                        {
                            DataTable? table = new DataTable();
                            table.Columns.Add("플레이 수", typeof(string));
                            table.Columns.Add("승률", typeof(string));
                            table.Columns.Add("승수", typeof(int));
                            table.Columns.Add("패배", typeof(int));
           


                            //int list2count 값으로정의되잇기때문에 int값연산이 다된다 , 줄의 값을 보여주기때문에 다른 Row를 선언하면 추천되지않는다

                
                            string playcount = string.Format("SELECT count(No) FROM myduel;");
                            // DB에서 SQL 때려본 결과는 잘돌아감
                            string wincount = string.Format("SELECT count(win_lose) FROM myduel where win_lose= '승리';");
                            string losecount = string.Format("SELECT count(win_lose) FROM myduel where win_lose= '패배';");
                            // 승률때문에 인한 double switch
                            double playcount_string_change_double = Convert.ToInt32(playcount);
                            double win_lose_string_change_double = Convert.ToInt32(wincount);
                            //MySqlCommand commnad = new MySqlCommand();
                            // win, lose count 반영이안됨
                            MessageBox.Show("error", "승리" + wincount + "패배 " + losecount);
                            table.Rows.Add(playcount, Math.Round(win_lose_string_change_double / playcount_string_change_double * 100) + "%", wincount, losecount);
                // 안쓰는코드 
                        }
                        catch { }
            }
           

        }
        #endregion

        #region Form2관련
        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void 덱승률확인하기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f2 = new Form2();
            f2.Owner = this;
            f2.Show();
            listView1.Text = f2.select;
            listView1.Text = "Select a Student";
            //this.Hide(); >>> 애가 문제임 
            // Hide 의 문제점은 메모리를 계속 점유해서 다음 실행에 문제가 존재함 
            //Form1.Dispose();
            // 결국은 DB 구현을 해야함 >> DB구현 ! 
            
        }
        #endregion

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
        
        #region 드래그 금지
        private void dataGridView3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // 이걸 추가하게되면 클릭에 대한 이벤트가 전혀 일어나지않음 원래의 경우 
                // 컬럼이 반응을하지만 아래의 값을 처리함으로 전혀 반응이 일어나지않게함
                int colums = dataGridView1.CurrentCell.ColumnIndex;
                int row = dataGridView1.CurrentCell.RowIndex;
                
                // enter에 대한 이벤트 처리
                e.Handled = true;
            }

        }

        private void dataGridView1_DragDrop(object sender, DragEventArgs e)
        {
            
        }
        #endregion
    }
}
