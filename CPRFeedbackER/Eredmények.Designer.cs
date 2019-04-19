﻿namespace CPRFeedbackER
{
    partial class Eredmények
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
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// textBox1
			// 
			this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
			this.textBox1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.textBox1.ForeColor = System.Drawing.SystemColors.Window;
			this.textBox1.Location = new System.Drawing.Point(-6, -2);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(229, 491);
			this.textBox1.TabIndex = 2;
			this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// lbMeasurements
			// 
			this.lbMeasurements.BackColor = System.Drawing.Color.Azure;
			this.lbMeasurements.DisplayMember = "Name";
			this.lbMeasurements.FormattingEnabled = true;
			this.lbMeasurements.Location = new System.Drawing.Point(5, 136);
			this.lbMeasurements.Name = "lbMeasurements";
			this.lbMeasurements.Size = new System.Drawing.Size(208, 303);
			this.lbMeasurements.TabIndex = 4;
			this.lbMeasurements.ValueMember = "Id";
			// 
			// cartesianChart1
			// 
			this.cartesianChart1.Location = new System.Drawing.Point(229, 138);
			this.cartesianChart1.Name = "cartesianChart1";
			this.cartesianChart1.Size = new System.Drawing.Size(867, 347);
			this.cartesianChart1.TabIndex = 5;
			this.cartesianChart1.Text = "cartesianChart1";
			// 
			// btn_Open
			// 
			this.btn_Open.FlatAppearance.BorderSize = 0;
			this.btn_Open.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
			this.btn_Open.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn_Open.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.btn_Open.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.btn_Open.Location = new System.Drawing.Point(5, 444);
			this.btn_Open.Name = "btn_Open";
			this.btn_Open.Size = new System.Drawing.Size(102, 34);
			this.btn_Open.TabIndex = 6;
			this.btn_Open.Text = "Megnyítás";
			this.btn_Open.UseVisualStyleBackColor = true;
			this.btn_Open.Click += new System.EventHandler(this.btn_Open_Click);
			// 
			// bpmGauge
			// 
			this.bpmGauge.Location = new System.Drawing.Point(272, 32);
			this.bpmGauge.Name = "bpmGauge";
			this.bpmGauge.Size = new System.Drawing.Size(200, 100);
			this.bpmGauge.TabIndex = 7;
			this.bpmGauge.Text = "BPMGauge";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label1.Location = new System.Drawing.Point(351, 11);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(41, 18);
			this.label1.TabIndex = 8;
			this.label1.Text = "BPM";
			// 
			// idealPressGauge
			// 
			this.idealPressGauge.Location = new System.Drawing.Point(849, 32);
			this.idealPressGauge.Name = "idealPressGauge";
			this.idealPressGauge.Size = new System.Drawing.Size(200, 100);
			this.idealPressGauge.TabIndex = 9;
			this.idealPressGauge.Text = "solidGauge2";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(478, 119);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(25, 13);
			this.label4.TabIndex = 12;
			this.label4.Text = "150";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(253, 119);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(13, 13);
			this.label5.TabIndex = 13;
			this.label5.Text = "0";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(1055, 119);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(25, 13);
			this.label6.TabIndex = 14;
			this.label6.Text = "120";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(830, 119);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(13, 13);
			this.label7.TabIndex = 15;
			this.label7.Text = "0";
			// 
			// releaseGauge
			// 
			this.releaseGauge.Location = new System.Drawing.Point(562, 32);
			this.releaseGauge.Name = "releaseGauge";
			this.releaseGauge.Size = new System.Drawing.Size(200, 100);
			this.releaseGauge.TabIndex = 19;
			this.releaseGauge.Text = "solidGauge3";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label3.Location = new System.Drawing.Point(602, 9);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(133, 20);
			this.label3.TabIndex = 20;
			this.label3.Text = "Teljes felengedés";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label8.Location = new System.Drawing.Point(857, 9);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(182, 20);
			this.label8.TabIndex = 21;
			this.label8.Text = "Ideális nyomások száma";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(768, 119);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(25, 13);
			this.label2.TabIndex = 22;
			this.label2.Text = "120";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(543, 119);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(13, 13);
			this.label9.TabIndex = 23;
			this.label9.Text = "0";
			// 
			// button1
			// 
			this.button1.FlatAppearance.BorderSize = 0;
			this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.button1.Location = new System.Drawing.Point(111, 444);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(102, 34);
			this.button1.TabIndex = 24;
			this.button1.Text = "Bezárás";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// Eredmények
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.BackColor = System.Drawing.Color.Azure;
			this.ClientSize = new System.Drawing.Size(1108, 489);
			this.Controls.Add(this.button1);
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
			this.Name = "Eredmények";
			this.Text = "Eredmények";
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
        private System.Windows.Forms.Button button1;
    }
}