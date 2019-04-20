using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Forms;
using System.Windows.Media;

namespace CPRFeedbackER {

    public partial class Eredmények : Form {
        private Measurement selectedDbItem;

        public Eredmények() {
            InitializeComponent();

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
                GradientStops = new GradientStopCollection
                {
                    new GradientStop(Colors.Yellow, 0),
                    new GradientStop(Colors.Orange, .5),
                    new GradientStop(Colors.Red, 1)
                }
            };
            SetData();
        }

        public void resultDataProcessingCaller(Measurement dbItem) {
            var name = dbItem.Name;
            int convertedData;
            PressDetector detector = new PressDetector();
            var dataSet = dbItem.Values;
            List<int> inputSignal = new List<int>();

            String[] rawData = dataSet.Split(';');

            foreach (String dataUnit in rawData) {
                int.TryParse(dataUnit, out convertedData);
                inputSignal.Add(convertedData);

                detector.PeakDetector(ref inputSignal);
            }
            elementsUpdater(detector);
        }

        private void elementsUpdater(PressDetector detector) {
            bpmGauge.Value = detector.bpmCounter;
            releaseGauge.Value = detector.goodReleaseCounter;
            idealPressGauge.Value = detector.goodPressCounter;

            cartesianChart1.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Series 1",
                    Values = new ChartValues<double> {4, 6, 5, 2, 7}
                },
                new LineSeries
                {
                    Title = "Series 2",
                    Values = new ChartValues<double> {6, 7, 3, 4, 6},
                    PointGeometry = null
                },
                new LineSeries
                {
                    Title = "Series 2",
                    Values = new ChartValues<double> {5, 2, 8, 3},
                    PointGeometry = DefaultGeometries.Square,
                    PointGeometrySize = 15
                }
            };

            cartesianChart1.AxisX.Add(new Axis {
                Title = "Month",
                Labels = new[] { "Jan", "Feb", "Mar", "Apr", "May" }
            });

            cartesianChart1.AxisY.Add(new Axis {
                Title = "Sales",
                LabelFormatter = value => value.ToString("C")
            });

            cartesianChart1.LegendLocation = LegendLocation.Right;

            //modifying the series collection will animate and update the chart
            cartesianChart1.Series.Add(new LineSeries {
                Values = new ChartValues<double> { 5, 3, 2, 4, 5 },
                LineSmoothness = 0, //straight lines, 1 really smooth lines
                PointGeometry = Geometry.Parse("m 25 70.36218 20 -28 -20 22 -8 -6 z"),
                PointGeometrySize = 50,
                PointForeground = Brushes.Gray
            });

            //modifying any series values will also animate and update the chart
            cartesianChart1.Series[2].Values.Add(5d);

            cartesianChart1.DataClick += CartesianChart1OnDataClick;
        }

        private void CartesianChart1OnDataClick(object sender, ChartPoint chartPoint) {
            MessageBox.Show("You clicked (" + chartPoint.X + "," + chartPoint.Y + ")");
        }

        private void SetData() {
            var db = new DataBaseManager();
            ObservableCollection<Measurement> data = db.GetAllItems();
            lbMeasurements.DataSource = data;
        }

        private void btn_Close_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void btn_Open_Click(object sender, EventArgs e) {
            if (lbMeasurements.SelectedItem != null) {
                selectedDbItem = (Measurement)lbMeasurements.SelectedItem;
            }
        }

        private void btn_X_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}