using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;


namespace CPRFeedbackER
{
    public partial class Form1_main : Form
    {
        SerialPort cprPort;
        public Form1_main()
        {
            InitializeComponent();
            foreach (var x in SerialPort.GetPortNames()) //Comboboxba berakja a  kapcsolódott portcímeket
            {
                comboBox1.Items.Add(x);
            }
            cprPort = new SerialPort();
        }
        public Form1_main(SerialPort cprPort) 
        {
            InitializeComponent();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            cprPort.Close();
            Application.Exit();
        }

        private void btn_Connect_Click(object sender, EventArgs e)
        {
            if (!cprPort.IsOpen)
            {
                //cprPort.DataReceived += cprPort_DataReceived;
                cprPort.PortName = comboBox1.Text;
                cprPort.BaudRate = 9600;
                cprPort.Open();
            }
            if (comboBox1.Text == "")
            {
                panel1.BackColor = Color.FromArgb(201, 21, 14);
                MessageBox.Show("Válasszon egy létező COM portot!");
            }
            
            if (cprPort.IsOpen)
            {
                panel1.BackColor = Color.FromArgb(16, 78, 9);
                btn_Connect.Text = "Csatlakozva";
                System.Threading.Thread.Sleep(500);
            }
        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            if (cprPort.IsOpen)  // Ha kapcsolódott az arduinohoz létrehozza az új Formot a régit meg elrejti. TODO: Megoldani, hogy bezárja az ablakot ne elrejtse
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
