using System.IO.Ports;
using System.Linq;

namespace CPRFeedbackER {

    public class SerialPortClass : SerialPort {
        private SerialPort cprPort = new SerialPort();

        public SerialPortClass() {
            cprPort.PortName = " ";
            cprPort.BaudRate = 9600;
        }

        public string[] PortFinder() {
            string[] ports = SerialPort.GetPortNames().ToArray();
            return ports;
        }
    }
}