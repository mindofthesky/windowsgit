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
            // ���� �̺�Ʈ�� �����߱⶧���� sender as ���� �̺�Ʈ�� �ް� Button�� ����
            // �׷��� ��ư�� ������ ��ư�� �ؽ�Ʈ�� �������� 
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
            // �ݾ��� ǥ������ �ʵ��� ǥ�� > 0~7 �� �ε����� ǥ���Ǳ⶧���� �ݾ��� �������ʴ´�

            string buwon ="";
            // string�� int ���� ���������� �ڵ�
            for (int i = 0; i < button.Text.Length; i++)
            {
                char ch = button.Text[i];
                if('0' <= ch && ch <= '9')
                {
                    buwon += ch;
                }
            }
            listViewItem.SubItems.Add(buwon);
            // ���� �� �����ϸ� ������ ����ǵ��� 
            // �ݾ��� ������ * n 

            
        }
    }
}
