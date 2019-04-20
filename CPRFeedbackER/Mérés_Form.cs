using LiveCharts.Wpf;
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
        private Boolean stopButtonWasClicked = false;

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
            gauge1.InnerRadius = 1;
            gauge1.HighFontSize = 60;
            gauge1.Value = 0;
            gauge1.GaugeBackground = new SolidColorBrush(Color.FromRgb(251, 255, 240));
            gauge1.Base.GaugeActiveFill = new LinearGradientBrush {
                GradientStops = new GradientStopCollection
                {
                    new GradientStop(Colors.Red, 0),
                    new GradientStop(Colors.Orange, .5),
                    new GradientStop(Colors.Green, 1),
                    new GradientStop(Colors.Red,1.5)
                }
            };
            // Gauge 2 AKTUÁLIS LENYOMÁS ÉRTÉKÉT MUTATJA
            depthGauge.NeedleFill = Brushes.Black;
            depthGauge.AnimationsSpeed = (TimeSpan.FromTicks(0));
            this.depthGauge.Sections.Add(new AngularSection {
                FromValue = 0,
                ToValue = 500,
                Fill = new LinearGradientBrush {
                    GradientStops = new GradientStopCollection {
                        new GradientStop(Colors.LightBlue, 0),
                        new GradientStop(Colors.Blue, 0.5),
                        new GradientStop(Colors.CadetBlue, 1),
                    }
                }
            });
            this.depthGauge.Sections.Add(new AngularSection {
                FromValue = 500,
                ToValue = 800,
                Fill = new LinearGradientBrush {
                    GradientStops = new GradientStopCollection {
                        new GradientStop(Colors.Green, 0),
                        new GradientStop(Colors.ForestGreen, 0.5),
                        new GradientStop(Colors.GreenYellow, 1),
                    }
                }
            });
            this.depthGauge.Sections.Add(new AngularSection {
                FromValue = 800,
                ToValue = 1000,
                Fill = new LinearGradientBrush {
                    GradientStops = new GradientStopCollection {
                        new GradientStop(Colors.IndianRed, 0),
                        new GradientStop(Colors.Tomato, 0.5),
                        new GradientStop(Colors.DarkRed, 1),
                    }
                }
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
            stopButtonWasClicked = true;
            btn_Start.Enabled = true;

            EvaluationStart();
        }

        // END OF MÉRÉS
        private void EvaluationStart() {
            StringBuilder sb = new StringBuilder();

            foreach (var item in inputSignal) {
                sb.Append(item.ToString() + ";");
            }
            var name = String.Empty;

            using (Popup form = new Popup()) {
                var answer = form.ShowDialog();

                if (answer == DialogResult.OK) {
                    DataBaseManager db = new DataBaseManager();
                    db.AddItem(new Measurement {
                        Name = form.Name,
                        Comment = form.comment,
                        Values = sb.ToString(),
                        Date = DateTime.Now.ToString("yyyy-MM-dd h:mm tt")
                    });
                }

                if (answer == DialogResult.Retry) {
                    // TODO KINULLÁZNI ÉS ÚJRAKEZDENI MINDENT;
                }

                if (answer == DialogResult.Abort) {
                    Application.Exit();
                }
            }
        }

        // ============     SERIALTHREAD CIKLUS         =======
        private void SerialReading() {
            var raw_data = cprPort.ReadLine();

            startTime = DateTime.Now;

            //cprPort.IsOpen mindig igazat fog adni TODO: ha kihúzodott az eszköz le kell állítani
            while (cprPort.IsOpen && elapsedTime.TotalSeconds <= 60 && !stopButtonWasClicked) {
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
            if (!stopButtonWasClicked)
                EvaluationStart();
        }
    }
}