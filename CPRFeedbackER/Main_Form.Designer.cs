namespace CPRFeedbackER
{
    partial class Main_Form
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main_Form));
            this.btn_new = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_close = new System.Windows.Forms.Button();
            this.btn_Connect = new System.Windows.Forms.Button();
            this.cbComport = new System.Windows.Forms.ComboBox();
            this.btn_results = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_new
            // 
            this.btn_new.FlatAppearance.BorderSize = 0;
            this.btn_new.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btn_new.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(94)))), ((int)(((byte)(8)))));
            this.btn_new.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_new.Font = new System.Drawing.Font("Segoe UI Black", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_new.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_new.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_new.ImageList = this.imageList1;
            this.btn_new.Location = new System.Drawing.Point(1, -2);
            this.btn_new.Name = "btn_new";
            this.btn_new.Size = new System.Drawing.Size(229, 213);
            this.btn_new.TabIndex = 0;
            this.btn_new.Text = "Új mérés";
            this.btn_new.UseVisualStyleBackColor = true;
            this.btn_new.Click += new System.EventHandler(this.Btn_new_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "list.png");
            this.imageList1.Images.SetKeyName(1, "mérés.png");
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(21)))), ((int)(((byte)(14)))));
            this.panel1.Controls.Add(this.btn_close);
            this.panel1.Controls.Add(this.btn_Connect);
            this.panel1.Controls.Add(this.cbComport);
            this.panel1.Location = new System.Drawing.Point(1, 211);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(470, 83);
            this.panel1.TabIndex = 1;
            // 
            // btn_close
            // 
            this.btn_close.FlatAppearance.BorderSize = 0;
            this.btn_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_close.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_close.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_close.Location = new System.Drawing.Point(258, 8);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(185, 60);
            this.btn_close.TabIndex = 7;
            this.btn_close.Text = "Bezárás";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.Btn_close_Click);
            // 
            // btn_Connect
            // 
            this.btn_Connect.FlatAppearance.BorderSize = 0;
            this.btn_Connect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Connect.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_Connect.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_Connect.Location = new System.Drawing.Point(21, 41);
            this.btn_Connect.Name = "btn_Connect";
            this.btn_Connect.Size = new System.Drawing.Size(196, 33);
            this.btn_Connect.TabIndex = 6;
            this.btn_Connect.Text = "Csatlakozás";
            this.btn_Connect.UseVisualStyleBackColor = true;
            this.btn_Connect.Click += new System.EventHandler(this.Btn_Connect_Click);
            // 
            // cbComport
            // 
            this.cbComport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.cbComport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbComport.DropDownWidth = 300;
            this.cbComport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbComport.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbComport.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.cbComport.FormattingEnabled = true;
            this.cbComport.Location = new System.Drawing.Point(53, 8);
            this.cbComport.Name = "cbComport";
            this.cbComport.Size = new System.Drawing.Size(125, 28);
            this.cbComport.Sorted = true;
            this.cbComport.TabIndex = 5;
            // 
            // btn_results
            // 
            this.btn_results.FlatAppearance.BorderSize = 0;
            this.btn_results.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btn_results.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue;
            this.btn_results.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_results.Font = new System.Drawing.Font("Segoe UI Black", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_results.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_results.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_results.ImageList = this.imageList1;
            this.btn_results.Location = new System.Drawing.Point(230, -2);
            this.btn_results.Name = "btn_results";
            this.btn_results.Size = new System.Drawing.Size(226, 215);
            this.btn_results.TabIndex = 6;
            this.btn_results.Text = "Eredmények";
            this.btn_results.UseVisualStyleBackColor = true;
            this.btn_results.Click += new System.EventHandler(this.Btn_results_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.BackgroundImage = global::My.Project.S.Proper.Namespace.Resources.háttér3;
            this.button1.Location = new System.Drawing.Point(230, -2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(1, 213);
            this.button1.TabIndex = 7;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // Main_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(456, 293);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_new);
            this.Controls.Add(this.btn_results);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Main_Form";
            this.Opacity = 0.9D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CPRFeedBackER";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_new;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbComport;
        private System.Windows.Forms.Button btn_results;
        private System.Windows.Forms.Button btn_Connect;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ImageList imageList1;
    }
}