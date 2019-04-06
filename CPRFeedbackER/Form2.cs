using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Globalization;
using System.Timers;
using System.Diagnostics;


namespace CPRFeedbackER
{
    public partial class CPRFeedbackER : Form   {
        public static readonly int INITIAL_POSITION = 0;

        readonly SerialPortClass cprPort;
        Thread serialReaderthread;
        PressDetector pressDetector = new PressDetector();
        Stopwatch sw = new Stopwatch();
        int value;
        
        // A lineráis poti értéktartománya pozitív (0 - 1023) között van
        List<int> inputSignal = new List<int>();

        public CPRFeedbackER(SerialPortClass cprPort)  {
            InitializeComponent();
            this.cprPort = cprPort;
            sw.Restart();
            btn_Stop.Enabled = false;
        }

        public int BpmCounter { get; set; }
        public int CprCounter { get; set; }

        private void saveToFile()  {
            string fileName = "InputSignal_" + DateTime.Now.ToFileTimeUtc() + ".txt";
            StreamWriter sr = new StreamWriter(fileName);

            foreach ( var item in inputSignal ) {
                sr.Write( item.ToString() + ";" );
            }
            sr.Close();
        }

        private void SerialReading()  {
            var raw_data = cprPort.ReadLine();
            
            sw.Start();

            while (cprPort.IsOpen || sw.Elapsed.TotalSeconds <= 60 ) {  // TODO: Countdownnál leáll 60mp után
                //System.Threading.Thread.Sleep( 100 );

                raw_data = cprPort.ReadLine();
                raw_data = raw_data.Trim();

                //textBox1.AppendText( raw_data + Environment.NewLine );
                int.TryParse(raw_data, out value);

                inputSignal.Add(value);
                pressDetector.PeakDetector(ref inputSignal);
                
            }

            
        }

        private void btn_Start_Click(object sender, EventArgs e) {
            try {
                if (!cprPort.IsOpen)
                    cprPort.Open();
            }
            catch (Exception ex) {
                MessageBox.Show("Hiba a porttal kapcsolatban!" + ex.Message, "Error!");
            }

            serialReaderthread = new Thread(SerialReading);
            serialReaderthread.Start();
            textBox1.Text = "Mérés elindítva";
            btn_Stop.Enabled = true;
            btn_Start.Enabled = false;
        }

        private void btn_Stop_Click(object sender, EventArgs e) {
            if (serialReaderthread.IsAlive) {
                serialReaderthread.Abort();

                textBox1.Clear();
                textBox1.AppendText("Leállítva!" + Environment.NewLine );

                textBox1.AppendText("G P: " +  pressDetector.goodPressCounter + Environment.NewLine );
                //textBox1.AppendText("G R: " + pressDetector.goodReleaseCounter);

                textBox1.AppendText("CPR count: " + pressDetector.cprCounter + Environment.NewLine);

                btn_Start.Enabled = true;
            }

            if (!serialReaderthread.IsAlive && (inputSignal.Count() != 0)) {
                saveToFile();
                btn_Stop.Enabled = false;
            }
        }

        private void btn_Close_Click(object sender, EventArgs e) {
            cprPort.Close();
            if (serialReaderthread.IsAlive)
                serialReaderthread.Abort();
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e) {
        }

      
    }

}