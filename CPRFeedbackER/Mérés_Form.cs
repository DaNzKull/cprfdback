using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Media;

namespace CPRFeedbackER {

    public partial class CPRFeedbackER : Form {
        public List<int> inputSignal = new List<int>();
        private readonly SerialPortClass cprPort;
        private TimeSpan elapsedTime = new TimeSpan();
        private TimeSpan oneMin = new TimeSpan(0, 0, 60);
        private PressDetector pressDetector = new PressDetector();
        private Thread serialReaderthread;
        private DateTime startTime = new DateTime();
        private Boolean stopButtonWasClicked = false;
        private int value;

        public CPRFeedbackER(SerialPortClass cprPort) {
            InitializeComponent();
            this.cprPort = cprPort;
            btn_Stop.Enabled = false;

            GaugesInitializer();
        }

        // UI ELEMENT UPDATERS   // NEM LEHET ELÉRNI MÁSIK THREADBŐL ENÉLKÜL
        public void ButtonUpdater() {
            if (!InvokeRequired) {
                btn_Start.Enabled = false;
                btn_Stop.Enabled = false;
            } else
                Invoke(new Action(ButtonUpdater));
        }

        public void FormBackGroundUpdater() {
            if (!InvokeRequired) {

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
                Invoke(new Action(FormBackGroundUpdater));
        }


        public void GaugeUpdater() {
            if (!InvokeRequired) {
                cprCountGauge.Value = pressDetector.cprCounter;
                depthGauge.Value = pressDetector.lastPressedValue;
            } else
                Invoke(new Action(GaugeUpdater));
        }

        public void LabelUpdater() {
            if (!InvokeRequired) {
                elapsedTime = DateTime.Now - startTime;
                TimeSpan timeLeft = oneMin - elapsedTime;
                timer_lbl.Text = timeLeft.ToString(@"ss") + " mp";
            } else
                Invoke(new Action(LabelUpdater));
        }
        // =========         END OF UI UPDATERS         =======


        public void StopReadingThread() {
            if (serialReaderthread.IsAlive && serialReaderthread != null)
                serialReaderthread.Abort();
        }

        // ========= BEZÁRÁS GOMB ===========
        private void Btn_Close_Click(object sender, EventArgs e) {
            //cprPort.Close();
            if (serialReaderthread != null && serialReaderthread.IsAlive)
                serialReaderthread.Abort();
            this.Close();
        }

        // ========= INDÍTÁS GOMB ===========
        private void Btn_Start_Click(object sender, EventArgs e) {
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
        private void Btn_Stop_Click(object sender, EventArgs e) {
            StopReadingThread();
            stopButtonWasClicked = true;
            btn_Start.Enabled = true;

            EvaluationStart();
        }

        // END OF MÉRÉS
        private void EvaluationStart() {
            ButtonUpdater();

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
                        Name = form.name,
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

        private void GaugesInitializer() {
            cprCountGauge.Uses360Mode = true;
            cprCountGauge.From = 0;
            cprCountGauge.To = 150;
            cprCountGauge.InnerRadius = 1;
            cprCountGauge.HighFontSize = 60;
            cprCountGauge.Value = 0;
            cprCountGauge.GaugeBackground = new SolidColorBrush(Color.FromRgb(251, 255, 240));
            cprCountGauge.Base.GaugeActiveFill = new LinearGradientBrush {
                GradientStops = new GradientStopCollection {
                    new GradientStop(Colors.Red, 0),
                    new GradientStop(Colors.Orange, .5),
                    new GradientStop(Colors.Green, 1),
                    new GradientStop(Colors.Red, 1.5)
                }
            };

            depthGauge.NeedleFill = Brushes.Black;
            depthGauge.FromValue = PressDetector.FULL_RELEASE_MIN;
            depthGauge.ToValue = PressDetector.MAX_PRESS;
            depthGauge.TickStep = 100;
            depthGauge.Base.FontSize = 15;
            depthGauge.SectionsInnerRadius = 0.3;
            depthGauge.TicksStrokeThickness = 2;
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

        // ============     SERIALTHREAD CIKLUS         =======
        private void SerialReading() {
            var raw_data = cprPort.ReadLine();
            cprPort.ReadTimeout = 1000;
            startTime = DateTime.Now;

            while (cprPort.IsOpen && elapsedTime.TotalSeconds <= 60 && !stopButtonWasClicked) {
                elapsedTime = DateTime.Now - startTime;

                try {
                    raw_data = cprPort.ReadLine();
                    raw_data = raw_data.Trim();
                } catch (TimeoutException) {
                    MessageBox.Show("Probléma történt az Arduino olvasása során");
                    serialReaderthread.Abort();
                }

                int.TryParse(raw_data, out value);

                inputSignal.Add(value);
                pressDetector.PeakDetector(ref inputSignal);

                GaugeUpdater();
                FormBackGroundUpdater();
                LabelUpdater();
            }

            if (!stopButtonWasClicked)
                EvaluationStart();
        }
    }
}