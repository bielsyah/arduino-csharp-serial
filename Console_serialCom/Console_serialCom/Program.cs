using System;
using System.IO.Ports;

namespace serialCom
{
    class serialCommunication
    {
        static SerialPort port;

        static void Main(string[] args)
        {
           port = new SerialPort("COM3", 9600);
            port.DtrEnable = true;
            port.DataReceived += myData;
            port.Open();

            while(true)
            {
                string dataToSend = Console.ReadLine();
                port.Write(dataToSend); 
            }

            //Console.ReadKey();
            //port.Close();
        }

        private static void myData(object sender, SerialDataReceivedEventArgs e)
        {
            string data = port.ReadExisting();
            Console.Write(data);
        }
    }
}
