namespace CPRFeedbackER
{
    partial class Results
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if ( disposing && ( components != null ) ) {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lbMeasurements = new System.Windows.Forms.ListBox();
            this.cartesianChart1 = new LiveCharts.WinForms.CartesianChart();
            this.btn_Open = new System.Windows.Forms.Button();
            this.bpmGauge = new LiveCharts.WinForms.SolidGauge();
            this.label1 = new System.Windows.Forms.Label();
            this.idealPressGauge = new LiveCharts.WinForms.SolidGauge();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.releaseGauge = new LiveCharts.WinForms.SolidGauge();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btn_Close = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblCommentHelper = new System.Windows.Forms.Label();
            this.txtBoxComment = new System.Windows.Forms.TextBox();
            this.txtBoxDate = new System.Windows.Forms.TextBox();
            this.txtBoxName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_X = new System.Windows.Forms.Button();
            this.btnMin = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Cursor = System.Windows.Forms.Cursors.SizeNESW;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.textBox1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox1.ForeColor = System.Drawing.SystemColors.Window;
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(247, 608);
            this.textBox1.TabIndex = 2;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbMeasurements
            // 
            this.lbMeasurements.BackColor = System.Drawing.Color.Azure;
            this.lbMeasurements.DisplayMember = "Name";
            this.lbMeasurements.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbMeasurements.FormattingEnabled = true;
            this.lbMeasurements.ItemHeight = 21;
            this.lbMeasurements.Location = new System.Drawing.Point(10, 300);
            this.lbMeasurements.Name = "lbMeasurements";
            this.lbMeasurements.Size = new System.Drawing.Size(228, 256);
            this.lbMeasurements.TabIndex = 4;
            this.lbMeasurements.ValueMember = "Id";
            // 
            // cartesianChart1
            // 
            this.cartesianChart1.BackColor = System.Drawing.Color.Transparent;
            this.cartesianChart1.Location = new System.Drawing.Point(256, 197);
            this.cartesianChart1.Name = "cartesianChart1";
            this.cartesianChart1.Size = new System.Drawing.Size(915, 411);
            this.cartesianChart1.TabIndex = 5;
            this.cartesianChart1.Text = "cartesianChart1";

            // 
            // btn_Open
            // 
            this.btn_Open.BackColor = System.Drawing.Color.Transparent;
            this.btn_Open.FlatAppearance.BorderSize = 0;
            this.btn_Open.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.btn_Open.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Open.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btn_Open.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_Open.Location = new System.Drawing.Point(12, 562);
            this.btn_Open.Name = "btn_Open";
            this.btn_Open.Size = new System.Drawing.Size(104, 34);
            this.btn_Open.TabIndex = 6;
            this.btn_Open.Text = "MEGNYÍT";
            this.btn_Open.UseVisualStyleBackColor = false;
            this.btn_Open.Click += new System.EventHandler(this.btn_Open_Click);
            // 
            // bpmGauge
            // 
            this.bpmGauge.BackColor = System.Drawing.Color.Transparent;
            this.bpmGauge.Location = new System.Drawing.Point(318, 71);
            this.bpmGauge.Name = "bpmGauge";
            this.bpmGauge.Size = new System.Drawing.Size(200, 100);
            this.bpmGauge.TabIndex = 7;
            this.bpmGauge.Text = "BPMGauge";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic);
            this.label1.Location = new System.Drawing.Point(318, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "BPM";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // idealPressGauge
            // 
            this.idealPressGauge.BackColor = System.Drawing.Color.Transparent;
            this.idealPressGauge.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.idealPressGauge.Location = new System.Drawing.Point(919, 71);
            this.idealPressGauge.Name = "idealPressGauge";
            this.idealPressGauge.Size = new System.Drawing.Size(200, 100);
            this.idealPressGauge.TabIndex = 9;
            this.idealPressGauge.Text = "solidGauge2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(528, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "150";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(299, 158);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(1125, 158);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(25, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "120";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(900, 158);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(13, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "0";
            // 
            // releaseGauge
            // 
            this.releaseGauge.BackColor = System.Drawing.Color.Transparent;
            this.releaseGauge.Location = new System.Drawing.Point(623, 71);
            this.releaseGauge.Name = "releaseGauge";
            this.releaseGauge.Size = new System.Drawing.Size(200, 100);
            this.releaseGauge.TabIndex = 19;
            this.releaseGauge.Text = "solidGauge3";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic);
            this.label3.Location = new System.Drawing.Point(623, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(200, 23);
            this.label3.TabIndex = 20;
            this.label3.Text = "Teljes felengedés";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic);
            this.label8.Location = new System.Drawing.Point(919, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(200, 23);
            this.label8.TabIndex = 21;
            this.label8.Text = "Ideális nyomások száma";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(829, 158);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "120";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(604, 158);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(13, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "0";
            // 
            // btn_Close
            // 
            this.btn_Close.BackColor = System.Drawing.Color.Transparent;
            this.btn_Close.FlatAppearance.BorderSize = 0;
            this.btn_Close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Close.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btn_Close.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_Close.Location = new System.Drawing.Point(127, 562);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(111, 34);
            this.btn_Close.TabIndex = 24;
            this.btn_Close.Text = "BEZÁR";
            this.btn_Close.UseVisualStyleBackColor = false;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.lblCommentHelper);
            this.panel1.Controls.Add(this.btn_X);
            this.panel1.Controls.Add(this.btnMin);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(247, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(927, 31);
            this.panel1.TabIndex = 26;
            // 
            // lblCommentHelper
            // 
            this.lblCommentHelper.AutoSize = true;
            this.lblCommentHelper.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblCommentHelper.ForeColor = System.Drawing.Color.Azure;
            this.lblCommentHelper.Location = new System.Drawing.Point(6, 6);
            this.lblCommentHelper.Name = "lblCommentHelper";
            this.lblCommentHelper.Size = new System.Drawing.Size(473, 15);
            this.lblCommentHelper.TabIndex = 62;
            this.lblCommentHelper.Text = "Az eredmény megnyításához válassza ki a listából, majd nyomja meg a megnyít gombo" +
    "t!";
            // 
            // txtBoxComment
            // 
            this.txtBoxComment.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBoxComment.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtBoxComment.Location = new System.Drawing.Point(10, 175);
            this.txtBoxComment.Multiline = true;
            this.txtBoxComment.Name = "txtBoxComment";
            this.txtBoxComment.ReadOnly = true;
            this.txtBoxComment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBoxComment.Size = new System.Drawing.Size(228, 105);
            this.txtBoxComment.TabIndex = 30;
            this.txtBoxComment.Text = "Ha az adott méréshez tartozik komment, akkor az itt jelenik meg";
            // 
            // txtBoxDate
            // 
            this.txtBoxDate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtBoxDate.Location = new System.Drawing.Point(10, 135);
            this.txtBoxDate.Name = "txtBoxDate";
            this.txtBoxDate.ReadOnly = true;
            this.txtBoxDate.Size = new System.Drawing.Size(228, 25);
            this.txtBoxDate.TabIndex = 31;
            this.txtBoxDate.Text = "Dátum";
            // 
            // txtBoxName
            // 
            this.txtBoxName.AllowDrop = true;
            this.txtBoxName.BackColor = System.Drawing.Color.DarkSalmon;
            this.txtBoxName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtBoxName.Location = new System.Drawing.Point(10, 104);
            this.txtBoxName.Name = "txtBoxName";
            this.txtBoxName.ReadOnly = true;
            this.txtBoxName.Size = new System.Drawing.Size(228, 25);
            this.txtBoxName.TabIndex = 32;
            this.txtBoxName.Text = "Név";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Cursor = System.Windows.Forms.Cursors.SizeNESW;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label10.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label10.Location = new System.Drawing.Point(256, 38);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(0, 20);
            this.label10.TabIndex = 33;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.panel3.BackgroundImage = global::My.Project.S.Proper.Namespace.Resources.logo;
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(247, 87);
            this.panel3.TabIndex = 27;
            // 
            // btn_X
            // 
            this.btn_X.BackColor = System.Drawing.Color.SeaShell;
            this.btn_X.BackgroundImage = global::My.Project.S.Proper.Namespace.Resources.letter_x;
            this.btn_X.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_X.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btn_X.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Coral;
            this.btn_X.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_X.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_X.Location = new System.Drawing.Point(898, 0);
            this.btn_X.Name = "btn_X";
            this.btn_X.Size = new System.Drawing.Size(26, 27);
            this.btn_X.TabIndex = 61;
            this.btn_X.UseVisualStyleBackColor = false;
            this.btn_X.Click += new System.EventHandler(this.Btn_X_Click_1);
            // 
            // btnMin
            // 
            this.btnMin.BackColor = System.Drawing.Color.SeaShell;
            this.btnMin.BackgroundImage = global::My.Project.S.Proper.Namespace.Resources.iconfinder_minus_remove_delete_minimize_2931142__1_;
            this.btnMin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
            this.btnMin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PaleGoldenrod;
            this.btnMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMin.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnMin.Location = new System.Drawing.Point(869, 0);
            this.btnMin.Name = "btnMin";
            this.btnMin.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnMin.Size = new System.Drawing.Size(26, 27);
            this.btnMin.TabIndex = 60;
            this.btnMin.UseVisualStyleBackColor = false;
            this.btnMin.Click += new System.EventHandler(this.BtnMin_Click);
            // 
            // Eredmények
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1174, 608);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtBoxComment);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.txtBoxDate);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtBoxName);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.releaseGauge);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.idealPressGauge);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bpmGauge);
            this.Controls.Add(this.btn_Open);
            this.Controls.Add(this.cartesianChart1);
            this.Controls.Add(this.lbMeasurements);
            this.Controls.Add(this.textBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Eredmények";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Eredmények";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ListBox lbMeasurements;
        private LiveCharts.WinForms.CartesianChart cartesianChart1;
        private System.Windows.Forms.Button btn_Open;
        private LiveCharts.WinForms.SolidGauge bpmGauge;
        private System.Windows.Forms.Label label1;
        private LiveCharts.WinForms.SolidGauge idealPressGauge;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private LiveCharts.WinForms.SolidGauge releaseGauge;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnMin;
        private System.Windows.Forms.Button btn_X;
        private System.Windows.Forms.Label lblCommentHelper;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtBoxComment;
        private System.Windows.Forms.TextBox txtBoxDate;
        private System.Windows.Forms.TextBox txtBoxName;
        private System.Windows.Forms.Label label10;
    }
}