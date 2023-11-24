using Microsoft.VisualBasic.Logging;

namespace POS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            listView1.View = View.Details;
            listView1.GridLines = true;
        }

        private void button_Click(object sender, EventArgs e)
        {
            // 다중 이벤트를 선언했기때문에 sender as 통해 이벤트를 받고 Button에 연결
            // 그래서 버튼을 누르면 버튼의 텍스트를 볼수있음 
            Button? button = sender as Button;
            textBox1.Text += button.Text;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void menu_Click(object sender, EventArgs e)
        {
            Button? button = sender as Button;
            ListViewItem? listViewItem = new ListViewItem();
            
            listViewItem.SubItems.Add(button.Text.Substring(0,7));
            // 금액은 표시하지 않도록 표현 > 0~7 의 인덱스만 표현되기때문에 금액이 나오지않는다

            string buwon ="";
            // string을 int 값만 들고오기위한 코드
            for (int i = 0; i < button.Text.Length; i++)
            {
                char ch = button.Text[i];
                if('0' <= ch && ch <= '9')
                {
                    buwon += ch;
                }
            }
            listViewItem.SubItems.Add(buwon);
            // 같은 걸 선택하면 수량이 가산되도록 
            // 금액은 지정값 * n 

            
        }
    }
}
