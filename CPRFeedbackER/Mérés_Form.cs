using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Media;

namespace CPRFeedbackER {

    public partial class CPRFeedbackER : Form {
        private readonly SerialPortClass cprPort;
        private TimeSpan elapsedTime = new TimeSpan();

        // Az Arduino ADC convertere miatt az analóg jelet 0-1023 közötti intekké alakítja, ez jön be
        public List<int> inputSignal = new List<int>();

        private PressDetector pressDetector = new PressDetector();
        private Thread serialReaderthread;
        private DateTime startTime = new DateTime();
        private int value;
        private TimeSpan oneMin = new TimeSpan(0, 0, 60);

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
            gauge1.GaugeBackground = new SolidColorBrush(Color.FromRgb(251, 255, 240));

            // Gauge 2 AKTUÁLIS LENYOMÁS ÉRTÉKÉT MUTATJA
            depthGauge.Value = 0;
            depthGauge.FromValue = 0;
            depthGauge.ToValue = 1000;
            depthGauge.TicksForeground = Brushes.OrangeRed;
            depthGauge.Base.Foreground = Brushes.White;
            depthGauge.Base.FontSize = 30;
            depthGauge.NeedleFill = Brushes.Black;
            depthGauge.AnimationsSpeed = (TimeSpan.FromTicks(0));
            depthGauge.Sections.Add(new LiveCharts.Wpf.AngularSection {
                FromValue = 0,
                ToValue = 400,
                Fill = new SolidColorBrush(Color.FromRgb(66, 134, 244))
            });
            depthGauge.Sections.Add(new LiveCharts.Wpf.AngularSection {
                FromValue = 400,
                ToValue = 600,
                Fill = new SolidColorBrush(Color.FromRgb(0, 204, 0))
            });
            depthGauge.Sections.Add(new LiveCharts.Wpf.AngularSection {
                FromValue = 600,
                ToValue = 1000,
                Fill = new SolidColorBrush(Color.FromRgb(255, 0, 0))
            });
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

                TimeSpan timeLeft = oneMin - elapsedTime;
                timer_lbl.Text = timeLeft.ToString(@"ss") + " mp";
            } else
                Invoke(new Action(labelUpdater));
        }

        public void formBackGroundUpdater() {
            if (!InvokeRequired) {
                // PRESSDETECTOR OSZTÁLYBAN VAN EGY METÓDUS AMI ÉRTÉKELI AZ UTOLSÓ NYOMÁST
                // TODO: VALAHOGY A UI-ON JELEZNI A MINŐSÉGÉT
                // EZ MOST NEM MŰKÖDIK
                String lastPressIs = pressDetector.lastPressEvaluated;
                switch (lastPressIs) {
                    case "GOOD":
                        labelGood.Visible = true;
                        labelBad.Visible = false;
                        labelWeak.Visible = false;
                        break;

                    case "OVERPRESSED":
                        labelGood.Visible = false;
                        labelBad.Visible = true;
                        labelWeak.Visible = false;
                        break;

                    case "WEAK":
                        labelGood.Visible = false;
                        labelBad.Visible = false;
                        labelWeak.Visible = true;
                        break;
                }
            } else
                Invoke(new Action(formBackGroundUpdater));
        }

        // =========         END OF UI UPDATERS         =======
        public void StopReadingThread() {
            if (serialReaderthread.IsAlive)
                serialReaderthread.Abort();
        }

        // ========= BEZÁRÁS GOMB ===========
        private void btn_Close_Click(object sender, EventArgs e) {
            //cprPort.Close();
            if (serialReaderthread != null && serialReaderthread.IsAlive)
                serialReaderthread.Abort();
            this.Close();
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
            //StopReadingThread();
            btn_Start.Enabled = true;

            EvaluationStart();
        }

        private void EvaluationStart() {
            btn_Stop.Enabled = false;
            StringBuilder sb = new StringBuilder();
            foreach (var item in inputSignal) {
                sb.Append(item.ToString() + ";");
            }
            var name = String.Empty;
            if (Helper.InputBox("Új név", "Név", ref name) == DialogResult.OK && !String.IsNullOrEmpty(name)) {
                DataBaseManager db = new DataBaseManager();
                db.AddItem(new Measurement {
                    Name = name,
                    Values = sb.ToString()
                });
            }
        }

        // ============     SERIALTHREAD CIKLUS         =======
        private void SerialReading() {
            var raw_data = cprPort.ReadLine();

            startTime = DateTime.Now;

            //cprPort.IsOpen mindig igazat fog adni TODO: ha kihúzodott az eszköz le kell állítani
            while (cprPort.IsOpen && elapsedTime.TotalSeconds <= 60) {
                
                elapsedTime = DateTime.Now - startTime;

                raw_data = cprPort.ReadLine();
                raw_data = raw_data.Trim();

                int.TryParse(raw_data, out value);

                inputSignal.Add(value);
                pressDetector.PeakDetector(ref inputSignal);

                gaugeUpdater();
                formBackGroundUpdater();
                labelUpdater();
            }
            //StopReadingThread();
            EvaluationStart();
        }
    }
}