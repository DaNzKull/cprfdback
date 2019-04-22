using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPRFeedbackER {
    public partial class ErrorPopup : Form {
        public ErrorPopup() {
            InitializeComponent();
        }

        private void Btn_Cancel_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.Abort;
            this.Close();
        }

        private void Btn_Yes_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
