using System;
using System.Windows.Forms;

namespace CPRFeedbackER {

    internal static class Program {

        [STAThread]
        private static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main_Form());
        }
    }
}