using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace UMelusiTrack
{
    public class livestock
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Picture { get; set; }
        public string Livestockid { get; set; }
        public int Trackerid { get; set; }
        public string Gender { get; set; }
        public DateTime Dateofbirth { get; set; }
        public string Color { get; set; }

    }

}
