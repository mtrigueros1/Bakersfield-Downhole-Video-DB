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
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.year1 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dd1_day = new System.Windows.Forms.ComboBox();
            this.dd1_month = new System.Windows.Forms.ComboBox();
            this.dd1_month2 = new System.Windows.Forms.ComboBox();
            this.dd1_day2 = new System.Windows.Forms.ComboBox();
            this.year2 = new System.Windows.Forms.TextBox();
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
            this.pictureBox1.Size = new System.Drawing.Size(282, 88);
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
            this.tabPage1.Controls.Add(this.dd1_month2);
            this.tabPage1.Controls.Add(this.dd1_day2);
            this.tabPage1.Controls.Add(this.year2);
            this.tabPage1.Controls.Add(this.dd1_month);
            this.tabPage1.Controls.Add(this.dd1_day);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.year1);
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(692, 340);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Reports";
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(249, 190);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(405, 63);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Submit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // year1
            // 
            this.year1.Location = new System.Drawing.Point(260, 33);
            this.year1.Name = "year1";
            this.year1.Size = new System.Drawing.Size(100, 20);
            this.year1.TabIndex = 5;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(203, 193);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 4;
            // 
            // dd1_day
            // 
            this.dd1_day.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dd1_day.FormattingEnabled = true;
            this.dd1_day.Location = new System.Drawing.Point(6, 32);
            this.dd1_day.Name = "dd1_day";
            this.dd1_day.Size = new System.Drawing.Size(121, 21);
            this.dd1_day.TabIndex = 8;
            // 
            // dd1_month
            // 
            this.dd1_month.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dd1_month.FormattingEnabled = true;
            this.dd1_month.Location = new System.Drawing.Point(133, 32);
            this.dd1_month.Name = "dd1_month";
            this.dd1_month.Size = new System.Drawing.Size(121, 21);
            this.dd1_month.TabIndex = 9;
            // 
            // dd1_month2
            // 
            this.dd1_month2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dd1_month2.FormattingEnabled = true;
            this.dd1_month2.Location = new System.Drawing.Point(133, 91);
            this.dd1_month2.Name = "dd1_month2";
            this.dd1_month2.Size = new System.Drawing.Size(121, 21);
            this.dd1_month2.TabIndex = 12;
            // 
            // dd1_day2
            // 
            this.dd1_day2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dd1_day2.FormattingEnabled = true;
            this.dd1_day2.Location = new System.Drawing.Point(6, 91);
            this.dd1_day2.Name = "dd1_day2";
            this.dd1_day2.Size = new System.Drawing.Size(121, 21);
            this.dd1_day2.TabIndex = 11;
            // 
            // year2
            // 
            this.year2.Location = new System.Drawing.Point(260, 92);
            this.year2.Name = "year2";
            this.year2.Size = new System.Drawing.Size(100, 20);
            this.year2.TabIndex = 10;
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox year1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox dd1_month;
        private System.Windows.Forms.ComboBox dd1_day;
        private System.Windows.Forms.ComboBox dd1_month2;
        private System.Windows.Forms.ComboBox dd1_day2;
        private System.Windows.Forms.TextBox year2;
    }
}

