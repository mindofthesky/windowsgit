﻿
namespace kiwoom_testing
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.axKHOpenAPI1 = new AxKHOpenAPILib.AxKHOpenAPI();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.txtTest = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.DayButton = new System.Windows.Forms.Button();
            this.daytxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.daychart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.conditionGridView = new System.Windows.Forms.DataGridView();
            this.stockItemGridView = new System.Windows.Forms.DataGridView();
            this.종목명 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.현재가 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.전일대비 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.등락률 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.거래량 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.시가 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.고가 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.저가 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.getConditionButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.axKHOpenAPI1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.daychart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.conditionGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockItemGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // axKHOpenAPI1
            // 
            this.axKHOpenAPI1.Enabled = true;
            this.axKHOpenAPI1.Location = new System.Drawing.Point(927, 508);
            this.axKHOpenAPI1.Name = "axKHOpenAPI1";
            this.axKHOpenAPI1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axKHOpenAPI1.OcxState")));
            this.axKHOpenAPI1.Size = new System.Drawing.Size(10, 10);
            this.axKHOpenAPI1.TabIndex = 0;
            this.axKHOpenAPI1.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 21);
            this.button1.TabIndex = 1;
            this.button1.Text = "로그인";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(62, 39);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(177, 37);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "검색";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(106, 10);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(108, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "로그인 상황 확인";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(13, 66);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(261, 233);
            this.richTextBox1.TabIndex = 6;
            this.richTextBox1.Text = "";
            // 
            // txtTest
            // 
            this.txtTest.Location = new System.Drawing.Point(14, 305);
            this.txtTest.Name = "txtTest";
            this.txtTest.Size = new System.Drawing.Size(135, 19);
            this.txtTest.TabIndex = 7;
            this.txtTest.Text = "리치박스테스트";
            this.txtTest.UseVisualStyleBackColor = true;
            this.txtTest.Click += new System.EventHandler(this.txtTest_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(174, 333);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 10;
            this.button4.Text = "확인";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 338);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "계좌번호";
            // 
            // DayButton
            // 
            this.DayButton.Location = new System.Drawing.Point(174, 358);
            this.DayButton.Name = "DayButton";
            this.DayButton.Size = new System.Drawing.Size(75, 23);
            this.DayButton.TabIndex = 13;
            this.DayButton.Text = "검색";
            this.DayButton.UseVisualStyleBackColor = true;
            this.DayButton.Click += new System.EventHandler(this.DayButton_Click);
            // 
            // daytxt
            // 
            this.daytxt.Location = new System.Drawing.Point(68, 360);
            this.daytxt.Name = "daytxt";
            this.daytxt.Size = new System.Drawing.Size(100, 21);
            this.daytxt.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 365);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "기준일";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(280, 24);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(228, 220);
            this.listBox1.TabIndex = 14;
            // 
            // daychart
            // 
            chartArea1.Name = "ChartArea1";
            this.daychart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.daychart.Legends.Add(legend1);
            this.daychart.Location = new System.Drawing.Point(280, 250);
            this.daychart.Name = "daychart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series1.YValuesPerPoint = 4;
            this.daychart.Series.Add(series1);
            this.daychart.Size = new System.Drawing.Size(228, 268);
            this.daychart.TabIndex = 15;
            this.daychart.Text = "Kdaychart";
            this.daychart.AxisViewChanged += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.ViewEventArgs>(this.daychart_AxisViewChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(70, 333);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(98, 20);
            this.comboBox1.TabIndex = 16;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 12;
            this.listBox2.Location = new System.Drawing.Point(14, 394);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(253, 124);
            this.listBox2.TabIndex = 17;
            // 
            // conditionGridView
            // 
            this.conditionGridView.AllowUserToAddRows = false;
            this.conditionGridView.AllowUserToDeleteRows = false;
            this.conditionGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.conditionGridView.Location = new System.Drawing.Point(514, 24);
            this.conditionGridView.Name = "conditionGridView";
            this.conditionGridView.RowHeadersVisible = false;
            this.conditionGridView.RowTemplate.Height = 23;
            this.conditionGridView.Size = new System.Drawing.Size(198, 494);
            this.conditionGridView.TabIndex = 18;
            this.conditionGridView.SelectionChanged += new System.EventHandler(this.conditionGridView_SelectionChanged);
            // 
            // stockItemGridView
            // 
            this.stockItemGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.stockItemGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.종목명,
            this.현재가,
            this.전일대비,
            this.등락률,
            this.거래량,
            this.시가,
            this.고가,
            this.저가});
            this.stockItemGridView.Location = new System.Drawing.Point(718, 24);
            this.stockItemGridView.Name = "stockItemGridView";
            this.stockItemGridView.RowHeadersVisible = false;
            this.stockItemGridView.RowTemplate.Height = 23;
            this.stockItemGridView.Size = new System.Drawing.Size(805, 494);
            this.stockItemGridView.TabIndex = 19;
            // 
            // 종목명
            // 
            this.종목명.HeaderText = "종목명";
            this.종목명.Name = "종목명";
            // 
            // 현재가
            // 
            this.현재가.HeaderText = "현재가";
            this.현재가.Name = "현재가";
            // 
            // 전일대비
            // 
            this.전일대비.HeaderText = "전일대비";
            this.전일대비.Name = "전일대비";
            // 
            // 등락률
            // 
            this.등락률.HeaderText = "등락률";
            this.등락률.Name = "등락률";
            // 
            // 거래량
            // 
            this.거래량.HeaderText = "거래량";
            this.거래량.Name = "거래량";
            // 
            // 시가
            // 
            this.시가.HeaderText = "시가";
            this.시가.Name = "시가";
            // 
            // 고가
            // 
            this.고가.HeaderText = "고가";
            this.고가.Name = "고가";
            // 
            // 저가
            // 
            this.저가.HeaderText = "저가";
            this.저가.Name = "저가";
            // 
            // getConditionButton
            // 
            this.getConditionButton.Location = new System.Drawing.Point(155, 305);
            this.getConditionButton.Name = "getConditionButton";
            this.getConditionButton.Size = new System.Drawing.Size(53, 23);
            this.getConditionButton.TabIndex = 20;
            this.getConditionButton.Text = "신창섭";
            this.getConditionButton.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1530, 526);
            this.Controls.Add(this.getConditionButton);
            this.Controls.Add(this.stockItemGridView);
            this.Controls.Add(this.conditionGridView);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.daychart);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.DayButton);
            this.Controls.Add(this.daytxt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTest);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.axKHOpenAPI1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.axKHOpenAPI1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.daychart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.conditionGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockItemGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AxKHOpenAPILib.AxKHOpenAPI axKHOpenAPI1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button txtTest;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button DayButton;
        private System.Windows.Forms.TextBox daytxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.DataVisualization.Charting.Chart daychart;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.DataGridView conditionGridView;
        private System.Windows.Forms.DataGridView stockItemGridView;
        private System.Windows.Forms.Button getConditionButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn 종목명;
        private System.Windows.Forms.DataGridViewTextBoxColumn 현재가;
        private System.Windows.Forms.DataGridViewTextBoxColumn 전일대비;
        private System.Windows.Forms.DataGridViewTextBoxColumn 등락률;
        private System.Windows.Forms.DataGridViewTextBoxColumn 거래량;
        private System.Windows.Forms.DataGridViewTextBoxColumn 시가;
        private System.Windows.Forms.DataGridViewTextBoxColumn 고가;
        private System.Windows.Forms.DataGridViewTextBoxColumn 저가;
    }
}

