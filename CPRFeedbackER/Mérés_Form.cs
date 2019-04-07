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
    public partial class CPRFeedbackER : Form
    {
        public static readonly int INITIAL_POSITION = 0;
        private DateTime startTime;
        readonly SerialPortClass cprPort;
        Thread serialReaderthread;
        PressDetector pressDetector = new PressDetector();
        int value;
        private static System.Timers.Timer aTimer;

        List<int> inputSignal = new List<int>(); // A lineráis poti értéktartománya pozitív (0 - 1023) között van

        public CPRFeedbackER(SerialPortClass cprPort)
        {
            InitializeComponent();
            this.cprPort = cprPort;
            btn_Stop.Enabled = false;

            // Timer settings
            aTimer = new System.Timers.Timer(30000);
            aTimer.Elapsed += TimesUp;
            aTimer.AutoReset = false;

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
                progressBar1.PerformStep();
            }
            else
                Invoke(new Action(progressBarUpdater));
        }

        //public void labelUpdater()
        //{
        //    if ( !InvokeRequired )
        //        //TODO
        //    else
        //        Invoke( new Action( labelUpdater ) );
        //}
        //end of updaters

        // ========= FILE MENTÉS ===========
        private void saveToFile()
        {
            string fileName = "InputSignal_" + DateTime.Now.ToFileTimeUtc() + ".txt";
            StreamWriter sr = new StreamWriter(fileName);

            foreach (var item in inputSignal)
            {
                sr.Write(item.ToString() + ";");
            }

            sr.Close();
        }

        // ============ SerialReading thread ============
        private void SerialReading()
        {
            var raw_data = cprPort.ReadLine();

            aTimer.Start();

            // ADDIG AMÍG MEG NEM SZAKAD A KAPCSOLAT VAGY LE NEM JÁR A 30 MP
            while (cprPort.IsOpen || pressDetector.cprCounter.Equals(30))
            {
                // TODO: Countdownnál leáll 60mp után
                raw_data = cprPort.ReadLine();
                raw_data = raw_data.Trim();

                int.TryParse(raw_data, out value);

                inputSignal.Add(value);
                pressDetector.PeakDetector(ref inputSignal);

                gaugeUpdater();
                progressBarUpdater();
            }

            //pressDetector.BpmCalculator(  TIMER   );
        }

        // ========= INDÍTÁS GOMB ===========
        private void btn_Start_Click(object sender, EventArgs e)
        {
            btn_Stop.Enabled = true;
            btn_Start.Enabled = false;

            try {
                if (!cprPort.IsOpen)
                    cprPort.Open();
            }
            catch (Exception ex) {
                MessageBox.Show("Hiba a porttal kapcsolatban! " + ex.Message, "Error!");
            }

            try {
                serialReaderthread = new Thread(SerialReading);
                serialReaderthread.Start();
            }
            catch (Exception ex) {
                MessageBox.Show("Szálkezelési hiba: " + ex.Message);
            }
        }

        // ========= LEÁLLÍTÁS GOMB ===========
        private void btn_Stop_Click(object sender, EventArgs e)
        {
            aTimer.Stop();
            StopReadingThread();
            btn_Start.Enabled = true;

            if (!serialReaderthread.IsAlive && (inputSignal.Count() != 0)) {
                saveToFile();
                btn_Stop.Enabled = false;
            }
        }

        // ========= BEZÁRÁS GOMB ===========
        private void btn_Close_Click(object sender, EventArgs e)
        {
            cprPort.Close();
            if (serialReaderthread.IsAlive)
                serialReaderthread.Abort();
            Application.Exit();
        }

        // ========= TIMER =============
        private void TimesUp(Object source, System.Timers.ElapsedEventArgs e)
        {
            MessageBox.Show("TODO felkínálni az eredmény megtekintését vagy új mérés kezdése");
            aTimer.Dispose();
            StopReadingThread();
        }

        public void StopReadingThread()
        {
            if (serialReaderthread.IsAlive)
                serialReaderthread.Abort();
        }

    }
}