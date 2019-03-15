using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using MaterialDesign;
using System.IO;
using DSPLib;
using System.Numerics;

//SYSTEM.NUMERICS LIBRARY KELL

/* 
 * MPU-6050 is an inertial module that has a 16-bit ADC for data conversion. It generates 16-bit signed integer data.
 * SAMPLING RATE 500Hz & 16bit-es felbontással digitalizáljuk
        - előszűrő "THIRD-ORDER BUTTERWORTH LOW PASS FILTER (CUTOFF 15HZ) magas frekvenciájú zajok elnyomására
        - RESAMPLING to 100Hz
        - PEAK DETECTOR (with 15mm treshold)ral elemezzük a CD-t (compression depth)
        - Visszajelzés kalkulálása rövid intervallumokon. Ha az intervallumok rövidek, akkor feltételezhetjük, hogy az összes kompresszió
        az analízis intervallumon belül nagyon hasonlóak.
        - Matematikailag azt jelenti, hogy a gyorsulás és a CD majdnem periódikus jelek, amelyeknek alapfrekvenciája a kompressziók átlagos frekvenciája
        - Ezt jelöljük fcc(Hz)-vel
        - Minden analízis intervallumon való periódikus megjelenésüket a(t)-vel jelöljük a gyorsulást és s(t)-vel a CD jelét.
        - Ezen periodikus reprezentációkat modellezhetjük a Fourier sorozatok decompoziciójának első N harmonikájának használatával.
        - Spektrális analízis hogy megbecsüljük az a(t) harmóniáját, amivel rekonstruálhatjuk s(t)-t
    *** LÉPÉSEK ***
        1. Hamming-ablak alkalmazása a gyorsulási jelre hogy kiválasszuk az analízis intervallumot.
        2. A 2048 pontos FFT  (zero padding) számítás.
        3. Első 3 harmonikust és azok alapfrekvenciáját megbecsüljük.
        4. Képlet használata az Sk és ¤k számítására, amelyeket s(t) rekonstruálására használjuk. 
        5. Ritmus és mélységet megkapjuk a rekonstruált s(t) ciklusból :  rate (min-1) = 60* fcc; depth(mm) = max{s(t)} - min{s(t)};
*/
namespace CPRFeedbackER
{
    public partial class CPRFeedbackER : Form
    {
        SerialPort _cprPort;
        
        Thread serialReaderthread;
        List<double> raw_double_data = new List<double>();
        List<string> raw_string_data = new List<string>();
        
        public CPRFeedbackER(SerialPort _cprPort)
        {
            InitializeComponent();
            btn_Stop.Enabled = false;
            this._cprPort = _cprPort;
            this._cprPort.BaudRate = 9600;
        }
        private void saveToFile()
        {
            System.IO.File.WriteAllLines("RawDataList.txt", raw_string_data);
        }
        
        private void SerialReading()
        {
            string data;
            double tmp_data;
            data = _cprPort.ReadExisting();
            data = "";
            while (_cprPort.IsOpen) // TODO: Countdownnál leáll 60mp után
            {
                data = _cprPort.ReadExisting(); 
                raw_string_data.Add(data);
                textBox1.AppendText(data + Environment.NewLine);
                Double.TryParse(data, out tmp_data);
                raw_double_data.Add(tmp_data);
                
                Thread.Sleep(100);
            }
        }
        private void btn_Start_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_cprPort.IsOpen)
                {
                    _cprPort.Open();
                }
            }
            catch (Exception ex)
            { MessageBox.Show("Hiba a porttal kapcsolatban!" + ex.Message, "Error!"); }
            serialReaderthread = new Thread(SerialReading);
            serialReaderthread.Start();
            textBox1.Text = "Mérés elindítva";
            btn_Stop.Enabled = true;
            btn_Start.Enabled = false;
        }
        private void btn_Stop_Click(object sender, EventArgs e)
        {
            if (serialReaderthread.IsAlive)
            {
                serialReaderthread.Abort();
                
                textBox1.Clear();
                textBox1.AppendText("Leállítva!");
                
                btn_Start.Enabled = true;
            }
            if (!serialReaderthread.IsAlive && (raw_string_data.Count() != 0))
            {
                saveToFile();
                btn_Stop.Enabled = false;
            }
        }
        private void btn_Close_Click(object sender, EventArgs e)
        {
            _cprPort.Close();
            serialReaderthread.Abort();
            Application.Exit();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}
