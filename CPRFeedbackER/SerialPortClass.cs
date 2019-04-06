using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace CPRFeedbackER
{
    public class SerialPortClass : SerialPort
    {
        SerialPort cprPort = new SerialPort();

        public SerialPortClass() {  
            cprPort.PortName = " ";
            cprPort.BaudRate = 9600;
        }

        public string[] PortFinder()
        {
            string[] ports = SerialPort.GetPortNames().ToArray();
            return ports;
        }
    }

}
