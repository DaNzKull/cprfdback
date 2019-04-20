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
    public partial class PopupCancel : Form {
        public PopupCancel() {
            InitializeComponent();
            
        }
      
        private void BtnCancel_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void BtnNewMes_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.Retry;
            this.Close();
            
        }
    }
}
