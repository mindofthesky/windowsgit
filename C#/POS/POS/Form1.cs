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
            // ���� �̺�Ʈ�� �����߱⶧���� sender as ���� �̺�Ʈ�� �ް� Button�� ����
            // �׷��� ��ư�� ������ ��ư�� �ؽ�Ʈ�� �������� 
            Button button = sender as Button;
            textBox1.Text += button.Text;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }
    }
}
