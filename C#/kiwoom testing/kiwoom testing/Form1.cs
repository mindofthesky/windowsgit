using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace kiwoom_testing
{
    public partial class Form1 : Form
    {
        #region 일봉 및 변수
        string 일체결일;
        int 일시가, 일저가, 일고가, 일현재가;
        long 일거래량;
        List<dayChart> priceInfoList;
        #endregion
        #region 자동 메세지박스 닫기 구현 
        public class AutoClosingMessageBox
        {
            private const int WM_CLOSE = 0x0010;

            [DllImport("user32.dll", SetLastError = true)]
            private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

            [DllImport("user32.dll", SetLastError = true)]
            private static extern bool PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

            public static void Show(string text, string caption, int timeout)
            {
                Task.Run(() =>
                {
                    IntPtr hWnd = IntPtr.Zero;
                    while ((hWnd = FindWindow(null, caption)) == IntPtr.Zero) ;
                    Task.Delay(timeout).Wait();
                    PostMessage(hWnd, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
                });

                MessageBox.Show(text, caption);
            }
        }
        #endregion
        #region 폼쪽 리시브 선언부
        public Form1()
        {
            InitializeComponent();
            #region 실행 가능 코드
            axKHOpenAPI1.OnReceiveTrData += OnReceiveTrData;
            // 정상 실행중   | 로그인 관련 리시브 함수
            
            
            //axKHOpenAPI1.OnReceiveTrData += OnReceiveTrDataDaychart;
            // 현재 해결완료 | 일봉 함수
            
            
            
            #region 차트 변수
            Series chartSeries;
            chartSeries = daychart.Series["Series1"];
            chartSeries.ChartType = SeriesChartType.Candlestick;
            daychart.ChartAreas[0].AxisY.IsStartedFromZero = false;
            // 얘는 0 값 없애줌 
            daychart.AxisViewChanged += daychart_AxisViewChanged;
            daychart.Capture = true;
            daychart.ChartAreas[0].AxisX.ScrollBar.Enabled = true;
            daychart.ChartAreas[0].AxisY.ScrollBar.Enabled = true;
            daychart.MouseWheel += daychart_MouseWheel;
            daychart.MouseEnter += (s, e) => daychart.Focus();
            daychart.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            daychart.ChartAreas[0].AxisY.ScaleView.Zoomable = true;
            daychart.ChartAreas[0].AxisX.Minimum = Double.NaN;
            daychart.ChartAreas[0].AxisX.Maximum = Double.NaN;
            daychart.ChartAreas[0].AxisY.Minimum = Double.NaN;
            daychart.ChartAreas[0].AxisY.Maximum = Double.NaN;
            // 구현완료 
            #endregion
            // 해결완료 
            #endregion
            //axKHOpenAPI1.OnReceiveTrData += ax_OnReceiveTrData;
            // 코드 테스트
            axKHOpenAPI1.OnReceiveTrCondition += axKHOpenAPI1_OnReceiveTrCondition;
            //axKHOpenAPI1.OnReceiveRealCondition += axKHOpenAPI1_OnReceiveRealCondition;
            axKHOpenAPI1.OnReceiveTrCondition += axKHOpenAPI1_OnReceiveRealCondition;
            axKHOpenAPI1.OnReceiveTrData+= OnReceiveTrCall;
        }
        #endregion
        #region 조건식검색 코드 구현완료 실시간 검색 나중에 
        // 세력 전광판을 만드는 핵심인데 
        
        // 클릭에서 GetConditionLoad  호출이 첫 이벤트 발생
        private void selebtn_Click(object sender, EventArgs e)
        {
            // 조건식을 불러오기위한 키움 
            // 첫 호출 
            int ret = axKHOpenAPI1.GetConditionLoad();
            if (ret == 1)
            {
                MessageBox.Show("조건식 목록 요청 성공");
            }
            else
            {
                MessageBox.Show("조건식 목록 요청 실패");
            }
            // 3번째 호출 여기서 사용자 호출 
            string conditionList = axKHOpenAPI1.GetConditionNameList();
            string[] conditions = conditionList.Split(';');
            foreach (string condition in conditions)
            {
                if (!string.IsNullOrEmpty(condition))
                {
                    string[] parts = condition.Split('^'); // 조건식을을 한줄로하지않고 하나하나 띄어줌 
                    string conditionIndex = parts[0];  // 조건식 번호
                    string conditionName = parts[1];   // 조건식 이름
                    //comboBox2.Items.Add($"{conditionIndex}: {conditionName}");
                    //dataGridView1.Rows.Add(conditionIndex);
                }
            }
            // 사용자 여기서 한번더 호출 후 > 조건 검색을 호출 
            // 4번째 호출 
            axKHOpenAPI1.SendCondition("1002", "이격도 순위", 0, 1);
            // 성공 1, 실패 0 

        }
        private async Task RequestStockInfoAsync(string code)
        {
           
                axKHOpenAPI1.SetInputValue("종목코드", code.Trim());
                axKHOpenAPI1.CommRqData($"주식기본정보_{code}", "OPT10001", 0, "1001");
                await Task.Delay(199); // 0.2초 딜레이
            
        }

        // 두번째 호출 시작  // 5번째 호출 
        private async void axKHOpenAPI1_OnReceiveTrCondition(object sender, AxKHOpenAPILib._DKHOpenAPIEvents_OnReceiveTrConditionEvent e)
        {
            dataGridView1.Columns.Add("종목코드", "종목코드");
            dataGridView1.Columns.Add("종목명", "종목명");
            dataGridView1.Columns.Add("현재가", "현재가");
            dataGridView1.Columns.Add("누적거래량", "누적거래량");
            dataGridView1.Columns.Add("시가", "시가");
            dataGridView1.Columns.Add("고가", "고가");
            dataGridView1.Columns.Add("저가", "저가");
            dataGridView1.Columns.Add("시가총액", "시가총액");

            int screenNumber = 1001;
            string screenNo = (screenNumber++).ToString();
            Debug.WriteLine(e.strConditionName);
            if (e.strCodeList.Length > 0)
            {
                //5번째 호출 시작 
                string[] codes = e.strCodeList.Split(';');
                foreach (string code in codes)
                {
                    if (!string.IsNullOrEmpty(code))
                    {
                        // 조건 검색을 호출 받고 출력 
                        string stockname = axKHOpenAPI1.GetMasterCodeName(code.Trim());
                        //listBox2.Items.Add($"종목코드: {code}");
                        //listBox2.Items.Add($"종목명:{종목명}");
                        // 실시간 체결 데이터 요청
                         int a =
                            axKHOpenAPI1.SetRealReg
                            (
                            "9000", 
                            code.Trim()
                            ,
                            "10;13;16;17;18;311;", // 10 현재가, 13 누적거래량, 16시가,17 고가, 18 저가 ,311 시가총액 
                            "0"
                            );  // 10번 필드(현재가)에 대해 실시간 요청

                        // 정상적으로 오고있음 오류내보니까 에러코드로 -105 가 오고있음 '
                        if (a >= 0)
                        {
                            // 오류 아님 
                            //Debug.WriteLine($"시카노코노코시코시탄탄:{a}");
                            // 최대 100개 불러옴 
                        }
                        else
                        {
                            MessageBox.Show("조건 검색 에러");
                        }
                        int rowIndex = dataGridView1.Rows.Add();
                        dataGridView1.Rows[rowIndex].Cells["종목코드"].Value = code;
                        dataGridView1.Rows[rowIndex].Cells["종목명"].Value = stockname;
                        //Thread.Sleep(100);
                        await RequestStockInfoAsync(code);
                        
                            //dataGridView1.Rows[rowIndex].Cells["고가"].Value = Math.Abs(int.Parse(axKHOpenAPI1.GetCommData(code, stockname, 0, "고가").Trim()));
                            //dataGridView1.Rows[rowIndex].Cells["저가"].Value = Math.Abs(int.Parse(axKHOpenAPI1.GetCommData(code, stockname, 0, "저가").Trim()));

                        // Math.Abs(int.Parse(axKHOpenAPI1.GetCommData(code, stockname, 2, "거래량").Trim()));
                        //Debug.WriteLine("코드 확인" + Rcount);

                    }
                }
            }
        }
        private void OnReceiveTrCall(object sender, AxKHOpenAPILib._DKHOpenAPIEvents_OnReceiveTrDataEvent e)
        {

            if (e.sRQName.StartsWith("주식기본정보_"))
            {

                Debug.WriteLine(e.sRQName+" "+e.sTrCode);
                string 종목코드 = e.sRQName.Split('_')[1].Trim();
                Debug.WriteLine(종목코드);
                string receivedCode = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "종목코드").Trim();
                int currentPrice = Math.Abs(int.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "현재가").Trim()));
                int stprice = Math.Abs(int.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "거래량").Trim()));
                // 인수를 100으로 바꾸는경우 어느 정도 해결은 된다 
                // 근데 너무느리다 100으로하는경우 너무 느리다 
                // 너무 많은 쿼리를  한번에 던지니까 에러가 난다 그래서 비동기로 데이터를 느리게 줬더니 해결은되는데 
                for (int i = 0; i < dataGridView1.Rows.Count && i < 100; i++)
                {
                    try
                    {
                        DataGridViewRow row = dataGridView1.Rows[i];
                    
                    
                    if (row.Cells["종목코드"].Value != null && row.Cells["종목코드"].Value.ToString() == receivedCode)
                    {
                        row.Cells["현재가"].Value = currentPrice;
                        row.Cells["누적거래량"].Value = stprice;
                        row.Cells["시가"].Value = Math.Abs(int.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "시가").Trim()));
                        row.Cells["고가"].Value = Math.Abs(int.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "고가").Trim()));
                        row.Cells["저가"].Value = Math.Abs(int.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "저가").Trim()));
                        row.Cells["시가총액"].Value = Math.Abs(int.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "시가총액").Trim()));
                        Debug.WriteLine(row + "1" + dataGridView1.Rows.Count);
                        // 필요시 break
                    }
                    }
                    catch (Exception ex)
                    {

                    }
                }
                Debug.WriteLine($"종목코드: {종목코드}, 현재가: {currentPrice}");
            }
        }
            // 6번째 호출로 결과를 내뱉자 
            // 실시간 조건 검색 처리 아직 안하니까 하지마셈 24.09.20 
            private void axKHOpenAPI1_OnReceiveRealCondition(object sender, AxKHOpenAPILib._DKHOpenAPIEvents_OnReceiveTrConditionEvent e)
        {
            // 
            string[] codes = e.strCodeList.Split(';');
            foreach (string code in codes)
            {

                string stockname = axKHOpenAPI1.GetMasterCodeName(code.Trim());
                //axKHOpenAPI1.GetCommRealData(code, 10).Trim();
                
                // 개고생을 하면서 봤는데 결국 이렇게 계속적으로 불러오는 주식조회정보라고? 
                /*
                Debug.WriteLine(
                  "여기오니? " + code.Trim()
                + "너는 어디까지? :" + stockname
                + "나도 여기까지 :" + e.sScrNo
                + "이건 뭘로 오냐 : " + e.nNext
                + "나는 뭔지보자 : " + e.nIndex
                            );
                */

                //Debug.WriteLine(axKHOpenAPI1.GetCommRealData(code, 10));
            }
                // e.strCodeList 배열 목록 이렇게옴 
            // 000150;000520;001000;001380;001750;001755;003720;006910;011420;012030;012170;013890;016610;018290;018310;019490;019570;
            // 019990;023770;033320;035250;036180;043090;047770;049180;062970;064850;071280;072130;078140;082850;084850;087010;087260;
            // 090430;090435;099220;101730;102370;112290;115610;119650;123330;130660;161580;163730;171090;173940;177350;187420;189330;
            // 196300;199820;206400;208370;210120;214260;214370;219550;226950;234300;239610;254490;288330;306620;313760;321820;338840;
            // 348080;351320;370090;373110;373220;378340;378800;388720;389260;389470;393210;419530;439580;440110;450080;455900;458870;
            // 464080;475150;950220;500066;500027;520050;530100;530036;550072;550043;570079;580037;580051;610042;700016;
            // e.strConditionName 얘는 그이름임  너는 어디까지? :이격도 순위
            // sScrNo 화면 번호 나도 여기까지 :1002
            // 버그가 있는데 실시간 조회가 listbox 까지 들어간다
        }
        #endregion
        #region 검색 주식종목 번호로 검색 ex ) 005930 > 삼성전자 
        private void button2_Click(object sender, EventArgs e)
        {
            axKHOpenAPI1.SetInputValue("종목코드", textBox1.Text); // 1. SetInputValue
            int ret = axKHOpenAPI1.CommRqData("주식기본정보", "OPT10001", 0, "1002"); // 2. CommRqData 를 통해 데이터 요청
            if (ret < 0)
            {
                MessageBox.Show("요청 실패\nError Code : " + ret, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            axKHOpenAPI1.SetInputValue("종목코드", textBox1.Text);
            int result = axKHOpenAPI1.CommRqData("주식거래원", "OPT10002", 0, "1002");
            listBox1.Items.Clear();
            axKHOpenAPI1.OnReceiveRealData += axKHOpenAPI_OnReceiveRealData;
            // 해결완료      | 실시간 데이터 

        }
        #region 주식기본정보 데이터 리시브 구현 
        private void OnReceiveTrData(object sender, AxKHOpenAPILib._DKHOpenAPIEvents_OnReceiveTrDataEvent e)
        {
            string jName;
            string jPrice;
            string jmonth;
            string jprices;
            string juptip;
            string jdowntip;
            int receiveCnt = axKHOpenAPI1.GetRepeatCnt(e.sTrCode, e.sRQName);
            if ("주식기본정보".Equals(e.sRQName))
            {
                for (int i = 0; i <= receiveCnt; i++)
                {
                    // for문 없애도 되고 i 를 0으로 처리하면 똑같이 나오나 귀찮으니까 그냥 이렇게 둠 
                    jName = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, i, "종목명").Trim(); // 4. GetCommData 메소드를 통해 데이터 접근
                    jPrice = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, i, "현재가").Trim(); // 4. GetCommData 메소드를 통해 데이터 접근
                    jmonth = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, i, "결산월").Trim();
                    jprices = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, i, "자본금").Trim();
                    juptip = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, i, "상한가").Trim();
                    jdowntip = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, i, "하한가").Trim();
                    if (jPrice.StartsWith("+") || jPrice.StartsWith("-"))
                    {
                        jPrice = jPrice.Substring(1);  // 첫 글자 부호 제거 > 현재가는 양수 음수가올수있기 때문에 처리 
                    }
                    //MessageBox.Show("[" + jName + "]\n현재가 : " + jPrice.Replace("-", "") + "\n결산월" + jmonth + "\n자본금" + jprices + "\n상한가" +juptip.Replace("+", "") + "\n하한가" + jdowntip.Replace("-", "") + "]\n");

                    richTextBox1.Text += "[" + jName + "]\n현재가 : " + jPrice + "\n결산월 : " + jmonth + "\n자본금 : " + jprices
                        + "\n상한가 : " + juptip.Replace("+", "") + "\n하한가 : " + jdowntip.Replace("-", "") + "\n";
                    richTextBox1.SelectionStart = richTextBox1.Text.Length;
                    richTextBox1.ScrollToCaret();
                    // 마지막 스크롤로 fouse 
                }
            }
            
        }
        #endregion
        #endregion
        #region 로그인 버튼 클릭 이벤트 처리
        private void button1_Click(object sender, EventArgs e)
        {
            if (axKHOpenAPI1.CommConnect() == 0) AutoClosingMessageBox.Show("로그인창 열기 성공.", "로그인 확인", 1000);
            else MessageBox.Show("로그인창 열기 실패");      
        }
        
        #endregion
        #region 로그인 확인 이벤트 처리 
            private void button3_Click(object sender, EventArgs e)
        {
            if (axKHOpenAPI1.GetConnectState() == 0) // 0이면 미연결, 1이면 정상연결 
                MessageBox.Show("Open API 연결되어 있지 않습니다.");
            else
                MessageBox.Show("Open API 연결 중입니다.");
        }

        #endregion
        #region 계좌 조회 및 예수금 조회
        private void txtTest_Click(object sender, EventArgs e)
        {
            axKHOpenAPI1.SetInputValue("", "");
            // 계좌 개수
            listBox2.Items.Add("계좌 갯수 : " + axKHOpenAPI1.GetLoginInfo("ACCOUNT_CNT"));


            // 전체 계좌 정보 (계좌별 구분 - ";")
            //comboBox1.Text = axKHOpenAPI1.GetLoginInfo("ACCNO");
            comboBox1.Items.AddRange(axKHOpenAPI1.GetLoginInfo("ACCNO").Split(';'));
            comboBox1.SelectedIndex = 0;
            // 사용자 ID
            listBox2.Items.Add("사용자 아이디 : " + axKHOpenAPI1.GetLoginInfo("USER_ID"));

            // 사용자명
            listBox2.Items.Add("유저명 : " + axKHOpenAPI1.GetLoginInfo("USER_NAME"));
        }
        #region 예수금 조회 버튼

        private void button_Clicked(object sender, EventArgs e)
        {
            string selectedAccount = (string)comboBox1.SelectedItem;
            axKHOpenAPI1.SetInputValue("계좌번호", selectedAccount.Trim());
            axKHOpenAPI1.SetInputValue("비밀번호", "");
            axKHOpenAPI1.SetInputValue("비밀번호입력매체구분", "00");
            axKHOpenAPI1.SetInputValue("조회구분", "3");
            int result = axKHOpenAPI1.CommRqData("RQName", "OPW00001", 0, "1002");
            if (axKHOpenAPI1.GetConnectState() == 0) // 0이면 미연결, 1이면 정상연결 
                MessageBox.Show("Open API 연결되어 있지 않습니다.");
            else
                MessageBox.Show("Open API 연결 중입니다.");

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string selectedAccount = (string)comboBox1.SelectedItem;
            axKHOpenAPI1.SetInputValue("계좌번호", selectedAccount.Trim());
            axKHOpenAPI1.SetInputValue("비밀번호", "");
            axKHOpenAPI1.SetInputValue("상장폐지조회구분", "0");
            axKHOpenAPI1.SetInputValue("비밀번호입력매체구분", "00");
            axKHOpenAPI1.CommRqData("계좌평가현황", "OPW00004", 0, "1002");
        }

        /// <summary>
        ///  잊지 말아야할점은 
        ///  코드 먼저 작성후에 
        ///  axKHOpenAPI1.OnReceiveTrData += TestOnReceiveTrData;
        /// </summary>
        /// <param name="sender">이벤트 처리의 sneder 굳이 중요하지는 않다</param>
        /// <param name="e"> 여기서 api이벤트랑, 클릭이벤트가 정해지는데 이게 중요하다</param>
        /// getConditionButton_Click 같이 한번 처리할 기능이 필요하다 
        /// <param name="sender">이벤트 처리의 sneder 굳이 중요하지는 않다</param>
        /// <param name="e"> e는 클릭 이벤트를 발생시키고 </param>
        /// TestOnReceiveTrData
        /// <param name="sender"></param>
        /// <param name="AxKHOpenAPILib._DKHOpenAPIEvents_OnReceiveTrDataEvent e ">랑 연결되있는데 
        /// getConditionButton_Click 에서는 SetInputValue값을 정의하고
        /// CommRqData를 호출해야한다 
        /// 그런이후 일봉 처럼 
        ///  string 예수금 = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "예수금").Trim(); 을 호출할수있게된다 
        /// </param>
        /// 지금 버그있어서 고민중임 
        private void getConditionButton_Click(object sender, EventArgs e)
        {
            string selectedAccount = (string)comboBox1.SelectedItem;

            // InputValue 설정
            axKHOpenAPI1.SetInputValue("계좌번호", selectedAccount.Trim()); // 계좌번호 설정
            axKHOpenAPI1.SetInputValue("비밀번호", "");                    // 비밀번호 (미입력 시 자동으로 처리됨)
            axKHOpenAPI1.SetInputValue("비밀번호입력매체구분", "00");         // 비밀번호입력매체구분
            axKHOpenAPI1.SetInputValue("조회구분", "3");                    // 3: 조회구분 (1: 추정자산, 3: 예수금)
            // 예수금 조회 요청 (RQName: "예수금상세현황요청", TRCode: "OPW00001")
            int ret = axKHOpenAPI1.CommRqData("예수금상세현황", "opw00001", 0, "1002");

            Debug.WriteLine("정상적이면 0이 들어옵니다  :" + ret);

            if (ret < 0)
            {
                MessageBox.Show("예수금 조회 요청 실패: " + ret);
                // 예수금상세현황요청으로하니까 -202 들어옴 > 키움 에러코드표를 참고
                // 예수금상세현황으로 변경하니까 정상적으로 되고있음 
            }

        }


        // 사용안된코드 
        private void KOSPIOnReceiveTrData(object sender, AxKHOpenAPILib._DKHOpenAPIEvents_OnReceiveTrDataEvent e)
        {
            Debug.WriteLine("버그 ");
            if (e.sRQName == "전업종지수요청")
            {
                Debug.WriteLine("버그1");
                int nCnt = axKHOpenAPI1.GetRepeatCnt(e.sTrCode, e.sRQName);
                for (int nIdx = 0; 0 <= nCnt; nIdx++)
                {
                    listBox2.Items.Add(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, nIdx, "거래량"));  // nIdx번째의 거래량 데이터 구함
                    listBox2.Items.Add(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, nIdx, "시가"));
                    listBox2.Items.Add(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, nIdx, "고가"));
                    listBox2.Items.Add(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, nIdx, "저가"));
                    listBox2.Items.Add(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, nIdx, "현재가"));
                }
            }


        }

        #endregion
        #region 차트 코드 

        #region 일봉 차트 관련 변수 선언 
        private class dayChart
        {
            public string 일자 { get; set; }
            public int 싯가 { get; set; }
            public int 곳가 { get; set; }
            public int 젓가 { get; set; }
            public int 종가 { get; set; }
            public int 거래량 { get; set; }
        }
        #endregion
        // 이동평균 계산 함수
        private List<double> CalculateMovingAverage(List<double> prices, int period)
        {
            List<double> movingAverages = new List<double>();

            for (int i = 0; i < prices.Count; i++)
            {
                if (i + 1 < period)
                {
                    movingAverages.Add(double.NaN);  // 초기 데이터가 부족할 때는 NaN 값 사용
                }
                else
                {
                    double sum = 0;
                    for (int j = i; j > i - period; j--)
                    {
                        sum += prices[j];
                    }
                    movingAverages.Add(sum / period);
                }
            }

            return movingAverages;
        }

        // 골든 크로스 탐지 함수
        private List<int> DetectGoldenCross(List<double> shortTermMA, List<double> longTermMA)
        {
            List<int> goldenCrossPoints = new List<int>();

            for (int i = 1; i < shortTermMA.Count; i++)
            {
                if (!double.IsNaN(shortTermMA[i]) && !double.IsNaN(longTermMA[i]) &&
                    shortTermMA[i - 1] < longTermMA[i - 1] && shortTermMA[i] > longTermMA[i])
                {
                    goldenCrossPoints.Add(i);  // 골든 크로스가 발생한 지점 저장
                }
            }

            return goldenCrossPoints;
        }
        private void DisplayMovingAveragesAndGoldenCross()
        {
            List<double> prices = priceInfoList.Select(p => (double)p.종가).ToList();  // 종가 데이터를 가져옴

            // 5일 및 20일 이동평균 계산
            List<double> shortTermMA = CalculateMovingAverage(prices, 5);  // 단기 이동평균: 5일
            List<double> longTermMA = CalculateMovingAverage(prices, 20);  // 장기 이동평균: 20일

            // 골든 크로스 탐지
            List<int> goldenCrossPoints = DetectGoldenCross(shortTermMA, longTermMA);

            // 이동평균선을 차트에 추가
            Series shortTermSeries = new Series("5일 이동평균")
            {
                ChartType = SeriesChartType.Line,
                Color = Color.Gold,
                BorderWidth = 2
            };

            Series longTermSeries = new Series("20일 이동평균")
            {
                ChartType = SeriesChartType.Line,
                Color = Color.Blue,
                BorderWidth = 2
            };

            for (int i = 0; i < prices.Count; i++)
            {
                shortTermSeries.Points.AddXY(priceInfoList[i].일자, shortTermMA[i]);
                longTermSeries.Points.AddXY(priceInfoList[i].일자, longTermMA[i]);
            }

            // 차트에 시리즈 추가
            daychart.Series.Add(shortTermSeries);
            daychart.Series.Add(longTermSeries);

            // 골든 크로스 지점에 마커 추가
            foreach (int pointIndex in goldenCrossPoints)
            {
                DataPoint goldenCrossPoint = new DataPoint();
                goldenCrossPoint.SetValueXY(priceInfoList[pointIndex].일자, shortTermMA[pointIndex]);
                goldenCrossPoint.MarkerStyle = MarkerStyle.Circle;
                goldenCrossPoint.MarkerSize = 10;
                goldenCrossPoint.MarkerColor = Color.Red;
                goldenCrossPoint.Label = "골든 크로스";  // 마커에 레이블 표시
                daychart.Series[0].Points.Add(goldenCrossPoint);  // 기존 시리즈에 추가
            }

            daychart.Invalidate();  // 차트 갱신
        }
        // daychart_AxisViewChanged 크기가 변경되면 이벤트가 작동하는 함수 
        private void daychart_AxisViewChanged(object sender, System.Windows.Forms.DataVisualization.Charting.ViewEventArgs e)
        {
            if (e.Axis.ScaleView.IsZoomed)
            {
                int startPosition = (int)e.Axis.ScaleView.ViewMinimum;
                int endPosition = (int)e.Axis.ScaleView.ViewMaximum;

                // 범위에 맞게 차트 다시 그리기
                UpdateChart(startPosition, endPosition);
            }
            /*
            if (sender.Equals(daychart))
            {
                int startPosition = (int)e.Axis.ScaleView.ViewMinimum;
                int endPosition = (int)e.Axis.ScaleView.ViewMaximum;
                Debug.WriteLine("값 확인 start, end :" + startPosition, endPosition);
                int max = (int)e.ChartArea.AxisY.ScaleView.ViewMinimum;
                int min = (int)e.ChartArea.AxisY.ScaleView.ViewMaximum;

                for (int i = startPosition - 1; i < endPosition; i++)
                {
                    if (i >= priceInfoList.Count)
                        break;
                    if (i < 0)
                        i = 0;

                    if (priceInfoList[i].곳가 > max)
                        max = priceInfoList[i].곳가;
                    if (priceInfoList[i].젓가 < min)
                        min = priceInfoList[i].젓가;
                }

                this.daychart.ChartAreas[0].AxisY.Maximum = max;
                this.daychart.ChartAreas[0].AxisY.Minimum = min;
            }*/
        }
        private void ConfigureChartScroll()
        {
            // X축 및 Y축 ScrollBar 설정
            daychart.ChartAreas[0].AxisX.ScrollBar.Enabled = true;
            daychart.ChartAreas[0].AxisY.ScrollBar.Enabled = true;

            // 전체 데이터 범위를 표시하도록 축 범위 설정
            daychart.ChartAreas[0].AxisX.Minimum = 0;  // X축 최소값
            daychart.ChartAreas[0].AxisX.Maximum = priceInfoList.Count - 1;  // X축 최대값은 데이터 수에 맞춤

            daychart.ChartAreas[0].AxisY.Minimum = priceInfoList.Min(p => p.젓가);  // Y축 최소값은 저가에 맞춤
            daychart.ChartAreas[0].AxisY.Maximum = priceInfoList.Max(p => p.곳가);  // Y축 최대값은 고가에 맞춤

            // X축 및 Y축의 Zoom 가능한 영역 설정
            daychart.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            daychart.ChartAreas[0].AxisY.ScaleView.Zoomable = true;

            // X축 Zoom을 시작할 때 보여줄 크기 설정 (ex: 30개의 데이터를 보여줌)
            daychart.ChartAreas[0].AxisX.ScaleView.Size = 30; // 한 번에 볼 데이터 수
            daychart.ChartAreas[0].AxisX.ScaleView.Position = priceInfoList.Count - 30; // 가장 마지막부터 보여줌
        }

        private void daychart_MouseWheel(object sender, MouseEventArgs e) 
        {
            double zoomFactor = 2.0;
            if (e.Delta > 0)  // 확대 시
            {
                double viewMin = daychart.ChartAreas[0].AxisX.ScaleView.ViewMinimum;
                double viewMax = daychart.ChartAreas[0].AxisX.ScaleView.ViewMaximum;

                double zoomSize = (viewMax - viewMin) / zoomFactor;
                double newMin = viewMin + (zoomSize / 2);
                double newMax = viewMax - (zoomSize / 2);

                // Zoom 범위가 너무 작아지지 않도록 제한
                if (newMax - newMin >= 5)  // 최소 5개의 데이터를 볼 수 있도록 제한
                {
                    daychart.ChartAreas[0].AxisX.ScaleView.Zoom(newMin, newMax);
                }
            }
            else if (e.Delta < 0)  // 축소 시
            {
                // 축소 시 범위가 전체 데이터 범위를 넘어가지 않도록 설정
                daychart.ChartAreas[0].AxisX.ScaleView.ZoomReset();
            }

            // 줌된 영역에 맞춰 차트 업데이트
            int startPosition = (int)daychart.ChartAreas[0].AxisX.ScaleView.ViewMinimum;
            int endPosition = (int)daychart.ChartAreas[0].AxisX.ScaleView.ViewMaximum;
            UpdateChart(startPosition, endPosition);
            //DisplayMovingAveragesAndGoldenCross();  // 골든 크로스 표시
            /* 버전 2 
            double zoomFactor = 2.0;
            if (e.Delta > 0)  // 확대 시
            {
                double viewMin = daychart.ChartAreas[0].AxisX.ScaleView.ViewMinimum;
                double viewMax = daychart.ChartAreas[0].AxisX.ScaleView.ViewMaximum;

                double zoomSize = (viewMax - viewMin) / zoomFactor;
                double newMin = viewMin + (zoomSize / 2);
                double newMax = viewMax - (zoomSize / 2);

                daychart.ChartAreas[0].AxisX.ScaleView.Zoom(newMin, newMax);
            }
            else if (e.Delta < 0)  // 축소 시
            {
                daychart.ChartAreas[0].AxisX.ScaleView.ZoomReset();
            }

            // 줌된 영역에 맞춰 차트 업데이트
            int startPosition = (int)daychart.ChartAreas[0].AxisX.ScaleView.ViewMinimum;
            int endPosition = (int)daychart.ChartAreas[0].AxisX.ScaleView.ViewMaximum;
            UpdateChart(startPosition, endPosition); */
            ///<summary >
            ///
            /// 이전 코드 내용이므로 굳이 필요없고 위에 코드로 차트 구현 오류 수정 완료 
            /// </summary>
            // 줌관련 이벤트 적용중인데 현재 적용됨 초기 코드도 작동이 되지만 문제는 새로 그림을그리지 못해서 수정 
            /*double zoomFactor = 2.0;
            Debug.WriteLine("휠 이벤트"+(daychart.ChartAreas[0].AxisX.ScaleView.IsZoomed || daychart.ChartAreas[0].AxisY.ScaleView.IsZoomed));
            

            Debug.WriteLine("IsZoomed: " + daychart.ChartAreas[0].AxisX.ScaleView.IsZoomed);
            Debug.WriteLine("Zoomable: " + daychart.ChartAreas[0].AxisX.ScaleView.Zoomable);
            if (e.Delta < 0)  // 축소 시
            {
                daychart.ChartAreas[0].AxisX.ScaleView.ZoomReset();
                daychart.ChartAreas[0].AxisY.ScaleView.ZoomReset();
            }
            else  // 확대 시
            {
                double xMin = daychart.ChartAreas[0].AxisX.ScaleView.ViewMinimum;
                double xMax = daychart.ChartAreas[0].AxisX.ScaleView.ViewMaximum;

                daychart.ChartAreas[0].AxisX.ScaleView.Zoom(xMin, xMax / zoomFactor);

                double yMin = daychart.ChartAreas[0].AxisY.ScaleView.ViewMinimum;
                double yMax = daychart.ChartAreas[0].AxisY.ScaleView.ViewMaximum;

                daychart.ChartAreas[0].AxisY.ScaleView.Zoom(yMin, yMax / zoomFactor);
            }

            // 차트 다시 그리기
            daychart.Invalidate();*/
        }
        private void UpdateChart(int startPosition, int endPosition)
        {
            daychart.Series["Series1"].Points.Clear();  // 차트 초기화
            daychart.Series["Series1"]["PriceUpColor"] = "Red";   // 상승 시 빨간색
            daychart.Series["Series1"]["PriceDownColor"] = "Blue"; // 하락 시 파란색

            for (int i = startPosition; i < endPosition; i++)
            {
                if (i >= priceInfoList.Count)
                    break;

                // 고가, 저가, 시가, 종가 추가
                daychart.Series["Series1"].Points.AddXY(priceInfoList[i].일자, priceInfoList[i].곳가);
                daychart.Series["Series1"].Points[daychart.Series["Series1"].Points.Count - 1].YValues[1] = priceInfoList[i].젓가;
                daychart.Series["Series1"].Points[daychart.Series["Series1"].Points.Count - 1].YValues[2] = priceInfoList[i].싯가;
                daychart.Series["Series1"].Points[daychart.Series["Series1"].Points.Count - 1].YValues[3] = priceInfoList[i].종가;

                // 상승/하락에 따른 색상 적용
                
                /*
                if (priceInfoList[i].싯가 < priceInfoList[i].종가)
                {
                    daychart.Series["Series1"].Points[daychart.Series["Series1"].Points.Count - 1].Color = Color.Red;  // 상승 시 빨간색
                }
                else
                {
                    daychart.Series["Series1"].Points[daychart.Series["Series1"].Points.Count - 1].Color = Color.Blue;  // 하락 시 파란색
                    
                }
                */
            }

            daychart.Invalidate();  // 차트 갱신
        }

        // 차트 일봉 데이터 마우스 커서 관련 구현 
        private ToolTip chartToolTip = new ToolTip();
        private void daychart_MouseMove(object sender, MouseEventArgs e)
        {
            HitTestResult result = daychart.HitTest(e.X, e.Y);

            // 해당 위치에 데이터 포인트가 있는 경우
            if (result.ChartElementType == ChartElementType.DataPoint)
            {
                DataPoint point = daychart.Series["Series1"].Points[result.PointIndex];
                int index = result.PointIndex;

                // 해당 데이터 포인트의 정보를 가져옵니다.
                string date = priceInfoList[index].일자;
                int open = priceInfoList[index].싯가;
                int high = priceInfoList[index].곳가;
                int low = priceInfoList[index].젓가;
                int close = priceInfoList[index].종가;
                int trade = priceInfoList[index].거래량;
                // 툴팁에 표시할 내용을 설정합니다.
                string toolTipText = $"일자: {date}\n시가: {open}\n고가: {high}\n저가: {low}\n종가: {close}";

                // 마우스 위치에 툴팁을 보여줍니다.
                chartToolTip.Show(toolTipText, this.daychart, e.X + 15, e.Y - 15);
            }
            else
            {
                // 마우스가 데이터 포인트 밖에 있으면 툴팁을 숨깁니다.
                chartToolTip.Hide(this.daychart);
            }
        }
        private void InitializeChart()
        {
            // 차트 초기 설정
            daychart.Series.Clear();

            // 시리즈 설정 (여기서는 실시간 데이터를 라인 차트로 그립니다)
            Series series = new Series("실시간 현재가")
            {
                ChartType = SeriesChartType.Line,
                BorderWidth = 2,
                Color = Color.Blue
            };

            daychart.Series.Add(series);

            // 차트 축 설정
            daychart.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;
            daychart.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;

            // 차트 Y축 자동 크기 조정
            daychart.ChartAreas[0].AxisY.IsStartedFromZero = false;
            daychart.ChartAreas[0].AxisY.Minimum = Double.NaN;
            daychart.ChartAreas[0].AxisY.Maximum = Double.NaN;

            // 차트 X축 스크롤바 설정
            daychart.ChartAreas[0].AxisX.ScrollBar.Enabled = true;
            daychart.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            daychart.ChartAreas[0].AxisX.ScaleView.Size = 30; // 보여줄 데이터의 개수
        }
        #endregion
        #region 일봉
        #region 일봉 조회 클릭 버튼 
        private void DayButton_Click(object sender, EventArgs e)
        {

            // 현재 하루만 당겨오는이유가 뭘까? 
            axKHOpenAPI1.SetInputValue("종목코드", textBox1.Text.Trim());
            axKHOpenAPI1.SetInputValue("기준일자", daytxt.Text.Trim()); // 공란시 오늘날짜로 들어감 
            //axKHOpenAPI1.SetInputValue("기준일자",DateTime.Now.ToString("yyyymmdd"));
            // 자동화 할려다 현재 잠시 에러 
            // 기준일자는 20240902 처럼 가야한다 
            axKHOpenAPI1.SetInputValue("수정주가구분", "1");
            int nRet = axKHOpenAPI1.CommRqData("주식일봉차트조회", "OPT10081", 0, "1002");
            

            // <!--
            // 실패한코드 
            //string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            //string newFileName = System.IO.Path.Combine(desktopPath, "[" + textBox1.Text.Trim() + "] " + label3.Text + "-" + daytxt.Text.Trim() + "-일봉.csv");
            // 아마 원드라이브 때문에 에러가 나는거일수도? 
            // -->

            // <summary> 현재 C로 잡아놔서 관리자 권한으로 실행해야 에러가 안남 > 수정해서 관리자 안해도됨 
            // 파일 만드는건 해놨는데 굳이 필요없는거 같아서 주석처리 
            //string newFileName = @"C:\Users\ms_cr\OneDrive\Desktop\[" + textBox1.Text.Trim() + "] " + label3.Text + "-" + daytxt.Text.Trim() + "-일봉.csv";
            //string directory = System.IO.Path.GetDirectoryName(newFileName);
            //if (!System.IO.Directory.Exists(directory))
            //{
            //    System.IO.Directory.CreateDirectory(directory);            
            //}
            //string title = "Date" + "," + "Open" + "," + "High" + "," + "Low" + "," + "Close" + "," + "Volume" + Environment.NewLine;
            //System.IO.File.WriteAllText(newFileName, title);
            // --- 여기까지가 파일만들어주는것 </summary>
            axKHOpenAPI1.OnReceiveTrData += OnReceiveTrDataDaychart;
            //UpdateChart();
            priceInfoList = new List<dayChart>();
        }
        
         
        private void OnReceiveTrDataDaychart(object sender, AxKHOpenAPILib._DKHOpenAPIEvents_OnReceiveTrDataEvent e)
        {
            // 이거 코드 해결한게 (e.sRQName == "주식일봉차트조회") 이게 원래 코드였는데 
            // 값이 제대로 오는지 보는 디버깅 
            //Debug.WriteLine("e.sRQName: " + e.sRQName);
            
            Debug.WriteLine("일봉 차트 리시브 sTrCode: " + e.sTrCode);
            Debug.WriteLine("일봉 차트 리시브 sRQName: " + e.sRQName);
            Debug.WriteLine("일봉 차트 리시브 sScrNo: " + e.sScrNo);
            Debug.WriteLine("일봉 차트 리시브 sPrevNext: " + e.sPrevNext);
            
            if ("예수금상세현황".Equals(e.sRQName))
            {
                // 8084657111
                // 예수금 조회 응답 처리
                string 예수금 = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "예수금").Trim();
                long 예수금Value = long.Parse(예수금);  // 문자열을 정수형으로 변환
                string formatted예수금 = 예수금Value.ToString("N0");  // 다시 문자열로 변환하며, 쉼표를 추가
                string D2추정예수금 = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "D+2추정예수금").Trim();

                string 출금가능금액 = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "출금가능금액").Trim();
                long 출금가능금액Value = long.Parse(출금가능금액);
                string formatted출금가능예수금 = 출금가능금액Value.ToString("N0");
                // 데이터를 리스트박스에 출력
                listBox2.Items.Clear();
                listBox2.Items.Add($"예수금: {formatted예수금}");
                listBox2.Items.Add($"D+2 추정 예수금 : {D2추정예수금} ");
                listBox2.Items.Add($"출금가능금액 {formatted출금가능예수금}");

            }
            if ("계좌평가현황".Equals(e.sRQName))
            {
                string 실시간예수금 = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "유가잔고평가액").Trim();
                listBox2.Items.Add($"유가잔고평가액 : {실시간예수금}");
            }
            if ("주식일봉차트조회".Equals(e.sRQName))
            // 아래로 코드 변경후 작동이 됩니다 
            {
                Debug.WriteLine("주식일봉차트조회 처리 시작");

                int nCnt = axKHOpenAPI1.GetRepeatCnt(e.sRQName, e.sRQName);
                Debug.WriteLine($"수신된 데이터 개수: {nCnt}");
                // 현재 코드 수정으로 여기까지 오고 있음 이제 어떻게 해야 받을수있는지 해결해야함 아니지 0이 맞잖아? 
                daychart.Series["Series1"].Points.Clear();
                priceInfoList.Clear();
                for (int i = 0; i <= nCnt; i++)
                {
                    try
                    {
                        일체결일 = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, i, "일자").Trim();
                        Debug.WriteLine(일체결일);
                        일시가 = Math.Abs(int.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, i, "시가").Trim()));
                        일고가 = Math.Abs(int.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, i, "고가").Trim()));
                        일저가 = Math.Abs(int.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, i, "저가").Trim()));
                        일현재가 = Math.Abs(int.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, i, "현재가").Trim()));
                        일거래량 = Math.Abs(int.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, i, "거래량").Trim()));
                        //string newFileName = @"C:\Users\ms_cr\OneDrive\Desktop\[" + textBox1.Text.Trim() + "] " + label3.Text + "-" + daytxt.Text.Trim() + "-일봉.csv";
                        //System.IO.File.AppendAllText(newFileName, 체결일 + "," + 시가 + "," + 고가 + "," + 저가 + "," + 현재가 + "," + 거래량 + Environment.NewLine);
                        // 테스트용 코드 아래 작성 위 
                        //using (System.IO.StreamWriter sw = new System.IO.StreamWriter(newFileName, true)) // append 모드로 파일 열기
                        //{
                        //    sw.WriteLine(체결일 + "," + 시가 + "," + 고가 + "," + 저가 + "," + 현재가 + "," + 거래량);
                        //    Debug.WriteLine("테스트 :" + 시가);
                        // 해결함! 
                        //}

                        richTextBox1.Text += (
                            "체결일 : " + 일체결일
                            + "\n 시가 :" + 일시가
                            + "\n 고가 :" + 일고가
                            + "\n 저가 :" + 일저가
                            + "\n 현재가 :" + 일현재가
                            + "\n 거래량 :" + 일거래량
                            + Environment.NewLine);

                        // 차트 관련 크기 
                        // 차트를 30일까지 뽑아주는 코드 구현 완료 
                        for (int j = 0; j < 30; j++)
                        {
                            priceInfoList.Add(new dayChart()
                            {

                                일자 = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 30 - j, "일자").Trim().Substring(4),
                                싯가 = Int32.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 30 - j, "시가").Trim()),
                                곳가 = Int32.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 30 - j, "고가").Trim()),
                                젓가 = Int32.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 30 - j, "저가").Trim()),
                                종가 = Int32.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 30 - j, "현재가").Trim())

                            });
                            // 고가 
                            daychart.Series["Series1"].Points.AddXY(priceInfoList[j].일자, priceInfoList[j].곳가);
                            // 저가
                            daychart.Series["Series1"].Points[j].YValues[1] = priceInfoList[j].젓가;
                            // 시작가
                            daychart.Series["Series1"].Points[j].YValues[2] = priceInfoList[j].싯가;
                            // 마감가 
                            daychart.Series["Series1"].Points[j].YValues[3] = priceInfoList[j].종가;

                            foreach (var point in daychart.Series["Series1"].Points)
                            {
                                if (point.YValues[2] < point.YValues[3]) // 시가 < 종가, 상승
                                {
                                    point.Color = Color.Red;
                                }
                                else // 시가 >= 종가, 하락
                                {
                                    point.Color = Color.Blue;
                                }
                            }
                            ///<summary>
                            /// 디버그에서는 표착됨 차트값이 들어오나 
                            /// 너무 적은 데이터가 들어옴 
                            /// 해결
                            /// </summary>
                            //Debug.WriteLine("값 3 2 1 :" + daychart.Series["Series1"].Points[j].YValues[3] + "," + daychart.Series["Series1"].Points[j].YValues[2] + "," + daychart.Series["Series1"].Points[j].YValues[1]);
                            // 해결했음 정상적으로 들어옴 

                            // 색에러 

                            //Debug.WriteLine($"일자: {priceInfoList[j].일자}, 시가: {priceInfoList[j].싯가}, 고가: {priceInfoList[j].곳가}, 저가: {priceInfoList[j].젓가}, 종가: {priceInfoList[j].종가}");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("에러발생" + ex.Message);
                    }


                }
                daychart.Invalidate();
            }
            e.sTrCode = "";
            e.sRQName = "";

        }
        #endregion

        #endregion
        
        #endregion
        #region 현재 구동안되는 코드 



        /*

            if (e.sRQName == "계좌평가현황요청")
            {
                this.listBox2.Items.Add("예수금 = " + Int32.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "예수금").Trim()));
                this.listBox2.Items.Add("D+2추정예수금 = " + Int32.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "D+2추정예수금").Trim()));
                this.listBox2.Items.Add("유가잔고평가액 = " + Int32.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "유가잔고평가액").Trim()));
                this.listBox2.Items.Add("예탁자산평가액 = " + Int32.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "예탁자산평가액").Trim()));
                this.listBox2.Items.Add("총매입금액 = " + Int32.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "총매입금액").Trim()));
                this.listBox2.Items.Add("추정예탁자산 = " + Int32.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "추정예탁자산").Trim()));
                this.listBox2.Items.Add("당일투자원금 = " + Int32.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "당일투자원금").Trim()));
                this.listBox2.Items.Add("당월투자원금 = " + Int32.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "당월투자원금").Trim()));
                this.listBox2.Items.Add("누적투자원금 = " + Int32.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "누적투자원금").Trim()));
                this.listBox2.Items.Add("당일투자손익 = " + Int32.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "당일투자손익").Trim()));
                this.listBox2.Items.Add("당월투자손익 = " + Int32.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "당월투자손익").Trim()));
                this.listBox2.Items.Add("누적투자손익 = " + Int32.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "누적투자손익").Trim()));
                this.listBox2.Items.Add("당일손익율 = " + Int32.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "당일손익율").Trim()));
                this.listBox2.Items.Add("당월손익율 = " + Int32.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "당월손익율").Trim()));
                this.listBox2.Items.Add("누적손익율 = " + Int32.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "누적손익율").Trim()));

                int nCnt = axKHOpenAPI1.GetRepeatCnt(e.sTrCode, e.sRQName);
                for (int nIdx = 0; nIdx < nCnt; nIdx++)
                {
                    this.listBox2.Items.Add("종목명 = " + axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, nIdx, "종목명").Trim());
                    this.listBox2.Items.Add("종목코드 = " + axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, nIdx, "종목코드").Trim());
                    this.listBox2.Items.Add("보유수량 = " + Int32.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "보유수량").Trim()));
                    this.listBox2.Items.Add("현재가 = " + Int32.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "현재가").Trim()));
                    this.listBox2.Items.Add("평가금액 = " + Int32.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "평가금액").Trim()));
                    this.listBox2.Items.Add("손익금액 = " + Int32.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "손익금액").Trim()));
                    this.listBox2.Items.Add("손익율 = " + axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "손익율").Trim());
                    this.listBox2.Items.Add("매입금액 = " + Int32.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "매입금액").Trim()));
                    this.listBox2.Items.Add("결제잔고 = " + Int32.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "결제잔고").Trim()));
                    this.listBox2.Items.Add("금일매수수량 = " + Int32.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "금일매수수량").Trim()));
                    this.listBox2.Items.Add("금일매도수량 = " + Int32.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "금일매도수량").Trim()));
                }
            }

            
        */
        /*
                    if ("예수금상세현황요청".Equals(e.sRQName))
            {
                Debug.WriteLine("정상화를해 ");
                //listBox2.Items.Add("코스피 지수 : " + axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName,0,"종목명").Trim());
                /*
                //this.listBox2.Items.Add("예수금 = " + Int32.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "예수금").Trim()));
                this.listBox2.Items.Add("D+2추정예수금 = " + Int32.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "D+2추정예수금").Trim()));
                this.listBox2.Items.Add("유가잔고평가액 = " + Int32.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "유가잔고평가액").Trim()));
                this.listBox2.Items.Add("예탁자산평가액 = " + Int32.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "예탁자산평가액").Trim()));
                this.listBox2.Items.Add("총매입금액 = " + Int32.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "총매입금액").Trim()));
                this.listBox2.Items.Add("추정예탁자산 = " + Int32.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "추정예탁자산").Trim()));
                this.listBox2.Items.Add("당일투자원금 = " + Int32.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "당일투자원금").Trim()));
                this.listBox2.Items.Add("당월투자원금 = " + Int32.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "당월투자원금").Trim()));
                this.listBox2.Items.Add("누적투자원금 = " + Int32.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "누적투자원금").Trim()));
                this.listBox2.Items.Add("당일투자손익 = " + Int32.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "당일투자손익").Trim()));
                this.listBox2.Items.Add("당월투자손익 = " + Int32.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "당월투자손익").Trim()));
                this.listBox2.Items.Add("누적투자손익 = " + Int32.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "누적투자손익").Trim()));
                this.listBox2.Items.Add("당일손익율 = " + Int32.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "당일손익율").Trim()));
                this.listBox2.Items.Add("당월손익율 = " + Int32.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "당월손익율").Trim()));
                this.listBox2.Items.Add("누적손익율 = " + Int32.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "누적손익율").Trim()));

                int nCnt = axKHOpenAPI1.GetRepeatCnt(e.sTrCode, e.sRQName);
                Debug.WriteLine("데이터 확인 : " + nCnt);
                for (int nIdx = 0; nIdx < nCnt; nIdx++)
                {
                    this.listBox2.Items.Add("종목명 = " + axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, nIdx, "종목명").Trim());
                    this.listBox2.Items.Add("종목코드 = " + axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, nIdx, "종목코드").Trim());
                    this.listBox2.Items.Add("보유수량 = " + Int32.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "보유수량").Trim()));
                    this.listBox2.Items.Add("현재가 = " + Int32.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "현재가").Trim()));
                    this.listBox2.Items.Add("평가금액 = " + Int32.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "평가금액").Trim()));
                    this.listBox2.Items.Add("손익금액 = " + Int32.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "손익금액").Trim()));
                    this.listBox2.Items.Add("손익율 = " + axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "손익율").Trim());
                    this.listBox2.Items.Add("매입금액 = " + Int32.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "매입금액").Trim()));
                    this.listBox2.Items.Add("결제잔고 = " + Int32.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "결제잔고").Trim()));
                    this.listBox2.Items.Add("금일매수수량 = " + Int32.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "금일매수수량").Trim()));
                    this.listBox2.Items.Add("금일매도수량 = " + Int32.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "금일매도수량").Trim()));
                }
                
            }*/
    #endregion
        #region 실시간 데이터 오후4시이후 조회 안됨 
        private void axKHOpenAPI_OnReceiveRealData(object sender, AxKHOpenAPILib._DKHOpenAPIEvents_OnReceiveRealDataEvent e)
        {

            //listBox1.Items.Clear();
            // 잘오고있고 디버그 로그 찍기 힘드니 주석처리 
            // Debug.WriteLine("OnRealTime");
            //listBox1.Items.Add(textBox1.Text.Trim());
            // 텍스트박스의 값을 주고 나니 정상적으로 출력중  실시간 속도가 너무 빠른거같음 
            //("주식체결".Equals(e.sRealType))
            // 실시간으로 데이터가 오니까 실시간안될때는 작동안되는게 맞음 
            Debug.Write("11" + e.sRealType);
                listBox1.Items.Add(e.sRealType);
                listBox1.Items.Add(e.sRealData);
                if  (e.sRealType == "주식체결")
                {
                    //richTextBox1.Text += axKHOpenAPI1.GetCommRealData(e.sRealType, 10).Trim();
                // 실시간 데이터 받아오게하는 데이터를 목록 
                    listBox1.Items.Add("------------------------------------------------------------------"); 
                    this.listBox1.Items.Add($"현재가 : { axKHOpenAPI1.GetCommRealData(e.sRealType, 10).Trim().Substring(1)}");
                    this.listBox1.Items.Add($"전일대비 : {axKHOpenAPI1.GetCommRealData(e.sRealType, 11).Trim()}");
                    this.listBox1.Items.Add($"등락율 : {axKHOpenAPI1.GetCommRealData(e.sRealType, 12).Trim()}");
                    this.listBox1.Items.Add("누적거래량 : " + axKHOpenAPI1.GetCommRealData(e.sRealType, 13).Trim().Substring(1));
                    // 이렇게 불러도되니까 꼭 $로 안불러도된다 
                    this.listBox1.Items.Add($"누적거래대금 : {axKHOpenAPI1.GetCommRealData(e.sRealType, 14).Trim().Substring(1)}");
                    this.listBox1.Items.Add($"시가 : {axKHOpenAPI1.GetCommRealData(e.sRealType, 16).Trim().Substring(1)}");
                    this.listBox1.Items.Add($"고가 : {axKHOpenAPI1.GetCommRealData(e.sRealType, 17).Trim().Substring(1)}");
                    this.listBox1.Items.Add($"저가 : {axKHOpenAPI1.GetCommRealData(e.sRealType, 18).Trim().Substring(1)}");
                    this.listBox1.Items.Add($"전일대비기호 : {axKHOpenAPI1.GetCommRealData(e.sRealType, 25).Trim().Substring(1)}");
                    this.listBox1.Items.Add($"전일거래량대비(계약,주) : {axKHOpenAPI1.GetCommRealData(e.sRealType, 26).Trim().Substring(1)}");
                    this.listBox1.Items.Add($"거래대금증감 : {axKHOpenAPI1.GetCommRealData(e.sRealType, 29).Trim().Substring(1)}");
                    this.listBox1.Items.Add($"전일거래량대비(비율) : {axKHOpenAPI1.GetCommRealData(e.sRealType, 30).Trim().Substring(1)}");
                    listBox1.Items.Add("------------------------------------------------------------------");
                    int maxItems = 100; // 최대 리스트박스 크기 설정 
                    if (listBox1.Items.Count > maxItems)
                    {
                        listBox1.Items.RemoveAt(0); // 가장 오래된 항목 삭제 
                    }
                    // 마지막 스크롤로 fouse 
                    listBox1.SelectedIndex = listBox1.Items.Count - 1;
                    listBox1.TopIndex = listBox1.SelectedIndex;
                    listBox1.TabIndex = listBox1.SelectedIndex + 1;
                
                }
            
        }
    
        
        #endregion
    }
}
