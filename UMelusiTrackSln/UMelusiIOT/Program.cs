using System;
using System.Diagnostics;
using System.Threading;
using System.IO.Ports;
using nanoFramework.Hardware.Esp32;
using System.Text;
using UMelusiIOT.Services;
using System.Net;
//using System.Collections.Specialized;
using System.Net.Http;
using UMelusiTrackApi.Models;

namespace UMelusiIOT
{
    public class Program
    {
      
        static SerialPort _serialDevice;

        public static void SendCommand()
        {
            _serialDevice.WriteTimeout = 500;


            _serialDevice.Write(DateTime.UtcNow + ">>>|");

            Thread.Sleep(750);

        }

        public static void ReadData()
        {
            _serialDevice.ReadTimeout = 4000;

            byte[] buffer = new byte[5];


            if (_serialDevice.BytesToRead > buffer.Length)
            {
                var bytesRead = _serialDevice.Read(buffer, 0, buffer.Length);

                Debug.WriteLine("Read completed: " + bytesRead + " bytes were read from " + _serialDevice.PortName + ".");

                if (bytesRead > 0)
                {
                    String temp = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    Debug.WriteLine("String: >>" + temp + "<< ");


                }
            }

            Thread.Sleep(1000);
        }


        public static void Main()
        {
            Debug.WriteLine("Hello from nanoFramework!");

            var ports = SerialPort.GetPortNames();

            Debug.WriteLine("Available ports: ");
            foreach (string port in ports)
            {
                Debug.WriteLine($" {port}");
            }

            Configuration.SetPinFunction(19, DeviceFunction.COM2_RX);
            Configuration.SetPinFunction(21, DeviceFunction.COM2_TX);


            _serialDevice = new SerialPort("COM2");

            _serialDevice.BaudRate = 9600;
            _serialDevice.Parity = Parity.None;
            _serialDevice.StopBits = StopBits.One;
            _serialDevice.Handshake = Handshake.None;
            _serialDevice.DataBits = 8;

            // if dealing with massive data input, increase the buffer size
            _serialDevice.ReadBufferSize = 2048;
            _serialDevice.DataReceived += SerialDevice_DataReceived;

            // open the serial port with the above settings
            _serialDevice.Open();

            //   ReadData();

            Thread.Sleep(Timeout.Infinite);

            // Browse our samples repository: https://github.com/nanoframework/samples
            // Check our documentation online: https://docs.nanoframework.net/
            // Join our lively Discord community: https://discord.gg/gCyBu8T
        }

        private static void SerialDevice_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort serialDevice = (SerialPort)sender;

            if (e.EventType == SerialData.Chars)
            {
                Debug.WriteLine("rx chars");
            }
            else if (e.EventType == SerialData.WatchChar)
            {
                Debug.WriteLine("rx watch char");
            }

            // need to make sure that there is data to be read, because
            // the event could have been queued several times and data read on a previous call
            if (serialDevice.BytesToRead > 0)
            {
                byte[] buffer = new byte[serialDevice.BytesToRead];

                var bytesRead = serialDevice.Read(buffer, 0, buffer.Length);

                Debug.WriteLine("Read completed: " + bytesRead + " bytes were read from " + serialDevice.PortName + ".");

                string temp = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                Debug.WriteLine("String: >>" + temp + "<< " + "2");
                string[] textSplit = temp.Split(',');
                if (textSplit[0] == "$GNGGA")
                {
                    Debug.WriteLine("The string is " +temp );


                    string latitude = textSplit[3];
                    string longitude = textSplit[4];

                    if (latitude != "" && longitude != "")
                    {
                        string livestockName = cow101;
                        int livestockid = 1;
                        /*
                        LivestockPosition livestockPosition = new LivestockPosition();
                        //var web = new 
                        livestockPosition = new LivestockPosition();
                        livestockPosition.Latitude = livestockMovement.Latitude;
                        livestockPosition.Longitude = livestockMovement.Longitude;
                        livestockPosition.DateTime = DateTime.Now;
                        livestockPosition.LivestockName = livestockMovement.LivestockName;
                        livestockPosition.LivestockId = livestockMovement.LivestockId;
                        livestockPosition.Livestock = livestock;
                        */

                        var uri = new Uri(AppConfigurationService.Instance.uMalusiServerUrl + "api/LivestockPosition");

                        try
                        {
                            var request = new LivestockMovement() { LivestockName = livestockName, Latitude = latitude, Longitude = longitude, DateTime = DateTime.Now, LivestockId = livestockid };

                            var requestJson = JsonConvert.SerializeObject(request);
                            var content = new StringContent(requestJson, Encoding.UTF8, "application/json");

                            var response = await _httpClient.PostAsync(uri, content);

                            if (response.IsSuccessStatusCode)
                            {
                                var contentResponse = await response.Content.ReadAsStringAsync();

                                var valueResponse = JsonConvert.DeserializeObject<LivestockPosition>(contentResponse);

                                return valueResponse;
                            }
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine(@"\tERROR {0}", ex.Message);
                        }

                    }
                    else
                    {
                        Debug.WriteLine("No values found!");
                    }
                    //

                  //  HttpClient client = new HttpClient();
                }
            }
        }
    }
}



//Debug.WriteLine("Hello from nanoFramework!");

//Thread.Sleep(Timeout.Infinite);