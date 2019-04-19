using System;
using System.Collections.ObjectModel;
using System.Windows.Forms;
using System.Windows.Media;

namespace CPRFeedbackER {

    public partial class Eredmények : Form {

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

		private void SetData()
		{
			var db = new DataBaseManager();
			ObservableCollection<Measurment> data = db.GetAllItems();
			lbMeasurements.DataSource = data;
		}

		private void button1_Click(object sender, EventArgs e) {
            this.Close();
        }

		

		private void btn_Open_Click(object sender, EventArgs e)
		{
			if (lbMeasurements.SelectedItem != null)
			{
				//  var item= (Measurment)lbMeasurements.SelectedItem;
				//go!
			}
		}
	}
}