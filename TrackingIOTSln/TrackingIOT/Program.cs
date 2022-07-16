using System;
using System.Device.Gpio;
using System.Diagnostics;
using System.Threading;

namespace TrackingIOT
{
    public class Program
    {

        private static GpioController s_GpioController;
        public static void Main()
        {
            // Debug.WriteLine("Hello from nanoFramework!");

            s_GpioController = new GpioController();

            GpioPin led = s_GpioController.OpenPin(
               2 , PinMode.Output
                );
            led.Write(PinValue.Low);

            while (true)
            {
                led.Toggle();
                Thread.Sleep(2000);
            }
            // Browse our samples repository: https://github.com/nanoframework/samples
            // Check our documentation online: https://docs.nanoframework.net/
            // Join our lively Discord community: https://discord.gg/gCyBu8T
        }
    }
}
