using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPRFeedbackER
{
    public partial class Eredmények : Form
    {
		DataBaseManager db;

		public Eredmények()
        {
            InitializeComponent();
			db = new DataBaseManager();
			listBox1.DataSource = db.GetAllItems();
			listBox1.DisplayMember = "Name";
        }

        private void label2_Click( object sender, EventArgs e )
        {

        }

        private void label9_Click( object sender, EventArgs e )
        {

        }

        private void label3_Click( object sender, EventArgs e )
        {

        }

		private void listBox1_DoubleClick(object sender, EventArgs e)
		{
			var items = db.GetItemById(((Measurment)listBox1.SelectedItem).Id);
			if (items.Count() > 0)
			{
				var values = items[0].Values;
				//itt meg lehet hívni egy grafikus elemet.
			}
		}

		private void btn_Open_Click(object sender, EventArgs e)
		{
			if (listBox1.SelectedItems.Count > 0)
			{
				var items = db.GetItemById(((Measurment)listBox1.SelectedItem).Id);
				if (items.Count() > 0)
				{
					var values = items[0].Values;
					//itt meg lehet hívni egy grafikus elemet.
				}
			}
		}
	}
}
