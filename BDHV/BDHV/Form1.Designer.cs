namespace BDHV
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dd1_month2 = new System.Windows.Forms.ComboBox();
            this.dd1_day2 = new System.Windows.Forms.ComboBox();
            this.dd1_year2 = new System.Windows.Forms.TextBox();
            this.dd1_month = new System.Windows.Forms.ComboBox();
            this.dd1_day = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.get_total_sums = new System.Windows.Forms.Button();
            this.dd1_year1 = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(308, 88);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 106);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(700, 366);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.DarkGray;
            this.tabPage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.dd1_month2);
            this.tabPage1.Controls.Add(this.dd1_day2);
            this.tabPage1.Controls.Add(this.dd1_year2);
            this.tabPage1.Controls.Add(this.dd1_month);
            this.tabPage1.Controls.Add(this.dd1_day);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.get_total_sums);
            this.tabPage1.Controls.Add(this.dd1_year1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(692, 340);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Reports";
            // 
            // dd1_month2
            // 
            this.dd1_month2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dd1_month2.FormattingEnabled = true;
            this.dd1_month2.Location = new System.Drawing.Point(153, 77);
            this.dd1_month2.Name = "dd1_month2";
            this.dd1_month2.Size = new System.Drawing.Size(80, 21);
            this.dd1_month2.TabIndex = 12;
            // 
            // dd1_day2
            // 
            this.dd1_day2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dd1_day2.FormattingEnabled = true;
            this.dd1_day2.Location = new System.Drawing.Point(96, 77);
            this.dd1_day2.Name = "dd1_day2";
            this.dd1_day2.Size = new System.Drawing.Size(51, 21);
            this.dd1_day2.TabIndex = 11;
            // 
            // dd1_year2
            // 
            this.dd1_year2.Location = new System.Drawing.Point(239, 77);
            this.dd1_year2.Name = "dd1_year2";
            this.dd1_year2.Size = new System.Drawing.Size(50, 20);
            this.dd1_year2.TabIndex = 10;
            // 
            // dd1_month
            // 
            this.dd1_month.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dd1_month.FormattingEnabled = true;
            this.dd1_month.Location = new System.Drawing.Point(153, 28);
            this.dd1_month.Name = "dd1_month";
            this.dd1_month.Size = new System.Drawing.Size(80, 21);
            this.dd1_month.TabIndex = 9;
            // 
            // dd1_day
            // 
            this.dd1_day.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dd1_day.DropDownWidth = 50;
            this.dd1_day.FormattingEnabled = true;
            this.dd1_day.Location = new System.Drawing.Point(96, 29);
            this.dd1_day.Name = "dd1_day";
            this.dd1_day.Size = new System.Drawing.Size(51, 21);
            this.dd1_day.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(42, 201);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 7;
            // 
            // get_total_sums
            // 
            this.get_total_sums.Location = new System.Drawing.Point(274, 154);
            this.get_total_sums.Name = "get_total_sums";
            this.get_total_sums.Size = new System.Drawing.Size(96, 23);
            this.get_total_sums.TabIndex = 6;
            this.get_total_sums.Text = "Get Total Sums";
            this.get_total_sums.UseVisualStyleBackColor = true;
            this.get_total_sums.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // dd1_year1
            // 
            this.dd1_year1.Location = new System.Drawing.Point(239, 29);
            this.dd1_year1.Name = "dd1_year1";
            this.dd1_year1.Size = new System.Drawing.Size(50, 20);
            this.dd1_year1.TabIndex = 5;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(692, 340);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 19);
            this.label2.TabIndex = 13;
            this.label2.Text = "Start Date:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 19);
            this.label3.TabIndex = 14;
            this.label3.Text = "End Date:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 205);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(191, 19);
            this.label4.TabIndex = 15;
            this.label4.Text = "Employee Worktime Profit:";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Gray;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(214, 205);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 21);
            this.label5.TabIndex = 16;
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Gray;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(214, 246);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 21);
            this.label6.TabIndex = 19;
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(41, 246);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(163, 19);
            this.label7.TabIndex = 18;
            this.label7.Text = "Total Employee Hours:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.DimGray;
            this.label8.Location = new System.Drawing.Point(42, 242);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(0, 13);
            this.label8.TabIndex = 17;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(724, 484);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Bakersfield Downhole Video";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button get_total_sums;
        private System.Windows.Forms.TextBox dd1_year1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox dd1_month;
        private System.Windows.Forms.ComboBox dd1_day;
        private System.Windows.Forms.ComboBox dd1_month2;
        private System.Windows.Forms.ComboBox dd1_day2;
        private System.Windows.Forms.TextBox dd1_year2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}

