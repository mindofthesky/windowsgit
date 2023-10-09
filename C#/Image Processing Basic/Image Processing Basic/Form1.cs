using OpenCvSharp;
using OpenCvSharp.Dnn;
using System.Drawing.Drawing2D;

namespace Image_Processing_Basic
{
    // �ڵ� ���� https://www.youtube.com/watch?v=33szl_pkSzo&ab_channel=%EC%B4%88%EB%94%A9YouTube
    public partial class Form1 : Form
    {
        string FileName = "";
        Net net;
        public Form1()
        {
            InitializeComponent();
            MessageBox.Show(Application.StartupPath);
        }
        private void yolotest()
        {
            string cfg_Path = Application.StartupPath + @"\";  //���ϰ�θ�  �ָ� �ذ� ����
            string model_path = Application.StartupPath + @"\"; //���ϰ�θ�  �ָ� �ذ� ����
            Net net = CvDnn.ReadNetFromDarknet("cfg", "model");

            net.SetPreferableBackend((Backend)3);

            net.SetPreferableTarget((Target)2);
        }
        public void yolostart()
        {
            Mat blob = CvDnn.BlobFromImage(new Mat(FileName),1.0/ 2 / 255, new OpenCvSharp.Size(416,416) ,new Scalar() , true, false);
            // Mat�Է� ���� �� ���� ó�� 
            // 1.0 / 255 �ȼ����� ���� ó�� �ȼ� ��Ʈ�������� �ʹ��������� ��� ����� ���ƸԾ cpu���ϰ� �ðŰ�����?

           net.SetInput(blob);

            var outName = net.GetUnconnectedOutLayers();
            var outs = outName.Select(_ => new Mat()).ToArray();

            net.Forward(outs, outName);
        }
        private static void GetResult(Mat[] outs, bool nms, PictureBox pictureBox1, Image image, RichTextBox richTextBox1, bool morethreshold = true)
        {
            float threshold = 0.1f;//��Ȯ�� 0~ 1
            float nmsThreshold = 0.1f;//���� ��ġ�� �� �����ۿ�

            try
            {
                if (outs != null)
                {

                    List<int> classed = new List<int>();//�ش� ��ü�� ��������
                    List<float> confidences = new List<float>();//��ü ��Ȯ��
                    List<float> probilities = new List<float>();//��Ȯ��
                    List<Rect2d> boxes = new List<Rect2d>();//�ڽ� �׸��� 
                    //IEnumerable �� ����� ���ǿ� ���� ���� �ݺ��ϰ� �ϴµ� ���δ�. �� �ܺ� Mat �������� �迭�� �ݺ��ϴµ� ����.
                    int w = 0;
                    int h = 0;

                    if (image != null)
                    {
                        pictureBox1.Image = image;
                        w = image.Width;//�̹����� ���� ���� ���
                        h = image.Height;//�̹����� ���� ���� ���
                    }
                    else
                    {
                        w = pictureBox1.Image.Width;//�̹����� ���� ���� ���
                        h = pictureBox1.Image.Height;//�̹����� ���� ���� ���
                    }

                    const int prefix = 5; //134�� �ٿ� ��������
                                          //const 2Ʈ°���� ���� ���̴�. ���� �Ұ�
                                          // int classnumber = -1;

                    richTextBox1.Text = "";
                    foreach (Mat mat in outs)
                    {

                        // classnumber++;
                        // richTextBox1.AppendText(classnumber.ToString());
                        //foreach�� for ������  output�� �迭 ���� ��ŭ �����鼭 �ش� ī��Ʈ�� Mat�� Mat count ����.
                        //���� ��� ù��° ������ Mat mat = output[0], �ι�°��  Mat mat = output[1] �̷������� ���ư���.
                        for (int i = 0; i < mat.Rows; i++)
                        {
                            float confidence = mat.At<float>(i, 4);//�ش� ��ü�� ��Ȯ�� ���
                            if (confidence > threshold)
                            { //confidence�� ���� threshold(0.5)���� ������
                                Cv2.MinMaxLoc(mat.Row(i).ColRange(prefix, mat.Cols), out _, out OpenCvSharp.Point max);
                                int classes = max.X;//�߰��� Ŭ������ �ѹ� ��.
                                float probability = mat.At<float>(i, classes + prefix);//5��° ���ĺ��� �˻��� Ŭ������ Ȯ���̱� ������ 5�� ���Ѵ�.  
                                if (probability > threshold)
                                {
                                    //mat �� �迭�� ���� ���ִ� ���� �ٸ�. 
                                    //0�� �̹����� �߾� x�� ��ġ ������
                                    //1 �� �̹����� �߾� y�� ��ġ ������
                                    //2 �� ��ü ������ ���� ����(w)
                                    //3 �� ��ü ������ ���� ����(h)
                                    //4 �� ��ü�� ��Ȯ�� 0~ 1���̷� ���.
                                    //5 �̻� ���ʹ� ���� Ŭ���� �ڽ� Ȯ���� ����,

                                    float centerX = mat.At<float>(i, 0) * w;
                                    float centerY = mat.At<float>(i, 1) * h;
                                    float width = mat.At<float>(i, 2) * w;
                                    float height = mat.At<float>(i, 3) * h;
                                    //richTextBox1.AppendText(i.ToString() + " "+ classes.ToString() + Label[classes] +" " +mat.At<float>(i, classes+1 + prefix).ToString() + "%��\n");
                                    //�׸��� �۾���
                                    //image �� ���������� �߾� ��ġ, ���� ���� ���� ������
                                    classed.Add(classes);
                                    confidences.Add(confidence);
                                    probilities.Add(probability);
                                    boxes.Add(new Rect2d(centerX, centerY, width, height));

                                }
                            }


                        }
                    }
                    if (boxes.Count == 0)
                    {

                        if (richTextBox1.Text != "�������� ����\n") richTextBox1.Text = "�������� ����\n";
                    }
                    else if (nms)
                    {
                        CvDnn.NMSBoxes(boxes, confidences, threshold, nmsThreshold, out int[] indices);
                        foreach (int i in indices)
                        {
                            Rect2d box = boxes[i];
                            richTextBox1.AppendText($"{Label[classed[i]]} {probilities[i] * 100:0.0}%\n");
                            richTextBox1.AppendText("x,y = " + ((int)box.X).ToString() + "/" + ((int)box.Y).ToString() + "\n" + "w,h = " + ((int)box.Width).ToString() + "/" + ((int)box.Height).ToString() + "\n\n");
                            Draw(classed[i], probilities[i], (float)box.X, (float)box.Y, (float)box.Width, (float)box.Height, pictureBox1);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < boxes.Count; i++)
                        {
                            Rect2d box = boxes[i];
                            richTextBox1.AppendText($"{Label[classed[i]]} {probilities[i] * 100:0.0}% \n"); ;
                            richTextBox1.AppendText(((int)box.X).ToString() + "/" + ((int)box.Y).ToString() + "\n" + ((int)box.Width).ToString() + "/" + ((int)box.Height).ToString() + "\n\n");
                            Draw(classed[i], probilities[i], (float)box.X, (float)box.Y, (float)box.Width, (float)box.Height, pictureBox1);
                        }
                    }
                }

            }
            catch
            {
                richTextBox1.AppendText("GetResult ������ ����");
            }
        }

