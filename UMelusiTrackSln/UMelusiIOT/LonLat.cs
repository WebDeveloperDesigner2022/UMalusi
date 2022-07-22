using System;
using System.Text;

namespace UMelusiIOT
{
    public class LonLat
    {
        private string _GPS_DATA;
        private bool _GetData_Flag; //Get GPS data flag bit
        private bool _ParseData_Flag; //Parse completed flag bit
        private string _UTCTime; //UTC time
        private string _latitude; //Latitude
        private string _N_S; //N/S
        private string _longitude; //Longitude
        private string _E_W; //E/W
        private bool _Usefull_Flag; //If the position information is valid flag bit

       
        public string Latitude
        {
            get { return _latitude; }
            set { _latitude = value; }
        }

       

        public string Longitude
        {
            get { return _longitude; }
            set { _longitude = value; }
        }

    }
}
