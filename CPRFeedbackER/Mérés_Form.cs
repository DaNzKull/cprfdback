using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Media;

namespace CPRFeedbackER {

    public partial class CPRFeedbackER : Form {
        private readonly SerialPortClass cprPort;
        private TimeSpan elapsedTime = new TimeSpan();
        // Az Arduino ADC convertere miatt az analóg jelet 0-1023 közötti intekké alakítja, ez jön be
        private List<int> inputSignal = new List<int>();

        private PressDetector pressDetector = new PressDetector();
        private Thread serialReaderthread;
        private DateTime startTime = new DateTime();
        private int value;
        public CPRFeedbackER(SerialPortClass cprPort) {
            InitializeComponent();
            this.cprPort = cprPort;
            btn_Stop.Enabled = false;

            // Gauge 1 NYOMÁSOK SZÁMÁT MUTATJA
            gauge1.Uses360Mode = true;
            gauge1.From = 0;
            gauge1.To = 150;
            gauge1.InnerRadius = 0;
            gauge1.HighFontSize = 60;
            gauge1.Value = 0;
			

            // Gauge 2 AKTUÁLIS LENYOMÁS ÉRTÉKÉT MUTATJA
            depthGauge.Value = 0;
            depthGauge.FromValue = 0;
            depthGauge.ToValue = 1023;
            //depthGauge.TicksForeground = Brushes.OrangeRed;
            //depthGauge.Base.Foreground = Brushes.White;
            //depthGauge.Base.FontWeight = FontWeights.Bold;
            depthGauge.Base.FontSize = 10;
            depthGauge.NeedleFill = Brushes.Black;
            depthGauge.AnimationsSpeed = (TimeSpan.FromTicks(0));
            depthGauge.Sections.Add(new LiveCharts.Wpf.AngularSection {
                FromValue = 0,
                ToValue = 400,
                Fill = new SolidColorBrush(Color.FromRgb(247, 166, 37))
            });
            depthGauge.Sections.Add(new LiveCharts.Wpf.AngularSection {
                FromValue = 400,
                ToValue = 600,
                Fill = new SolidColorBrush(Color.FromRgb(0, 204, 0))
            });
            depthGauge.Sections.Add(new LiveCharts.Wpf.AngularSection {
                FromValue = 600,
                ToValue = 1023,
                Fill = new SolidColorBrush(Color.FromRgb(255, 0, 0))
            });
        }

        public void evaluationStart(int reason) {
            //TODO: HA VÉGE AKKOR HÍVODJON MEG EZ
            // KELL NEKI KÜLÖN FORM !
        }

        public void formBackGroundUpdater() {
            if (!InvokeRequired) {
                // PRESSDETECTOR OSZTÁLYBAN VAN EGY METÓDUS AMI ÉRTÉKELI AZ UTOLSÓ NYOMÁST
                // TODO: VALAHOGY A UI-ON JELEZNI A MINŐSÉGÉT
                // EZ MOST NEM MŰKÖDIK
                String lastPressIs = pressDetector.lastPressEvaluated;
                switch (lastPressIs) {
                    case "GOOD":
                        this.BackColor = System.Drawing.Color.DarkSeaGreen;
                        break;

                    case "OVERPRESSED":
                        this.BackColor = System.Drawing.Color.DarkRed;
                        break;

                    case "WEAK":
                        this.BackColor = System.Drawing.Color.Aqua;
                        break;
                }
            } else
                Invoke(new Action(formBackGroundUpdater));
        }

        // UI ELEMENT UPDATERS   // NEM LEHET ELÉRNI MÁSIK THREADBŐL ENÉLKÜL
        public void gaugeUpdater() {
            if (!InvokeRequired) {
                gauge1.Value = pressDetector.cprCounter;
                depthGauge.Value = pressDetector.lastPressedValue;
            } else
                Invoke(new Action(gaugeUpdater));
        }
        public void labelUpdater() {
            if (!InvokeRequired) {
                // FUT EGY TIMER A UI-ON
                elapsedTime = DateTime.Now - startTime;
                timer_lbl.Text = "Eltelt idő: " + elapsedTime.ToString(@"mm\:ss");
            } else
                Invoke(new Action(labelUpdater));
        }

        // =========         END OF UI UPDATERS         =======

        //
        public void StopReadingThread() {
            if (serialReaderthread.IsAlive)
                serialReaderthread.Abort();
        }

        // ========= BEZÁRÁS GOMB ===========
        private void btn_Close_Click(object sender, EventArgs e) {
            cprPort.Close();
            if (serialReaderthread.IsAlive)
                serialReaderthread.Abort();
			this.Close();
          //  Application.Exit();
        }

        // ========= INDÍTÁS GOMB ===========
        private void btn_Start_Click(object sender, EventArgs e) {
            btn_Stop.Enabled = true;
            btn_Start.Enabled = false;
            try {
                if (!cprPort.IsOpen)
                    cprPort.Open();
            } catch (Exception ex) {
                MessageBox.Show("Hiba a porttal kapcsolatban! " + ex.Message, "Error!");
            }
            try {
                serialReaderthread = new Thread(SerialReading);
                serialReaderthread.Start();
            } catch (Exception ex) {
                MessageBox.Show("Szálkezelési hiba: " + ex.Message);
            }
        }

        // ========= LEÁLLÍTÁS GOMB ===========
        private void btn_Stop_Click(object sender, EventArgs e) {
            StopReadingThread();
            btn_Start.Enabled = true;

            if (!serialReaderthread.IsAlive && (inputSignal.Count() != 0)) {
                saveToFile();
                btn_Stop.Enabled = false;
            }
            EvaluationStart();
        }

		private void EvaluationStart()
		{
			StringBuilder sb = new StringBuilder();
			foreach (var item in inputSignal)
			{
				sb.Append(item.ToString() + ";");
			}
			var name = String.Empty;
			if (Helper.InputBox("Új név", "Név", ref name) == DialogResult.OK && !String.IsNullOrEmpty(name))
			{
				DataBaseManager db = new DataBaseManager();
				db.AddItem(new Measurment
				{
					Name = name,
					Values = sb.ToString()
				});
			}
		}

		// =========            FILE MENTÉS             =======
		private void saveToFile() {
            string fileName = "InputSignal_" + DateTime.Now.ToFileTimeUtc() + ".txt";
            StreamWriter sr = new StreamWriter(fileName);

            foreach (var item in inputSignal) {
                sr.Write(item.ToString() + ";");
            }
            sr.Close();
        }

        // ============     SERIALTHREAD CIKLUS         =======
        private void SerialReading() {
            var raw_data = cprPort.ReadLine();

            startTime = DateTime.Now;

            //cprPort.IsOpen mindig igazat fog adni TODO: ha kihúzodott az eszköz le kell állítani
            while (cprPort.IsOpen && elapsedTime.TotalSeconds <= 60) {
                formBackGroundUpdater();
                elapsedTime = DateTime.Now - startTime;

                raw_data = cprPort.ReadLine();
                raw_data = raw_data.Trim();

                int.TryParse(raw_data, out value);

                inputSignal.Add(value);
                pressDetector.PeakDetector(ref inputSignal);

                gaugeUpdater();
                labelUpdater();
            }

            EvaluationStart();
        }
    }
}