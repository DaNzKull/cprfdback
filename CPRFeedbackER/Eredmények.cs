using LiveCharts;
using LiveCharts.Defaults;
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

        
            GetData();
        }

        public void ResultDataProcesser(Measurement dbItem) {
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
            ElementsUpdater(detector, ref inputSignal);
        }

        private void ElementsUpdater(PressDetector detector, ref List<int> inputSignal) {
            bpmGauge.Value = detector.bpmCounter;
            releaseGauge.Value = detector.goodReleaseCounter;
            idealPressGauge.Value = detector.goodPressCounter;

            //modifying the series collection will animate and update the chart

            detector.BpmCalculator(60);
            bpmGauge.Value = detector.bpmCounter;
            releaseGauge.Value = detector.goodReleaseCounter;
            idealPressGauge.Value = detector.goodPressCounter;
            ///////////////////////////////////////////////////////////////////////
            ///

            ChartValues<ObservablePoint> Listpoints = new ChartValues<ObservablePoint>();
            for (int i = 0; i < inputSignal.Count; i+=100) {
                Listpoints.Add(new ObservablePoint {
                    X = i,
                    Y = inputSignal[i]
                });
            }
            cartesianChart1.LegendLocation = LegendLocation.Right;

            cartesianChart1.Series = new SeriesCollection {
                new LineSeries {
                    Title = "Mért értékek",
                    PointGeometry = DefaultGeometries.Square,
                    PointGeometrySize = 15,
                    Values = Listpoints,
                    

                }
            };

            cartesianChart1.AxisY.Add(new Axis {
                Sections = new SectionsCollection {
                    new AxisSection {
                        Value = 800,
                        Label = "Good",
                        Fill = new SolidColorBrush {
                            Color = System.Windows.Media.Color.FromRgb(150,0,0),
                            Opacity = 0.3
                        }
                    },
                    new AxisSection {
                        Value = 400,
                        Label = "Bad"
                    }
                }
            });


            cartesianChart1.DataClick += CartesianChart1OnDataClick;
        }

        private void CartesianChart1OnDataClick(object sender, ChartPoint chartPoint) {
            label10.Text = ("(" + chartPoint.X + "," + chartPoint.Y + ")");
        }

        private void GetData() {
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
                ResultDataProcesser(selectedDbItem);
            }
        }

        private void BtnMin_Click(object sender, EventArgs e) {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Btn_X_Click_1(object sender, EventArgs e) {
            this.Close();
        }
    }
}