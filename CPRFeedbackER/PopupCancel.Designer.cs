namespace CPRFeedbackER {
    partial class PopupCancel {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.btnCancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnNewMes = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_X = new System.Windows.Forms.Button();
            this.btnMin = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Red;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnCancel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCancel.Location = new System.Drawing.Point(196, 72);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(181, 36);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Nem";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // label2
            // 
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(389, 53);
            this.label2.TabIndex = 7;
            this.label2.Text = "Nem került mentésre! Új mérés?";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.UseCompatibleTextRendering = true;
            // 
            // btnNewMes
            // 
            this.btnNewMes.BackColor = System.Drawing.Color.ForestGreen;
            this.btnNewMes.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnNewMes.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnNewMes.Location = new System.Drawing.Point(12, 72);
            this.btnNewMes.Name = "btnNewMes";
            this.btnNewMes.Size = new System.Drawing.Size(174, 36);
            this.btnNewMes.TabIndex = 8;
            this.btnNewMes.Text = "Igen";
            this.btnNewMes.UseVisualStyleBackColor = false;
            this.btnNewMes.Click += new System.EventHandler(this.BtnNewMes_Click);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::My.Project.S.Proper.Namespace.Resources.háttér1;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(389, 123);
            this.panel1.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SteelBlue;
            this.panel2.Controls.Add(this.btn_X);
            this.panel2.Controls.Add(this.btnMin);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(389, 53);
            this.panel2.TabIndex = 27;
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
            // 
            // PopupCancel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(38)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(389, 123);
            this.Controls.Add(this.btnNewMes);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PopupCancel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mégse";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnNewMes;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_X;
        private System.Windows.Forms.Button btnMin;
    }
}