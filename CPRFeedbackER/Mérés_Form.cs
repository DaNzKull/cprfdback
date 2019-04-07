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
        Timer timer = new Timer();
        int value;
        
        // A lineráis poti értéktartománya pozitív (0 - 1023) között van
        List<int> inputSignal = new List<int>();

        public CPRFeedbackER(SerialPortClass cprPort)  {
            InitializeComponent();
            this.cprPort = cprPort;

            timer.resetTimer();

            btn_Stop.Enabled = false;

            // Gauge settings
            gauge1.Uses360Mode = true;
            gauge1.From = 0;
            gauge1.To = 30;
            gauge1.InnerRadius = 0;
            gauge1.HighFontSize = 60;
            gauge1.Value = 0;

            // Progress bar
            progressBar1.Maximum = 30;
            progressBar1.Minimum = 0;
            progressBar1.Value = 30;
            progressBar1.Step = -1;

        }
        // UI elemeket más threadből nem lehet elérni enélkül
        public void gaugeUpdater()
        {
            if (!InvokeRequired)
                gauge1.Value = pressDetector.cprCounter;
            else 
                Invoke(new Action(gaugeUpdater));
        }

        public void progressBarUpdater()
        {
            if (!InvokeRequired)
            {
                if (timer.getElapsedSec() % 1 == 0)
                progressBar1.PerformStep();
            }
                
            else
                Invoke(new Action(progressBarUpdater));
        }
        // end of updaters


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
            
            timer.startTimer();

            while (cprPort.IsOpen || timer.getElapsedSec() <= 60 || pressDetector.cprCounter.Equals(30) ) {  // TODO: Countdownnál leáll 60mp után
                
                raw_data = cprPort.ReadLine();
                raw_data = raw_data.Trim();

                int.TryParse(raw_data, out value);

                inputSignal.Add(value);
                pressDetector.PeakDetector(ref inputSignal);

                gaugeUpdater();
                progressBarUpdater();
            }

            timer.stopTimer();
            pressDetector.BpmCalculator(timer.getElapsedSec());
            timer.resetTimer();
            
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
            
            btn_Stop.Enabled = true;
            btn_Start.Enabled = false;
        }

        private void btn_Stop_Click(object sender, EventArgs e) {
            if (serialReaderthread.IsAlive) {
                serialReaderthread.Abort();

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