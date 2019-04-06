using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Globalization;
using System.Timers;
using System.Diagnostics;

//SYSTEM.NUMERICS LIBRARY KELL

///* 
// * MPU-6050 is an inertial module that has a 16-bit ADC for data conversion. It generates 16-bit signed integer data.
// * SAMPLING RATE 500Hz & 16bit-es felbontással digitalizáljuk
//        - előszűrő "THIRD-ORDER BUTTERWORTH LOW PASS FILTER (CUTOFF 15HZ) magas frekvenciájú zajok elnyomására
//        - RESAMPLING to 100Hz
//        - PEAK DETECTOR (with 15mm treshold)ral elemezzük a CD-t (compression depth)
//        - Visszajelzés kalkulálása rövid intervallumokon. Ha az intervallumok rövidek, akkor feltételezhetjük, hogy az összes kompresszió
//        az analízis intervallumon belül nagyon hasonlóak.
//        - Matematikailag azt jelenti, hogy a gyorsulás és a CD majdnem periódikus jelek, amelyeknek alapfrekvenciája a kompressziók átlagos frekvenciája
//        - Ezt jelöljük fcc(Hz)-vel
//        - Minden analízis intervallumon való periódikus megjelenésüket a(t)-vel jelöljük a gyorsulást és s(t)-vel a CD jelét.
//        - Ezen periodikus reprezentációkat modellezhetjük a Fourier sorozatok decompoziciójának első N harmonikájának használatával.
//        - Spektrális analízis hogy megbecsüljük az a(t) harmóniáját, amivel rekonstruálhatjuk s(t)-t
//    *** LÉPÉSEK ***
//        1. Hamming-ablak alkalmazása a gyorsulási jelre hogy kiválasszuk az analízis intervallumot.
//        2. A 2048 pontos FFT  (zero padding) számítás.
//        3. Első 3 harmonikust és azok alapfrekvenciáját megbecsüljük.
//        4. Képlet használata az Sk és ¤k számítására, amelyeket s(t) rekonstruálására használjuk. 
//        5. Ritmus és mélységet megkapjuk a rekonstruált s(t) ciklusból :  rate (min-1) = 60* fcc; depth(mm) = max{s(t)} - min{s(t)};
//*/
namespace CPRFeedbackER
{
    public partial class CPRFeedbackER : Form
    {
        readonly SerialPortClass cprPort;
        Thread serialReaderthread;

        // A lineráis poti értéktartománya pozitív (0 - 1000) között van
        List<UInt16> inputSignal = new List<UInt16>();
        List<String> raw_inputSignal = new List<string>();

        private static System.Timers.Timer aTimer;

        public CPRFeedbackER(SerialPortClass cprPort)
        {
            InitializeComponent();
            this.cprPort = cprPort;
            btn_Stop.Enabled = false;
            
        }

        private void saveToFile()
        {
            string fileName = "InputSignal_" + DateTime.Now.ToFileTime() + ".txt";
            using (StreamWriter sr = new StreamWriter(fileName))
            {
                foreach (var item in raw_inputSignal)
                {
                    sr.WriteLine(item);
                }
            }

            System.IO.File.WriteAllLines(fileName, raw_inputSignal);
        }

        private void SerialReading() {
            var data = cprPort.ReadLine();
            var sw = new Stopwatch();

            sw.Start();

            while (cprPort.IsOpen || sw.Elapsed.TotalSeconds <= 60) // TODO: Countdownnál leáll 60mp után
            {
                data = cprPort.ReadLine();
                data = data.Trim();

                inputSignal.Add(UInt16.Parse(data));
                raw_inputSignal.Add(data);rhgehe 

                textBox1.AppendText(data + Environment.NewLine);
                //Thread.Sleep(20);
            }
        }

        private void btn_Start_Click(object sender, EventArgs e)
        {
            try
            {
                if (!cprPort.IsOpen)
                    cprPort.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba a porttal kapcsolatban!" + ex.Message, "Error!");
            }

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
            if (!serialReaderthread.IsAlive && (inputSignal.Count() != 0))
            {
                saveToFile();
                btn_Stop.Enabled = false;
            }
        }
        private void btn_Close_Click(object sender, EventArgs e)
        {
            cprPort.Close();
            serialReaderthread.Abort();
            Application.Exit();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {

        }


    }
}