namespace POS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            listView1.View= View.Details;
        }

        private void button_Click(object sender, EventArgs e)
        {
            // 다중 이벤트를 선언했기때문에 sender as 통해 이벤트를 받고 Button에 연결
            // 그래서 버튼을 누르면 버튼의 텍스트를 볼수있음 
            Button button = sender as Button;
            textBox1.Text += button.Text;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }
    }
}
