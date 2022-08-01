using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace UMelusiTrack.Models
{
    public class SigningDataModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public string AzureMapId { get; set; }
        public int AuthenticationId { get; set; }
        public bool Done { get; set; }

    }
}