        //Deaw �� 

        private static void Draw(int classes, float probability, float centerX, float centerY, float width, float height, PictureBox pictureBox1)
        {
            string text = $"{Label[classes]} ({probability * 100:0.0}%)";
            //https://bananamandoo.tistory.com/30 ���� ����Ʈ ���� ������ �Ҽ��� ���ڸ� ���ڸ� ��Ÿ���ڴٴ� ��
            float x = centerX - width / 2;//�߾������� ������ ���� ����� �׸��� ���� ���� ����Ʈ�� ��
            float y = centerY - height / 2;//�߾������� ������ ���� ����� �׸��� ���� ���� ����Ʈ�� ��

            using (Graphics thumbnailGraphic = Graphics.FromImage(pictureBox1.Image))//�׸��� ��ȭ���� pictureBox1.Image�� ����
            {
                thumbnailGraphic.CompositingQuality = CompositingQuality.HighQuality;
                thumbnailGraphic.SmoothingMode = SmoothingMode.HighQuality;
                thumbnailGraphic.InterpolationMode = InterpolationMode.HighQualityBicubic;

                // Define Text Options
                Font drawFont = new Font("Arial", 12, FontStyle.Bold);//��Ʈ�� Arial �� ũ��� 12, ����� ����
                SizeF size = thumbnailGraphic.MeasureString(text, drawFont);
                SolidBrush fontBrush = new SolidBrush(Color.Black);
                System.Drawing.Point atPoint = new System.Drawing.Point((int)x, (int)y - (int)size.Height - 1); ;
                // Define BoundingBox options
                Pen pen = new Pen(color[classes], 3.2f);//color[classes] 151 ��° ���� ���� �ش� ��ü���� �����ִ� ���� ���� 
                SolidBrush colorBrush = new SolidBrush(color[classes]);//color[classes] 151 ��° ���� ���� �ش� ��ü���� �����ִ� ���� ���� 

                thumbnailGraphic.FillRectangle(colorBrush, (int)x, (int)(y - size.Height - 1), (int)size.Width, (int)size.Height);
                //�簢�� �׸���
                thumbnailGraphic.DrawString(text, drawFont, fontBrush, atPoint);
                //�ش� ��ü ���� �׸���

                // Draw bounding box on image
                thumbnailGraphic.DrawRectangle(pen, x, y, width, height);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if(dlg.ShowDialog() == DialogResult.OK)
            {
                FileName = dlg.FileName;
                pictureBox1.Image = new Bitmap(FileName);
            }
        }
    }
}