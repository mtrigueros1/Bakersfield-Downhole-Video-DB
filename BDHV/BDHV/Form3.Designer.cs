namespace BDHV
{
    partial class Form3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.label15 = new System.Windows.Forms.Label();
            this.getstartdate = new System.Windows.Forms.MonthCalendar();
            this.subyearafter = new System.Windows.Forms.Button();
            this.subyearbefore = new System.Windows.Forms.Button();
            this.submonthafter = new System.Windows.Forms.Button();
            this.submonthbefore = new System.Windows.Forms.Button();
            this.subweekafter = new System.Windows.Forms.Button();
            this.subweekbefore = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(185, 44);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(98, 16);
            this.label15.TabIndex = 21;
            this.label15.Text = "Choose Date";
            // 
            // getstartdate
            // 
            this.getstartdate.Location = new System.Drawing.Point(127, 69);
            this.getstartdate.MaxSelectionCount = 1;
            this.getstartdate.Name = "getstartdate";
            this.getstartdate.ShowTodayCircle = false;
            this.getstartdate.TabIndex = 22;
            // 
            // subyearafter
            // 
            this.subyearafter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subyearafter.Location = new System.Drawing.Point(306, 290);
            this.subyearafter.Name = "subyearafter";
            this.subyearafter.Size = new System.Drawing.Size(128, 23);
            this.subyearafter.TabIndex = 24;
            this.subyearafter.Text = "A Year After";
            this.subyearafter.UseVisualStyleBackColor = true;
            this.subyearafter.Click += new System.EventHandler(this.subyearafter_Click);
            // 
            // subyearbefore
            // 
            this.subyearbefore.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subyearbefore.Location = new System.Drawing.Point(306, 261);
            this.subyearbefore.Name = "subyearbefore";
            this.subyearbefore.Size = new System.Drawing.Size(128, 23);
            this.subyearbefore.TabIndex = 25;
            this.subyearbefore.Text = "A Year Before";
            this.subyearbefore.UseVisualStyleBackColor = true;
            this.subyearbefore.Click += new System.EventHandler(this.subyearbefore_Click);
            // 
            // submonthafter
            // 
            this.submonthafter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submonthafter.Location = new System.Drawing.Point(172, 290);
            this.submonthafter.Name = "submonthafter";
            this.submonthafter.Size = new System.Drawing.Size(128, 23);
            this.submonthafter.TabIndex = 26;
            this.submonthafter.Text = "A Month After";
            this.submonthafter.UseVisualStyleBackColor = true;
            this.submonthafter.Click += new System.EventHandler(this.submonthafter_Click);
            // 
            // submonthbefore
            // 
            this.submonthbefore.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submonthbefore.Location = new System.Drawing.Point(172, 261);
            this.submonthbefore.Name = "submonthbefore";
            this.submonthbefore.Size = new System.Drawing.Size(128, 23);
            this.submonthbefore.TabIndex = 27;
            this.submonthbefore.Text = "A Month Before";
            this.submonthbefore.UseVisualStyleBackColor = true;
            this.submonthbefore.Click += new System.EventHandler(this.submonthbefore_Click);
            // 
            // subweekafter
            // 
            this.subweekafter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subweekafter.Location = new System.Drawing.Point(38, 290);
            this.subweekafter.Name = "subweekafter";
            this.subweekafter.Size = new System.Drawing.Size(128, 23);
            this.subweekafter.TabIndex = 28;
            this.subweekafter.Text = "A Week After";
            this.subweekafter.UseVisualStyleBackColor = true;
            this.subweekafter.Click += new System.EventHandler(this.subweekafter_Click);
            // 
            // subweekbefore
            // 
            this.subweekbefore.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subweekbefore.Location = new System.Drawing.Point(38, 261);
            this.subweekbefore.Name = "subweekbefore";
            this.subweekbefore.Size = new System.Drawing.Size(128, 23);
            this.subweekbefore.TabIndex = 29;
            this.subweekbefore.Text = "A Week Before";
            this.subweekbefore.UseVisualStyleBackColor = true;
            this.subweekbefore.Click += new System.EventHandler(this.subweekbefore_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(207, 240);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 16);
            this.label1.TabIndex = 30;
            this.label1.Text = "Range";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(485, 335);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.subweekbefore);
            this.Controls.Add(this.subweekafter);
            this.Controls.Add(this.submonthbefore);
            this.Controls.Add(this.submonthafter);
            this.Controls.Add(this.subyearbefore);
            this.Controls.Add(this.subyearafter);
            this.Controls.Add(this.getstartdate);
            this.Controls.Add(this.label15);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form3";
            this.Text = "Date Selection";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.MonthCalendar getstartdate;
        private System.Windows.Forms.Button subyearafter;
        private System.Windows.Forms.Button subyearbefore;
        private System.Windows.Forms.Button submonthafter;
        private System.Windows.Forms.Button submonthbefore;
        private System.Windows.Forms.Button subweekafter;
        private System.Windows.Forms.Button subweekbefore;
        private System.Windows.Forms.Label label1;
    }
}