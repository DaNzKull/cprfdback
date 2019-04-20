using System;
using System.Windows.Forms;

namespace CPRFeedbackER {

    public partial class Popup : Form {

        public Popup() {
            InitializeComponent();
        }

        public string name {
            get { return txtboxName.Text; }
        }

        public string comment {
            get { return txtBoxComment.Text; }
        }

        private void BtnSave_Click(object sender, EventArgs e) {
            if (txtboxName != null) {
                this.DialogResult = DialogResult.OK;
                this.Close();
            } else {
                MessageBox.Show("Adjon meg nevet mielőtt menti!");
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.Cancel;
            
            using (PopupCancel cancelPopup = new PopupCancel()) {
                
                var answer = cancelPopup.ShowDialog();
                if (answer == DialogResult.Cancel) {
                    this.DialogResult = DialogResult.Abort;
                    this.Close();
                }

                if (answer == DialogResult.OK) {
                    this.DialogResult = DialogResult.Retry;
                    this.Close();
                }
                
            }
        }
    }
}