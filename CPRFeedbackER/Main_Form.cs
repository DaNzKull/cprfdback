﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace CPRFeedbackER {

    public partial class Main_Form : Form {
        private SerialPortClass cprPort;
        private Boolean comboBoxEmpty;

        public Main_Form() {
            InitializeComponent();
            cprPort = new SerialPortClass();
            cbComport.Items.AddRange(cprPort.PortFinder());
			if (cbComport.Items.Count == 1) cbComport.SelectedIndex = 0;
        }

        private void btn_Connect_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(cbComport.Text)) {
                panel1.BackColor = Color.FromArgb(201, 21, 14);
                MessageBox.Show("Válasszon egy létező COM portot!");
                comboBoxEmpty = true;
            }

            if (!cprPort.IsOpen && comboBoxEmpty != true) {
                cprPort.PortName = cbComport.SelectedItem.ToString();
                cprPort.Open();
            }

            if (cprPort.IsOpen) {
                panel1.BackColor = Color.FromArgb(16, 78, 9);
                btn_Connect.Text = "Csatlakozva";
                System.Threading.Thread.Sleep(500);
            }
        }

        private void btn_new_Click(object sender, EventArgs e) {
            if (cprPort.IsOpen) {
                var newForm = new CPRFeedbackER(cprPort);
                newForm.Show();
            } else
                MessageBox.Show("Előbb csatlakozni kell az eszközhöz!");
        }

        private void btn_results_Click(object sender, EventArgs e) {
            var newForm = new Eredmények();
            newForm.Show();
        }

        private void btn_close_Click(object sender, EventArgs e) {
            cprPort.Close();
            Application.Exit();
        }
    }
}