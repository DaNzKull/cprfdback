using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Forms;
using System.Windows.Media;

namespace CPRFeedbackER {

    public partial class Results : Form {
        private Measurement selectedDbItem;
        private ChartValues<ObservablePoint> listPoints;

        public Results() {
            InitializeComponent();
            listPoints = new ChartValues<ObservablePoint>();
            GaugeInitializer();
            GetData();
        }

        public Results(Boolean caller) {
            InitializeComponent();
            listPoints = new ChartValues<ObservablePoint>();
            GaugeInitializer();
            GetData();
            var db = new DataBaseManager();
            selectedDbItem = db.GetLastItem();
            if (selectedDbItem != null) {
                ResultDataProcesser(selectedDbItem);
            }
        }

        public void ResultDataProcesser(Measurement dbItem) {
            txtBoxName.Text = dbItem.Name;
            txtBoxDate.Text = dbItem.Date;
            txtBoxComment.Text = dbItem.Comment;
            var dataSet = dbItem.Values;
            int convertedData;

            List<int> inputSignal = new List<int>();
            PressDetector detector = new PressDetector();

            String[] rawData = dataSet.Split(';');

            foreach (String dataUnit in rawData) {
                int.TryParse(dataUnit, out convertedData);
                inputSignal.Add(convertedData);

                detector.PeakDetector(ref inputSignal);
            }

            ElementsUpdater(detector, ref inputSignal);
        }

        private void btn_Open_Click(object sender, EventArgs e) {
            cartesianChart1.Refresh();
            cartesianChart1.Series.Clear();
            if (lbMeasurements.SelectedItem != null) {
                selectedDbItem = (Measurement)lbMeasurements.SelectedItem;
                ResultDataProcesser(selectedDbItem);
            }
        }

        private void ElementsUpdater(PressDetector detector, ref List<int> inputSignal) {
            bpmGauge.Value = detector.BpmCounter;
            releaseGauge.Value = detector.GoodReleaseCounter;
            idealPressGauge.Value = detector.GoodPressCounter;
            detector.BpmCalculator(60);
            bpmGauge.Value = detector.BpmCounter;
            releaseGauge.Value = detector.GoodReleaseCounter;
            idealPressGauge.Value = detector.GoodPressCounter;
            bool startingZeros = true;

            for (int i = 0; i < inputSignal.Count; i += 5) {
                if (inputSignal[i] != 0 && startingZeros) {
                    startingZeros = false;
                } else {
                    listPoints.Add(new ObservablePoint {
                        X = i,
                        Y = inputSignal[i]
                    });
                }
            }

            cartesianChart1.Series = new SeriesCollection {
                new LineSeries {
                    Title = "Mért értékek",
                    PointGeometry = DefaultGeometries.Circle,
                    PointGeometrySize = 5,
                    Values = listPoints
                }
            };

            cartesianChart1.DataClick += CartesianChart1OnDataClick;
        }

        private void GaugeInitializer() {
            lbMeasurements.MultiColumn = true;
            lbMeasurements.TabIndex = 0;
            lbMeasurements.ColumnWidth = 85;
            lbMeasurements.Items.AddRange(new object[] {
                "Item 1, column 1"
            });

            // BPMGAUGE
            bpmGauge.From = 0;
            bpmGauge.To = 150;
            bpmGauge.InnerRadius = 0;
            bpmGauge.HighFontSize = 60;
            bpmGauge.GaugeBackground = new SolidColorBrush(System.Windows.Media.Color.FromRgb(71, 128, 181));

            // RELEASEGAUGE    TELJES FELENGEDÉS SZÁMA
            releaseGauge.From = 0;
            releaseGauge.To = 120;
            releaseGauge.FromColor = Colors.Green;
            releaseGauge.InnerRadius = 0;
            releaseGauge.HighFontSize = 60;

            // IDEALPRESS GAUGE  TÖKÉLETES NYOMÁSOK SZÁMA
            idealPressGauge.From = 0;
            idealPressGauge.To = 120;
            idealPressGauge.InnerRadius = 0;
            idealPressGauge.HighFontSize = 60;

            idealPressGauge.Value = 100;
            idealPressGauge.Base.GaugeActiveFill = new LinearGradientBrush {
                GradientStops = new GradientStopCollection {
                    new GradientStop(Colors.Yellow, 0),
                    new GradientStop(Colors.Orange, .5),
                    new GradientStop(Colors.Red, 1)
                }
            };
        }
        private void GetData() {
            var db = new DataBaseManager();
            ObservableCollection<Measurement> data = db.GetAllItems();
            lbMeasurements.DataSource = data;
        }

        private void CartesianChart1OnDataClick(object sender, ChartPoint chartPoint) {
            label10.Text = ("(" + chartPoint.X + "," + chartPoint.Y + ")");
        }

        private void btn_Close_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void Btn_X_Click_1(object sender, EventArgs e) {
            this.Close();
        }

        private void BtnMin_Click(object sender, EventArgs e) {
            this.WindowState = FormWindowState.Minimized;
        }

    }
}