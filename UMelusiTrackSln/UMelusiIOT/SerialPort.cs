using System;
/*
using System.Collections.Generic;
using System.IO.Ports;
using System.Text;
*/

namespace UMelusiIOT
{
    public sealed class SerialPort : IDisposable
    {
        /*
        public SerialPort(string portName, int baudRate = 9600, Parity parity = Parity.None, int dataBits = 8, StopBits stopBits = StopBits.One)
        {
            SerialPort mySerialPort = new SerialPort("COM6");

            mySerialPort.BaudRate = 9600;
            mySerialPort.Parity = Parity.None;
            mySerialPort.StopBits = StopBits.One;
            mySerialPort.DataBits = 8;
            mySerialPort.Handshake = Handshake.None;
            mySerialPort.RtsEnable = true;
        }
        */
        public int BytesToRead { get; }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
