namespace CPRFeedbackER {

    using LiveCharts.Wpf;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Windows.Media;

    /// <summary>
    /// LiveFeedBack Form
    /// </summary>
    public partial class CPRFeedbackER : Form {
        public List<int> inputSignal;
        private readonly SerialPortClass cprPort;
        private TimeSpan elapsedTime;
        private TimeSpan oneMin;
        private PressDetector pressDetector;
        private DateTime startTime;
        private bool stopButtonWasClicked;
        private int value;

        private CancellationTokenSource tokenSource;

        public CPRFeedbackER(SerialPortClass cprPort) {
            InitializeComponent();
            this.cprPort = cprPort;
            btn_Stop.Enabled = false;
            pressDetector = new PressDetector();
            oneMin = new TimeSpan(0, 0, 10);
            elapsedTime = new TimeSpan();
            inputSignal = new List<int>();
            startTime = new DateTime();
            stopButtonWasClicked = false;

            GaugesInitializer();
        }

        // UI ELEMENT UPDATERS   // NEM LEHET ELÉRNI MÁSIK THREADBŐL ENÉLKÜL
        public void ButtonUpdater() {
            if (!InvokeRequired) {
                btn_Start.Enabled = false;
                btn_Stop.Enabled = false;
            } else
                Invoke(new Action(this.ButtonUpdater));
        }

        public void QualityIndicatorUpdater() {
            if (!InvokeRequired) {
                string lastPressIs = pressDetector.LastPressEvaluated;
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
                Invoke(new Action(QualityIndicatorUpdater));
        }

        public void GaugeUpdater() {
            if (!InvokeRequired) {
                cprCountGauge.Value = pressDetector.CprCounter;
                depthGauge.Value = pressDetector.LastPressedValue;
            } else
                Invoke(new Action(GaugeUpdater));
        }

        public void TimerLabelUpdater() {
            if (!InvokeRequired) {
                elapsedTime = DateTime.Now - startTime;
                TimeSpan timeLeft = oneMin - elapsedTime;
                timer_lbl.Text = timeLeft.ToString(@"ss") + " mp";
            } else
                Invoke(new Action(TimerLabelUpdater));
        }

        // =========         END OF UI UPDATERS         =======
        public void ResetForm() {
            btn_Stop.Enabled = false;
            oneMin = new TimeSpan(0, 0, 10);
            elapsedTime = new TimeSpan();
            inputSignal = new List<int>();
            startTime = new DateTime();
            stopButtonWasClicked = false;

            timer_lbl.Text = "60 másodperc";
            labelGood.Visible = true;
            labelBad.Visible = true;
            labelWeak.Visible = true;
            btn_Start.Enabled = true;
            btn_Stop.Enabled = false;

            GaugesInitializer();
        }

        // ========= BEZÁRÁS GOMB ===========
        private void Btn_Close_Click(object sender, EventArgs e) {
            cprPort.Close();
            cancelTask();
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
            startTime = DateTime.Now;
            SerialReading();
        }

        /// <summary>
        /// Beállítja a Gaugeokat
        /// </summary>
        private void Btn_Stop_Click(object sender, EventArgs e) {
            stopButtonWasClicked = true;
            cancelTask();
            using (ErrorPopup form = new ErrorPopup()) {
                var answer = form.ShowDialog();
                if (answer == DialogResult.OK) {
                    ResetForm();
                    btn_Start.Enabled = true;
                    return;
                } else {
                    Application.Exit();
                }
            }
        }

        /// <summary>
        /// Mérési folyamat vége után ide kerül
        /// </summary>
        private void EvaluationStart() {
            StringBuilder sb = new StringBuilder();
            foreach (var item in inputSignal) {
                sb.Append(item.ToString() + ";");
            }
            var name = string.Empty;

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
                    ResetForm();
                    FormCaller();
                }
                if (answer == DialogResult.Retry) {
                    ResetForm();
                }
                if (answer == DialogResult.Abort) {
                    Application.Exit();
                }
            }
        }

        /// <summary>
        /// Meghívja az Eredmény Formot
        /// </summary>
        public void FormCaller() {
                var form = new Results(true);
                form.Show();
        }

        /// <summary>
        /// Beállítja a Gaugeokat
        /// </summary>
        private void GaugesInitializer() {
            cprCountGauge.Uses360Mode = true;
            cprCountGauge.From = 0;
            cprCountGauge.To = 140;
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
            cprCountGauge.Base.GaugeRenderTransform = new TransformGroup {
                Children = new TransformCollection
                {
                    new RotateTransform(90),
                    new ScaleTransform {ScaleX = -1}
                }
            };

            depthGauge.NeedleFill = Brushes.Black;
            depthGauge.FromValue = PressDetector.FULL_RELEASE_MIN;
            depthGauge.ToValue = PressDetector.MAX_PRESS;
            depthGauge.TickStep = 100;
            depthGauge.Value = 0;
            depthGauge.Base.FontSize = 15;
            depthGauge.SectionsInnerRadius = 0.3;
            depthGauge.TicksStrokeThickness = 2;
            this.depthGauge.Sections.Add(new AngularSection {
                FromValue = PressDetector.FULL_RELEASE_MIN,
                ToValue = PressDetector.GOOD_PRESS_MIN,
                Fill = new LinearGradientBrush {
                    GradientStops = new GradientStopCollection {
                        new GradientStop(Colors.LightBlue, 0),
                        new GradientStop(Colors.Blue, 0.5),
                        new GradientStop(Colors.CadetBlue, 1),
                    }
                }
            });
            this.depthGauge.Sections.Add(new AngularSection {
                FromValue = PressDetector.MIN_PRESS,
                ToValue = PressDetector.GOOD_PRESS_MAX,
                Fill = new LinearGradientBrush {
                    GradientStops = new GradientStopCollection {
                        new GradientStop(Colors.Green, 0),
                        new GradientStop(Colors.ForestGreen, 0.5),
                        new GradientStop(Colors.GreenYellow, 1),
                    }
                }
            });
            this.depthGauge.Sections.Add(new AngularSection {
                FromValue = PressDetector.GOOD_PRESS_MAX,
                ToValue = PressDetector.MAX_PRESS,
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
        private async void SerialReading() {
            try {
                tokenSource = new CancellationTokenSource();
                CancellationToken token = tokenSource.Token;
                await Task.Run(() => {
                    var raw_data = cprPort.ReadLine();
                    cprPort.ReadTimeout = 1000;
                    pressDetector = new PressDetector();

                    while (cprPort.IsOpen && elapsedTime <= oneMin && !token.IsCancellationRequested && !stopButtonWasClicked) {
                        elapsedTime = DateTime.Now - startTime;
                        try {
                            raw_data = cprPort.ReadLine();
                            raw_data = raw_data.Trim();
                        } catch (TimeoutException) {
                            MessageBox.Show("Probléma történt az Arduino olvasása során");
                        }
                        int.TryParse(raw_data, out value);
                        inputSignal.Add(value);

                        if (pressDetector.isPressed) {
                            pressDetector.ReleaseDetector(ref inputSignal);
                        } else {
                            pressDetector.PeakDetector(ref inputSignal);
                        }
                        GaugeUpdater();
                        QualityIndicatorUpdater();
                        TimerLabelUpdater();
                    }
                }, tokenSource.Token);
            } catch (OperationCanceledException) {
            }
            if (!stopButtonWasClicked)
                EvaluationStart();
            return;
        }

        private void cancelTask() {
            tokenSource.Cancel();
        }
    }
}