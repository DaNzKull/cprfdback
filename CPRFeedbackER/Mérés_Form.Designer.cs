using LiveCharts.Wpf;
using System.Windows.Media;

namespace CPRFeedbackER
{
    partial class CPRFeedbackER
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_Close = new System.Windows.Forms.Button();
            this.btn_Stop = new System.Windows.Forms.Button();
            this.btn_Start = new System.Windows.Forms.Button();
            this.timer_lbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cprCountGauge = new LiveCharts.WinForms.SolidGauge();
            this.depthGauge = new LiveCharts.WinForms.AngularGauge();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.labelGood = new System.Windows.Forms.Label();
            this.labelWeak = new System.Windows.Forms.Label();
            this.labelBad = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.btn_Close);
            this.panel1.Controls.Add(this.btn_Stop);
            this.panel1.Controls.Add(this.btn_Start);
            this.panel1.ForeColor = System.Drawing.Color.Coral;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(204, 420);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Location = new System.Drawing.Point(-8, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(212, 110);
            this.panel2.TabIndex = 6;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.panel3.BackgroundImage = global::My.Project.S.Proper.Namespace.Resources.logo;
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel3.Location = new System.Drawing.Point(3, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(209, 110);
            this.panel3.TabIndex = 11;
            // 
            // btn_Close
            // 
            this.btn_Close.FlatAppearance.BorderSize = 0;
            this.btn_Close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Close.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold);
            this.btn_Close.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Close.Location = new System.Drawing.Point(3, 344);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(201, 76);
            this.btn_Close.TabIndex = 5;
            this.btn_Close.Text = "Bezárás";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // btn_Stop
            // 
            this.btn_Stop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_Stop.FlatAppearance.BorderSize = 0;
            this.btn_Stop.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.btn_Stop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Stop.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_Stop.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Stop.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Stop.ImageKey = "LogoMakr_9OJvEc.png";
            this.btn_Stop.Location = new System.Drawing.Point(0, 190);
            this.btn_Stop.Name = "btn_Stop";
            this.btn_Stop.Size = new System.Drawing.Size(204, 64);
            this.btn_Stop.TabIndex = 4;
            this.btn_Stop.Text = "Leállítás";
            this.btn_Stop.UseVisualStyleBackColor = true;
            this.btn_Stop.Click += new System.EventHandler(this.btn_Stop_Click);
            // 
            // btn_Start
            // 
            this.btn_Start.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Start.FlatAppearance.BorderSize = 0;
            this.btn_Start.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.btn_Start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Start.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Start.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Start.Location = new System.Drawing.Point(-5, 116);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(209, 68);
            this.btn_Start.TabIndex = 2;
            this.btn_Start.Text = "Indítás";
            this.btn_Start.UseVisualStyleBackColor = true;
            this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
            // 
            // timer_lbl
            // 
            this.timer_lbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.timer_lbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.timer_lbl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.timer_lbl.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.timer_lbl.ForeColor = System.Drawing.Color.White;
            this.timer_lbl.Location = new System.Drawing.Point(202, -3);
            this.timer_lbl.Name = "timer_lbl";
            this.timer_lbl.Size = new System.Drawing.Size(321, 49);
            this.timer_lbl.TabIndex = 6;
            this.timer_lbl.Text = "60 másodperc";
            this.timer_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.timer_lbl.UseCompatibleTextRendering = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(343, -23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 31);
            this.label1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(261, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(207, 21);
            this.label2.TabIndex = 5;
            this.label2.Text = "Mellkaskompressziók száma";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cprCountGauge
            // 
            this.cprCountGauge.BackColorTransparent = true;
            this.cprCountGauge.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cprCountGauge.Location = new System.Drawing.Point(210, 84);
            this.cprCountGauge.Name = "cprCountGauge";
            this.cprCountGauge.Size = new System.Drawing.Size(305, 333);
            this.cprCountGauge.TabIndex = 9;
            this.cprCountGauge.Text = "solidGauge1";
            // 
            // depthGauge
            // 
            this.depthGauge.BackColor = System.Drawing.SystemColors.Window;
            this.depthGauge.BackColorTransparent = true;
            this.depthGauge.Font = new System.Drawing.Font("Segoe UI Emoji", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.depthGauge.ForeColor = System.Drawing.Color.Coral;
            this.depthGauge.Location = new System.Drawing.Point(529, 84);
            this.depthGauge.Name = "depthGauge";
            this.depthGauge.Size = new System.Drawing.Size(302, 333);
            this.depthGauge.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Location = new System.Drawing.Point(521, -3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(2, 425);
            this.label4.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label3.Location = new System.Drawing.Point(592, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(184, 21);
            this.label3.TabIndex = 12;
            this.label3.Text = "Utolsó nyomás mélysége";
            // 
            // panel4
            // 
            this.panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel4.Controls.Add(this.labelGood);
            this.panel4.Controls.Add(this.labelWeak);
            this.panel4.Controls.Add(this.labelBad);
            this.panel4.Location = new System.Drawing.Point(521, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(313, 46);
            this.panel4.TabIndex = 13;
            // 
            // labelGood
            // 
            this.labelGood.BackColor = System.Drawing.Color.Lime;
            this.labelGood.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelGood.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold);
            this.labelGood.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labelGood.Location = new System.Drawing.Point(207, 0);
            this.labelGood.Name = "labelGood";
            this.labelGood.Size = new System.Drawing.Size(106, 46);
            this.labelGood.TabIndex = 2;
            this.labelGood.Text = "JÓ";
            this.labelGood.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelWeak
            // 
            this.labelWeak.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.labelWeak.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold);
            this.labelWeak.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labelWeak.Location = new System.Drawing.Point(103, 0);
            this.labelWeak.Name = "labelWeak";
            this.labelWeak.Size = new System.Drawing.Size(106, 46);
            this.labelWeak.TabIndex = 1;
            this.labelWeak.Text = "GYENGE";
            this.labelWeak.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelBad
            // 
            this.labelBad.BackColor = System.Drawing.Color.Red;
            this.labelBad.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelBad.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold);
            this.labelBad.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labelBad.Location = new System.Drawing.Point(0, 0);
            this.labelBad.Name = "labelBad";
            this.labelBad.Size = new System.Drawing.Size(108, 46);
            this.labelBad.TabIndex = 0;
            this.labelBad.Text = "ROSSZ";
            this.labelBad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CPRFeedbackER
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(834, 420);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.depthGauge);
            this.Controls.Add(this.cprCountGauge);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.timer_lbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CPRFeedbackER";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CPRFeedBackER";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Stop;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label timer_lbl;
		private LiveCharts.WinForms.SolidGauge cprCountGauge;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label labelGood;
        private System.Windows.Forms.Label labelWeak;
        private System.Windows.Forms.Label labelBad;
        public LiveCharts.WinForms.AngularGauge depthGauge;
    }
}

