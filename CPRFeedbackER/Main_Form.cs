using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPRFeedbackER
{
    public partial class Main_Form : Form
    {
        SerialPortClass cprPort;
        Boolean comboBoxEmpty;

        public Main_Form()
        {
            InitializeComponent();
            cprPort = new SerialPortClass();
            comboBox1.Items.AddRange(cprPort.PortFinder());
        }
       
        private void btn_Connect_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBox1.Text))
            {
                panel1.BackColor = Color.FromArgb(201, 21, 14);
                MessageBox.Show("Válasszon egy létező COM portot!");
                comboBoxEmpty = true;
            }

            if (!cprPort.IsOpen && comboBoxEmpty != true)
            {
                //cprPort.DataReceived += cprPort_DataReceived;
                cprPort.PortName = comboBox1.SelectedItem.ToString();
                cprPort.Open();
            }
            
            if (cprPort.IsOpen)
            {
                panel1.BackColor = Color.FromArgb(16, 78, 9);
                btn_Connect.Text = "Csatlakozva";
                System.Threading.Thread.Sleep(500);
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            cprPort.Close();
            Application.Exit();
        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            // Ha kapcsolódott az arduinohoz létrehozza az új Formot a régit meg elrejti.
            // TODO: Megoldani, hogy bezárja az ablakot ne elrejtse
            if (cprPort.IsOpen)  
            {
                var newForm = new CPRFeedbackER(cprPort);
                newForm.Show();
                this.Hide();
            }
            else
                MessageBox.Show("Előbb csatlakozni kell az eszközhöz!");
            
        }
        
    }
}
